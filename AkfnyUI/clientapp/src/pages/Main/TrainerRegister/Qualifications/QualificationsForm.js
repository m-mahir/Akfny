import React, { useEffect } from "react";
import { makeStyles } from "@material-ui/styles";
import { createTheme } from "@material-ui/core/styles";
import { useTranslation } from "react-i18next";
import Grid from "@material-ui/core/Grid";
import { useForm } from "react-hook-form";
import Select from "react-select";
import Button from "@material-ui/core/Button";
import { GET, URLS } from "../../../../utils/http";
import MaterialTableDemo from "./QualTable";

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

export default function QualificationsForm(props) {
  const { data, changeTab, onSubmit, removeItem } = props;
  const { t } = useTranslation();
  const classes = useStyles();

  const { handleSubmit } = useForm();

  const [qualifications, setQualifications] = React.useState([]);
  const [selectedQualification, setSelectedQualification] = React.useState();

  const [mainSpecialty, setMainSpecialty] = React.useState("");
  const [secSpecialty, setSecSpecialty] = React.useState("");
  const [gradYear, setGradYear] = React.useState("");
  const [gradCountry, setGradCountry] = React.useState("");
  const [college, setCollege] = React.useState("");

  const populateSelectLists = () => {
    GET(URLS.qualification.all).then((res) => {
      setQualifications([
        ...res.data.value.map((o) => ({
          label: o.QualificationType,
          value: o.Id,
        })),
      ]);
    });
  };

  const submitForm = () => {
    changeTab("profQualification");
  };

  useEffect(() => {
    populateSelectLists();
  }, []);

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
            <Select
              options={qualifications}
              value={
                selectedQualification
                  ? qualifications.filter(
                      (option) => option.value === selectedQualification.id
                    )
                  : null
              }
              // isLoading={isLoading}
              placeholder={t("trainer.register.scientificQualification")}
              isClearable={true}
              isRtl={isArabic()}
              style={{ display: "block" }}
              onChange={(event) => {
                if (event)
                  setSelectedQualification({
                    id: event.value,
                    value: event.label,
                  });
                else setSelectedQualification();
              }}
            />
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={mainSpecialty}
              onChange={(e) => setMainSpecialty(e.target.value)}
              placeholder={t("trainer.register.mainSpecialty")}
            />
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={secSpecialty}
              onChange={(e) => setSecSpecialty(e.target.value)}
              placeholder={t("trainer.register.secSpecialty")}
            />
          </Grid>
          <Grid item xs={12} sm={3}></Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="number"
              value={gradYear}
              onChange={(e) => setGradYear(e.target.value)}
              placeholder={t("trainer.register.gradYear")}
            />
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={gradCountry}
              onChange={(e) => setGradCountry(e.target.value)}
              placeholder={t("trainer.register.gradCountry")}
            />
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={college}
              onChange={(e) => setCollege(e.target.value)}
              placeholder={t("trainer.register.college")}
            />
          </Grid>

          <Grid item xs={12} sm={3} style={{ textAlign: "end" }}>
            <Button
              variant="contained"
              onClick={() => {
                onSubmit(
                  {
                    QualificationDefineId: selectedQualification.id,
                    qual: selectedQualification,
                    MajorSpecialization: mainSpecialty,
                    SecondarySpecialization: secSpecialty,
                    GraduationYear: +gradYear,
                    CountryOfGraduation: gradCountry,
                    TheUniversity: college,
                  },
                  "LecturerQualificationList"
                );
                setSelectedQualification();
                setMainSpecialty("");
                setSecSpecialty("");
                setGradYear("");
                setGradCountry("");
                setCollege("");
              }}
              disabled={
                !selectedQualification ||
                !mainSpecialty ||
                !secSpecialty ||
                !gradYear ||
                !gradCountry ||
                !college ||
                data.find(
                  (i) => i.QualificationDefineId === selectedQualification.id
                )
              }
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
                    removeItem(element, "LecturerQualificationList", [
                      "QualificationDefineId",
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
              onClick={() => changeTab("personal-info")}
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
