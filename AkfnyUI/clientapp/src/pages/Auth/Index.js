import AuthForm, { STATE_LOGIN } from "../../components/AuthForm";
import React from "react";
import { Card, Col, Row } from "reactstrap";
import { Content, Footer, HomeHeader } from "../../components/Layout";
import background from "../../assets/img/background.png";

class AuthPage extends React.Component {
  handleAuthState = (authState) => {
    if (authState === STATE_LOGIN) {
      this.props.history.push("/");
    } else {
      this.props.history.push("/signup");
    }
  };

  handleLogoClick = () => {
    this.props.history.push("/");
  };

  render() {
    return (
      <>
        <Content fluid onClick={this.handleContentClick}>
          {/* <HomeHeader /> */}
        </Content>
        <div
          style={{
            backgroundImage: `url(${background})`,
            backgroundPosition: "center",
            backgroundSize: "cover",
            backgroundRepeat: "no-repeat",
            width: "100vw",
            height: "95vh",
            marginTop: "-0.5rem",
          }}
        >
          <Row
            style={{
              height: "95vh",
              justifyContent: "center",
              alignItems: "center",
            }}
          >
            <Col md={6} lg={4}>
              <Card body style={{
                borderRadius: '25px',
                background: 'rgb(0 0 0 / 80%)'
              }}>
                <AuthForm
                  authState={this.props.authState}
                  onChangeAuthState={this.handleAuthState}
                  onLogoClick={this.handleLogoClick}
                />
              </Card>
            </Col>
          </Row>
        </div>

        <Footer />
      </>
    );
  }
}

export default AuthPage;
