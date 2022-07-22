import * as React from "react";
import Grid from "@material-ui/core/Grid";
import TextField from "@material-ui/core/TextField";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { makeStyles } from "@material-ui/styles";
import { createTheme } from "@material-ui/core/styles";
import { Tabs, Tab } from "react-bootstrap";
import ModalTable from "./ModalTable";
import { useTranslation } from "react-i18next";

const lang = localStorage.getItem("lang");
const isArabic = () => lang === "ar";
const direction = isArabic() ? "rtl" : "ltr";

const defaultTheme = createTheme({
  direction: direction,
});

const useStyles = makeStyles(
  (theme) => ({
    modal: {
      "& .MuiInputLabel-formControl": {
        left: isArabic() ? "auto" : 0,
        right: isArabic() ? 0 : "auto",
      },
      "& .MuiInputLabel-shrink": {
        transformOrigin: isArabic() ? "top right" : "top left",
      },
      "& .modal-footer > :not(:last-child)": {
        marginLeft: theme.spacing(0.5),
      },
    },
  }),
  { defaultTheme }
);

function FormItem(props) {
  const { field, value, label } = props;
  return (
    <Grid item xs={12} sm={6}>
      <TextField
        id={field}
        name={field}
        value={value}
        label={label}
        fullWidth
        disabled={true}
      />
    </Grid>
  );
}

export default function DetailsModal(props) {
  const { modal, toggle, selectedRow } = props;
  const classes = useStyles();

  const { t } = useTranslation();

  const data = {
    personalDetails: {
      name: "محمد احمد",
      city: "مصر - الاسكندرية",
      id: "fbae2b11-6f52",
      type: "ذكر",
      nationality: "مصرى",
      IDType: "مواطن",
      status: "معتمد",
    },
    qualifications: [
      {
        type: "ماجيستير",
        majorSpec: "Science",
        minorSpec: "Chemistry",
        org: "FCIS",
      },
      {
        type: "دكتوراة",
        majorSpec: "Bio",
        minorSpec: "Animal",
        org: "MIT",
      },
    ],
  };

  return (
    <Modal
      isOpen={modal}
      toggle={toggle()}
      className={classes.modal}
      dir={direction}
    >
      <ModalHeader
        style={{
          backgroundColor: "#98276e",
          color: "white",
          alignItems: "center",
        }}
        toggle={toggle()}
        cssModule={{ "modal-title": "w-100 text-center" }}
      >
        <div className="d-flex justify-content-center">
          <p
            style={{
              marginTop: "0.7rem",
              marginBottom: "0.3rem",
              fontSize: 22,
            }}
          >
            {t("trainee.details")}
          </p>
        </div>
      </ModalHeader>
      <ModalBody>
        <Tabs
          // defaultActiveKey={Object.keys(data)[0]}
          id="trainee-details-tab"
          className="mb-3"
        >
          {Object.keys(data).map((key) => (
            <Tab eventKey={key} title={t("trainer." + key)}>
              <div
                style={{
                  padding: 15,
                  direction: direction,
                }}
              >
                {Array.isArray(data[key]) ? (
                  <ModalTable rows={data[key]} />
                ) : (
                  <Grid container spacing={3}>
                    {Object.keys(data[key]).map((field) => (
                      <FormItem
                        field={data[key][field]}
                        value={selectedRow ? data[key][field] : ""}
                        label={field}
                      />
                    ))}
                  </Grid>
                )}
              </div>
            </Tab>
          ))}
        </Tabs>
      </ModalBody>
      <ModalFooter>
        <Button color="secondary" onClick={toggle()}>
          {t("general.close")}
        </Button>
      </ModalFooter>
    </Modal>
  );
}
