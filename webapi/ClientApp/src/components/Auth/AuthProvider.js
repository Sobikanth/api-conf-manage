import React, { createContext, useEffect, useState } from "react";

export const AuthContext = createContext(null);

const AuthProvider = ({ children }) => {
  const [loading, setLoading] = useState(true);
  const [token, setToken] = useState(null);

  // useEffect to store token in local storage whenever it changes
  useEffect(() => {
    if (token) {
      localStorage.setItem("token", token);
    } else {
      localStorage.removeItem("token");
    }
  }, [token]);

  const createUser = async (user) => {
    setLoading(true);
    const response = await fetch("https://localhost:5132/api/Users/Register", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(user),
    });
    const data = await response.json();

    if (data.succeeded) {
      setLoading(false);
      return data;
    } else {
      setLoading(false);
      throw new Error(data.errors);
    }
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
      setToken(data.token);
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

  const logout = () => {
    setToken(null);
  };

  return (
    <AuthContext.Provider value={{ createUser, signIn, logout, token }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthProvider;
