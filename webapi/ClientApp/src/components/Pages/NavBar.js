import { Login, Logout } from "@mui/icons-material";
import { AppBar, Avatar, Toolbar, Typography, styled } from "@mui/material";
import React, { useState } from "react";
import { NavLink } from "react-router-dom";

const StyledToolbar = styled(Toolbar)({
  display: "flex",
  justifyContent: "space-between",
});

const NavBar = () => {
  const [isActive, setIsActive] = useState(false);

  const handleLinkClick = () => {
    setIsActive(true); // Update state when link is clicked
  };
  return (
    <AppBar
      position="sticky"
      sx={{
        backgroundColor: (theme) => theme.palette.primary.main,
        color: (theme) => theme.palette.primary.contrastText,
      }}
    >
      <StyledToolbar>
        <Typography variant="h5">My App</Typography>
        <NavLink
          to="/signin"
          onClick={handleLinkClick}
        >
          {/* Conditional rendering of icons based on active state */}
          {!isActive ? (
            <Login
              fontSize="large"
              sx={{ color: (theme) => theme.palette.primary.contrastText }}
            />
          ) : (
            <Logout
              fontSize="large"
              sx={{ color: (theme) => theme.palette.primary.contrastText }}
            />
          )}
        </NavLink>
      </StyledToolbar>
    </AppBar>
  );
};

export default NavBar;
