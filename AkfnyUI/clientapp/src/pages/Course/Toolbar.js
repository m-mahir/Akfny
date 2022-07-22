import * as React from "react";
import PropTypes from "prop-types";
import {
  GridToolbarDensitySelector,
  GridToolbarFilterButton,
  GridToolbarColumnsButton,
  GridToolbarExport,
} from "@material-ui/data-grid";
import IconButton from "@material-ui/core/IconButton";
import TextField from "@material-ui/core/TextField";
import ClearIcon from "@material-ui/icons/Clear";
import SearchIcon from "@material-ui/icons/Search";
import HowToRegIcon from "@material-ui/icons/HowToReg";
import PersonAddDisabledIcon from "@material-ui/icons/PersonAddDisabled";
import PersonAddIcon from "@material-ui/icons/PersonAdd";
import AddCircleOutlineIcon from "@material-ui/icons/AddCircleOutline";
import InfoIcon from "@material-ui/icons/Info";
import EditIcon from "@material-ui/icons/Edit";
import { createTheme } from "@material-ui/core/styles";
import { makeStyles } from "@material-ui/styles";
import DeleteOutlineIcon from "@material-ui/icons/DeleteOutline";
import { useTranslation } from "react-i18next";
import { Link } from "react-router-dom";

const lang = localStorage.getItem("lang");
const isArabic = () => lang === "ar";
const direction = isArabic() ? "rtl" : "ltr";

const defaultTheme = createTheme({
  direction: direction,
});

const useStyles = makeStyles(
  (theme) => ({
    root: {
      padding: theme.spacing(0.5, 0.5, 0),
      justifyContent: "space-between",
      display: "flex",
      alignItems: "center",
      flexWrap: "wrap",
    },
    toolbarItem: {
      color: "#98276e",
      "& .MuiButton-startIcon.MuiButton-iconSizeSmall": {
        marginLeft: theme.spacing(0.5),
      },
    },
    textField: {
      [theme.breakpoints.down("xs")]: {
        width: "100%",
      },
      margin: theme.spacing(1, 0.5, 1.5),
      "& .MuiSvgIcon-root": {
        marginRight: theme.spacing(0.5),
        marginLeft: theme.spacing(0.5),
      },

      "& .MuiInput-underline:before": {
        borderBottom: `1px solid ${theme.palette.divider}`,
      },
    },
  }),
  { defaultTheme }
);

export default function QuickSearchToolbar(props) {
  const classes = useStyles();
  const { t } = useTranslation();

  const options = [
    { value: "chocolate", label: "Chocolate" },
    { value: "strawberry", label: "Strawberry" },
    { value: "vanilla", label: "Vanilla" },
  ];

  return (
    <div className={classes.root}>
      <div>
        <Link to="/course/add">
          <IconButton style={{color: "black"}} aria-label="add">
            <AddCircleOutlineIcon />
          </IconButton>
        </Link>
        {!!props.selectedRow && (
          <>
            <Link to={`/course/add/${props.selectedRow.id}`}>
              <IconButton style={{color: "black"}} aria-label="add">
                <EditIcon />
              </IconButton>
            </Link>
          </>
        )}
        <TextField
          variant="standard"
          value={props.value}
          onChange={props.onChange}
          placeholder={t("general.search")}
          className={classes.textField}
          InputProps={{
            startAdornment: <SearchIcon fontSize="small" />,
            endAdornment: (
              <IconButton
                title="Clear"
                aria-label="Clear"
                size="small"
                style={{color: "black"}}
                style={{ visibility: props.value ? "visible" : "hidden" }}
                onClick={props.clearSearch}
              >
                <ClearIcon fontSize="small" />
              </IconButton>
            ),
          }}
        />
      </div>
      <div>
        <GridToolbarColumnsButton className={classes.toolbarItem} />
        <GridToolbarFilterButton className={classes.toolbarItem} />
        <GridToolbarDensitySelector className={classes.toolbarItem} />
        <GridToolbarExport className={classes.toolbarItem} />
      </div>
    </div>
  );
}

QuickSearchToolbar.propTypes = {
  clearSearch: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  value: PropTypes.string.isRequired,
  selectedRow: PropTypes.object,
  toggleModal: PropTypes.func.isRequired,
};
