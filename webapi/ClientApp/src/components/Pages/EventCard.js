import {
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  CardHeader,
  CardMedia,
  Typography,
} from "@mui/material";
import React from "react";
import { Link, NavLink } from "react-router-dom";
import useFetch from "./useFetch";
import styled from "@emotion/styled";

const EventCard = (event) => {
  const StyledNavLink = styled(NavLink)({
    textDecoration: "none",
    color: "white",
    fontSize: 20,
  });

  const StyledBox = styled(Box)({
    backgroundColor: "navy",
    padding: "10px 20px 10px 20px",
    borderRadius: 10,
  });
  return (
    <Card sx={{ maxWidth: 600, marginBottom: "20px" }}>
      <CardHeader
        title={event.title}
        subheader={event.date}
        sx={{
          backgroundColor: (theme) => theme.palette.primary.dark,
          color: (theme) => theme.palette.primary.contrastText,
        }}
      />
      <CardMedia
        sx={{ height: 140 }}
        image={event.image}
        // title="green iguana"
      />
      <CardContent
        sx={{
          height: 50,
          overflow: "hidden",
        }}
      >
        {/* <Typography gutterBottom variant="h5" component="div">
          Lizard
        </Typography> */}
        <Typography variant="body2" color="text.secondary">
          {event.description}
        </Typography>
      </CardContent>
      <CardActions
        sx={{
          display: "flex",
          justifyContent: "center",
          color: (theme) => theme.palette.primary.contrastText,
        }}
      >
        <StyledBox>
          <StyledNavLink to={`/event/${event.id}`}>Details</StyledNavLink>
        </StyledBox>
      </CardActions>
    </Card>
  );
};

export default EventCard;
