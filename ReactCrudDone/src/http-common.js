import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:44362/api",
  headers: {
    "Accept": "application/json",
    "Content-type": "application/json, charset=utf-8"
  }
});
