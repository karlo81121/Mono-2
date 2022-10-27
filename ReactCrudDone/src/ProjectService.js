import http from "./http-common";

const getAll = () => {
  return http.get("/Project/GetAllProjects");
};

const getById = (id) => {
  return http.get(`/Project/GetProject/${id}`);
};

const getByFilter = (Rpp = null, pageNumber = null, OrderBy = null, sortOrder = null, projectName = null, locationName = null) => {
    let params = {Rpp, pageNumber, OrderBy, sortOrder, projectName, locationName}
    return http.get(`/Project/GetAllProjects`,{params});
};

//ova funkcija se nigdje ne poziva, korišten axios.post()
const post = (data) => {
  return http.post("/Project/PostProject", data, { headers: {
    "Accept": "application/json",
    "Content-type": "application/json, charset=utf-8"
  }})
};

const deleteProject = (id) => {
  return http.delete(`/Project/DeleteProject/${id}`);
};

const projectService = {
  getAll,
  getById,
  getByFilter,
  post,
  deleteProject
};

export default projectService;
