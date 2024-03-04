import { Typography } from "@mui/material";
import React from "react";
import AllEventCard from "../components/Pages/AllEventCard";
import { NavLink, Outlet } from "react-router-dom";

const EventLayout = () => {
  return (
    <>
      <Outlet />
    </>
  );
};

export default EventLayout;
