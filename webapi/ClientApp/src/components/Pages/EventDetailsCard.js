import { Box, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import React from "react";
import { NavLink } from "react-router-dom";
import EventCard from "./EventCard";

const EventDetailsCard = () => {
  return (
    <Box>
      <Card sx={{ maxWidth: 800 }}>
      <CardHeader
        title="Shrimp and Chorizo Paella"
        subheader="September 14, 2016"
        sx={{
          backgroundColor: (theme) => theme.palette.primary.dark,
          color: (theme) => theme.palette.primary.contrastText,
        }}
      />
      <CardMedia
        sx={{ height: 140 }}
        image="https://picsum.photos/2000"
        title="green iguana"
      />
      <CardContent>
        {/* <Typography gutterBottom variant="h5" component="div">
          Lizard
        </Typography> */}
        <Typography variant="body2" color="text.secondary">
          Lizards are a widespread group of squamate reptiles, with over 6,000
          species, ranging across all continents except Antarctica
        </Typography>
      </CardContent>
      <CardActions>
        <NavLink to="register">Register</NavLink>
      </CardActions>
    </Card>
    </Box>
  );
};

export default EventDetailsCard;
