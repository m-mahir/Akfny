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
import { SignalCellularNullOutlined } from "@material-ui/icons";

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
      headerName: t("course.name"),
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
      width: 450,
    },
    {
      editable: false,
      field: "duration",
      headerName: t("course.duration"),
      cellClassName: isArabic() ? "alignTextRight" : "alignTextLeft",
      width: 200,
    },
    ,
  ];

  const [searchText, setSearchText] = React.useState("");
  const [rows, setRows] = React.useState([]);
  const [selectedRow, setSelectedRow] = React.useState();
  const [modal, setModal] = React.useState(false);
  const [pageSize, setPageSize] = React.useState(5);
  const [totalSize, setTotalSize] = React.useState(0);
  const [loading, setLoading] = React.useState(false);
  const [sectors, setSectors] = React.useState([]);
  const [selectedSector, setSelectedSector] = React.useState();
  const [fields, setFields] = React.useState([]);
  const [selectedField, setSelectedField] = React.useState();
  const [currentPage, setCurrentPage] = React.useState(0);

  // const requestSearch = (searchValue) => {
  //   setSearchText(searchValue);
  //   const searchRegex = new RegExp(escapeRegExp(searchValue), "i");
  //   const filteredRows = rs.filter((row) => {
  //     return Object.keys(row).some((field) => {
  //       return searchRegex.test(row[field].toString());
  //     });
  //   });
  //   setRows(filteredRows);
  // };

  const requestSearch = (searchValue) => {
    setSearchText(searchValue);
    if (timeout) clearTimeout(timeout);
    timeout = setTimeout(() => {
      getData(0, searchValue, selectedSector, selectedField);
    }, timeoutSeconds);
  };
  const mapFilterFieldName = (col) => {
    if (col == "name") return "E_CourseTxt";
    else if (col == "id") return "Id";
    return col;
  };
  const filterModelChange = (event) => {
    let filter = f(event.linkOperator);
    if (event.items.length > 0) {
      event.items.forEach((element) => {
        const field = mapFilterFieldName(element.columnField);
        const operatorValue = element.operatorValue;
        if (operatorValue == "equals" && element.value)
          filter = filter.eq(
            field,
            field == "Id" ? +element.value : element.value
          );
        else if (operatorValue == "contains" && element.value)
          filter = filter.contains(field, element.value);
        else if (operatorValue == "startsWith" && element.value)
          filter = filter.startsWith(field, element.value);
        else if (operatorValue == "endsWith" && element.value)
          filter = filter.endsWith(field, element.value);
        else if (operatorValue == "isNotEmpty")
          filter = filter.not(f().isEmpty(field, element.value));
        else if (operatorValue == "isEmpty")
          filter = filter.isEmpty(field, element.value);
      });
      getData(0, searchText, filter, selectedSector, selectedField);
    }
  };

  const getData = function async(
    page,
    searchText = "",
    selectedSectorID = null,
    selectedFieldID = null
  ) {
    const top = pageSize;
    const skip = pageSize * page;
    setCurrentPage(page);
    setLoading(true);
    const expand = ["Field", "Sector"];
    let filter = "";
    if (searchText) {
      filter = f("or")
        .contains((x) => x.toLower("E_CourseTxt"), searchText)
        .toString();
    }
    const count = true;

    let query = buildQuery({ count, expand, top, skip, filter });

    setSelectedSector(selectedSectorID);
    setSelectedField(selectedFieldID);
    if (selectedSectorID) query += "&sectorId=" + selectedSectorID;
    if (selectedFieldID) query += "&fieldId=" + selectedFieldID;

    GET(URLS.course.all + query).then((res) => {
      setLoading(false);
      let fetchedRows = [];
      if (res.data && res.data.value && Array.isArray(res.data.value)) {
        fetchedRows = res.data.value.map((o) => ({
          name: o.E_CourseTxt,
          duration: `${o.Days} ${t("course.days")} - ${o.Hour} ${t(
            "course.hours"
          )}`,
          id: o.Id,
        }));
        setTotalSize(res.data["@odata.count"]);
      }
      setRows([...fetchedRows]);
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

  React.useEffect(() => {
    getData(0, "");
    getSectors();
    getFields();
  }, []);

  const toggle = (modalType) => () => {
    if (!modalType) {
      return setModal(!modal);
    }
  };

  return (
    <Page
      title={t("course.title")}
      // breadcrumbs={[{ name: "   " + t("course.title"), active: true }]}
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
                options={sectors}
                // isLoading={isLoading}
                placeholder={t("course.sector")}
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
                placeholder={t("course.field")}
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
          </Grid>
        </div>
      )}
      <div
        dir={direction}
        style={{
          height: "65vh",
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
          onFilterModelChange={(event, details) =>
            filterModelChange(event, details)
          }
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
          page={currentPage}
          paginationMode={"server"}
          onPageChange={(page) =>
            getData(page, searchText, selectedSector, selectedField)
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
