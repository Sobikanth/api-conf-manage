const checkAuthentication = () => {
  // Check if the JWT token is present in localStorage
  const token = localStorage.getItem("token");

  // Return true if the token exists and is not expired, otherwise return false
  return !!token; // Convert token to a boolean value
};
