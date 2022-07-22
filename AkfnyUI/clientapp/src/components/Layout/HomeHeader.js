import Avatar from "../Avatar";
import { UserCard } from "../Card";
import React from "react";
import {
  MdClearAll,
  MdExitToApp,
  MdHelp,
  MdPerson,
  MdPersonPin,
  MdSettingsApplications,
} from "react-icons/md";
import {
  Button,
  ListGroup,
  ListGroupItem,
  Nav,
  Navbar,
  NavItem,
  NavLink,
  Popover,
  PopoverBody,
} from "reactstrap";
import bn from "../../utils/bemnames";
import logoImg from "../../assets/img/app-logo.png";
import { withTranslation } from "react-i18next";
import { Link } from "react-router-dom";
import { Card, CardTitle, CardSubtitle, CardText, CardBody } from "reactstrap";

const bem = bn.create("header");

class HomeHeader extends React.Component {
  state = {
    isOpenNotificationPopover: false,
    isNotificationConfirmed: false,
    isOpenUserCardPopover: false,
  };

  toggleNotificationPopover = () => {
    this.setState({
      isOpenNotificationPopover: !this.state.isOpenNotificationPopover,
    });

    if (!this.state.isNotificationConfirmed) {
      this.setState({ isNotificationConfirmed: true });
    }
  };

  toggleUserCardPopover = () => {
    this.setState({
      isOpenUserCardPopover: !this.state.isOpenUserCardPopover,
    });
  };

  lang = localStorage.getItem("lang");
  isArabic = () => this.lang === "ar";
  direction = this.isArabic() ? "rtl" : "ltr";

  selector = this.isArabic() ? "cr-sidebar-ar" : "cr-sidebar";

  handleSidebarControlButton = (event) => {
    event.preventDefault();
    event.stopPropagation();

    document
      .querySelector("." + this.selector)
      .classList.toggle(this.selector + "--open");
  };

  toggleLang = () => {
    const lang = this.isArabic() ? "en" : "ar";
    localStorage.setItem("lang", lang);
    this.props.i18n.changeLanguage(lang);
    window.location.reload();
  };

  render() {
    const { t } = this.props;
    let sideBarBtn = (
      <Nav navbar className="mr-2">
        <Button outline onClick={this.handleSidebarControlButton}>
          <MdClearAll size={25} />
        </Button>
      </Nav>
    );
    let links = (
      <Nav
        navbar
        className={bem.e("nav-right")}
        style={{ direction: this.direction }}
      >
        <NavItem>
          <Link to={"/main"}>
            <Button className="mr-4" color="light" onClick={() => {}}>
              {t("menu.home")}
            </Button>
          </Link>
        </NavItem>
        <NavItem>
          <NavLink id="Popover2">
            <Button
              onClick={this.toggleUserCardPopover}
              className="mr-4"
              style={{ marginTop: "-7px" }}
              color="light"
            >
              {t("menu.register")}
            </Button>
          </NavLink>
          <Popover
            placement="bottom-end"
            isOpen={this.state.isOpenUserCardPopover}
            toggle={this.toggleUserCardPopover}
            target="Popover2"
            className="p-0 border-0"
            style={{ minWidth: 150 }}
          >
            <PopoverBody className="p-0">
              <Card inverse>
                <ListGroup flush>
                  <Link to={"/trainerRegister"}>
                    <ListGroupItem
                      tag="button"
                      action
                      style={{ textAlign: "center" }}
                    >
                      {t("sigupMenu.asATrainer")}
                    </ListGroupItem>
                  </Link>
                  <Link to="/traineeRegister">
                    <ListGroupItem
                      tag="button"
                      action
                      style={{ textAlign: "center" }}
                    >
                      {t("sigupMenu.asATrainee")}
                    </ListGroupItem>
                  </Link>
                </ListGroup>
              </Card>
            </PopoverBody>
          </Popover>
        </NavItem>
        <NavItem>
          <Link to={"/"}>
            <Button className="mr-4" color="light" onClick={() => {}}>
              {t("menu.login")}
            </Button>
          </Link>
        </NavItem>

        {
          <NavItem>
            <Button className="mr-4" outline onClick={this.toggleLang}>
              {t("general.lang")}
            </Button>
          </NavItem>
        }
      </Nav>
    );

    let logo = (
      <Nav navbar className={bem.e("nav-right")}>
        <NavItem>
          <NavLink>
            <img src={logoImg} alt="Logo" width="90" height="40" />
          </NavLink>
        </NavItem>
      </Nav>
    );

    let userPopover = (
      <Nav navbar>
        <NavItem>
          <NavLink id="Popover2">
            <Avatar
              onClick={this.toggleUserCardPopover}
              className="can-click"
            />
          </NavLink>
          <Popover
            placement="bottom-end"
            isOpen={this.state.isOpenUserCardPopover}
            toggle={this.toggleUserCardPopover}
            target="Popover2"
            className="p-0 border-0"
            style={{ minWidth: 250 }}
          >
            <PopoverBody className="p-0 border-light">
              <UserCard
                title="Jane"
                subtitle="jane@jane.com"
                className="border-light"
              >
                <ListGroup flush>
                  <ListGroupItem tag="button" action className="border-light">
                    <MdPersonPin /> Profile
                  </ListGroupItem>
                  <ListGroupItem tag="button" action className="border-light">
                    <MdSettingsApplications /> Settings
                  </ListGroupItem>
                  <ListGroupItem tag="button" action className="border-light">
                    <MdHelp /> Help
                  </ListGroupItem>
                  <Link to="/">
                    <ListGroupItem tag="button" action className="border-light">
                      <MdExitToApp /> Signout
                    </ListGroupItem>
                  </Link>
                </ListGroup>
              </UserCard>
            </PopoverBody>
          </Popover>
        </NavItem>
      </Nav>
    );

    return (
      <Navbar light expand className={bem.b("bg-gradient-theme-left")}>
        {this.isArabic() ? (
          <>
            {links}
            {logo}
          </>
        ) : (
          <>
            {logo}
            {links}
          </>
        )}
      </Navbar>
    );
  }
}

export default withTranslation()(HomeHeader);
