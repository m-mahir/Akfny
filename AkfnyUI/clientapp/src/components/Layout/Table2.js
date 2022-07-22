import * as React from 'react';
import PropTypes from 'prop-types';
import { useSelector } from 'react-redux';
import {
  DataGrid,
  GridToolbarDensitySelector,
  GridToolbarFilterButton,
  GridToolbarColumnsButton,
  GridToolbarExport,
} from '@material-ui/data-grid';
import Grid from '@material-ui/core/Grid';
import IconButton from '@material-ui/core/IconButton';
import TextField from '@material-ui/core/TextField';
import ClearIcon from '@material-ui/icons/Clear';
import SearchIcon from '@material-ui/icons/Search';
import { createTheme } from '@material-ui/core/styles';
import { makeStyles } from '@material-ui/styles';
import AddCircleIcon from '@material-ui/icons/AddCircle';
import EditIcon from '@material-ui/icons/Edit';
import DeleteOutlineIcon from '@material-ui/icons/DeleteOutline';
import InfoIcon from '@material-ui/icons/Info';
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import { useTranslation } from 'react-i18next';

function escapeRegExp(value) {
  return value.replace(/[-[\]{}()*+?.,\\^$|#\s]/g, '\\$&');
}

const defaultTheme = createTheme({
  direction: 'rtl',
});

const useStyles = makeStyles(
  theme => ({
    root: {
      padding: theme.spacing(0.5, 0.5, 0),
      justifyContent: 'space-between',
      display: 'flex',
      alignItems: 'center',
      flexWrap: 'wrap',
    },
    grid: {
      '& .MuiDataGrid-columnSeparator': {
        visibility: 'hidden',
      },
    },
    toolbarItem: {
      color: '#98276e',
      '& .MuiButton-startIcon.MuiButton-iconSizeSmall': {
        marginLeft: theme.spacing(0.5),
      },
    },
    textField: {
      [theme.breakpoints.down('xs')]: {
        width: '100%',
      },
      margin: theme.spacing(1, 0.5, 1.5),
      '& .MuiSvgIcon-root': {
        marginRight: theme.spacing(0.5),
        marginLeft: theme.spacing(0.5),
      },

      '& .MuiInput-underline:before': {
        borderBottom: `1px solid ${theme.palette.divider}`,
      },
    },
  }),
  { defaultTheme },
);

function QuickSearchToolbar(props) {
  const classes = useStyles();

  // const lang = useSelector(state => state.user.lang);
  const lang = localStorage.getItem('lang');
  const isArabic = () => lang === 'ar';
  const direction = isArabic() ? 'rtl' : 'ltr';

  const { t } = useTranslation();

  return (
    <div className={classes.root}>
      <div>
        <IconButton aria-label="add" onClick={props.toggleModal()}>
          <AddCircleIcon />
        </IconButton>
        {!!props.selectedRow && (
          <>
            <IconButton aria-label="edit" onClick={() => {}}>
              <EditIcon />
            </IconButton>
            <IconButton aria-label="delete" onClick={() => {}}>
              <DeleteOutlineIcon />
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
                style={{ visibility: props.value ? 'visible' : 'hidden' }}
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

export default function QuickFilteringGrid() {
  const classes = useStyles();

  // const lang = useSelector(state => state.user.lang);
  const lang = localStorage.getItem('lang');
  const isArabic = () => lang === 'ar';
  const direction = isArabic() ? 'rtl' : 'ltr';

  const columns = [
    {
      editable: false,
      field: 'id',
      hide: true,
    },
    {
      editable: false,
      field: 'commodity',
      headerName: 'الاسم',
      width: 180,
      cellClassName: isArabic() ? 'alignTextRight' : 'alignTextLeft',
    },
    {
      editable: false,
      field: 'desk',
      headerName: 'العنوان',
      width: 180,
      cellClassName: isArabic() ? 'alignTextRight' : 'alignTextLeft',
    },
    {
      editable: false,
      field: 'traderName',
      headerName: 'Trader Name',
      width: 200,
      cellClassName: isArabic() ? 'alignTextRight' : 'alignTextLeft',
    },
    {
      editable: false,
      field: 'traderEmail',
      headerName: 'Trader Email',
      width: 200,
      cellClassName: isArabic() ? 'alignTextRight' : 'alignTextLeft',
    },
    {
      editable: false,
      field: 'quantity',
      headerName: 'Quantity',
      type: 'number',
      width: 140,
      cellClassName: isArabic() ? 'alignTextLeft' : 'alignTextRight',
    },
  ];

  const rs = [
    {
      commodity: 'Rapeseed',
      desk: 'D-3183',
      id: 'fbae2b11-6f52-5bff-9893-6fab6e9860a2',
      quantity: 78819,
      traderEmail: 'iz@hajetsul.tm',
      traderName: 'Jean Garner',
    },
    {
      commodity: 'Robusta coffee',
      desk: 'D-8469',
      id: 'e3488f96-1192-523d-9376-f969c38fe235',
      quantity: 67677,
      traderEmail: 'cewomi@tipehof.fo',
      traderName: 'Harvey Bass',
    },
  ];

  const [searchText, setSearchText] = React.useState('');
  const [rows, setRows] = React.useState(rs);
  const [selectedRow, setSelectedRow] = React.useState();
  const [modal, setModal] = React.useState(false);

  const requestSearch = searchValue => {
    setSearchText(searchValue);
    const searchRegex = new RegExp(escapeRegExp(searchValue), 'i');
    const filteredRows = rs.filter(row => {
      return Object.keys(row).some(field => {
        return searchRegex.test(row[field].toString());
      });
    });
    setRows(filteredRows);
  };

  // React.useEffect(() => {
  //   setRows(rs);
  // }, [rs]);

  const toggle = modalType => () => {
    if (!modalType) {
      return setModal(!modal);
    }
  };

  return (
    <div
      dir={direction}
      style={{
        height: '75vh',
        width: '100%',
        boxShadow: '0 2px 2px #9E9E9E',
        borderRadius: 8,
      }}
    >
      <DataGrid
        components={{ Toolbar: QuickSearchToolbar }}
        rows={rows}
        columns={columns}
        className={classes.grid}
        onSelectionModelChange={e => {
          const selectedID = e[0];
          const selectedRowData = rows.filter(
            row => selectedID == row.id.toString(),
          );
          setSelectedRow(selectedRowData[0]);
        }}
        componentsProps={{
          toolbar: {
            value: searchText,
            onChange: event => requestSearch(event.target.value),
            clearSearch: () => requestSearch(''),
            selectedRow: selectedRow,
            toggleModal: toggle,
          },
        }}
      />
      <Modal isOpen={modal} toggle={toggle()}>
        <ModalHeader
          style={{
            backgroundColor: '#98276e',
            color: 'white',
            alignItems: 'center',
          }}
          toggle={toggle()}
          cssModule={{ 'modal-title': 'w-100 text-center' }}
        >
          <div className="d-flex justify-content-center">
            <p
              style={{
                marginTop: '0.7rem',
                marginBottom: '0.3rem',
                fontSize: 22,
              }}
            >
              بيانات المتدرب
            </p>
          </div>
        </ModalHeader>
        <ModalBody>
          <div
            style={{
              padding: 15,
            }}
          >
            <Grid container spacing={3}>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  id="firstName"
                  name="firstName"
                  label="اسم العائلة"
                  fullWidth
                  autoComplete="given-name"
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  id="lastName"
                  name="lastName"
                  label="الاسم الاول"
                  fullWidth
                  autoComplete="family-name"
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  id="address1"
                  name="address1"
                  label="العنوان"
                  fullWidth
                  autoComplete="shipping address-line1"
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  id="city"
                  name="city"
                  label="المدينة"
                  fullWidth
                  autoComplete="shipping address-level2"
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField id="state" name="state" label="المنطقة" fullWidth />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  id="zip"
                  name="zip"
                  label="الرقم البريدى"
                  fullWidth
                  autoComplete="shipping postal-code"
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  id="country"
                  name="country"
                  label="البلد"
                  fullWidth
                  autoComplete="shipping country"
                />
              </Grid>
              <Grid item xs={12}>
                <FormControlLabel
                  control={
                    <Checkbox
                      color="secondary"
                      name="saveAddress"
                      value="yes"
                    />
                  }
                  dir="rtl"
                  label="استخدم هذا العنوان للمراسلات"
                />
              </Grid>
            </Grid>
          </div>
        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={toggle()}>
            حفظ
          </Button>{' '}
          <Button color="secondary" onClick={toggle()}>
            الغاء
          </Button>
        </ModalFooter>
      </Modal>
    </div>
  );
}
