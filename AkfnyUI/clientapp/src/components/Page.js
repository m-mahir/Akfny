import React from "react";
import PropTypes from "../utils/propTypes";

import bn from "../utils/bemnames";

import { Breadcrumb, BreadcrumbItem } from "reactstrap";

import Typography from "./Typography";
import { useTranslation } from "react-i18next";

const bem = bn.create("page");

const Page = ({
  title,
  breadcrumbs,
  tag: Tag,
  endComp,
  className,
  children,
  ...restProps
}) => {
  const classes = bem.b("px-3", className);

  const { t } = useTranslation();

  return (
    <Tag className={classes} {...restProps}>
      <div className={bem.e("header")}>
        {title && typeof title === "string" ? (
          <Typography type="h1" className={bem.e("title")}>
            {title}
          </Typography>
        ) : (
          title
        )}
        {breadcrumbs && (
          <Breadcrumb className={bem.e("breadcrumb")}>
            <BreadcrumbItem>{t("menu.home")}</BreadcrumbItem>
            {breadcrumbs.length &&
              breadcrumbs.map(({ name, active }, index) => (
                <BreadcrumbItem key={index} active={active}>
                  {name}
                </BreadcrumbItem>
              ))}
          </Breadcrumb>
        )}
        {endComp}
      </div>
      {children}
    </Tag>
  );
};

Page.propTypes = {
  tag: PropTypes.component,
  endComp: PropTypes.component,
  title: PropTypes.oneOfType([PropTypes.string, PropTypes.element]),
  className: PropTypes.string,
  children: PropTypes.node,
  breadcrumbs: PropTypes.arrayOf(
    PropTypes.shape({
      name: PropTypes.string,
      active: PropTypes.bool,
    })
  ),
};

Page.defaultProps = {
  tag: "div",
  title: "",
};

export default Page;
