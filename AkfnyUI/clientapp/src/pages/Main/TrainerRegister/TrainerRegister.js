import React from "react";
import { Footer, HomeHeader } from "../../../components/Layout";
import { makeStyles } from "@material-ui/styles";
import { createTheme } from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";
import { useTranslation } from "react-i18next";
import "react-draft-wysiwyg/dist/react-draft-wysiwyg.css";
import { POST, URLS } from "../../../utils/http";
import { Tabs, Tab } from "react-bootstrap";
import PersonalInfoForm from "./PersonalInfoForm";
import QualificationsForm from "./Qualifications/QualificationsForm";
import AcademicQualificationsForm from "./ProfQualififcations/ProfQualificationForm";
import CoursesForm from "./Courses/CoursesForm";
import ConfirmationForm from "./ConfirmationForm";

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
      "& .nav-tabs .nav-link.disabled": {
        backgroundColor: "#00000005",
        color: "#6c757d73",
        borderColor: "#dee2e6",
      },
    },
  }),
  { defaultTheme }
);

export default function RegisterTraineeForm(props) {
  const { t } = useTranslation();
  const classes = useStyles();

  const [tabKey, setTabKey] = React.useState("personal-info");
  const [formData, setFormData] = React.useState({});

  const addDataToForm = (data, childPropName) => {
    setFormData((prevData) => {
      if (childPropName) {
        let oldPropData = prevData[childPropName] || [];
        return {
          ...prevData,
          [childPropName]: [...oldPropData, data],
        };
      } else return { ...prevData, ...data };
    });
  };

  const deleteFormListData = (id, listPropName, idPropNames) => {
    setFormData((prevData) => {
      let newList = prevData[listPropName].filter((i) => {
        let idVal = "";
        idPropNames.forEach((element) => {
          if (idVal.length) idVal += "_";
          idVal += i[element];
        });
        return idVal !== id;
      });
      return {
        ...prevData,
        [listPropName]: newList,
      };
    });
  };

  function buildFormData(formData, data, parentKey) {
    if (
      data &&
      typeof data === "object" &&
      !(data instanceof Date) &&
      !(data instanceof File)
    ) {
      Object.keys(data).forEach((key) => {
        buildFormData(
          formData,
          data[key],
          parentKey ? `${parentKey}[${key}]` : key
        );
      });
    } else {
      const value = data == null ? "" : data;

      formData.append(parentKey, value);
    }
  }

  const validateEmail = (email) => {
    const re =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  };

  const registerTrainer = () => {
    if (
      !formData.firstName ||
      !formData.firstName.length ||
      !formData.middleName ||
      !formData.middleName.length ||
      !formData.lastName ||
      !formData.lastName.length ||
      !formData.familyName ||
      !formData.familyName.length ||
      !formData.selectedCountry ||
      !formData.selectedCity ||
      !formData.selectedGender ||
      !formData.mail ||
      !validateEmail(formData.mail) ||
      !formData.phone ||
      !formData.idNumber ||
      !formData.selectedIDType ||
      !formData.experienceField ||
      !formData.experienceYears ||
      !formData.secExperienceField ||
      !formData.secExperienceYears ||
      !formData.selectedNationality
    ) {
      setTabKey("personal-info");
      return;
    }
    const data = new FormData();

    buildFormData(data, formData);

    POST(URLS.trainer.add, data).then((res) => {
      if (res.status == 200) {
        // history.goBack();
      }
    });
  };

  return (
    <>
      <HomeHeader />
      <div
        className={classes.form}
        style={{
          margin: 15,
          boxShadow: "0 2px 2px #9E9E9E",
          borderRadius: 8,
          borderTopLeftRadius: 15,
          borderTopRightRadius: 15,
          direction: direction,
        }}
      >
        <div
          style={{
            background: "#98276e",
            color: "white",
            padding: 15,
            display: "flex",
            alignItems: "center",
            justifyContent: "center",
            borderTopRightRadius: 12,
            borderTopLeftRadius: 12,
          }}
        >
          <Typography variant="h6">{t("trainer.register.title")}</Typography>
        </div>
        <div
          style={{
            paddingInlineEnd: 10,
            paddingInlineStart: 30,
            paddingBottom: 25,
            paddingTop: 35,
            backgroundColor: "#f0f0f075",
          }}
        >
          <Tabs
            id="trainer-register-tab"
            activeKey={tabKey}
            className="mb-3"
            onSelect={(k) => setTabKey(k)}
          >
            <Tab
              eventKey={"personal-info"}
              title={t("trainer.register.personalInfo")}
            >
              <PersonalInfoForm
                changeTab={setTabKey}
                onSubmit={addDataToForm}
              />
            </Tab>
            <Tab
              eventKey={"qualification"}
              // disabled={!formData.LecturerFname}
              title={t("trainer.register.qualification")}
            >
              <QualificationsForm
                changeTab={setTabKey}
                data={formData.LecturerQualificationList || []}
                onSubmit={addDataToForm}
                removeItem={deleteFormListData}
              />
            </Tab>
            <Tab
              eventKey={"profQualification"}
              // disabled={!formData.LecturerQualificationList}
              title={t("trainer.register.academicQualification")}
            >
              <AcademicQualificationsForm
                changeTab={setTabKey}
                data={formData.LecturerCertificateList || []}
                onSubmit={addDataToForm}
                removeItem={deleteFormListData}
              />
            </Tab>
            <Tab
              eventKey={"courses"}
              // disabled={!formData.LecturerCertificateList}
              title={t("trainer.register.courses")}
            >
              <CoursesForm
                changeTab={setTabKey}
                data={formData.LecturerInterestedCourseList || []}
                onSubmit={addDataToForm}
                removeItem={deleteFormListData}
              />
            </Tab>
            <Tab
              eventKey={"confirm"}
              // disabled={!formData.LecturerInterestedCourseList}
              title={t("trainer.register.confirm")}
            >
              <ConfirmationForm
                changeTab={setTabKey}
                onSubmit={registerTrainer}
              />
            </Tab>
          </Tabs>
        </div>
      </div>
      <Footer />
    </>
  );
}
