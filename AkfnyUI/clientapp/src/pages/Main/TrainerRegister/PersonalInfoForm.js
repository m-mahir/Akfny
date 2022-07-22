import React, { useEffect } from "react";
import { makeStyles } from "@material-ui/styles";
import { createTheme } from "@material-ui/core/styles";
import { useTranslation } from "react-i18next";
import Grid from "@material-ui/core/Grid";
import { useForm } from "react-hook-form";
import Select from "react-select";
import buildQuery from "odata-query";
import ImageUpload from "../ImageUpload";
import { GET, POST, URLS } from "../../../utils/http";
import ErrorMsg from "../../../components/common/ErrorMsg";

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

export default function PersonalInfoForm(props) {
  const { changeTab, onSubmit } = props;
  const { t } = useTranslation();
  const classes = useStyles();

  const { handleSubmit } = useForm();

  const [firstName, setFirstName] = React.useState("");
  const [middleName, setMiddleName] = React.useState("");
  const [lastName, setLastName] = React.useState("");
  const [familyName, setFamilyName] = React.useState("");
  const [idNumber, setIdNumber] = React.useState("");
  const [idTypes, setIdTypes] = React.useState([]);
  const [selectedIDType, setSelectedIDType] = React.useState();
  const [nationalities, setNationalities] = React.useState([]);
  const [selectedNationality, setSelectedNationality] = React.useState();
  const [genderList, setGenderList] = React.useState([]);
  const [selectedGender, setSelectedGender] = React.useState();
  const [cities, setCities] = React.useState([]);
  const [selectedCity, setSelectedCity] = React.useState();
  const [countries, setCountries] = React.useState([]);
  const [selectedCountry, setSelectedCountry] = React.useState();
  const [phone, setPhone] = React.useState("");
  const [phonePrefix, setPhonePrefix] = React.useState("");
  const [mail, setMail] = React.useState("");
  const [experienceField, setExperienceField] = React.useState("");
  const [experienceYears, setExperienceYears] = React.useState("");
  const [secExperienceField, setSecExperienceField] = React.useState("");
  const [secExperienceYears, setSecExperienceYears] = React.useState("");
  const [imageUrl, setImageUrl] = React.useState();
  const [cv, setCV] = React.useState();

  const [submitted, setSubmitted] = React.useState(false);

  const validateEmail = (email) => {
    const re =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  };

  const getCities = (countryID) => {
    const filter = { CountryId: countryID };
    let query = buildQuery({ filter });
    GET(URLS.city.all + query).then((res) => {
      setCities([
        ...res.data.value.map((o) => ({
          label: o.CityName,
          value: o.Id,
        })),
      ]);
    });
  };

  const populateSelectLists = () => {
    GET(URLS.idType.all).then((res) => {
      setIdTypes([
        ...res.data.value.map((o) => ({
          label: o.NumType,
          value: o.Id,
        })),
      ]);
    });
    GET(URLS.gender.all).then((res) => {
      setGenderList([
        ...res.data.value.map((o) => ({
          label: o.SexType,
          value: o.Id,
        })),
      ]);
    });
    GET(URLS.country.all).then((res) => {
      setCountries([
        ...res.data.value.map((o) => ({
          label: o.CountryName,
          value: o.Id,
          CountryCode: o.CountryCode,
        })),
      ]);
    });
    GET(URLS.nationality.all).then((res) => {
      setNationalities([
        ...res.data.value.map((o) => ({
          label: o.NationalityType,
          value: o.Id,
        })),
      ]);
    });
  };

  const submitForm = () => {
    setSubmitted(true);
    if (
      !firstName.length ||
      !middleName.length ||
      !lastName.length ||
      !familyName.length ||
      !selectedCountry ||
      !selectedCity ||
      !selectedGender ||
      !mail ||
      !validateEmail(mail) ||
      !phone ||
      !idNumber ||
      !selectedIDType ||
      !experienceField ||
      !experienceYears ||
      !secExperienceField ||
      !secExperienceYears ||
      !selectedNationality
    )
      return;
    changeTab("qualification");
  };

  useEffect(() => {
    populateSelectLists();
  }, []);

  const getMailValidationMsg = () => {
    if (submitted) {
      if (!mail.length)
        return <ErrorMsg>{t("general.form.required")}</ErrorMsg>;
      else if (!validateEmail(mail))
        return <ErrorMsg>{t("trainer.register.validate.mail")}</ErrorMsg>;
    }
  };

  const setImage = (base64) => {
    setImageUrl(base64);
    onSubmit({ Photograph_Base64: base64 ? base64.split(",")[1] : null });
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
          <Grid item xs={12}>
            <ImageUpload setImageUrl={setImage} imageUrl={imageUrl} />
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={firstName}
              onChange={(e) => {
                setFirstName(e.target.value);
                onSubmit({ LecturerFname: e.target.value });
              }}
              placeholder={t("trainee.register.firstname")}
            />
            {submitted && !firstName.length && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={middleName}
              onChange={(e) => {
                setMiddleName(e.target.value);
                onSubmit({ LecturerSname: e.target.value });
              }}
              placeholder={t("trainee.register.middlename")}
            />
            {submitted && !middleName.length && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={lastName}
              onChange={(e) => {
                setLastName(e.target.value);
                onSubmit({ LecturerTname: e.target.value });
              }}
              placeholder={t("trainee.register.lastname")}
            />
            {submitted && !lastName.length && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={familyName}
              onChange={(e) => {
                setFamilyName(e.target.value);
                onSubmit({ LecturerLname: e.target.value });
              }}
              placeholder={t("trainee.register.familyname")}
            />
            {submitted && !familyName.length && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={idNumber}
              onChange={(e) => {
                setIdNumber(e.target.value);
                onSubmit({ IDNumber: e.target.value });
              }}
              placeholder={t("trainer.register.id")}
            />
            {submitted && !phone.length && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <Select
              options={idTypes}
              value={idTypes.filter(
                (option) => option.value === selectedIDType
              )}
              // isLoading={isLoading}
              placeholder={t("trainer.register.IdType")}
              isClearable={true}
              isRtl={isArabic()}
              style={{ display: "block" }}
              onChange={(item) => {
                if (item) {
                  setSelectedIDType(item.value);
                  onSubmit({ NumberTypeId: item.value });
                } else {
                  setSelectedIDType();
                  onSubmit({ NumberTypeId: null });
                }
              }}
            />
            {submitted && !selectedIDType && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <Select
              options={nationalities}
              value={nationalities.filter(
                (option) => option.value === selectedNationality
              )}
              // isLoading={isLoading}
              placeholder={t("trainer.register.nationality")}
              isClearable={true}
              isRtl={isArabic()}
              style={{ display: "block" }}
              onChange={(item) => {
                if (item) {
                  setSelectedNationality(item.value);
                  onSubmit({ NationalityId: item.value });
                } else {
                  setSelectedNationality();
                  onSubmit({ NationalityId: null });
                }
              }}
            />
            {submitted && !selectedNationality && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <Select
              options={genderList}
              value={genderList.filter(
                (option) => option.value === selectedGender
              )}
              // isLoading={isLoading}
              placeholder={t("trainer.register.gender")}
              isClearable={true}
              isRtl={isArabic()}
              style={{ display: "block" }}
              onChange={(item) => {
                if (item) {
                  setSelectedGender(item.value);
                  onSubmit({ SexId: item.value });
                } else {
                  setSelectedGender();
                  onSubmit({ SexId: null });
                }
              }}
            />
            {submitted && !selectedGender && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <Select
              options={countries}
              value={countries.filter(
                (option) => option.value === selectedCountry
              )}
              // isLoading={isLoading}
              placeholder={t("trainee.register.country")}
              isClearable={true}
              isRtl={isArabic()}
              style={{ display: "block" }}
              onChange={(item) => {
                if (item) {
                  setPhonePrefix(item.CountryCode);
                  setSelectedCountry(item.value);
                  getCities(item.value);
                  onSubmit({ CountryId: item.value });
                } else {
                  setSelectedCountry();
                  setCities([]);
                  setSelectedCity();
                  onSubmit({ CountryId: null });
                }
              }}
            />
            {submitted && !selectedCountry && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <Select
              options={cities}
              value={cities.filter((option) => option.value === selectedCity)}
              // isLoading={isLoading}
              placeholder={t("trainee.register.city")}
              isClearable={true}
              isRtl={isArabic()}
              style={{ display: "block" }}
              onChange={(item) => {
                if (item) {
                  setSelectedCity(item.value);
                  onSubmit({ CityId: item.value });
                } else {
                  setSelectedCity();
                  onSubmit({ CityId: null });
                }
              }}
            />
            {submitted && !selectedCity && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          {phonePrefix.length ? (
            <Grid item xs={12} sm={1}>
              <label style={{ padding: "10px" }}>{phonePrefix}</label>
            </Grid>
          ) : null}
          <Grid item xs={12} sm={phonePrefix.length ? 2 : 3}>
            <input
              type="text"
              value={phone}
              onChange={(e) => {
                setPhone(e.target.value);
                onSubmit({ JawwalNumber1: e.target.value });
              }}
              placeholder={t("trainee.register.phone")}
            />
            {submitted && !phone.length && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={mail}
              onChange={(e) => {
                setMail(e.target.value);
                onSubmit({ Email1: e.target.value });
              }}
              placeholder={t("trainee.register.mail")}
            />
            {getMailValidationMsg()}
          </Grid>

          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={experienceField}
              onChange={(e) => {
                setExperienceField(e.target.value);
                onSubmit({ Fieldofexpertise: e.target.value });
              }}
              placeholder={t("trainer.register.mainExperienceField")}
            />
            {submitted && !experienceField.length && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="number"
              value={experienceYears}
              onChange={(e) => {
                setExperienceYears(e.target.value);
                onSubmit({ TheNumberOfYears: e.target.value });
              }}
              placeholder={t("trainer.register.mainExperienceYears")}
            />
            {submitted && !experienceYears.length && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="text"
              value={secExperienceField}
              onChange={(e) => {
                setSecExperienceField(e.target.value);
                onSubmit({ SubFieldofexpertise: e.target.value });
              }}
              placeholder={t("trainer.register.secExperienceField")}
            />
            {submitted && !secExperienceField.length && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={3}>
            <input
              type="number"
              value={secExperienceYears}
              onChange={(e) => {
                setSecExperienceYears(e.target.value);
                onSubmit({ SubTheNumberOfYears: e.target.value });
              }}
              placeholder={t("trainer.register.secExperienceYears")}
            />
            {submitted && !secExperienceYears.length && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12} sm={2} style={{ textAlign: "start" }}>
            <label>{t("trainer.register.cv")}</label>
          </Grid>
          <Grid item xs={12} sm={4}>
            <input
              type="file"
              name="file"
              onChange={(e) => {
                setCV(e.target.files[0]);
                onSubmit({ CVFile: e.target.files[0] });
              }}
              accept=".pdf,.doc,.docx"
            />
            {submitted && !cv && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={12}>
            <input type="submit" value={t("trainer.register.next")} />
          </Grid>
        </Grid>
      </form>
    </div>
  );
}
