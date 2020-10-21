import Axios from "axios";
export const api = Axios.create({
  baseURL: "https://localhost",
  timeout: 3000,
});

export const setBearer = function(bearer) {
  api.defaults.headers.authorization = bearer;
};

export const resetBearer = function() {
  api.defaults.headers.authorization = "";
};
