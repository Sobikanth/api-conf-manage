import { AppBar, Avatar, Toolbar, Typography, styled } from "@mui/material";
import React from "react";

const StyledToolbar = styled(Toolbar)({
  display: "flex",
  justifyContent: "space-between",
});

const NavBar = () => {
  return (
    <AppBar
      position="sticky "
      sx={{
        backgroundColor: (theme) => theme.palette.primary.main,
        color: (theme) => theme.palette.primary.contrastText,
      }}
    >
      <StyledToolbar>
        <Typography variant="h5">My App</Typography>
        {/* <Avatar alt="Remy Sharp" src="https://i.pravatar.cc/300" /> */}
        <button>Sign In</button>
      </StyledToolbar>
    </AppBar>
  );
};

export default NavBar;
