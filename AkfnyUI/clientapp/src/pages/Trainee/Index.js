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
import TextField from "@material-ui/core/TextField";
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

export default function Trainee() {
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
      headerName: t("trainee.name"),
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
      width: 220,
    },
    {
      editable: false,
      field: "address",
      headerName: t("trainee.address"),
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
      width: 200,
    },
    {
      editable: false,
      field: "type",
      headerName: t("trainee.gender"),
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
      width: 140,
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
  const [rows, setRows] = React.useState([]);
  const [selectedRow, setSelectedRow] = React.useState();
  const [modal, setModal] = React.useState(false);
  const [pageSize, setPageSize] = React.useState(5);
  const [totalSize, setTotalSize] = React.useState(0);
  const [courses, setCourses] = React.useState([]);
  const [selectedCourse, setSelectedCourse] = React.useState();
  const [mainInterests, setMainInterests] = React.useState([]);
  const [selectedMainInterest, setSelectedMainInterest] = React.useState();
  const [secondaryInterests, setSecondaryInterests] = React.useState([]);
  const [selectedSecondaryInterest, setSelectedSecondaryInterest] =
    React.useState();
  const [loading, setLoading] = React.useState(false);
  const [currentPage, setCurrentPage] = React.useState(0);

  const requestSearch = (searchValue) => {
    setSearchText(searchValue);
    if (timeout) clearTimeout(timeout);
    timeout = setTimeout(() => {
      getData(
        0,
        searchValue,
        selectedCourse,
        selectedMainInterest,
        selectedSecondaryInterest
      );
    }, timeoutSeconds);
  };

  const getCourses = function () {
    GET(URLS.course.all).then((res) => {
      setCourses([
        ...res.data.value.map((o) => ({ label: o.CourseTxt, value: o.Id })),
      ]);
    });
  };

  const getMajorInterests = function () {
    GET(URLS.majorInterest.all).then((res) => {
      setMainInterests([
        ...res.data.value.map((o) => ({
          label: o.MajorInterestTxt,
          value: o.Id,
        })),
      ]);
    });
  };

  const getSubInterests = function () {
    GET(URLS.subInterest.all).then((res) => {
      setSecondaryInterests([
        ...res.data.value.map((o) => ({
          label: o.SubInterestTxt,
          value: o.Id,
        })),
      ]);
    });
  };

  // const mapFilterFieldName = (col) => {
  //   if (col == "name") return "TrainerFname";
  //   else if (col == "id") return "Id";
  //   else if (col == "type") return "Sex.SexType";
  //   return col;
  // };
  // const filterModelChange = (event) => {
  //   let filter = f(event.linkOperator);
  //   if (event.items.length > 0) {
  //     event.items.forEach((element) => {
  //       const field = mapFilterFieldName(element.columnField);
  //       const operatorValue = element.operatorValue;
  //       if (operatorValue == "equals" && element.value)
  //         filter = filter.eq(
  //           field,
  //           field == "Id" ? +element.value : element.value
  //         );
  //       else if (operatorValue == "contains" && element.value)
  //         filter = filter.contains(field, element.value);
  //       else if (operatorValue == "startsWith" && element.value)
  //         filter = filter.startsWith(field, element.value);
  //       else if (operatorValue == "endsWith" && element.value)
  //         filter = filter.endsWith(field, element.value);
  //       else if (operatorValue == "isNotEmpty")
  //         filter = filter.not(f().isEmpty(field, element.value));
  //       else if (operatorValue == "isEmpty")
  //         filter = filter.isEmpty(field, element.value);
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
    POST(URLS.trainee.changeStatus, data).then((res) => {
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
    POST(URLS.trainee.delete, data).then((res) => {
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
  const getData = function async(
    page,
    searchText = "",
    selectedCourseID = null,
    selectedMainInterestID = null,
    selectedSubInterestID = null
  ) {
    const top = pageSize;
    const skip = pageSize * page;
    setCurrentPage(page);
    setLoading(true);
    const expand = ["Country", "City", "Sex"];
    let filter = f("or").eq("IsDeleted", false).toString();
    if (searchText) {
      filter = f("or")
        .contains((x) => x.toLower("TrainerFname"), searchText)
        .contains((x) => x.toLower("TrainerSname"), searchText)
        .contains((x) => x.toLower("TrainerTname"), searchText)
        .contains((x) => x.toLower("TrainerLname"), searchText)
        .and((x) => x.eq("IsDeleted", false))
        .toString();
    }
    const count = true;

    let query = buildQuery({ count, expand, top, skip, filter });

    setSelectedCourse(selectedCourseID);
    setSelectedMainInterest(selectedMainInterestID);
    setSelectedSecondaryInterest(selectedSubInterestID);
    if (selectedCourseID) query += "&courseId=" + selectedCourseID;
    if (selectedMainInterestID)
      query += "&majorInterestId=" + selectedMainInterestID;
    if (selectedSubInterestID)
      query += "&subInterestId=" + selectedSubInterestID;

    GET(URLS.trainee.all + query).then((res) => {
      setLoading(false);
      let fetchedRows = [];
      if (res.data && res.data.value && Array.isArray(res.data.value)) {
        fetchedRows = res.data.value.map((o) => ({
          name:
            o.TrainerFname +
            " " +
            o.TrainerSname +
            " " +
            o.TrainerTname +
            " " +
            o.TrainerLname,
          id: o.Id,
          type: o.Sex.SexType,
          status:
            o.IsActive && o.IsSuspend
              ? "منتظر"
              : !o.IsActive && !o.IsSuspend
              ? "غير معتمد"
              : "معتمد",
          address: o.City.CityName + " - " + o.Country.CountryName,
        }));
        setTotalSize(res.data["@odata.count"]);
      }
      setRows([...fetchedRows]);
    });
  };
  React.useEffect(() => {
    getData(0, "");
    getCourses();
    getMajorInterests();
    getSubInterests();
  }, []);

  const toggle = (modalType) => () => {
    if (!modalType) {
      return setModal(!modal);
    }
  };

  return (
    <Page
      title={t("trainee.title")}
      breadcrumbs={[{ name: "   " + t("trainee.title"), active: true }]}
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
      dir={direction}
    >
      {showFilters && (
        <div
          style={{
            marginBottom: 10,
          }}
        >
          <Grid container spacing={3}>
            <Grid item xs={12} sm={4}>
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
            <Grid item xs={12} sm={4}>
              <Select
                options={mainInterests}
                // isLoading={isLoading}
                placeholder={t("trainee.mainInterestSearch")}
                isClearable={true}
                isRtl={isArabic()}
                style={{ display: "block" }}
                onChange={(item) =>
                  getData(0, searchText, item ? item.value : undefined)
                }
              />
            </Grid>
            <Grid item xs={12} sm={4}>
              <Select
                options={secondaryInterests}
                // isLoading={isLoading}
                placeholder={t("trainee.secondaryInterestSearch")}
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
          filterMode="server"
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
          onPageChange={(page) =>
            getData(
              page,
              searchText,
              selectedCourse,
              selectedMainInterest,
              selectedSecondaryInterest
            )
          }
          page={currentPage}
          paginationMode={"server"}
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
