import { STATE_LOGIN, STATE_SIGNUP } from "./components/AuthForm";
import GAListener from "./components/GAListener";
import { EmptyLayout, LayoutRoute, MainLayout } from "./components/Layout";
import PageSpinner from "./components/PageSpinner";
import AuthPage from "./pages/Auth/Index";
import React from "react";
import componentQueries from "react-component-queries";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import "./styles/reduction.scss";

const ButtonGroupPage = React.lazy(() => import("./pages/ButtonGroupPage"));
const ButtonPage = React.lazy(() => import("./pages/ButtonPage"));
const TrainerPage = React.lazy(() => import("./pages/Trainer/Index"));
const TrainerInvitePage = React.lazy(() => import("./pages/Trainer/Invite"));
const TraineePage = React.lazy(() => import("./pages/Trainee/Index"));
const TraineeInvitePage = React.lazy(() => import("./pages/Trainer/Invite"));
const CoursePage = React.lazy(() => import("./pages/Course/Index"));
const AddCoursePage = React.lazy(() => import("./pages/Course/Add"));
const CourseSuggestPage = React.lazy(() =>
  import("./pages/Course/Suggestions/Index")
);
const HomePage = React.lazy(() => import("./pages/Home/Index"));
const MainPage = React.lazy(() => import("./pages/Main/Index"));
const RegisterTrainerPage = React.lazy(() =>
  import("./pages/Main/TrainerRegister/TrainerRegister")
);
const RegisterTraineePage = React.lazy(() =>
  import("./pages/Main/TraineeRegister/TraineeRegister")
);

const getBasename = () => {
  return `/${process.env.PUBLIC_URL.split("/").pop()}`;
};

class App extends React.Component {
  render() {
    return (
      <BrowserRouter basename={getBasename()}>
        <GAListener>
          <Switch>
            <LayoutRoute
              exact
              path="/"
              layout={EmptyLayout}
              component={(props) => (
                <AuthPage {...props} authState={STATE_LOGIN} />
              )}
            />
            <LayoutRoute
              exact
              path="/signup"
              layout={EmptyLayout}
              component={(props) => (
                <AuthPage {...props} authState={STATE_SIGNUP} />
              )}
            />
            <LayoutRoute
              exact
              path="/main"
              layout={EmptyLayout}
              component={(props) => (
                <MainPage {...props} authState={STATE_SIGNUP} />
              )}
            />
            <LayoutRoute
              exact
              path="/trainerRegister"
              layout={EmptyLayout}
              component={(props) => (
                <RegisterTrainerPage {...props} authState={STATE_SIGNUP} />
              )}
            />
            <LayoutRoute
              exact
              path="/traineeRegister"
              layout={EmptyLayout}
              component={(props) => (
                <RegisterTraineePage {...props} authState={STATE_SIGNUP} />
              )}
            />

            <MainLayout breakpoint={this.props.breakpoint}>
              <React.Suspense fallback={<PageSpinner />}>
                <Route exact path="/home" component={HomePage} />
                {/* <Route exact path="/main" component={MainPage} /> */}
                <Route exact path="/buttons" component={ButtonPage} />
                <Route exact path="/trainer" component={TrainerPage} />
                <Route
                  exact
                  path="/trainerInvite"
                  component={TrainerInvitePage}
                />
                <Route exact path="/trainee" component={TraineePage} />
                <Route
                  exact
                  path="/traineeInvite"
                  component={TraineeInvitePage}
                />
                <Route exact path="/course" component={CoursePage} />
                <Route
                  exact
                  path="/course/add/:id?"
                  component={AddCoursePage}
                />
                <Route
                  exact
                  path="/course/suggest"
                  component={CourseSuggestPage}
                />

                <Route
                  exact
                  path="/button-groups"
                  component={ButtonGroupPage}
                />
              </React.Suspense>
            </MainLayout>
            <Redirect to="/" />
          </Switch>
        </GAListener>
      </BrowserRouter>
    );
  }
}

const query = ({ width }) => {
  if (width < 575) {
    return { breakpoint: "xs" };
  }

  if (576 < width && width < 767) {
    return { breakpoint: "sm" };
  }

  if (768 < width && width < 991) {
    return { breakpoint: "md" };
  }

  if (992 < width && width < 1199) {
    return { breakpoint: "lg" };
  }

  if (width > 1200) {
    return { breakpoint: "xl" };
  }

  return { breakpoint: "xs" };
};

export default componentQueries(query)(App);
