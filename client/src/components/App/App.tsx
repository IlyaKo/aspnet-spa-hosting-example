import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";

export default function App() {
  const [answer, setAnswer] = useState("");

  useEffect(() => {
    axios
      .get("api/admin/ping")
      .then((response) => setAnswer(response.data))
      .catch((error) => setAnswer(error.message));
  }, []);

  return (
    <>
      <h1>Todo app</h1>
      <input className="input" type="text" placeholder="Enter your todo" />
      <button className="button">Add</button>
      <div>Server answer: {answer}</div>
    </>
  );
}
