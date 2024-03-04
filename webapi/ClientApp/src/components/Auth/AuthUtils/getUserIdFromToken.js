const getUserIdFromToken = () => {
  // Get the JWT token from localStorage
  const token = localStorage.getItem("token");

  // If the token is not present or empty, return null
  if (!token) {
    return null;
  }

  try {
    // Decode the token to extract the payload
    const payload = JSON.parse(atob(token.split(".")[1]));

    // Extract the user ID from the payload
    const userId = payload.userId;

    return userId;
  } catch (error) {
    console.error("Error decoding token:", error);
    return null;
  }
};
