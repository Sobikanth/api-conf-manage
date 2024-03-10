import styled from "@emotion/styled";
import { Event, Home, Info, Login, Person } from "@mui/icons-material";
import {
  Box,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";
import React from "react";
import { NavLink } from "react-router-dom";

const Menu = () => {
  const StyledListItem = styled(ListItem)({
    "&:hover": {
      backgroundColor: "#1565c0",
      color: "white",
      elevation: 40,
      boxShadow: "0 0 10px 0px #1565c0",
    },
  });

  const StyledNavLink = styled(NavLink)({
    textDecoration: "none",
    color: "black",
    fontSize: 20,
    "&.active": {
      background: "#1565c0",
      color: "white",
      padding: "0px 20px 0px 0px",
      borderRadius: 5,
    },
  });

  const StyledListItemIcon = styled(ListItemIcon)({
    color: "primary",
  });

  return (
    <Box
      mt={2}
      flex={1}
      sx={{
        display: { xs: "none", md: "none", lg: "block", xl: "block" },
      }}
      ml={4}
    >
      <Box position="fixed">
        <List>
          <StyledListItem disablePadding>
            <StyledNavLink to="/" style={{ textDecoration: "none" }}>
              <ListItemButton>
                <StyledListItemIcon>
                  <Home />
                </StyledListItemIcon>
                <ListItemText primary="Home" />
              </ListItemButton>
            </StyledNavLink>
          </StyledListItem>

          <StyledListItem disablePadding>
            <StyledNavLink to="event" style={{ textDecoration: "none" }}>
              <ListItemButton>
                <StyledListItemIcon>
                  <Event />
                </StyledListItemIcon>
                <ListItemText primary="Event" />
              </ListItemButton>
            </StyledNavLink>
          </StyledListItem>

          <StyledListItem disablePadding>
            <StyledNavLink to="speaker" style={{ textDecoration: "none" }}>
              <ListItemButton>
                <StyledListItemIcon>
                  <Person />
                </StyledListItemIcon>
                <ListItemText primary="Speakers" />
              </ListItemButton>
            </StyledNavLink>
          </StyledListItem>

          <StyledListItem disablePadding>
            <StyledNavLink to="about" style={{ textDecoration: "none" }}>
              <ListItemButton>
                <StyledListItemIcon>
                  <Info />
                </StyledListItemIcon>
                <ListItemText primary="About" />
              </ListItemButton>
            </StyledNavLink>
          </StyledListItem>
        </List>
      </Box>
    </Box>
  );
};

export default Menu;
