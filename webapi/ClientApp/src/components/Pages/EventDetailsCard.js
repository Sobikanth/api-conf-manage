import {
  Box,
  Card,
  CardActions,
  CardContent,
  CardHeader,
  CardMedia,
  Grid,
  Paper,
  Typography,
} from "@mui/material";
import React from "react";
import { NavLink, useParams } from "react-router-dom";
import useFetch from "./useFetch";
import styled from "@emotion/styled";

const EventDetailsCard = () => {
  const StyledNavLink = styled(NavLink)({
    textDecoration: "none",
    color: "white",
    fontSize: 20,
  });

  const StyledBox = styled(Box)({
    backgroundColor: "navy",
    padding: "10px 50px 10px 50px",
    borderRadius: 10,
  });
  const { id } = useParams();
  const { data: event } = useFetch("http://localhost:8000/event/" + id);
  console.log(event);

  return (
    <>
      {event && (
        <Grid container spacing={3} alignItems="center">
          <Grid item xs={6}>
            <Paper style={{ background: "#e0b7ff", minHeight: 400 }}>
              <Box>
                <Card>
                  <CardHeader
                    title={event.title}
                    subheader={event.date}
                    sx={{
                      backgroundColor: (theme) => theme.palette.primary.dark,
                      color: (theme) => theme.palette.primary.contrastText,
                    }}
                  />
                  <CardMedia
                    sx={{ height: 500 }}
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
                      <StyledNavLink to={`/event/${event.id}`}>
                        Register
                      </StyledNavLink>
                    </StyledBox>
                  </CardActions>
                </Card>
              </Box>
            </Paper>
          </Grid>
          <Grid item xs={6}>
            <Paper style={{ minHeight: 200, textAlign: "center" }}>
              {/* Speaker Picture */}
              <CardMedia
                component="img"
                height="140"
                image={event.speakerimage}
                alt="Speaker Picture"
              />

              {/* Speaker Name */}
              <Typography variant="body1">Speaker: {event.speaker}</Typography>
              {/* Date */}
              <Typography variant="body1">Date: {event.date}</Typography>
              {/* Start Time */}
              <Typography variant="body1">
                Start Time: {event.startTime}
              </Typography>
              {/* End Time */}
              <Typography variant="body1">End Time: {event.endTime}</Typography>
              {/* University */}
              <Typography variant="body1">
                University: {event.university}
              </Typography>
              {/* Room */}
              <Typography variant="body1">Room: {event.room}</Typography>
            </Paper>
          </Grid>
        </Grid>
      )}
    </>
  );
};

export default EventDetailsCard;
