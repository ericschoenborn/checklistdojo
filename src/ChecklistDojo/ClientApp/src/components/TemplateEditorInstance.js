import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHome } from "@fortawesome/free-solid-svg-icons";

export default class TemplateEditorInstance extends Component {
  displayName = TemplateEditorInstance.name;

  constructor(props) {
    super(props);

    // This should work as our general core format for a checklist, though it is missing
    // the metadata we'll need for database idos, user idos, etc
    this.state = {
      title: "default",
      description: "default",
      items: []
    };
  }

  render() {
    const { title, description, items } = this.state;
    return (
      <div>
        <span>
          <FontAwesomeIcon icon={faHome} size={"1x"} /> Home
        </span>
        <h1>{title}</h1>
        <h6>{description}</h6>
        {items.length === 0 ? <p>no items</p> : <p>{items}</p>}
      </div>
    );
  }
}
