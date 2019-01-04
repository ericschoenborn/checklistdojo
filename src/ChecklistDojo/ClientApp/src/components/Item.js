import React from "react";

export default ({ text, placeholder }) => (
  <span>
    <input type="text" placeholder={placeholder} value={text} />
  </span>
);
