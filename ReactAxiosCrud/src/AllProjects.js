import React from "react";
import "./allProjects.css";
import { useEffect, useState } from "react";
import projectService from "./ProjectService";

function AllProjects() {
  const [data, setData] = useState([]);

  useEffect(() => {
    projectService.getAll().then((res) => {
      setData(res.data);
      console.log(res.data);
    });
  }, []);

  const arr = data.map((data) => {
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
    <div className="all-projects-container">
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

export default AllProjects;
