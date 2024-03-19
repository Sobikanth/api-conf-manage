import { AuthContext } from "../components/Auth/AuthProvider";
import { useContext } from "react";
import { Navigate, useLocation } from "react-router-dom";

const PrivateRoute = ({ children }) => {
  const { token } = useContext(AuthContext);
  const location = useLocation();
  if (token) {
    return children;
  }
  return <Navigate state={location.pathname} to="/signin" />;
};

export default PrivateRoute;
