import React from "react";
import {
  Route,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";
import Root from "../Root/Root";
import About from "../components/Pages/About";
import Event from "../components/Pages/Event";
import Home from "../components/Pages/Home";
import SignIn from "../components/Auth/SignIn";
import SignUp from "../components/Auth/SignUp";

const Router = createBrowserRouter([
  {
    path: "/",
    element: <Root />,
    children: [
      { path: "/", element: <Home /> },
      { path: "/about", element: <About /> },
      { path: "/event", element: <Event /> },
      { path: "/signin", element: <SignIn /> },
      { path: "/signup", element: <SignUp /> },
    ],
  },
  { path: "*", element: <h1>Not Found</h1> },
]);
export default Router;
