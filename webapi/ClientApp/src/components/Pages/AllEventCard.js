import React from "react";
import EventCard from "./EventCard";
import { Box, Grid, Typography } from "@mui/material";
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
      <Box
        flex={8}
        padding={3}
        sx={{
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <Box
          sx={{
            marginBottom: "20px",
            backgroundColor: "navy",
            width: "50%",
            padding: "10px",
            borderRadius: "20px",
          }}
        >
          <Typography
            variant="h4"
            gutterBottom
            sx={{
              textAlign: "center",
              fontWeight: "bold",
              alignItems: "center",
              margin: "auto",
              color: "white",
            }}
          >
            Events
          </Typography>
        </Box>
        <Grid container spacing={2}>
          {events &&
            events.map((event) => (
              <Grid item xs={4} key={event.id}>
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
