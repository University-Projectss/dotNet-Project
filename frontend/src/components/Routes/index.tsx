import React from "react";
import { Route, Routes } from "react-router-dom";
import { Home } from "../Home";
import { NotFound } from "../NotFound";

export const RoutesComponent = () => {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};
