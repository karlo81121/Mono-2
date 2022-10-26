import React from "react";
import { useEffect, useState } from "react";
import projectService from "./ProjectService";
import './getSingleProject.css';

function GetSingleProject() {
    const [singleProject, setSingleProject] = useState({
        Location: {
            PostalCode: 53270,
            LocationName: "Senj"
        },
        State: {
            StateName: "In progress"
        },
        ProjectName: "Bulding hospital",
        Summary: "summary",
        Category: "Public facilities"
    });

  useEffect(() => {
    projectService
      .getById("D7B22584-7221-4FED-A2C4-2C1977854603")
      .then((res) => {
        setSingleProject(res.data);
        console.log(res.data);
      });
  }, []);

  return (
    <div className="single-project-container">
      <p><b>Project ID:</b> D7B22584-7221-4FED-A2C4-2C1977854603</p>
      <p><b>Project name:</b> {singleProject.ProjectName}</p>
      <p><b>State name:</b> {singleProject.State.StateName}</p>
      <p><b>Category name:</b> {singleProject.Category}</p>
      <p><b>Postal code:</b> {singleProject.Location.PostalCode}</p>
      <p><b>Location: </b> {singleProject.Location.LocationName}</p>
    </div>
  );
}

export default GetSingleProject;
