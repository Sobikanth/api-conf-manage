import React, { createContext, useState } from "react";

export const AuthContext = createContext(null);

const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);

  const createUser = (user) => {
    setLoading(true);
    return fetch("https://localhost:5132/api/Users/Register", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(user),
    })
      .then((response) => {
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        return response.json();
      })
      .then((data) => {
        if (data.succeeded) {
          console.log("Success:", data);
          // Assuming you want to set the user state after successful registration
          setUser(user);
        } else {
          console.log("Failed:", data);
        }
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error:", error);
        setLoading(false);
      });
  };

  const signIn = async (user) => {
    setLoading(true);
    try {
      const response = await fetch("https://localhost:5132/api/Users/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(user),
      });

      if (!response.ok) {
        if (response.status === 401) {
          throw new Error("Invalid username or password");
        }
        throw new Error("Network response was not ok");
      }

      const data = await response.json();
      localStorage.setItem("token", data.token);
      // Delete token after 1 hour (3600000 milliseconds)
      setTimeout(() => {
        localStorage.removeItem("token");
      }, 3600000);

      setLoading(false);
      return data;
    } catch (err) {
      console.log("Error: ", err.message);
      setLoading(false);
      throw err; // Rethrow the error so that the caller can catch it
    }
  };
  return (
    <AuthContext.Provider value={{ user, createUser, signIn }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthProvider;
