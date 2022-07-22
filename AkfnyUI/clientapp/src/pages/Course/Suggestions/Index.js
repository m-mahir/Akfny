import * as React from "react";
import { DataGrid } from "@material-ui/data-grid";
import { createTheme } from "@material-ui/core/styles";
import { makeStyles } from "@material-ui/styles";
import CheckIcon from "@material-ui/icons/Check";
import WarningIcon from "@material-ui/icons/Warning";
import HourglassEmptyIcon from "@material-ui/icons/HourglassEmpty";
import Page from "../../../components/Page";
import QuickSearchToolbar from "./Toolbar";
import DetailsModal from "./DetailsModal";
import { useTranslation } from "react-i18next";
import Switch from "@material-ui/core/Switch";
import { FormControlLabel, FormGroup } from "@material-ui/core";
import Select from "react-select";
import Grid from "@material-ui/core/Grid";
import { GET, POST, URLS } from "../../../utils/http";
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

export default function Suggestions() {
  const classes = useStyles();

  const { t } = useTranslation();

  const [showFilters, setShowFilters] = React.useState(false);

  const toggleFilters = (event) => {
    setShowFilters(event.target.checked);
  };

  const columns = [
    {
      editable: false,
      field: "sector",
      headerName: t("suggestion.sector"),
      width: 180,
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
    },
    {
      editable: false,
      field: "field",
      headerName: t("suggestion.field"),
      width: 180,
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
    },
    {
      editable: false,
      field: "courseName",
      headerName: t("suggestion.courseName"),
      width: 180,
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
    },
    {
      editable: false,
      field: "trainerName",
      headerName: t("suggestion.trainerName"),
      width: 200,
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
    },
    {
      editable: false,
      field: "status",
      hide: true,
      headerName: t("suggestion.status"),
      // type: 'number',
      width: 140,
      type: "singleSelect",
      valueOptions: ["معتمد", "غير معتمد", "منتظر"],
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
    },
    {
      field: "actions",
      headerName: t("suggestion.status"),
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
  const [sectors, setSectors] = React.useState([]);
  const [selectedSector, setSelectedSector] = React.useState();
  const [fields, setFields] = React.useState([]);
  const [selectedField, setSelectedField] = React.useState();
  const [status, setStatus] = React.useState([]);
  const [selectedStatus, setSelectedStatus] = React.useState();
  const [rows, setRows] = React.useState([]);
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
      getData(0, searchValue, selectedSector, selectedField, selectedStatus);
    }, timeoutSeconds);
  };

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

  const getSectors = function () {
    GET(URLS.sector.all).then((res) => {
      setSectors([
        ...res.data.value.map((o) => ({ label: o.SectorTxt, value: o.Id })),
      ]);
    });
  };

  const getFields = function () {
    GET(URLS.field.all).then((res) => {
      setFields([
        ...res.data.value.map((o) => ({ label: o.FieldTxt, value: o.Id })),
      ]);
    });
  };

  const getSuggestionStatus = function () {
    GET(URLS.suggestionStatus.all).then((res) => {
      setStatus([
        ...res.data.value.map((o) => ({ label: o.Status, value: o.Id })),
      ]);
    });
  };

  const getData = function async(
    page,
    searchText = "",
    selectedSectorID = null,
    selectedFieldID = null,
    selectedStatusID = null
  ) {
    const top = pageSize;
    const skip = pageSize * page;
    const expand = ["Field", "Sector", "ProfferStatu"];
    setPage(page);
    setLoading(true);

    let filter = "";
    if (searchText) {
      filter = f("or")
        .contains((x) => x.toLower("CourseTxt"), searchText)
        .toString();
    }
    const count = true;

    let query = buildQuery({ count, expand, top, skip, filter });

    setSelectedSector(selectedSectorID);
    setSelectedField(selectedFieldID);
    setSelectedStatus(selectedStatusID);
    if (selectedSectorID) query += "&sectorId=" + selectedSectorID;
    if (selectedFieldID) query += "&fieldId=" + selectedFieldID;
    if (selectedStatusID) query += "&profferStatuId=" + selectedStatusID;

    GET(URLS.suggestion.all + query).then((res) => {
      setLoading(false);
      let fetchedRows = [];
      if (res.data && res.data.value && Array.isArray(res.data.value)) {
        fetchedRows = res.data.value.map((o) => ({
          sector: o.Sector.SectorTxt,
          field: o.Field.FieldTxt,
          id: o.Id,
          courseName: o.CourseTxt,
          trainerName:
            o.Lecturer.LecturerFname +
            " " +
            o.Lecturer.LecturerSname +
            " " +
            o.Lecturer.LecturerTname +
            " " +
            o.Lecturer.LecturerLname,
          status:
            o.IsActive && o.IsSuspend
              ? "منتظر"
              : !o.IsActive && !o.IsSuspend
              ? "غير معتمد"
              : "معتمد",
        }));
        setTotalSize(res.data["@odata.count"]);
      }
      setRows([...fetchedRows]);
    });
  };
  React.useEffect(() => {
    getData(0, "");
    getSectors();
    getFields();
    getSuggestionStatus();
  }, []);

  const toggle = (modalType) => () => {
    if (!modalType) {
      return setModal(!modal);
    }
  };

  return (
    <Page
      title={t("suggestion.title")}
      breadcrumbs={[{ name: "   " + t("suggestion.title"), active: true }]}
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
            <Grid item xs={12} sm={4}>
              <Select
                options={sectors}
                // isLoading={isLoading}
                placeholder={t("suggestion.sector")}
                isClearable={true}
                isRtl={isArabic()}
                style={{ display: "block" }}
                onChange={(item) =>
                  getData(
                    0,
                    searchText,
                    item ? item.value : undefined,
                    selectedField
                  )
                }
              />
            </Grid>
            <Grid item xs={12} sm={4}>
              <Select
                options={fields}
                // isLoading={isLoading}
                placeholder={t("suggestion.field")}
                isClearable={true}
                isRtl={isArabic()}
                style={{ display: "block" }}
                onChange={(item) =>
                  getData(
                    0,
                    searchText,
                    selectedSector,
                    item ? item.value : undefined
                  )
                }
              />
            </Grid>
            <Grid item xs={12} sm={4}>
              <Select
                options={status}
                // isLoading={isLoading}
                placeholder={t("suggestion.status")}
                isClearable={true}
                isRtl={isArabic()}
                style={{ display: "block" }}
                onChange={(item) =>
                  getData(
                    0,
                    searchText,
                    selectedStatus,
                    item ? item.value : undefined
                  )
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
          onPageChange={(page) =>
            getData(
              page,
              searchText,
              selectedSector,
              selectedField,
              selectedStatus
            )
          }
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
