import React from "react";
import {
  Routes,
  Route,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";
import Rootlayout from "../Layouts/Rootlayout";
import About from "../components/Pages/About";
import AllEventCard from "../components/Pages/AllEventCard";
import Home from "../components/Pages/Home";
import SignIn from "../components/Auth/SignIn";
import SignUp from "../components/Auth/SignUp";
import Speaker from "../components/Pages/Speaker";
import EventLayout from "../Layouts/EventLayout";
import EventDetailsCard from "../components/Pages/EventDetailsCard";
import Error from "../components/Pages/Error";
import PrivateRoute from "./PrivateRoute";

const Router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<Rootlayout />} errorElement={<Error></Error>}>
      <Route index element={<Home />} />
      <Route path="about" element={<About />} />

      <Route
        path="event"
        element={

            <EventLayout />

        }
      >
        <Route index element={<AllEventCard />} />
        <Route path=":id" element={<EventDetailsCard />} />
        <Route path=":id/register" element={<Error />} />
      </Route>

      <Route path="speaker" element={<Speaker />} />
      <Route path="signin" element={<SignIn />} />
      <Route path="signup" element={<SignUp />} />
    </Route>
  )
);
export default Router;
