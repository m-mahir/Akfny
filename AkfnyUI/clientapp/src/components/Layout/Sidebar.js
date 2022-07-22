import sidebarBgImage from "../../assets/img/sidebar/sidebar-4.jpg";
import React from "react";
import {
  MdAccountCircle,
  MdKeyboardArrowDown,
  MdInsertInvitation,
  MdViewList,
  MdHome,
} from "react-icons/md";
import { FaChalkboardTeacher } from "react-icons/fa";
import { NavLink } from "react-router-dom";
import { Collapse, Nav, NavItem, NavLink as BSNavLink } from "reactstrap";
import bn from "../../utils/bemnames";

const sidebarBackground = {
  backgroundImage: `url("${sidebarBgImage}")`,
  backgroundSize: "cover",
  backgroundRepeat: "no-repeat",
  // background:
    // "linear-gradient(168deg, rgb(142, 19, 91) 0%, rgb(120, 26, 85) 18%, rgb(246, 246, 246) 10%, rgb(246, 246, 246) 100%)",
};

class Sidebar extends React.Component {
  state = {
    isOpenTrainer: false,
    isOpenTrainee: false,
    isOpenCourse: true,
  };

  handleClick = (name) => () => {
    this.setState((prevState) => {
      const isOpen = prevState[`isOpen${name}`];

      return {
        [`isOpen${name}`]: !isOpen,
      };
    });
  };

  lang = localStorage.getItem("lang");
  isArabic = () => this.lang === "ar";
  mainClassName = this.isArabic() ? "sidebar-ar" : "sidebar";
  bem = bn.create(this.mainClassName);

  render() {
    const direction = this.isArabic() ? "rtl" : "ltr";
    const { i18n } = this.props;

    const trainerContents = [
      {
        to: "/trainer",
        name: i18n.t("trainer.list"),
        exact: true,
        Icon: MdViewList,
      },
      {
        to: "/trainerInvite",
        name: i18n.t("trainer.invitations"),
        exact: true,
        Icon: MdInsertInvitation,
      },
    ];

    const traineeContents = [
      {
        to: "/trainee",
        name: i18n.t("trainer.list"),
        exact: true,
        Icon: MdViewList,
      },
      {
        to: "/traineeInvite",
        name: i18n.t("trainer.invitations"),
        exact: true,
        Icon: MdInsertInvitation,
      },
    ];

    const courseContents = [
      {
        to: "/course",
        name: i18n.t("trainer.list"),
        exact: true,
        Icon: MdViewList,
      },
      {
        to: "/course/suggest",
        name: i18n.t("course.suggestions.title"),
        exact: true,
        Icon: MdInsertInvitation,
      },
    ];

    const navItems = [
      { to: "/", name: i18n.t("menu.home"), exact: true, Icon: MdHome },
      // { to: "/login", name: i18n.t("general.login"), exact: false, Icon: MdDashboard },
    ];

    return (
      <aside
        className={this.bem.b()}
        data-image={sidebarBgImage}
        dir={direction}
      >
        <div className={this.bem.e("background")} style={sidebarBackground} />
        <div className={this.bem.e("content")}>
          <Nav vertical>
            {navItems.map(({ to, name, exact, Icon }, index) => (
              <NavItem key={index} className={this.bem.e("nav-item")}>
                <BSNavLink
                  id={`navItem-${name}-${index}`}
                  className="text-uppercase"
                  tag={NavLink}
                  to={to}
                  activeClassName="active"
                  exact={exact}
                >
                  <Icon className={this.bem.e("nav-item-icon")} />
                  <span className="">{name}</span>
                </BSNavLink>
              </NavItem>
            ))}

<NavItem
              className={this.bem.e("nav-item")}
              onClick={this.handleClick("Course")}
            >
              <BSNavLink className={this.bem.e("nav-item-collapse")}>
                <div className="d-flex">
                  <FaChalkboardTeacher
                    className={this.bem.e("nav-item-icon")}
                  />
                  <span className="">{i18n.t("course.title")}</span>
                </div>
                <MdKeyboardArrowDown
                  className={this.bem.e("nav-item-icon")}
                  style={{
                    padding: 0,
                    transform: this.state.isOpenCourse
                      ? "rotate(0deg)"
                      : this.isArabic()
                      ? "rotate(90deg)"
                      : "rotate(-90deg)",
                    transitionDuration: "0.3s",
                    transitionProperty: "transform",
                  }}
                />
              </BSNavLink>
            </NavItem>
            <Collapse isOpen={this.state.isOpenCourse}>
              {courseContents.map(({ to, name, exact, Icon }, index) => (
                <NavItem key={index} className={this.bem.e("nav-item")}>
                  <BSNavLink
                    id={`navItem-${name}-${index}`}
                    className="text-uppercase"
                    tag={NavLink}
                    style={
                      this.isArabic()
                        ? { paddingRight: 35 }
                        : { paddingLeft: 35 }
                    }
                    to={to}
                    activeClassName="active"
                    exact={exact}
                  >
                    <Icon className={this.bem.e("nav-item-icon")} />
                    <span className="">{name}</span>
                  </BSNavLink>
                </NavItem>
              ))}
            </Collapse>
            
            <NavItem
              className={this.bem.e("nav-item")}
              onClick={this.handleClick("Trainer")}
            >
              <BSNavLink className={this.bem.e("nav-item-collapse")}>
                <div className="d-flex">
                  <MdAccountCircle className={this.bem.e("nav-item-icon")} />
                  <span className="">{i18n.t("trainer.title")}</span>
                </div>
                <MdKeyboardArrowDown
                  className={this.bem.e("nav-item-icon")}
                  style={{
                    padding: 0,
                    transform: this.state.isOpenTrainer
                      ? "rotate(0deg)"
                      : this.isArabic()
                      ? "rotate(90deg)"
                      : "rotate(-90deg)",
                    transitionDuration: "0.3s",
                    transitionProperty: "transform",
                  }}
                />
              </BSNavLink>
            </NavItem>
            <Collapse isOpen={this.state.isOpenTrainer}>
              {trainerContents.map(({ to, name, exact, Icon }, index) => (
                <NavItem key={index} className={this.bem.e("nav-item")}>
                  <BSNavLink
                    id={`navItem-${name}-${index}`}
                    className="text-uppercase"
                    tag={NavLink}
                    style={
                      this.isArabic()
                        ? { paddingRight: 35 }
                        : { paddingLeft: 35 }
                    }
                    to={to}
                    activeClassName="active"
                    exact={exact}
                  >
                    <Icon className={this.bem.e("nav-item-icon")} />
                    <span className="">{name}</span>
                  </BSNavLink>
                </NavItem>
              ))}
            </Collapse>

            <NavItem
              className={this.bem.e("nav-item")}
              onClick={this.handleClick("Trainee")}
            >
              <BSNavLink className={this.bem.e("nav-item-collapse")}>
                <div className="d-flex">
                  <MdAccountCircle className={this.bem.e("nav-item-icon")} />
                  <span className="">{i18n.t("trainee.title")}</span>
                </div>
                <MdKeyboardArrowDown
                  className={this.bem.e("nav-item-icon")}
                  style={{
                    padding: 0,
                    transform: this.state.isOpenTrainee
                      ? "rotate(0deg)"
                      : this.isArabic()
                      ? "rotate(90deg)"
                      : "rotate(-90deg)",
                    transitionDuration: "0.3s",
                    transitionProperty: "transform",
                  }}
                />
              </BSNavLink>
            </NavItem>
            <Collapse isOpen={this.state.isOpenTrainee}>
              {traineeContents.map(({ to, name, exact, Icon }, index) => (
                <NavItem key={index} className={this.bem.e("nav-item")}>
                  <BSNavLink
                    id={`navItem-${name}-${index}`}
                    className="text-uppercase"
                    tag={NavLink}
                    style={
                      this.isArabic()
                        ? { paddingRight: 35 }
                        : { paddingLeft: 35 }
                    }
                    to={to}
                    activeClassName="active"
                    exact={exact}
                  >
                    <Icon className={this.bem.e("nav-item-icon")} />
                    <span className="">{name}</span>
                  </BSNavLink>
                </NavItem>
              ))}
            </Collapse>

          </Nav>
        </div>
      </aside>
    );
  }
}
// const mapStateToProps = state => ({
//   lang: state.user.lang,
// });
// export default withRouter(connect(mapStateToProps)(Sidebar));
export default Sidebar;
