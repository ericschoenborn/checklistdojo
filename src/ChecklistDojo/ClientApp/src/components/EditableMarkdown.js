import React, { Component } from "react";
import Markdown from "markdown-to-jsx";

class EditableMarkdown extends Component {
  displayName = EditableMarkdown;
  constructor(props) {
    super(props);
    this.state = {
      text: props.text,
      change: props.update,
      edit: false
    };
  }

  render() {
    const { text, change, edit } = this.state;
    return (
      <div>
        {edit ? (
          <input
            autoFocus
            onBlur={() => this.setState({ edit: false })}
            onChange={event => {
              this.setState({ text: event.target.value });
              change(event.target.value);
            }}
            value={text}
          />
        ) : (
          <div onClick={() => this.setState({ edit: true })}>{text}</div>
        )}
      </div>
    );
  }
}
export default EditableMarkdown;
