import React from "react";
import { Box, Button, Typography } from "@mui/material";

const Home = () => {
  const handleClick = () => {
    const token = localStorage.getItem("token");

    // If the token is not present or empty, return null
    if (!token) {
      console.log("Token not found");
    }

    try {
      // Decode the token to extract the payload
      const payload = JSON.parse(atob(token.split(".")[1]));

      // Extract the user ID from the payload
      const userId =
        payload[
          "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
        ];

      console.log("Hello " + userId);
    } catch (error) {
      console.error("Error decoding token:", error);
    }
  };
  return (
    <Box flex={5}>
      <Typography variant="h3">Home</Typography>
      <Typography variant="body1">
        Lorem ipsum dolor sit, amet consectetur adipisicing elit. Porro ipsum
        eos aperiam reiciendis vitae doloremque maiores impedit et quas magnam!
        Optio veritatis beatae dolore tempora quaerat, dignissimos debitis
        inventore aliquam!
      </Typography>
      <Button variant="contained" color="primary" onClick={handleClick}>
        Register
      </Button>
    </Box>
  );
};

export default Home;
