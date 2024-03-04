import React from "react";
import EventCard from "./EventCard";
import { Box, Grid } from "@mui/material";
import useFetch from "./useFetch";

const AllEventCard = () => {
  const {
    data: events,
    error,
    isLoading,
  } = useFetch("http://localhost:8000/event");
  return (
    <>
      {isLoading && <div>Loading...</div>}
      {error && <div>{error}</div>}
      <Box flex={5} padding={3}>
        <Grid container spacing={2}>
          {events &&
            events.map((event) => (
              <Grid item xs={6} key={event.id}>
                <EventCard
                  title={event.title}
                  date={event.date}
                  image={event.image}
                  description={event.description}
                  id={event.id}
                />
              </Grid>
            ))}
        </Grid>
      </Box>
    </>
  );
};

export default AllEventCard;
