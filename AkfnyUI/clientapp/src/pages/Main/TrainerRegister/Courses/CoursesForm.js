import React, { useEffect } from "react";
import { makeStyles } from "@material-ui/styles";
import { createTheme } from "@material-ui/core/styles";
import { useTranslation } from "react-i18next";
import Grid from "@material-ui/core/Grid";
import { useForm } from "react-hook-form";
import Select from "react-select";
import Button from "@material-ui/core/Button";
import buildQuery from "odata-query";
import { GET, URLS } from "../../../../utils/http";
import MaterialTableDemo from "./CoursesTable";

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

export default function CoursesForm(props) {
  const { data, changeTab, onSubmit, removeItem } = props;
  const { t } = useTranslation();
  const classes = useStyles();

  const { handleSubmit } = useForm();

  const [sectors, setSectors] = React.useState([]);
  const [selectedSector, setSelectedSector] = React.useState();
  const [fields, setFields] = React.useState([]);
  const [selectedField, setSelectedField] = React.useState();
  const [courses, setCourses] = React.useState([]);
  const [selectedCourse, setSelectedCourse] = React.useState();
  const [price, setPrice] = React.useState("");

  const getFields = (sectorID) => {
    const filter = { SectorID: sectorID };
    let query = buildQuery({ filter });
    GET(URLS.field.all + query).then((res) => {
      setFields([
        ...res.data.value.map((o) => ({ label: o.FieldTxt, value: o.Id })),
      ]);
    });
  };

  const getCourses = (fieldID) => {
    const filter = { FieldID: fieldID };
    let query = buildQuery({ filter });
    GET(URLS.course.all + query).then((res) => {
      setCourses([
        ...res.data.value.map((o) => ({ label: o.CourseTxt, value: o.Id })),
      ]);
    });
  };

  const populateSelectLists = () => {
    GET(URLS.sector.all).then((res) => {
      setSectors([
        ...res.data.value.map((o) => ({ label: o.SectorTxt, value: o.Id })),
      ]);
    });
  };

  const submitForm = () => {
    changeTab("confirm");
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
              options={sectors}
              value={
                selectedSector
                  ? sectors.filter(
                      (option) => option.value === selectedSector.id
                    )
                  : null
              }
              // isLoading={isLoading}
              placeholder={t("trainer.register.sector")}
              isClearable={true}
              isRtl={isArabic()}
              style={{ display: "block" }}
              onChange={(item) => {
                if (item) {
                  setSelectedSector({
                    id: item.value,
                    value: item.label,
                  });
                  getFields(item.value);
                } else {
                  setSelectedSector();
                  setFields([]);
                  setSelectedField();
                }
              }}
            />
          </Grid>
          <Grid item xs={12} sm={3}>
            <Select
              options={fields}
              value={
                selectedField
                  ? fields.filter((option) => option.value === selectedField.id)
                  : null
              }
              // isLoading={isLoading}
              placeholder={t("trainer.register.field")}
              isClearable={true}
              isRtl={isArabic()}
              style={{ display: "block" }}
              onChange={(item) => {
                if (item) {
                  setSelectedField({
                    id: item.value,
                    value: item.label,
                  });
                  getCourses(item.value);
                } else {
                  setSelectedField();
                  setCourses([]);
                  setSelectedCourse();
                }
              }}
            />
          </Grid>
          <Grid item xs={12} sm={3}>
            <Select
              options={courses}
              value={
                selectedCourse
                  ? courses.filter(
                      (option) => option.value === selectedCourse.id
                    )
                  : null
              }
              // isLoading={isLoading}
              placeholder={t("trainer.register.course")}
              isClearable={true}
              isRtl={isArabic()}
              style={{ display: "block" }}
              onChange={(event) => {
                if (event)
                  setSelectedCourse({
                    id: event.value,
                    value: event.label,
                  });
                else setSelectedCourse();
              }}
            />
          </Grid>
          <Grid item xs={12} sm={2}>
            <input
              type="number"
              value={price}
              onChange={(e) => setPrice(e.target.value)}
              placeholder={t("trainer.register.price")}
            />
          </Grid>

          <Grid item xs={12} sm={1} style={{ textAlign: "end" }}>
            <Button
              variant="contained"
              onClick={() => {
                onSubmit(
                  {
                    CourseId: selectedCourse.id,
                    CourseName: selectedCourse.value,
                    fieldId: selectedField.id,
                    fieldName: selectedField.value,
                    sectorId: selectedSector.id,
                    sectorName: selectedSector.value,
                    Price: price,
                  },
                  "LecturerInterestedCourseList"
                );
                setSelectedCourse();
                setSelectedField();
                setSelectedSector();
                setPrice("");
              }}
              disabled={
                !selectedCourse ||
                !selectedField ||
                !selectedSector ||
                !price ||
                data.find(
                  (i) =>
                    i.CourseId === selectedCourse.id &&
                    i.fieldId === selectedField.id &&
                    i.sectorId === selectedSector.id
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
                    removeItem(element, "LecturerInterestedCourseList", [
                      "sectorId",
                      "fieldId",
                      "courseId",
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
              onClick={() => changeTab("profQualification")}
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
