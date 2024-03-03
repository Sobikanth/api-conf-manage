import styled from "@emotion/styled";
import { Event, Home, Info, Person } from "@mui/icons-material";
import {
  Box,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";
import React from "react";
import About from "../About";

const Menu = () => {
  const StyledListItem = styled(ListItem)({
    "&:hover": {
      backgroundColor: "#1565c0",
      color: "white",
    },
  });

  return (
    <Box
      mt={2}
      flex={1}
      sx={{
        display: { xs: "none", md: "block" },
      }}
    >
      <Box position="fixed">
        <List>
          <StyledListItem disablePadding>
            <ListItemButton>
              <ListItemIcon>
                <Home />
              </ListItemIcon>
              <ListItemText primary="Home" />
            </ListItemButton>
          </StyledListItem>

          <StyledListItem disablePadding>
            <ListItemButton>
              <ListItemIcon>
                <Event />
              </ListItemIcon>
              <ListItemText primary="Event" />
            </ListItemButton>
          </StyledListItem>

          <StyledListItem disablePadding>
            <ListItemButton>
              <ListItemIcon>
                <Person />
              </ListItemIcon>
              <ListItemText primary="Speakers" />
            </ListItemButton>
          </StyledListItem>

          <StyledListItem disablePadding>
            <ListItemButton>
              <ListItemIcon>
                <Info />
              </ListItemIcon>
              <ListItemText primary="About Us" />
            </ListItemButton>
          </StyledListItem>
        </List>
      </Box>
    </Box>
  );
};

export default Menu;
