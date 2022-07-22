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
import InfoIcon from "@material-ui/icons/Info";
import { createTheme } from "@material-ui/core/styles";
import { makeStyles } from "@material-ui/styles";
import DeleteIcon from "@material-ui/icons/Delete";
import { useTranslation } from "react-i18next";

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
        {!!props.selectedRow && (
          <>
            <IconButton style={{color: "black"}} aria-label="info" onClick={props.toggleModal()}>
              <InfoIcon />
            </IconButton>
            <IconButton style={{color: "black"}} aria-label="info" onClick={()=>props.deleteItem(props.selectedRow)}>
              <DeleteIcon />
            </IconButton>
            <IconButton style={{color: "black"}} aria-label="status" onClick={() => props.clickHandler(props.selectedRow)}>
              {props.selectedRow.status == "معتمد" ? (
                <PersonAddDisabledIcon />
              ) : props.selectedRow.status == "منتظر" ? (
                <HowToRegIcon />
              ) : (
                <PersonAddIcon />
              )}
            </IconButton>
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
  clickHandler: PropTypes.func.isRequired,
  deleteItem: PropTypes.func.isRequired,
};
