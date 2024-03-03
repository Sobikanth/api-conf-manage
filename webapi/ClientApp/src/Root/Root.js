import React from "react";
import Menu from "../components/Pages/SideBar/Menu";
import { Outlet } from "react-router-dom";
import NavBar from "../components/Pages/NavBar";
import { Box, Container, Divider, Stack } from "@mui/material";

const Root = () => {
  return (
    <>
      <Box>
        <NavBar />
        <Container maxWidth="xl">
          <Stack
            direction="row"
            divider={<Divider orientation="vertical" flexItem />}
            spacing={2}
            justifyContent="space-between"
          >
            <Menu />
            <Outlet />
          </Stack>
        </Container>
      </Box>
    </>
  );
};

export default Root;
