import React from "react";

export default ({ text, placeholder, id, select }) => (
  <input
    type="text"
    placeholder={placeholder}
    value={text}
    id={id}
    onClick={select}
  />
);
