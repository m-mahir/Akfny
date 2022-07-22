import React from "react";
import { withStyles, makeStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import ClearIcon from "@material-ui/icons/Clear";

const lang = localStorage.getItem("lang");
const isArabic = () => lang === "ar";
const position = isArabic() ? "right" : "left";

const StyledTableCell = withStyles((theme) => ({
  head: {
    backgroundColor: "#893c6c",
    color: "white",
  },
  body: {
    fontSize: 14,
  },
}))(TableCell);

const StyledTableRow = withStyles((theme) => ({
  root: {
    "&:nth-of-type(even)": {
      backgroundColor: "#f5ebf1",
    },
  },
}))(TableRow);

const useStyles = makeStyles({
  table: {
    width: "100%",
  },
});

export default function CustomizedTables(props) {
  const { rows, deleteRow } = props;
  const classes = useStyles();

  return (
    <TableContainer component={Paper}>
      <Table className={classes.table} aria-label="customized table">
        <TableHead>
          <TableRow>
            {Object.keys(rows[0]).map((field) => (
              <StyledTableCell align={position}>{field}</StyledTableCell>
            ))}
            {deleteRow ? (
              <StyledTableCell align={position}></StyledTableCell>
            ) : null}
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <StyledTableRow key={Object.keys(row)[0]}>
              {Object.keys(row).map((field) => (
                <StyledTableCell align={position}>{row[field]}</StyledTableCell>
              ))}
              {deleteRow ? (
                <StyledTableCell align={position}><ClearIcon fontSize="small" /></StyledTableCell>
              ) : null}
              {/* <StyledTableCell component="th" scope="row">
                {row.name}
              </StyledTableCell>
              <StyledTableCell align="right">{row.protein}</StyledTableCell> */}
            </StyledTableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
