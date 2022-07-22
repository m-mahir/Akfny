import React from "react";
import Select from "react-select";

export default (props) => (
  <Select
    {...props}
    value={props.options.filter((option) => option.label === "Some label")}
    // onChange={(value) => props.input.onChange(value)}
    // onBlur={() => props.input.onBlur(props.input.value)}
    // options={props.options}
    // placeholder={props.placeholder}
  />
);
