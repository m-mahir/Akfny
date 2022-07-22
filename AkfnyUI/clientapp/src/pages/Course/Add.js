import React, { useEffect } from "react";
import Grid from "@material-ui/core/Grid";
import Typography from "@material-ui/core/Typography";
import TextField from "@material-ui/core/TextField";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Checkbox from "@material-ui/core/Checkbox";
import Button from "@material-ui/core/Button";
import { useTranslation } from "react-i18next";
import Select from "react-select";
import ImageUpload from "./ImageUpload";
import { Editor } from "react-draft-wysiwyg";
import { ContentState, convertFromHTML, EditorState } from "draft-js";
import "react-draft-wysiwyg/dist/react-draft-wysiwyg.css";
import { makeStyles } from "@material-ui/styles";
import { createTheme } from "@material-ui/core/styles";
import ModalTable from "./ModalTable";
import MaterialTableDemo from "./MaterialTable";
import { GET, POST, URLS } from "../../utils/http";
import { useHistory } from "react-router-dom";
import buildQuery from "odata-query";
import { useForm } from "react-hook-form";
import DraftPasteProcessor from "draft-js/lib/DraftPasteProcessor";
import htmlToDraft from "html-to-draftjs";
import ErrorMsg from "../../components/common/ErrorMsg";

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

      // },
      // button: {
      //   minWidth: 100,
      //   height: 40,
      //   borderRadius: 35,
      //   backgroundColor: "#98276e",
      //   color: "white",
      //   fontSize: 18,
      //   "&:disabled": {
      //     backgroundColor: "lightgrey",
      //     color: "white",
      // },
    },
  }),
  { defaultTheme }
);

function FormItem(props) {
  const { field, value, label, type, onChange } = props;
  return (
    <Grid item xs={12} sm={6}>
      <TextField
        id={field}
        name={field}
        type={type}
        value={value}
        label={label}
        onChange={onChange}
        fullWidth
      />
    </Grid>
  );
}

const ColoredLine = () => (
  <Grid item xs={12}>
    <hr
      style={{
        color: "purple",
        backgroundColor: "purple",
        height: "0.001em",
      }}
    />
  </Grid>
);

export default function AddCourseForm(props) {
  const { t } = useTranslation();
  const classes = useStyles();
  const history = useHistory();

  const { handleSubmit } = useForm();

  const isEditMode = !!props.match.params.id;

  const [submitted, setSubmitted] = React.useState(false);
  const [title, setTitle] = React.useState("");
  const [days, setDays] = React.useState("");
  const [hours, setHours] = React.useState("");
  const [imageUrl, setImageUrl] = React.useState();
  const [generalGoalEditorState, setGeneralGoalEditorState] = React.useState(
    () => EditorState.createEmpty()
  );
  const [detailedGoalsEditorState, setDetailedGoalsEditorState] =
    React.useState(() => EditorState.createEmpty());
  const [themeEditorState, setThemeEditorState] = React.useState(() =>
    EditorState.createEmpty()
  );

  const [sectors, setSectors] = React.useState([]);
  const [selectedSector, setSelectedSector] = React.useState();
  const [fields, setFields] = React.useState([]);
  const [selectedField, setSelectedField] = React.useState();
  const [mainInterests, setMainInterests] = React.useState([]);
  const [selectedMainInterest, setSelectedMainInterest] = React.useState();
  const [secondaryInterests, setSecondaryInterests] = React.useState([]);
  const [selectedSecondaryInterest, setSelectedSecondaryInterest] =
    React.useState();
  const [interestList, setInterestList] = React.useState([]);

  const populateSelectLists = () => {
    GET(URLS.field.all).then((res) => {
      setFields([
        ...res.data.value.map((o) => ({ label: o.FieldTxt, value: o.Id })),
      ]);
    });
    GET(URLS.sector.all).then((res) => {
      setSectors([
        ...res.data.value.map((o) => ({ label: o.SectorTxt, value: o.Id })),
      ]);
    });
  };

  const addCourse = (formData) => {
    setSubmitted(true);
    if (
      !interestList.length ||
      !title.length ||
      !hours ||
      !days ||
      !selectedField ||
      !selectedSector ||
      !generalGoalEditorState.getCurrentContent().getPlainText("\u0001") ||
      !detailedGoalsEditorState.getCurrentContent().getPlainText("\u0001") ||
      !themeEditorState.getCurrentContent().getPlainText("\u0001")
    )
      return;
    const data = {
      CourseTxt: title,
      FieldId: selectedField,
      SectorId: selectedSector,
      Days: parseInt(days),
      Hour: parseInt(hours),
      General_Description: generalGoalEditorState
        .getCurrentContent()
        .getPlainText("\u0001"),
      Detailed_Goal: detailedGoalsEditorState
        .getCurrentContent()
        .getPlainText("\u0001"),
      The_main_axis: themeEditorState
        .getCurrentContent()
        .getPlainText("\u0001"),
      InterestId: interestList.reduce((acc, item) => {
        acc[item.main.id.toString()] = item.secondary.id;
        return acc;
      }, {}),
      Targeted: null,
      Img_Base64: imageUrl ? imageUrl.split(",")[1] : null,
      InsertCode: null,
    };
    if (isEditMode) {
      data.Id = parseInt(props.match.params.id);
      POST(URLS.course.edit, data).then((res) => {
        if (res.status == 200) {
          history.goBack();
        }
      });
    } else
      POST(URLS.course.add, data).then((res) => {
        if (res.status == 200) {
          history.goBack();
        }
      });
  };

  const htmlDecode = (input) => {
    var e = document.createElement("div");
    e.innerHTML = input;
    return e.childNodes.length === 0 ? "" : e.childNodes[0].nodeValue;
  };

  useEffect(() => {
    populateSelectLists();
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
        if (isEditMode) {
          const expand = ["Field", "Sector", "CourseTargetedFinals"];
          let query = buildQuery({ expand });
          query += "&courseId=" + props.match.params.id;

          GET(URLS.course.all + query).then((res) => {
            const course = res.data.value[0];
            setTitle(course.CourseTxt);
            setDays(course.Days);
            setHours(course.Hour);
            setImageUrl("data:image/jpeg;base64, " + course.Course_Img);
            // const blocksFromHtml = htmlToDraft(course.General_Description);
            // const { contentBlocks, entityMap } = blocksFromHtml;
            // const contentState = ContentState.createFromBlockArray(contentBlocks, entityMap);
            // const editorState = EditorState.createWithContent(contentState);

            // const processedHTML = DraftPasteProcessor.processHTML(
            //   course.General_Description
            // );
            // const blocksFromHtml = htmlToDraft(course.General_Description);
            // const contentState =
            //   ContentState.createFromBlockArray(blocksFromHtml);
            const GD_blocksFromHTML = convertFromHTML(
              htmlDecode(course.General_Description)
            );
            setGeneralGoalEditorState(
              EditorState.createWithContent(
                ContentState.createFromBlockArray(
                  GD_blocksFromHTML.contentBlocks,
                  GD_blocksFromHTML.entityMap
                )
              )
            );
            const DG_blocksFromHTML = convertFromHTML(
              htmlDecode(course.Detailed_Goal)
            );
            setDetailedGoalsEditorState(
              EditorState.createWithContent(
                ContentState.createFromBlockArray(
                  DG_blocksFromHTML.contentBlocks,
                  DG_blocksFromHTML.entityMap
                )
              )
            );

            const MA_blocksFromHTML = convertFromHTML(
              htmlDecode(course.The_main_axis)
            );
            setThemeEditorState(
              EditorState.createWithContent(
                ContentState.createFromBlockArray(
                  MA_blocksFromHTML.contentBlocks,
                  MA_blocksFromHTML.entityMap
                )
              )
            );
            setSelectedSector(course.SectorId);
            setSelectedField(course.FieldId);
            let interests = course.CourseTargetedFinals.map((t) => {
              return {
                main: {
                  id: t.MajorInterestId,
                  value: mainInterestList.find(
                    (m) => m.value == t.MajorInterestId
                  ).label,
                },
                secondary: {
                  id: t.SubInterestId,
                  value: subInterestList.find((s) => s.value == t.SubInterestId)
                    .label,
                },
              };
            });
            setInterestList(interests);
          });
        }
      });
    });
  }, [isEditMode]);

  return (
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
        <Typography variant="h6">{t("course.add")}</Typography>
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
        <form onSubmit={handleSubmit(addCourse)} className={classes.form}>
          <Grid container spacing={3}>
            <Grid item xs={12}>
              <input
                // {...register("title", { required: true, maxLength: 80 })}
                type="text"
                value={title}
                onChange={(e) => setTitle(e.target.value)}
                placeholder={t("course.name")}
              />
              {submitted && !title.length && (
                <ErrorMsg>{t("general.form.required")}</ErrorMsg>
              )}
            </Grid>
            <Grid item xs={12} sm={6}>
              <Select
                options={sectors}
                value={sectors.filter(
                  (option) => option.value === selectedSector
                )}
                // isLoading={isLoading}
                placeholder={t("course.sector")}
                isClearable={true}
                isRtl={isArabic()}
                style={{ display: "block" }}
                onChange={(item) => {
                  if (item) setSelectedSector(item.value);
                  else setSelectedSector();
                }}
              />
              {submitted && !selectedSector && (
                <ErrorMsg>{t("general.form.required")}</ErrorMsg>
              )}
            </Grid>
            <Grid item xs={12} sm={6}>
              <Select
                options={fields}
                value={fields.filter(
                  (option) => option.value === selectedField
                )}
                // isLoading={isLoading}
                placeholder={t("course.field")}
                isClearable={true}
                isRtl={isArabic()}
                style={{ display: "block" }}
                onChange={(item) => {
                  if (item) setSelectedField(item.value);
                  else setSelectedField();
                }}
              />
              {submitted && !selectedField && (
                <ErrorMsg>{t("general.form.required")}</ErrorMsg>
              )}
            </Grid>
            <Grid item xs={2} lg={1} style={{ textAlign: "start" }}>
              <label>{t("course.duration")}</label>
            </Grid>
            <Grid item xs={4} lg={5}>
              <input
                // {...register("days", { required: true, maxLength: 80 })}
                type="number"
                value={days}
                onChange={(e) => setDays(e.target.value)}
                placeholder={t("course.days")}
              />
              {submitted && !days && (
                <ErrorMsg>{t("general.form.required")}</ErrorMsg>
              )}
              <input
                // {...register("hours", { required: true, maxLength: 80 })}
                type="number"
                value={hours}
                onChange={(e) => setHours(e.target.value)}
                placeholder={t("course.hours")}
              />
              {submitted && !hours && (
                <ErrorMsg>{t("general.form.required")}</ErrorMsg>
              )}
            </Grid>
            <Grid item xs={2} md={1} style={{ textAlign: "start" }}>
              <label>{t("course.image")}</label>
            </Grid>
            <Grid item xs={4} md={5}>
              <ImageUpload setImageUrl={setImageUrl} imageUrl={imageUrl} />
            </Grid>
            <Grid item xs={12} style={{ textAlign: "start" }}>
              <label>{t("course.generalObjective")}</label>
              <div
                style={{
                  direction: "ltr",
                }}
              >
                <Editor
                  editorState={generalGoalEditorState}
                  onEditorStateChange={(s) => setGeneralGoalEditorState(s)}
                  toolbar={{
                    inline: { inDropdown: true },
                    list: { inDropdown: true },
                    textAlign: { inDropdown: true },
                    link: { inDropdown: true },
                    history: { inDropdown: true },
                    // image: {
                    //   uploadCallback: uploadImageCallBack,
                    //   alt: { present: true, mandatory: true },
                    // },
                  }}
                />
              </div>
              {submitted &&
                !generalGoalEditorState
                  .getCurrentContent()
                  .getPlainText("\u0001") && (
                  <ErrorMsg>{t("general.form.required")}</ErrorMsg>
                )}
            </Grid>

            <Grid item xs={12} style={{ textAlign: "start" }}>
              <label>{t("course.detailedObjectives")}</label>
              <div
                style={{
                  direction: "ltr",
                }}
              >
                <Editor
                  editorState={detailedGoalsEditorState}
                  onEditorStateChange={(s) => setDetailedGoalsEditorState(s)}
                  toolbar={{
                    inline: { inDropdown: true },
                    list: { inDropdown: true },
                    textAlign: { inDropdown: true },
                    link: { inDropdown: true },
                    history: { inDropdown: true },
                    // image: {
                    //   uploadCallback: uploadImageCallBack,
                    //   alt: { present: true, mandatory: true },
                    // },
                  }}
                />
              </div>
              {submitted &&
                !detailedGoalsEditorState
                  .getCurrentContent()
                  .getPlainText("\u0001") && (
                  <ErrorMsg>{t("general.form.required")}</ErrorMsg>
                )}
            </Grid>

            <Grid item xs={12} style={{ textAlign: "start" }}>
              <label>{t("course.themes")}</label>
              <div
                style={{
                  direction: "ltr",
                }}
              >
                <Editor
                  editorState={themeEditorState}
                  onEditorStateChange={(s) => setThemeEditorState(s)}
                  toolbar={{
                    inline: { inDropdown: true },
                    list: { inDropdown: true },
                    textAlign: { inDropdown: true },
                    link: { inDropdown: true },
                    history: { inDropdown: true },
                    // image: {
                    //   uploadCallback: uploadImageCallBack,
                    //   alt: { present: true, mandatory: true },
                    // },
                  }}
                />
              </div>
              {submitted &&
                !themeEditorState
                  .getCurrentContent()
                  .getPlainText("\u0001") && (
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
            <Grid item xs={12} sm={6}>
              <input type="submit" value={t("general.buttons.save")} />
            </Grid>
            <Grid item xs={12} sm={6}>
              <input
                type="button"
                value={t("general.buttons.cancel")}
                onClick={history.goBack}
              />
            </Grid>
          </Grid>
        </form>
      </div>
    </div>
  );
}
