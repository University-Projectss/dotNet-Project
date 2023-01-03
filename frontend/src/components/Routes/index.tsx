import React from "react";
import { Route, Routes } from "react-router-dom";
import { Home } from "../Home";
import { Login } from "../Login";
import { NotFound } from "../NotFound";
import { ProtectedRoute } from "./ProtectedRoute";

export const RoutesComponent = () => {
  return (
    <Routes>
      <Route
        path="/"
        element={
          <ProtectedRoute>
            <Home />
          </ProtectedRoute>
        }
      />
      <Route path="login" element={<Login />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};
