import React from "react";
import { useState } from "react";
import "./postProject.css";
import axios from "axios";

function PostProject() {
  const initialProjectState = {
    Location: {
      PostalCode: "10000",
    },
    State: {
      StateId: "1",
    },
    ProjectName: "",
    Summary: "",
    Category: "Building houses",
    IsActive: "true",
  };

  const [postProject, setPostProject] = useState(initialProjectState);
  const [submitted, setSubmitted] = useState(false);

  console.log(postProject);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setPostProject({ ...postProject, [name]: value });
    console.log(postProject);
  };

  const saveProject = () => {
    var data = {
      Location: {
        PostalCode: postProject.Location.PostalCode,
      },
      State: {
        StateId: postProject.State.StateId,
      },
      ProjectName: postProject.ProjectName,
      Summary: postProject.Summary,
      Category: postProject.Category,
      IsActive: postProject.IsActive,
    };

    setSubmitted(true);

    axios
      .post("https://localhost:44362/api/Project/PostProject", data)
      .then((res) => {
        setPostProject(JSON.stringify(res.data));
      });
  };

  const newProject = () => {
    setPostProject(initialProjectState);
    setSubmitted(false);
  };

  return (
    <div className="submit-form">
      {submitted ? (
        <div>
          <h4>You submitted successfully!</h4>
          <button className="submit-button" onClick={newProject}>
            Add
          </button>
        </div>
      ) : (
        <div>
          <div className="form-group">
            <label htmlFor="project-name">Project Name:</label>
            <input
              type="text"
              className="form-control"
              id="project-name"
              required
              value={postProject.ProjectName}
              onChange={handleInputChange}
              name="ProjectName"
            />
          </div>

          <div className="form-group">
            <label htmlFor="summary">Summary:</label>
            <input
              type="text"
              className="form-control"
              id="summary"
              required
              value={postProject.Summary}
              onChange={handleInputChange}
              name="Summary"
            />
          </div>

          <button onClick={saveProject} className="submit-button">
            Submit
          </button>
        </div>
      )}
    </div>
  );
}

export default PostProject;
