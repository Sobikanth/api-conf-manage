import { useState } from "react";
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
import { NavLink, useParams } from "react-router-dom";
import useFetch from "./useFetch";
import styled from "@emotion/styled";
import { checkAuthentication } from "../Auth/AuthUtils/checkAuthentication";
import { getUserIdFromToken } from "../Auth/AuthUtils/getUserIdFromToken";

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
  const [isRegistered, setIsRegistered] = useState(false); // Track registration status

  // Function to handle registration
  const handleRegister = async () => {
    // Check if user is authenticated (assuming you have a function to check authentication status)
    const isAuthenticated = checkAuthentication();

    if (isAuthenticated) {
      // Get user ID from JWT token (assuming you have a function to retrieve user ID from the token)
      const userId = getUserIdFromToken();

      // Send POST request to register for the event
      try {
        const response = await fetch("http://localhost:8000/event/register", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${localStorage.getItem("token")}`,
          },
          body: JSON.stringify({ userId, eventId: id }),
        });

        if (response.ok) {
          setIsRegistered(true);
          // Optionally, you can perform additional actions upon successful registration
        } else {
          throw new Error("Registration failed");
        }
      } catch (error) {
        console.error("Error registering for event:", error);
      }
    } else {
      // User is not authenticated, handle accordingly (e.g., redirect to login page)
    }
  };

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
                  <CardMedia sx={{ height: 500 }} image={event.image} />
                  <CardContent
                    sx={{
                      height: 50,
                      overflow: "hidden",
                    }}
                  >
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
                    {!isRegistered ? ( // Render Register button if not registered
                      <StyledBox>
                        <StyledNavLink to={`/event/${event.id}/register`}>
                          Register
                        </StyledNavLink>
                      </StyledBox>
                    ) : (
                      <Typography variant="body2" color="text.secondary">
                        Registered
                      </Typography>
                    )}
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
          ;
        </Grid>
      )}
    </>
  );
};

export default EventDetailsCard;
