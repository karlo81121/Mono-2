import React from "react";
import { useEffect, useState } from "react";
import projectService from "./ProjectService";
import './getFilteredProjects.css';

function GetFilteredProjects() {
    const [filteredProjects, setFilteredProjects] = useState([]);

  useEffect(() => {
    projectService.getByFilter("10", "2", "ProjectName", "ASC").then(res => {
        setFilteredProjects(res.data);
        console.log(res.data);
    })
  }, []);

  const arr = filteredProjects.map((data) => {
    return (
      <tr>
        <td>{data.ProjectName}</td>
        <td>{data.State.StateName}</td>
        <td>{data.Category}</td>
        <td>{data.Location.PostalCode}</td>
        <td>{data.Location.LocationName}</td>
      </tr>
    );
  });

  return (
    <div className="filtered-projects-container">
      <table>
        <tr>
          <th>Project name</th>
          <th>State name</th>
          <th>Category</th>
          <th>Postal code</th>
          <th>Location name</th>
        </tr>
        <tbody>{arr}</tbody>
      </table>
    </div>
  );
}

export default GetFilteredProjects;