import React from "react";
import EventCard from "./EventCard";
import { Box, Grid } from "@mui/material";

const Content = () => {
  return (
    <Box flex={5} padding={3}>
      <Grid container spacing={2}>
        <Grid item xs={6}>
          <EventCard />
        </Grid>
        <Grid item xs={6}>
          <EventCard />
        </Grid>
        <Grid item xs={6}>
          <EventCard />
        </Grid>
        <Grid item xs={6}>
          <EventCard />
        </Grid>
        <Grid item xs={6}>
          <EventCard />
        </Grid>
        <Grid item xs={6}>
          <EventCard />
        </Grid>
      </Grid>
    </Box>
  );
};

export default Content;
