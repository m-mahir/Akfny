import * as React from "react";
import { DataGrid } from "@material-ui/data-grid";
import { createTheme } from "@material-ui/core/styles";
import { makeStyles } from "@material-ui/styles";
import CheckIcon from "@material-ui/icons/Check";
import WarningIcon from "@material-ui/icons/Warning";
import HourglassEmptyIcon from "@material-ui/icons/HourglassEmpty";
import Page from "../../components/Page";
import QuickSearchToolbar from "./Toolbar";
import DetailsModal from "./DetailsModal";
import { useTranslation } from "react-i18next";
import Switch from "@material-ui/core/Switch";
import { FormControlLabel, FormGroup } from "@material-ui/core";
import Select from "react-select";
import Grid from "@material-ui/core/Grid";
import { GET, POST, URLS } from "../../utils/http";
import buildQuery from "odata-query";
import f from "odata-filter-builder";

function escapeRegExp(value) {
  return value.replace(/[-[\]{}()*+?.,\\^$|#\s]/g, "\\$&");
}

const lang = localStorage.getItem("lang");
const isArabic = () => lang === "ar";
const direction = isArabic() ? "rtl" : "ltr";

const defaultTheme = createTheme({
  direction: direction,
});

const useStyles = makeStyles(
  (theme) => ({
    grid: {
      "& .MuiDataGrid-columnSeparator": {
        visibility: "hidden",
      },
    },
  }),
  { defaultTheme }
);

let timeout = null;
const timeoutSeconds = 1000;

export default function Trainer() {
  const classes = useStyles();

  const { t } = useTranslation();

  const [showFilters, setShowFilters] = React.useState(false);

  const toggleFilters = (event) => {
    setShowFilters(event.target.checked);
  };

  const columns = [
    {
      editable: false,
      field: "name",
      headerName: t("trainer.name"),
      width: 180,
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
    },
    {
      editable: false,
      field: "city",
      headerName: t("trainer.city"),
      width: 180,
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
    },
    {
      editable: false,
      field: "id",
      // hide: true,
      headerName: t("trainer.id"),
      width: 180,
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
    },
    {
      editable: false,
      field: "IDType",
      headerName: t("trainer.idType"),
      width: 200,
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
    },
    {
      editable: false,
      field: "nationality",
      headerName: t("trainer.nationality"),
      width: 200,
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
    },
    {
      editable: false,
      field: "type",
      headerName: t("trainer.gender"),
      // type: 'number',
      width: 140,
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
    },
    {
      editable: false,
      field: "status",
      hide: true,
      headerName: t("trainer.status"),
      // type: 'number',
      width: 140,
      type: "singleSelect",
      valueOptions: ["معتمد", "غير معتمد", "منتظر"],
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
    },
    {
      field: "actions",
      headerName: t("trainer.status"),
      sortable: false,
      width: 140,
      disableClickEventBubbling: true,
      renderCell: (params) => {
        let StatusIcon;
        let color;
        let borderColor;
        switch (params.row.status) {
          case "معتمد":
            StatusIcon = CheckIcon;
            color = "#388e3c";
            borderColor = "#4caf50";
            break;
          case "غير معتمد":
            StatusIcon = WarningIcon;
            color = "#d32f2f";
            borderColor = "#f44336";
            break;
          case "منتظر":
            StatusIcon = HourglassEmptyIcon;
            color = "#f57c00";
            borderColor = "#ff9800";
            break;
          default:
            return;
        }
        return (
          <div
            className="d-flex justify-content-between align-items-center"
            style={{
              cursor: "pointer",
              color: color,
              border: "2px solid " + borderColor,
              borderRadius: 20,
              lineHeight: 0,
              padding: 1,
              width: 105,
            }}
          >
            <StatusIcon
              index={params.row.id}
              className={isArabic() ? "mr-2" : "ml-2"}
            />
            <span className={isArabic() ? "ml-2" : "mr-2"}>
              {params.row.status}
            </span>
          </div>
        );
      },
    },
  ];

  const [searchText, setSearchText] = React.useState("");
  const [course, setCourse] = React.useState();
  const [rows, setRows] = React.useState([]);
  const [courses, setCourses] = React.useState([]);
  const [selectedRow, setSelectedRow] = React.useState();
  const [modal, setModal] = React.useState(false);
  const [loading, setLoading] = React.useState(false);
  const [pageSize, setPageSize] = React.useState(5);
  const [totalSize, setTotalSize] = React.useState(0);
  const [currentPage, setPage] = React.useState(0);

  const requestSearch = (searchValue) => {
    setSearchText(searchValue);
    if (timeout) clearTimeout(timeout);
    timeout = setTimeout(() => {
      getData(0, searchValue, course);
    }, timeoutSeconds);
  };
  const mapFilterFieldName = (col) => {
    if (col == "name") return "LecturerFname";
    else if (col == "id") return "Id";
    else if (col == "IDType") return "NumberType.NumType";
    else if (col == "nationality") return "Nationality.NationalityType";
    else if (col == "type") return "Sex.SexType";
    return col;
  };
  // const filterModelChange = (event) => {
  //   let filter = f(event.linkOperator);
  //   if (event.items.length > 0) {
  //     event.items.forEach((element) => {
  //       const field = mapFilterFieldName(element.columnField);
  //       const operatorValue = element.operatorValue;
  //       // if (operatorValue == "equals" && element.value) filter = filter.eq(field, field=="Id"?+element.value:element.value);
  //       // else
  //        if (operatorValue == "contains"&& element.value)
  //         filter = filter.contains(field, element.value);
  //       // else if (operatorValue == "startsWith"&& element.value)
  //       //   filter = filter.startsWith(field, element.value);
  //       // else if (operatorValue == "endsWith"&& element.value)
  //       //   filter = filter.endsWith(field, element.value);
  //       // else if (operatorValue == "isNotEmpty")
  //       //   filter = filter.not(f().isEmpty(field, element.value));
  //       // else if (operatorValue == "isEmpty")
  //       //   filter = filter.isEmpty(field, element.value);
  //     });
  //     getData(0, searchText, filter);
  //   }
  // };
  const clickHandler = (row) => {
    let data = {
      Id: row.id,
      isDeactivate: row.status == "معتمد",
      isReactivate: row.status != "معتمد",
    };
    POST(URLS.trainer.changeStatus, data).then((res) => {
      if (res.status == 200 && res.data) {
        let indx = rows.findIndex((o) => o.id == res.data.id);
        if (indx > -1) {
          let items = rows.slice();
          let item = {
            ...rows[indx],
            status:
              res.data.isActive && res.data.isSuspend
                ? "منتظر"
                : !res.data.isActive && !res.data.isSuspend
                ? "غير معتمد"
                : "معتمد",
          };
          items[indx] = { ...item };
          setRows([...items]);
          setSelectedRow({ ...item });
        }
      }
    });
  };
  const deleteItemHandler = (row) => {
    let data = {
      Id: row.id,
    };
    POST(URLS.trainer.delete, data).then((res) => {
      if (res.status == 200) {
        let indx = rows.findIndex((o) => o.id == row.id);
        if (indx > -1) {
          let items = rows.slice();
          items.splice(indx, 1);
          setRows([...items]);
          setSelectedRow(null);
        }
      }
    });
  };
  const getCourses = function () {
    GET(URLS.course.all).then((res) => {
      setCourses([
        ...res.data.value.map((o) => ({ label: o.CourseTxt, value: o.Id })),
      ]);
    });
  };
  const getData = function async(page, searchText = "", CourseId = null) {
    const top = pageSize;
    const skip = pageSize * page;
    setPage(page);
    setLoading(true);
    let expand = ["Country", "City", "Sex", "Nationality", "NumberType"];

    //const expand = { Friends: { expand: 'Photos' } }
    //const expand = { LecturerInterestedCourses: { filter: { Name: 'Trip in US' } } };
    //List<LecturerInterestedCourse> LIC = db.LecturerInterestedCourses.Where(x => x.CourseId == CourseId && x.Lecturer.IsActive == true && x.Lecturer.IsSuspend == false && x.Lecturer.IsDeleted == false).ToList();

    let filter = f("or").eq("IsDeleted", false).toString();
    if (searchText) {
      filter = f("or")
        .contains((x) => x.toLower("LecturerFname"), searchText)
        .contains((x) => x.toLower("LecturerSname"), searchText)
        .contains((x) => x.toLower("LecturerTname"), searchText)
        .contains((x) => x.toLower("LecturerLname"), searchText)
        .and((x) => x.eq("IsDeleted", false))
        .toString();
    }
    const count = true;

    let query = buildQuery({ count, expand, top, skip, filter });
    setCourse(CourseId);
    if (CourseId) {
      query += "&courseId=" + CourseId;
    }
    GET(URLS.trainer.all + query).then((res) => {
      setLoading(false);
      let fetchedRows = [];
      if (res.data && res.data.value && Array.isArray(res.data.value)) {
        fetchedRows = res.data.value.map((o) => ({
          name:
            o.LecturerFname +
            " " +
            o.LecturerSname +
            " " +
            o.LecturerTname +
            " " +
            o.LecturerLname,
          CountryName: o.Country.CountryName,
          city: o.City.CityName,
          id: o.Id,
          type: o.Sex.SexType,
          nationality: o.Nationality.NationalityType,
          IDType: o.NumberType.NumType,
          status:
            o.IsActive && o.IsSuspend
              ? "منتظر"
              : !o.IsActive && !o.IsSuspend
              ? "غير معتمد"
              : "معتمد",
          IDNumber: o.IDNumber,
          NumType: o.NumberType.NumType,
          LecturerId: o.LecturerId,
        }));
        setTotalSize(res.data["@odata.count"]);
      }
      setRows([...fetchedRows]);
    });
  };
  React.useEffect(() => {
    getData(0, "", undefined);
    getCourses();
  }, []);

  const toggle = (modalType) => () => {
    if (!modalType) {
      return setModal(!modal);
    }
  };

  return (
    <Page
      title={t("trainer.title")}
      breadcrumbs={[{ name: "   " + t("trainer.title"), active: true }]}
      dir={direction}
      endComp={
        <FormGroup
          style={{ direction: isArabic() ? "ltr" : "rtl", flex: "auto" }}
        >
          <FormControlLabel
            control={
              <Switch
                checked={showFilters}
                onChange={toggleFilters}
                name="filters"
                inputProps={{ "aria-label": "secondary checkbox" }}
              />
            }
            label={t("general.advancedSearch")}
          />
        </FormGroup>
      }
    >
      {showFilters && (
        <div
          style={{
            marginBottom: 10,
          }}
        >
          <Grid container spacing={3}>
            <Grid item xs={12} sm={12}>
              <Select
                options={courses}
                // isLoading={isLoading}
                placeholder={t("trainer.coursesSearch")}
                isClearable={true}
                isRtl={isArabic()}
                style={{ display: "block" }}
                onChange={(item) =>
                  getData(0, searchText, item ? item.value : undefined)
                }
              />
            </Grid>
          </Grid>
        </div>
      )}
      <div
        dir={direction}
        style={{
          height: "72vh",
          width: "100%",
          boxShadow: "0 2px 2px #9E9E9E",
          borderRadius: 8,
        }}
      >
        <DataGrid
          components={{ Toolbar: QuickSearchToolbar }}
          rows={rows}
          columns={columns}
          className={classes.grid}
          loading={loading}
          density="compact"
          onCellDoubleClick={toggle()}
          // onFilterModelChange={(event, details) =>
          //   filterModelChange(event, details)
          // }
          //filterMode="server"
          localeText={{
            toolbarFilters: t("toolbar.filter"),
            toolbarColumns: t("toolbar.columns"),
            toolbarDensity: t("toolbar.density"),
            toolbarExport: t("toolbar.export"),
            toolbarExportCSV: t("toolbar.exportCSV"),
            MuiTablePagination: { labelRowsPerPage: t("toolbar.rowsCount") },
          }}
          pageSize={pageSize}
          onPageSizeChange={(newPageSize) => setPageSize(newPageSize)}
          // rowsPerPageOptions={[5, 10, 20]}
          rowCount={totalSize}
          page={currentPage}
          paginationMode={"server"}
          onPageChange={(page) => getData(page, searchText, course)}
          pagination
          onSelectionModelChange={(e) => {
            const selectedID = e[0];
            const selectedRowData = rows.filter(
              (row) => selectedID == row.id.toString()
            );
            setSelectedRow(selectedRowData[0]);
          }}
          componentsProps={{
            toolbar: {
              value: searchText,
              onChange: (event) => requestSearch(event.target.value),
              clearSearch: () => requestSearch(""),
              selectedRow: selectedRow,
              toggleModal: toggle,
              clickHandler: clickHandler,
              deleteItem: deleteItemHandler,
            },
          }}
        />
        <DetailsModal
          modal={modal}
          toggle={toggle}
          selectedRow={selectedRow}
          columns={columns}
        />
      </div>
    </Page>
  );
}
