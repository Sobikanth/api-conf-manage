import { RouterProvider } from "react-router-dom";
import Router from "./Router/Router";
import AuthProvider from "./components/Auth/AuthProvider";

function App() {
  return (
    <AuthProvider>
      <RouterProvider router={Router} />
    </AuthProvider>
  );
}

export default App;
