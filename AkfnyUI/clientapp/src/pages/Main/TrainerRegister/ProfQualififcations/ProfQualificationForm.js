import React from "react";
import { makeStyles } from "@material-ui/styles";
import { createTheme } from "@material-ui/core/styles";
import { useTranslation } from "react-i18next";
import Grid from "@material-ui/core/Grid";
import { useForm } from "react-hook-form";
import Button from "@material-ui/core/Button";
import DatePicker from "react-datepicker";
import MaterialTableDemo from "./ProfQualTable";
import "react-datepicker/dist/react-datepicker.css";

const lang = localStorage.getItem("lang");
const isArabic = () => lang === "ar";
const direction = isArabic() ? "rtl" : "ltr";

const defaultTheme = createTheme({
  direction: direction,
});

const useStyles = makeStyles(
  (theme) => ({
    form: {
      width: "97%",
      "& .MuiInputLabel-formControl": {
        left: isArabic() ? "auto" : 0,
        right: isArabic() ? 0 : "auto",
      },
      "& .MuiInputLabel-shrink": {
        transformOrigin: isArabic() ? "top right" : "top left",
      },
      "& input": {
        width: "100%",
        borderRadius: "4px",
        border: "1px solid white",
        padding: "10px 15px",
        marginBottom: "10px",
        fontSize: "14px",
      },
      '& button[type="submit"], input[type="submit"]': {
        background: "#98276e",
        color: "white",
        border: "none",
        marginTop: "30px",
        marginLeft: "10px",
        marginRight: "10px",
        padding: "10px",
        fontSize: "18px",
        fontWeight: "100",
      },
      '& button[type="submit"]:hover, input[type="submit"]:hover': {
        background: "#5d2548",
      },
      '& button[type="submit"]:active, input[type="button"]:active, input[type="submit"]:active':
        {
          transition: "0.3s all",
          transform: "translateY(3px)",
          border: "1px solid transparent",
          opacity: 0.8,
        },
      '& input[type="button"]': {
        background: "#a7478414",
        color: "#98276e",
        border: "1px solid #98276e",
        marginTop: "30px",
        marginLeft: "10px",
        marginRight: "10px",
        padding: "10px",
        fontSize: "18px",
        fontWeight: "100",
      },
      '& input[type="button"]:hover': {
        background: "lightgrey",
      },
      "& .rdw-editor-main": {
        backgroundColor: "white",
      },
    },
  }),
  { defaultTheme }
);

export default function AcademicQualificationsForm(props) {
  const { data, changeTab, onSubmit, removeItem } = props;
  const { t } = useTranslation();
  const classes = useStyles();

  const [title, setTitle] = React.useState("");
  const [certificate, setCertificate] = React.useState();
  const [date, setDate] = React.useState("");
  const [imageKey, setImageKey] = React.useState(new Date());

  const { handleSubmit } = useForm();

  const submitForm = () => {
    changeTab("courses");
  };

  const handleUploadClick = (event) => {
    let files = event.target.files;
    let reader = new FileReader();
    reader.readAsDataURL(files[0]);

    reader.onload = (e) => {
      setCertificate(e.target.result);
    };
  };

  return (
    <div
      style={{
        padding: 15,
        direction: direction,
      }}
    >
      <form onSubmit={handleSubmit(submitForm)} className={classes.form}>
        <Grid container spacing={3}>
          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
              placeholder={t("trainer.register.academicQualTitle")}
            />
          </Grid>
          <Grid item xs={12} sm={1}>
            <label>{t("trainer.register.certifcate")}</label>
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              key={imageKey}
              type="file"
              name="file"
              onChange={handleUploadClick}
              accept="image/*"
            />
          </Grid>
          <Grid item xs={12} sm={3}>
            <DatePicker
              selected={date}
              onChange={(d) => setDate(d)}
              placeholderText={t("trainer.register.date")}
            />
          </Grid>
          <Grid item xs={12} sm={2} style={{ textAlign: "end" }}>
            <Button
              variant="contained"
              onClick={() => {
                onSubmit(
                  {
                    LecturerCertificateTital: title,
                    LecturerCertificateImg_Base64: certificate
                      ? certificate.split(",")[1]
                      : null,
                    LecturerCertificateDate: date.toISOString(),
                  },
                  "LecturerCertificateList"
                );
                setTitle("");
                setImageKey(new Date());
                setCertificate();
                setDate();
              }}
              disabled={!title.length || !certificate || !date}
              className={classes.button}
            >
              {t("general.buttons.add")}
            </Button>
          </Grid>
          <Grid item xs={12}>
            {data.length ? (
              <MaterialTableDemo
                rows={data}
                removeRow={(itemList) => {
                  itemList.forEach((element) => {
                    removeItem(element, "LecturerCertificateList", [
                      "LecturerCertificateTital",
                      "LecturerCertificateDate",
                    ]);
                  });
                }}
              />
            ) : null}
          </Grid>
          <Grid item xs={6}>
            <input
              type="button"
              value={t("trainer.register.previous")}
              onClick={() => changeTab("qualification")}
            />
          </Grid>
          <Grid item xs={6}>
            <input type="submit" value={t("trainer.register.next")} />
          </Grid>
        </Grid>
      </form>
    </div>
  );
}
