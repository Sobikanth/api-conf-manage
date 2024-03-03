import { Box, Container, Divider, Stack } from "@mui/material";
import Menu from "./components/Pages/SideBar/Menu";
import Event from "./components/Pages/Event";
import NavBar from "./components/Pages/NavBar";
import { RouterProvider } from "react-router-dom";
import Router from "./Router/Router";

function App() {
  return (
    <Box>
      <NavBar />
      <Container maxWidth="xl">
        <Stack
          direction="row"
          divider={<Divider orientation="vertical" flexItem />}
          spacing={2}
          justifyContent="space-between"
        >
          <RouterProvider router={Router} />
        </Stack>
      </Container>
    </Box>
  );
}

export default App;
