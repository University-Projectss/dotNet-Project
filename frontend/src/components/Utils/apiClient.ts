import axios, { AxiosInstance } from "axios";

export const BASE_URL = "http://localhost:7247";

export const getAccesToken = () => {
  return localStorage.getItem("token");
};

const errorInterceptor = (val: AxiosInstance) => {
  val.interceptors.response.use(
    (res) => {
      return res;
    },
    (err) => {
      if (err.response.status === 401 || err.response.status === 403) {
        localStorage.removeItem("token");
        window.location.reload();
      } else {
        return Promise.reject(err);
      }
    }
  );
};

export const authorise = () => {
  return {
    headers: {
      Authorization: `Bearer ${getAccesToken()}`,
    },
  };
};

export const apiClient = axios.create({
  baseURL: BASE_URL,
});

errorInterceptor(apiClient);
