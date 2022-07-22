import logo200Image from "../assets/img/akfeny.png";
import PropTypes from "prop-types";
import React, { useState } from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { auth } from "../store/actions/creators";
import { connect, useDispatch } from "react-redux";
import { useHistory } from "react-router-dom";
import { authFail, authSuccess } from "../store/actions/creators/auth";

export default function AuthForm(props) {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const dispatch = useDispatch();

  const history = useHistory();

  // const isLogin = (props) => {
  //   return props.authState === STATE_LOGIN;
  // };

  // const isSignup = () => {
  //   return props.authState === STATE_SIGNUP;
  // };

  // const changeAuthState = (authState) => (event) => {
  //   event.preventDefault();

  //   props.onChangeAuthState(authState);
  // };

  const handleSubmit = (event) => {
    event.preventDefault();
    dispatch(auth(username, password))
      .then((response) => {
        debugger;
        dispatch(authSuccess(response.data, username));
        history.push("/home");
      })
      .catch((err) => {
        console.log(err);
        debugger;
        dispatch(authFail(err));
      });
  };

  const renderButtonText = () => {
    const { buttonText } = props;

    // if (!buttonText && isLogin()) {
    return "Login";
    // }

    // if (!buttonText && isSignup()) {
    //   return "Signup";
    // }

    return buttonText;
  };

  const {
    showLogo,
    usernameLabel,
    usernameInputProps,
    passwordLabel,
    passwordInputProps,
    confirmPasswordLabel,
    confirmPasswordInputProps,
    children,
    onLogoClick,
  } = props;

  return (
    <Form onSubmit={handleSubmit}>
      {showLogo && (
        <div className="text-center pb-4">
          <div
            style={{
              background: "white",
              width: '70px',
              borderRadius: 15,
              margin: "0 auto",
              position: "relative",
            }}
          >
            <img
              src={logo200Image}
              className="rounded"
              style={{ width: 70, height: 70, cursor: "pointer" }}
              alt="logo"
              onClick={onLogoClick}
            />
          </div>
        </div>
      )}
      <FormGroup>
        <Label
          for={usernameLabel}
          style={{ color: "#fff", fontWeight: "bold" }}
        >
          {usernameLabel}
        </Label>
        <Input
          {...usernameInputProps}
          style={{ background: "#fff", color: "black" }}
          value={username}
          onChange={(e) => setUsername(e.target.value)}
        />
      </FormGroup>
      <FormGroup>
        <Label
          for={passwordLabel}
          style={{ color: "#fff", fontWeight: "bold" }}
        >
          {passwordLabel}
        </Label>
        <Input
          {...passwordInputProps}
          style={{ background: "#fff", color: "black" }}
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </FormGroup>
      {/* {isSignup() && (
        <FormGroup>
          <Label for={confirmPasswordLabel}>{confirmPasswordLabel}</Label>
          <Input {...confirmPasswordInputProps} />
        </FormGroup>
      )} */}
      <FormGroup check>
        <Label check style={{ color: "#fff" }}>
          <Input type="checkbox" />
          {/* {isSignup() ? "Agree the terms and policy" : "Remember me"} */}
          {"Remember me"}
        </Label>
      </FormGroup>
      <hr />
      <Button
        size="lg"
        className="bg-gradient-theme-right border-0"
        block
        // onClick={handleSubmit}
        onClick={() => history.push('/course') }
      >
        {renderButtonText()}
      </Button>

      {/* <div className="text-center pt-1">
          <h6>or</h6>
          <h6>
            {this.isSignup ? (
              <a href="#login" onClick={this.changeAuthState(STATE_LOGIN)}>
                Login
              </a>
            ) : (
              <a href="#signup" onClick={this.changeAuthState(STATE_SIGNUP)}>
                Signup
              </a>
            )}
          </h6>
        </div> */}

      {children}
    </Form>
  );
}

export const STATE_LOGIN = "LOGIN";
export const STATE_SIGNUP = "SIGNUP";

AuthForm.propTypes = {
  authState: PropTypes.oneOf([STATE_LOGIN, STATE_SIGNUP]).isRequired,
  showLogo: PropTypes.bool,
  usernameLabel: PropTypes.string,
  usernameInputProps: PropTypes.object,
  passwordLabel: PropTypes.string,
  passwordInputProps: PropTypes.object,
  confirmPasswordLabel: PropTypes.string,
  confirmPasswordInputProps: PropTypes.object,
  onLogoClick: PropTypes.func,
};

AuthForm.defaultProps = {
  authState: "LOGIN",
  showLogo: true,
  usernameLabel: "Email",
  usernameInputProps: {
    type: "email",
    placeholder: "your@email.com",
  },
  passwordLabel: "Password",
  passwordInputProps: {
    type: "password",
    placeholder: "your password",
  },
  confirmPasswordLabel: "Confirm Password",
  confirmPasswordInputProps: {
    type: "password",
    placeholder: "confirm your password",
  },
  onLogoClick: () => {},
};
