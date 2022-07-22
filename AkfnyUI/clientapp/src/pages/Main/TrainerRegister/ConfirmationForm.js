import React from "react";
import { makeStyles } from "@material-ui/styles";
import { createTheme } from "@material-ui/core/styles";
import { useTranslation } from "react-i18next";
import Grid from "@material-ui/core/Grid";
import { useForm } from "react-hook-form";
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

export default function ConfirmationForm(props) {
  const { changeTab, onSubmit } = props;
  const { t } = useTranslation();
  const classes = useStyles();

  const { handleSubmit } = useForm();

  const [checked, setChecked] = React.useState(false);

  const [submitted, setSubmitted] = React.useState(false);

  const submitForm = () => {
    setSubmitted(true);
    if (!checked) return;
    onSubmit();
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
          <Grid
            item
            xs={12}
            style={{
              height: "35vh",
              overflowY: "auto",
              borderRadius: "5px",
              border: "1px solid lightgrey",
              padding: "5px",
              textAlign: "start",
            }}
          >
            <label className="col-xs-12 control-label">الشروط والأحكام</label>
            <div className="col-xs-12">
              <div>
                <p>
                  <strong>الالتزام</strong>
                </p>

                <p>
                  اتعهد واقر بمحض ارادتي القانونية بان سيرتي الذاتية وجميع
                  البيانات والمعلومات - سواءاً التي ادخلتها او ارفقتها – هي
                  معلومات وبيانات صحيحة وتامة. كما وانها لا تتعارض ولا تخالف
                  حقوق الملكية الفكرية. ويحق لمعهد صقور التنمية للتدريب او
                  شركاءه فقط بإعادة استخدام تلك البيانات والمعلومات للأغراض
                  المهنية المتعارف عليها لأغراض التدريب والدراسات والخدمات
                  الاستشارية.&nbsp;
                </p>

                <p>
                  اننا نحن معهد صقور التنمية للتدريب وشركاءه فقط؛ نؤكد لكم أننا
                  ملتزمون بالسرية التامة لما تدلون به من بيانات ومعلومات او
                  مرفقات والمحفوظة بشكل آمن على قاعدة البيانات الخاصة بنا، فانها
                  سوف تستخدم للأغراض المهنية المتعارف عليها لأغراض التدريب فقط.
                  كما انه لن يتم الإفصاح عنها لغير شركائنا الموثوق بهم، وذلك
                  بغرض تفعيل وتطوير برنامجنا التدريبية.
                </p>

                <p>
                  <strong>موافقتك</strong>
                </p>

                <p>باستخدامك لموقعنا، فأنت بالفعل موافق على سياسة الخصوصية.</p>
              </div>
            </div>
            {submitted && !checked && (
              <ErrorMsg>{t("general.form.required")}</ErrorMsg>
            )}
          </Grid>
          <Grid item xs={1} style={{ textAlign: "end" }}>
            <input
              onChange={() => setChecked(!checked)}
              id={"123"}
              type="checkbox"
              checked={checked}
            />
          </Grid>
          <Grid item xs={11} style={{ textAlign: "start" }}>
            <label htmlFor={"123"}>{t("trainer.register.agree")}</label>
          </Grid>
          <Grid item xs={6}>
            <input
              type="button"
              value={t("trainer.register.previous")}
              onClick={() => changeTab("courses")}
            />
          </Grid>
          <Grid item xs={6}>
            <input
              type="submit"
              disabled={!checked}
              value={t("general.buttons.save")}
            />
          </Grid>
        </Grid>
      </form>
    </div>
  );
}
