import React from "react";

export default ({ text, placeholder, id, select, textChange }) => (
  <input
    className="fillParent"
    type="text"
    placeholder={placeholder}
    value={text}
    id={id}
    onClick={select}
    onChange={textChange}
  />
);
