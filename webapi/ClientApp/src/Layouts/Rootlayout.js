import React from "react";
import Menu from "../components/Pages/SideBar/Menu";
import { Outlet } from "react-router-dom";
import NavBar from "../components/Pages/NavBar";
import { Box, Container, Divider, Stack } from "@mui/material";

const Rootlayout = () => {
  return (
    <>
      <NavBar />
      <Menu />
      <Container maxWidth="lg">
        <Stack
          direction="row"
          divider={<Divider orientation="vertical" flexItem />}
          spacing={2}
          justifyContent="space-between"
        >
          <Outlet />
        </Stack>
      </Container>
    </>
  );
};

export default Rootlayout;
