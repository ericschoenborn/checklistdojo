import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlus } from "@fortawesome/free-solid-svg-icons";
import { faFile } from "@fortawesome/free-solid-svg-icons";
import { faArrowUp } from "@fortawesome/free-solid-svg-icons";
import { faArrowDown } from "@fortawesome/free-solid-svg-icons";
import { faTrash } from "@fortawesome/free-solid-svg-icons";

export default () => (
  <div calssName="TemplateEditorToolbox">
    <FontAwesomeIcon icon={faPlus} size={"1x"} /> Task{" "}
    <FontAwesomeIcon icon={faFile} size={"1x"} /> Dubplicate{" "}
    <FontAwesomeIcon icon={faArrowUp} size={"1x"} /> Move{" "}
    <FontAwesomeIcon icon={faArrowDown} size={"1x"} /> Move{" "}
    <FontAwesomeIcon icon={faTrash} size={"1x"} /> Delete{" "}
  </div>
);
