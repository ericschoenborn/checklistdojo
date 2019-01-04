import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHome } from "@fortawesome/free-solid-svg-icons";
import Item from "./Item";
import TemplateEditorTools from "./TemplateEditorTools";

export default class TemplateEditorInstance extends Component {
  displayName = TemplateEditorInstance.name;

  constructor(props) {
    super(props);

    // This should work as our general core format for a checklist, though it is missing
    // the metadata we'll need for database idos, user idos, etc
    this.state = {
      title: "default",
      description: "default",
      items: [{ text: "first thing" }]
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
        <ul className="removeBullets">
          {items.map(i => (
            <span>
              <Item text={i.text} />
              <br />
            </span>
          ))}
          <Item placeholder={"Add New Item"} />
        </ul>
        <br />
        <TemplateEditorTools />
      </div>
    );
  }
}
