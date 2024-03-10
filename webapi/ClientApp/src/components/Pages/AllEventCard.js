import React from "react";
import EventCard from "./EventCard";
import {
  Box,
  Grid,
  LinearProgress,
  Pagination,
  Stack,
  Typography,
} from "@mui/material";
import useFetch from "./useFetch";

const MAX_TITLE_LENGTH = 10;
const MAX_DESCRIPTION_LENGTH = 100;

const AllEventCard = ({ title }) => { // Receive title as a prop
  const {
    data: events,
    error,
    isPending,
  } = useFetch("http://localhost:8000/event");
  const [page, setPage] = React.useState(1);
  const eventsPerPage = 6;

  const handleChange = (event, value) => {
    setPage(value);
  };

  // Check if events is null or undefined
  if (isPending) {
    return (
      <Box sx={{ width: "100%" }}>
        <LinearProgress />
      </Box>
    );
  }

  if (error) {
    return <div>{error}</div>;
  }

  // Calculate the starting index of events for the current page
  const startIndex = (page - 1) * eventsPerPage;

  // Slice the events array to get events for the current page
  const displayedEvents = events.slice(startIndex, startIndex + eventsPerPage);

  return (
    <>
      <Box
        flex={4}
        // padding={3}
        sx={{
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <Typography
          variant="h4"
          sx={{
            textAlign: "center",
            fontWeight: "bold",
            alignItems: "center",
            margin: "auto",
            color: "white",
          }}
        >
          {title} {/* Display title received as a prop */}
        </Typography>
        <Grid container spacing={2} my={1}>
          {displayedEvents &&
            displayedEvents.map((event) => (
              <Grid item xs={12} sm={6} lg={4} key={event.id}>
                <EventCard
                  title={
                    event.title.length > MAX_TITLE_LENGTH
                      ? `${event.title.substring(0, MAX_TITLE_LENGTH)}...`
                      : event.title
                  }
                  date={event.date}
                  image={event.image}
                  description={
                    event.description.length > MAX_DESCRIPTION_LENGTH
                      ? `${event.description.substring(
                          0,
                          MAX_DESCRIPTION_LENGTH
                        )}...`
                      : event.description
                  }
                  id={event.id}
                />
              </Grid>
            ))}
        </Grid>
        <Stack spacing={2}>
          <Typography>Page: {page}</Typography>
          <Pagination
            count={Math.ceil(events.length / eventsPerPage)}
            page={page}
            color="primary"
            onChange={handleChange}
          />
        </Stack>
      </Box>
    </>
  );
};

export default AllEventCard;
