import React, { Component } from "react";
import Markdown from "markdown-to-jsx";

class EditableMarkdown extends Component {
  displayName = EditableMarkdown;
  constructor(props) {
    super(props);
    this.state = {
      text: props.text,
      OnChange: props.OnChange,
      edit: false
    };
  }

  render() {
    const { text, OnChange, edit } = this.state;
    const textAlt = text.replace("<", "&lt;");
    return (
      <div>
        {edit ? (
          <input
            autoFocus
            type="text"
            maxLength="280"
            onBlur={() => this.setState({ edit: false })}
            onChange={event => {
              this.setState({ text: event.target.value });
              OnChange(event.target.value);
            }}
            value={text}
          />
        ) : (
          <div onClick={() => this.setState({ edit: true })}>
            <Markdown>{textAlt}</Markdown>
          </div>
        )}
      </div>
    );
  }
}
export default EditableMarkdown;
