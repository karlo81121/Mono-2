import React from "react";
import { useState, useEffect } from "react";
import projectService from "./ProjectService";
import './deleteProject.css';

function DeleteProject() {
  const [isDeleted, setIsDeleted] = useState(false);
  const [uniqueID, setUniqueID] = useState('');

  const handleId = (event) => {
    setUniqueID(event.target.value);
  }

  const handlePost = () => {
    projectService
      .deleteProject(uniqueID)
      .then((res) => {
        if(res.data === '200 OK'){
          setIsDeleted(true);
        }
        clearState();
      });
  }

  const clearState = () => {
    setUniqueID('');
  }

  return (
    <div className="delete-form">
      <button className="delete-button" onClick={handlePost}>Delete with ID</button>
      <input className="delete-id-input" type="text" placeholder="Paste ID" value={uniqueID} onChange={handleId} />
      { isDeleted ? (
        <h4>Successfully deleted!</h4>
      ) : (
        <h4>Paste your ID to delete!</h4>
      )}
    </div>
  );
}

export default DeleteProject;
