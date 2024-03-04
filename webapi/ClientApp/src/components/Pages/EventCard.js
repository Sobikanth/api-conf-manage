import {
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

const EventCard = (event) => {
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
      <CardActions>
        <NavLink to={`/event/${event.id}`}>Details</NavLink>
      </CardActions>
    </Card>
  );
};

export default EventCard;
