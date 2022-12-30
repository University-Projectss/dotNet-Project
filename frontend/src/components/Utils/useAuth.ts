import { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { apiClient, authorise } from "./apiClient";
import { UserInterface } from "./types";

export const useAuth = () => {
  const [user, setUser] = useState<UserInterface>({} as UserInterface);
  const navigate = useNavigate();
  const location = useLocation();

  const logIn = async () => {
    if (localStorage.token) {
      await apiClient
        .get("/api/ce ruta era", authorise())
        .then((res) => {
          setUser({ ...res.data });
          if (location.pathname === "/login") navigate("/");
        })
        .catch((err) => {
          console.log(err);
          logOut();
        });
    }
  };

  const logOut = () => {
    setUser({} as UserInterface);
    localStorage.removeItem("token");
    navigate("/login");
  };

  return {
    user,
    logIn,
    logOut,
  };
};
