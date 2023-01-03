import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { UserInterface } from "./types";

export const useAuth = () => {
  const [user, setUser] = useState<UserInterface>({} as UserInterface);
  const navigate = useNavigate();

  const logOut = () => {
    setUser({} as UserInterface);
    localStorage.removeItem("token");
    navigate("/login");
  };

  return {
    user,
    setUser,
    logOut,
  };
};
