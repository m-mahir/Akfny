import { Content, Footer, Header, Sidebar } from "../../components/Layout";
import React from "react";
import {
  MdImportantDevices,
  // MdCardGiftcard,
  MdLoyalty,
} from "react-icons/md";
import NotificationSystem from "react-notification-system";
import { connect } from "react-redux";
import { NOTIFICATION_SYSTEM_STYLE } from "../../utils/constants";
import { withTranslation } from "react-i18next";

class MainLayout extends React.Component {
  lang = localStorage.getItem("lang");
  isArabic = () => this.lang === "ar";
  // isArabic = () => this.props.lang === 'ar';
  selector = this.isArabic() ? "cr-sidebar-ar" : "cr-sidebar";

  static isSidebarOpen() {
    let sideBar = document.querySelector(".cr-sidebar");
    if (sideBar) return sideBar.classList.contains("cr-sidebar--open");

    sideBar = document.querySelector(".cr-sidebar-ar");
    if (sideBar) return sideBar.classList.contains("cr-sidebar-ar--open");
  }

  componentWillReceiveProps({ breakpoint }) {
    if (breakpoint !== this.props.breakpoint) {
      this.checkBreakpoint(breakpoint);
    }
  }

  componentDidMount() {
    this.checkBreakpoint(this.props.breakpoint);

    // setTimeout(() => {
    //   if (!this.notificationSystem) {
    //     return;
    //   }

    //   this.notificationSystem.addNotification({
    //     title: <MdImportantDevices />,
    //     message: 'Welome to Reduction Admin!',
    //     level: 'info',
    //   });
    // }, 1500);

    // setTimeout(() => {
    //   if (!this.notificationSystem) {
    //     return;
    //   }

    //   this.notificationSystem.addNotification({
    //     title: <MdLoyalty />,
    //     message:
    //       'Reduction is carefully designed template powered by React and Bootstrap4!',
    //     level: 'info',
    //   });
    // }, 2500);
  }

  // close sidebar when
  handleContentClick = (event) => {
    // close sidebar if sidebar is open and screen size is less than `md`
    if (
      MainLayout.isSidebarOpen() &&
      (this.props.breakpoint === "xs" ||
        this.props.breakpoint === "sm" ||
        this.props.breakpoint === "md")
    ) {
      this.openSidebar("close");
    }
  };

  checkBreakpoint(breakpoint) {
    switch (breakpoint) {
      case "xs":
      case "sm":
      case "md":
        return this.openSidebar("close");

      case "lg":
      case "xl":
      default:
        return this.openSidebar("open");
    }
  }

  openSidebar(openOrClose) {
    if (openOrClose === "open") {
      return document
        .querySelector("." + this.selector)
        .classList.add(this.selector + "--open");
    }
    document
      .querySelector("." + this.selector)
      .classList.remove(this.selector + "--open");
  }

  render() {
    const { children } = this.props;
    return (
      <main className="cr-app bg-light">
        <Sidebar i18n={this.props.i18n} />
        <Content fluid onClick={this.handleContentClick}>
          <Header />
          {children}
          <Footer />
        </Content>

        <NotificationSystem
          dismissible={false}
          ref={(notificationSystem) =>
            (this.notificationSystem = notificationSystem)
          }
          style={NOTIFICATION_SYSTEM_STYLE}
        />
      </main>
    );
  }
}

// const mapStateToProps = state => ({
//   lang: state.user.lang,
// });
// export default connect(mapStateToProps)(MainLayout);
export default withTranslation()(MainLayout);
