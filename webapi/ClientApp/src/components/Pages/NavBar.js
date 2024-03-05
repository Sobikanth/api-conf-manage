import { Login, Logout } from "@mui/icons-material";
import {
  AppBar,
  Avatar,
  Box,
  Toolbar,
  Typography,
  styled,
} from "@mui/material";
import React, { useContext } from "react";
import { NavLink } from "react-router-dom";
import { AuthContext } from "../Auth/AuthProvider";

const StyledToolbar = styled(Toolbar)({
  display: "flex",
  justifyContent: "space-between",
});

const NavBar = () => {
  const { token, logout } = useContext(AuthContext);

  const capitalizeFirstLetter = (str) => {
    // Check if the string is empty or null
    if (!str) return str;

    // Capitalize the first letter and concatenate with the rest of the string
    return str.charAt(0).toUpperCase() + str.slice(1);
  };

  let name = "";

  if (token) {
    const payload = JSON.parse(atob(token.split(".")[1]));

    const username =
      payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];

    name = username.split("@")[0];
  }

  const handleLogout = () => {
    logout();
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
        <Typography variant="h5">Conference Management</Typography>
        {token ? (
          <Box
            sx={{
              display: "flex",
              justifyContent: "space-between",
              alignItems: "center",
              gap: 2,
            }}
          >
            <Avatar alt="User Avatar" src="https://i.pravatar.cc/1000" />
            <Typography
              variant="h6"
              sx={{
                textDecoration: "none",
              }}
            >
              {capitalizeFirstLetter(name)}
            </Typography>
            <NavLink
              to="/"
              onClick={handleLogout}
              style={{
                textDecoration: "none",
              }}
            >
              <Logout
                fontSize="large"
                sx={{ color: (theme) => theme.palette.primary.contrastText }}
              />
            </NavLink>
          </Box>
        ) : (
          <NavLink to="/signin" style={{ textDecoration: "none" }}>
            <Login
              fontSize="large"
              sx={{ color: (theme) => theme.palette.primary.contrastText }}
            />
          </NavLink>
        )}
      </StyledToolbar>
    </AppBar>
  );
};

export default NavBar;
