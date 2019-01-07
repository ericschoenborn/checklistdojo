import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHome } from "@fortawesome/free-solid-svg-icons";
import Item from "./Item";
import TemplateEditorTools from "./TemplateEditorTools";
import "./TemplateEditorInstance.css";

export default class TemplateEditorInstance extends Component {
  displayName = TemplateEditorInstance.name;

  constructor(props) {
    super(props);

    // This should work as our general core format for a checklist, though it is missing
    // the metadata we'll need for database idos, user idos, etc
    this.state = {
      title: "default",
      description: "default",
      selected: 0,
      items: [
        { text: "first thing" },
        { text: "secound thing" },
        { text: "fith thing" }
      ]
    };
  }

  render() {
    const { title, description, items, selected } = this.state;
    return (
      <div>
        <FontAwesomeIcon icon={faHome} size={"1x"} /> Home
        <h1>{title}</h1>
        <h6>{description}</h6>
        <ul className="removeBullets">
          {items.map((value, index) => (
            <div className={index == selected ? "selected" : "notSelected"}>
              <span>{index}</span>
              <Item
                text={value.text}
                id={index}
                select={e => {
                  this.setState({ selected: e.target.id });
                }}
              />
            </div>
          ))}
          <Item placeholder={"Add New Item"} id="new" />
        </ul>
        <br />
        <TemplateEditorTools />
      </div>
    );
  }
}
