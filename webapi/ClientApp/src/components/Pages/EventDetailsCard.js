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

const EventDetailsCard = () => {
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
                  <CardActions>
                    <NavLink to="register">Register</NavLink>
                  </CardActions>
                </Card>
              </Box>
            </Paper>
          </Grid>
          <Grid item xs={6}>
            <Paper style={{ minHeight: 200 , textAlign:'center'}}>
              <Typography
                variant="h5"
                sx={{
                  backgroundColor: (theme) => theme.palette.primary.dark,
                  color: (theme) => theme.palette.primary.contrastText,
                }}
              >
                Speakers
              </Typography>
              <Typography variant="body1">{event.speakers}</Typography>
            </Paper>
          </Grid>
        </Grid>
      )}
    </>
  );
};

export default EventDetailsCard;
