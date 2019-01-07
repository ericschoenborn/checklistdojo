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
        { text: "fith thing" },
        { text: "Part C" }
      ]
    };
  }

  handleItemTextChange = event => {
    const key = event.target.id;
    const text = event.target.value;

    const newItems = this.state.items.map((value, index) => {
      return index == key ? text : value;
    });

    this.setState({
      items: newItems
    });
  };

  handleItemMoveUp = () => {
    const key = parseInt(this.state.selected);
    const switchItem = this.state.items[key];
    var newItems = this.state.items;
    newItems[key] = newItems[key - 1];
    newItems[key - 1] = switchItem;

    this.setState({
      items: newItems,
      selected: this.state.selected - 1
    });
  };

  handleItemMoveDown = () => {
    const key = parseInt(this.state.selected);
    const switchItem = this.state.items[key];
    var newItems = this.state.items;
    newItems[key] = newItems[key + 1];
    newItems[key + 1] = switchItem;

    this.setState({
      items: newItems,
      selected: parseInt(this.state.selected) + 1
    });
  };

  handleItemRemove = () => {
    const key = parseInt(this.state.selected);
    const newItems = this.state.items.filter((value, index) => {
      if (index != key) {
        return value;
      }
    });
    const count = newItems.length;
    this.setState({
      items: newItems,
      selected: key == count ? key - 1 : key
    });
  };

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
                textChange={this.handleItemTextChange}
              />
            </div>
          ))}
          <Item placeholder={"Add New Item"} id="new" />
        </ul>
        <br />
        <TemplateEditorTools
          moveItemUp={this.handleItemMoveUp}
          moveItemDown={this.handleItemMoveDown}
          deleteItem={this.handleItemRemove}
          selected={selected}
          total={this.state.items.length - 1}
        />
      </div>
    );
  }
}
