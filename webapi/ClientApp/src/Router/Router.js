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
import Speaker from "../components/Pages/Speaker";

const Router = createBrowserRouter(
  createRoutesFromElements(
    <Route element={<Root />}>
      <Route path="/" element={<Home />} />
      <Route path="/about" element={<About />} />
      <Route path="/event" element={<Event />} />
      <Route path="/speaker" element={<Speaker />} />
      <Route path="/signin" element={<SignIn />} />
      <Route path="/signup" element={<SignUp />} />
    </Route>
  )
);
export default Router;
