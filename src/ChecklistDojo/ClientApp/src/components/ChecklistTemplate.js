import React, { Component } from "react";
import { NavLink } from "reactstrap";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHome } from "@fortawesome/free-solid-svg-icons";
import ChecklistTemplateItem from "./ChecklistTemplateItem";
import ChecklistTemplateTools from "./ChecklistTemplateTools";
import "./ChecklistTemplate.css";
import "./Theme.css";

export default class ChecklistTemplate extends Component {
  displayName = ChecklistTemplate;
  constructor(props) {
    super(props);

    // This should work as our general core format for a checklist, though it is missing
    // the metadata we'll need for database idos, user idos, etc
    this.state = {
      title: "default",
      description: "default",
      items: [
        { text: "first thing", selected: true },
        { text: "secound thing", selected: false },
        { text: "fith thing", selected: false },
        { text: "Part C", selected: false }
      ]
    };
  }
  handleItemSelect = event => {
    const key = parseInt(event.target.id);
    const changedItems = this.state.items.map((value, index) => {
      if (index === key) {
        value.selected = true;
      } else {
        value.selected = false;
      }
      return value;
    });
    this.setState({
      items: changedItems
    });
  };
  handleItemTextChange = event => {
    const text = event.target.value;
    const newItems = this.state.items.map(value => {
      value.text = value.selected ? text : value.text;
      return value;
    });
    this.setState({
      items: newItems
    });
  };

  handleItemMoveUp = () => {
    const key = this.state.items.findIndex(value => value.selected === true);
    const switchItem = this.state.items[key];
    var newItems = this.state.items;
    newItems[key] = newItems[key - 1];
    newItems[key - 1] = switchItem;

    this.setState({
      items: newItems
    });
  };

  handleItemMoveDown = () => {
    const key = this.state.items.findIndex(value => value.selected === true);
    const switchItem = this.state.items[key];
    var newItems = this.state.items;
    newItems[key] = newItems[key + 1];
    newItems[key + 1] = switchItem;
    this.setState({
      items: newItems
    });
  };

  handleItemRemove = () => {
    const key = this.state.items.findIndex(value => value.selected === true);
    var newItems = this.state.items.filter(value => !value.selected);
    const length = newItems.length;
    if (length > 0) {
      var noneSelected = true;
      newItems = newItems.map((value, index) => {
        if (key === index) {
          value.selected = true;
          noneSelected = false;
        } else if (index === length - 1 && noneSelected) {
          value.selected = true;
        }
        return value;
      });
    } else {
      newItems = [{ text: "", selected: true }];
    }

    this.setState({
      items: newItems
    });
  };

  handleItemAdd = newText => {
    const newItems = this.state.items
      .map(value => {
        value.selected = false;
        return value;
      })
      .concat({ text: newText, selected: true });
    this.setState({
      items: newItems
    });
  };

  render() {
    const { title, description, items } = this.state;
    return (
      <div>
        <NavLink to="/" tag={Link} className="noColor">
          <FontAwesomeIcon icon={faHome} size={"1x"} />
          Home
        </NavLink>
        <h1>{title}</h1>
        <h6>{description}</h6>
        <ul className="removeBullets">
          {items.map((value, index) => (
            <div
              key={index}
              className={`checklistTemplateItems ${
                value.selected ? "selected" : "notSelected"
              }`}
            >
              <span>{index}</span>{" "}
              <ChecklistTemplateItem
                text={value.text}
                placeholder={"Add New Item"}
                id={index}
                key={index}
                select={this.handleItemSelect}
                textChange={this.handleItemTextChange}
              />
            </div>
          ))}
        </ul>
        <br />
        <ChecklistTemplateTools
          moveItemUp={this.handleItemMoveUp}
          moveItemDown={this.handleItemMoveDown}
          deleteItem={this.handleItemRemove}
          noSelected={items.length === 0}
          firstSelected={items[0].selected}
          lastSelected={items[items.length - 1].selected}
          addItem={this.handleItemAdd}
          duplicateItem={
            this.state.items.find(value => value.selected === true).text
          }
        />
      </div>
    );
  }
}
