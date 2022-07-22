import React, { useEffect } from "react";
import { Footer, HomeHeader } from "../../../components/Layout";
import Grid from "@material-ui/core/Grid";
import Typography from "@material-ui/core/Typography";
import Button from "@material-ui/core/Button";
import { useTranslation } from "react-i18next";
import Select from "react-select";
import ImageUpload from "../ImageUpload";
import "react-draft-wysiwyg/dist/react-draft-wysiwyg.css";
import { makeStyles } from "@material-ui/styles";
import { createTheme } from "@material-ui/core/styles";
import { GET, POST, URLS } from "../../../utils/http";
import { useHistory } from "react-router-dom";
import buildQuery from "odata-query";
import { useForm } from "react-hook-form";
import ErrorMsg from "../../../components/common/ErrorMsg";
import MaterialTableDemo from "../../Course/MaterialTable";

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
export default function RegisterTraineeForm(props) {
  const { t } = useTranslation();
  const classes = useStyles();
  const history = useHistory();

  const { handleSubmit } = useForm();

  const [submitted, setSubmitted] = React.useState(false);
  const [firstName, setFirstName] = React.useState("");
  const [middleName, setMiddleName] = React.useState("");
  const [lastName, setLastName] = React.useState("");
  const [familyName, setFamilyName] = React.useState("");
  const [imageUrl, setImageUrl] = React.useState();
  const [phonePrefix, setPhonePrefix] = React.useState("");
  const [phone, setPhone] = React.useState("");
  const [mail, setMail] = React.useState("");
  const [genderList, setGenderList] = React.useState([]);
  const [selectedGender, setSelectedGender] = React.useState();
  const [cities, setCities] = React.useState([]);
  const [selectedCity, setSelectedCity] = React.useState();
  const [countries, setCountries] = React.useState([]);
  const [selectedCountry, setSelectedCountry] = React.useState();
  const [mainInterests, setMainInterests] = React.useState([]);
  const [selectedMainInterest, setSelectedMainInterest] = React.useState();
  const [secondaryInterests, setSecondaryInterests] = React.useState([]);
  const [selectedSecondaryInterest, setSelectedSecondaryInterest] =
    React.useState();
  const [interestList, setInterestList] = React.useState([]);

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
    GET(URLS.majorInterest.all).then((res) => {
      let mainInterestList = [
        ...res.data.value.map((o) => ({
          label: o.MajorInterestTxt,
          value: o.Id,
        })),
      ];
      setMainInterests(mainInterestList);
      GET(URLS.subInterest.all).then((res) => {
        let subInterestList = [
          ...res.data.value.map((o) => ({
            label: o.SubInterestTxt,
            value: o.Id,
          })),
        ];
        setSecondaryInterests(subInterestList);
      });
    });
  };

  const registerTrainee = (formData) => {
    setSubmitted(true);
    if (
      !interestList.length ||
      !firstName.length ||
      !middleName.length ||
      !lastName.length ||
      !familyName.length ||
      !selectedGender ||
      !selectedCountry ||
      !selectedCity ||
      !phone.length ||
      !mail.length
    )
      return;
    const data = {
      TrainerFname: firstName,
      TrainerSname: middleName,
      TrainerTname: lastName,
      TrainerLname: familyName,
      InterestId: interestList.reduce((acc, item) => {
        acc[item.main.id.toString()] = item.secondary.id;
        return acc;
      }, {}),
      Photograph_Base64: imageUrl ? imageUrl.split(",")[1] : null,
      CountryId: selectedCountry,
      CityId: selectedCity,
      SexId: selectedGender,
      Email1: mail,
      JawwalNumber1: phone,
    };
    POST(URLS.trainee.add, data).then((res) => {
      if (res.status == 200) {
        history.goBack();
      }
    });
  };

  useEffect(() => {
    populateSelectLists();
  }, []);

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
          <Typography variant="h6">{t("trainee.register.title")}</Typography>
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
          <form
            onSubmit={handleSubmit(registerTrainee)}
            className={classes.form}
          >
            <Grid container spacing={3}>
              <Grid item xs={12}>
                <ImageUpload setImageUrl={setImageUrl} imageUrl={imageUrl} />
              </Grid>
              <Grid item xs={12} sm={3}>
                <input
                  type="text"
                  value={firstName}
                  onChange={(e) => setFirstName(e.target.value)}
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
                  onChange={(e) => setMiddleName(e.target.value)}
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
                  onChange={(e) => setLastName(e.target.value)}
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
                  onChange={(e) => setFamilyName(e.target.value)}
                  placeholder={t("trainee.register.familyname")}
                />
                {submitted && !familyName.length && (
                  <ErrorMsg>{t("general.form.required")}</ErrorMsg>
                )}
              </Grid>
              <Grid item xs={12} sm={4}>
                <Select
                  options={genderList}
                  value={genderList.filter(
                    (option) => option.value === selectedGender
                  )}
                  // isLoading={isLoading}
                  placeholder={t("trainee.register.gender")}
                  isClearable={true}
                  isRtl={isArabic()}
                  style={{ display: "block" }}
                  onChange={(item) => {
                    if (item) setSelectedGender(item.value);
                    else setSelectedGender();
                  }}
                />
                {submitted && !selectedGender && (
                  <ErrorMsg>{t("general.form.required")}</ErrorMsg>
                )}
              </Grid>
              <Grid item xs={12} sm={4}>
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
                    } else {
                      setSelectedCountry();
                      setCities([]);
                      setSelectedCity();
                    }
                  }}
                />
                {submitted && !selectedCountry && (
                  <ErrorMsg>{t("general.form.required")}</ErrorMsg>
                )}
              </Grid>
              <Grid item xs={12} sm={4}>
                <Select
                  options={cities}
                  value={cities.filter(
                    (option) => option.value === selectedCity
                  )}
                  // isLoading={isLoading}
                  placeholder={t("trainee.register.city")}
                  isClearable={true}
                  isRtl={isArabic()}
                  style={{ display: "block" }}
                  onChange={(item) => {
                    if (item) setSelectedCity(item.value);
                    else setSelectedCity();
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
              <Grid item xs={12} sm={phonePrefix.length ? 5 : 6}>
                <input
                  type="text"
                  value={phone}
                  onChange={(e) => setPhone(e.target.value)}
                  placeholder={t("trainee.register.phone")}
                />
                {submitted && !phone.length && (
                  <ErrorMsg>{t("general.form.required")}</ErrorMsg>
                )}
              </Grid>
              <Grid item xs={12} sm={6}>
                <input
                  type="text"
                  value={mail}
                  onChange={(e) => setMail(e.target.value)}
                  placeholder={t("trainee.register.mail")}
                />
                {submitted && !mail.length && (
                  <ErrorMsg>{t("general.form.required")}</ErrorMsg>
                )}
              </Grid>
              <Grid item xs={12} sm={5}>
                <Select
                  options={mainInterests}
                  value={
                    selectedMainInterest
                      ? mainInterests.filter(
                          (option) => option.value === selectedMainInterest.id
                        )
                      : null
                  }
                  // isLoading={isLoading}
                  placeholder={t("course.mainInterest")}
                  isClearable={true}
                  isRtl={isArabic()}
                  style={{ display: "block" }}
                  onChange={(event) => {
                    if (event)
                      setSelectedMainInterest({
                        id: event.value,
                        value: event.label,
                      });
                    else setSelectedMainInterest();
                  }}
                />
              </Grid>
              <Grid item xs={12} sm={5}>
                <Select
                  options={secondaryInterests}
                  value={
                    selectedSecondaryInterest
                      ? secondaryInterests.filter(
                          (option) =>
                            option.value === selectedSecondaryInterest.id
                        )
                      : null
                  }
                  // isLoading={isLoading}
                  placeholder={t("course.secondaryInterest")}
                  isClearable={true}
                  isRtl={isArabic()}
                  style={{ display: "block" }}
                  onChange={(event) => {
                    if (event)
                      setSelectedSecondaryInterest({
                        id: event.value,
                        value: event.label,
                      });
                    else setSelectedSecondaryInterest();
                  }}
                />
              </Grid>
              <Grid item xs={12} sm={2} style={{ textAlign: "end" }}>
                <Button
                  variant="contained"
                  onClick={() => {
                    setInterestList((oldInterests) => [
                      ...oldInterests,
                      {
                        main: selectedMainInterest,
                        secondary: selectedSecondaryInterest,
                      },
                    ]);
                    setSelectedMainInterest();
                    setSelectedSecondaryInterest();
                  }}
                  disabled={
                    !selectedMainInterest ||
                    !selectedSecondaryInterest ||
                    interestList.find(
                      (i) =>
                        i.main.id === selectedMainInterest.id &&
                        i.secondary.id === selectedSecondaryInterest.id
                    )
                  }
                  className={classes.button}
                >
                  {t("general.buttons.add")}
                </Button>
              </Grid>
              <Grid item xs={12}>
                {interestList.length ? (
                  <MaterialTableDemo
                    rows={interestList}
                    removeRow={(itemList) => {
                      itemList.forEach((element) => {
                        setInterestList((oldInterests) =>
                          oldInterests.filter(
                            (i) => i.main.id + "_" + i.secondary.id !== element
                          )
                        );
                      });
                    }}
                  />
                ) : (
                  submitted && (
                    <div style={{ marginInlineStart: "15px" }}>
                      <ErrorMsg>{t("general.form.required")}</ErrorMsg>
                    </div>
                  )
                )}
              </Grid>

              <Grid item xs={12}>
                <input type="submit" value={t("general.buttons.save")} />
              </Grid>
            </Grid>
          </form>
        </div>
      </div>
      <Footer />
    </>
  );
}
