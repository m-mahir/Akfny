import Avatar from "../../components/Avatar";
import { UserCard } from "../../components/Card";
import React from "react";
import {
  MdClearAll,
  MdExitToApp,
  MdHelp,
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
import Typography from "@material-ui/core/Typography";
import { connect } from "react-redux";
import { setLanguage } from "../../store/actions/creators/user";
import { withTranslation } from "react-i18next";
import { Link } from "react-router-dom";

const bem = bn.create("header");

class Header extends React.Component {
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
        <Button
          style={{
            // background: "black",
            // color: "white",
            // borderColor: "transparent",
            background: '#f7f7f7',
            color: '#89155a',
            borderColor: '#6c757d',
          }}
          outline
          onClick={this.handleSidebarControlButton}
        >
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
          <Button
            style={{
              background: "transparent",
              color: "white",
              borderColor: "transparent",
            }}
            onClick={() => {}}
          >
            {t("menu.home")}
          </Button>
        </NavItem>
        <NavItem>
          <Button
            style={{
              background: "transparent",
              color: "white",
              borderColor: "transparent",
            }}
            onClick={() => {}}
          >
            {t("menu.manage")}
          </Button>
        </NavItem>
        <NavItem>
          <Button
            style={{
              background: "transparent",
              color: "white",
              borderColor: "transparent",
            }}
            onClick={() => {}}
          >
            {t("menu.contactUs")}
          </Button>
        </NavItem>

        {
          // <NavItem>
          //   <Button
          //     style={{
          //       background: "white",
          //       color: "#89155a",
          //       borderColor: "#89155a",
          //       borderRadius: '30px',
          //       fontSize: 18
          //     }}
          //     onClick={this.toggleLang}
          //   >
          //     {t("general.lang")}
          //   </Button>
          // </NavItem>
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
                // text="Last updated 3 mins ago"
                className="border-light"
              >
                <ListGroup flush>
                  <ListGroupItem tag="button" action className="border-light">
                    <MdPersonPin /> Profile
                  </ListGroupItem>
                  {/* <ListGroupItem tag="button" action className="border-light">
                <MdInsertChart /> Stats
              </ListGroupItem>
              <ListGroupItem tag="button" action className="border-light">
                <MdMessage /> Messages
              </ListGroupItem> */}
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
      <Navbar
        light
        expand
        className={bem.b("bg-gradient-navbar")}
        style={{
          boxShadow: "rgb(0 0 0 / 40%) 0px 2px 5px 1px",
          borderBottom: "none",
          background:
            "linear-gradient(135deg, #8e135b 0%,#781a55 83%,#f6f6f6 50%,#f6f6f6 100%)",
        }}
      >
        {this.isArabic() ? (
          <>
            {userPopover}
            {links}
            {logo}
            {sideBarBtn}
          </>
        ) : (
          <>
            {sideBarBtn}
            <div
              style={{
                display: "flex",
                flexDirection: "row",
                alignItems: "center",
                justifyContent: "flex-end",
                width: "65%"
              }}
            >
              {links}
              {userPopover}
            </div>
            {logo}
          </>
        )}
      </Navbar>
    );
  }
}

// const mapStateToProps = state => ({
//   lang: state.user.lang,
// });
// const mapDispatchToProps = dispatch => ({
//   changeLanguage: lang => {
//     dispatch(setLanguage(lang));
//     // document.body.setAttribute("dir", lang);
//   },
// });
// export default connect(mapStateToProps, mapDispatchToProps)(Header);
export default withTranslation()(Header);
