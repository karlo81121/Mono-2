import React from "react";
import { useState } from "react";
import './updateProject.css';
import axios from "axios";

function UpdateProject() {
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
        IsActive: "false",
      };
    
      const [postProject, setPostProject] = useState(initialProjectState);
      const [submitted, setSubmitted] = useState(false);
    
      console.log(postProject);
    
      const handleInputChange = (event) => {
        const { name, value } = event.target;
        setPostProject({ ...postProject, [name]: value });
        console.log(postProject);
      };
    
      const updateProject = () => {
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
    
        axios
          .put("https://localhost:44362/api/Project/UpdateProject/F4043263-0F88-4F80-AB8A-719764DC1E0C", data)
          .then((res) => {
            setPostProject(JSON.stringify(res.data));
            clearState();
          });
      };
    
      const newProject = () => {
        setPostProject(initialProjectState);
        setSubmitted(false);
      };

      const clearState = () => {
        setPostProject('');
      }
    
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
    
              <button onClick={updateProject} className="submit-button">
                Submit
              </button>
            </div>
          )}
        </div>
      );
}

export default UpdateProject;