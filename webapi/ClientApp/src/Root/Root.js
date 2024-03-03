import React from "react";
import Menu from "../components/Pages/SideBar/Menu";
import { Outlet } from "react-router-dom";
import { Container } from "@mui/material";

const Root = () => {
  return (
    <>
      <Menu />
      <Outlet />
    </>
  );
};

export default Root;
