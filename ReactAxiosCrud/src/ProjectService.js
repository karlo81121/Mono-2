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

const projectService = {
  getAll,
  getById,
  getByFilter,
};

export default projectService;
