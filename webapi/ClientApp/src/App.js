import { Box, Container, Divider, Stack } from "@mui/material";
import Menu from "./components/Menu";
import Content from "./components/Content";
import NavBar from "./components/NavBar";

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
          <Menu />
          <Content />
        </Stack>
      </Container>
    </Box>
  );
}

export default App;
