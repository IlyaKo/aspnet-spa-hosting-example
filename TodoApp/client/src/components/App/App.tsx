import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";
import { TodoItem } from "../../models/TodoItem";

export default function App() {
  const [newItem, setNewItem] = useState<string>("");
  const [todos, setTodos] = useState<TodoItem[]>([]);
  const handleToggleItem = (id: number, isDone: boolean) => {
    axios
      .put(`api/todos/${id}/status?isDone=${isDone}`)
      .then(() => {
        setTodos(
          todos.map((todo) =>
            todo.id === id ? { ...todo, isDone: !todo.isDone } : todo
          )
        );
      })
      .catch((error) => console.log(error.message));
  };

  const handleDelete = (id: number) => {
    axios
      .delete(`api/todos/${id}`)
      .then(() => {
        setTodos(todos.filter((todo) => todo.id !== id));
      })
      .catch((error) => console.log(error.message));
  };

  const handleAddItem = () => {
    axios
      .post("api/todos", { content: newItem })
      .then((response) => {
        setTodos([...todos, response.data]);
        setNewItem("");
      })
      .catch((error) => console.log(error.message));
  };

  useEffect(() => {
    axios
      .get<TodoItem[]>("api/todos")
      .then((response) => {
        setTodos(response.data);
        console.log(response.data);
      })
      .catch((error) => console.log(error.message));
  }, []);

  return (
    <div className="m-4">
      <h1 className="title">Todo items:</h1>
      <ul>
        {todos.map((item) => (
          <li key={item.id}>
            <div className="card m-2">
              <div className="card-content">
                <p>{item.content}</p>
                <p>{formatDate(item.createdAt)}</p>
                <p>{item.isDone ? "Done" : "Not done"}</p>
              </div>
              <footer className="card-footer">
                <button
                  className="card-footer-item"
                  onClick={() => handleToggleItem(item.id, !item.isDone)}
                >
                  Mark as {item.isDone ? "undone" : "done"}
                </button>
                <button
                  className="card-footer-item"
                  onClick={() => handleDelete(item.id)}
                >
                  Delete
                </button>
              </footer>
            </div>
          </li>
        ))}
        <li>
          <div className="field has-addons">
            <div className="control is-expanded">
              <input
                className="input"
                type="text"
                placeholder="New item"
                value={newItem}
                onChange={(e) => setNewItem(e.target.value)}
              />
            </div>
            <div className="control">
              <button
                className="button is-primary"
                onClick={() => handleAddItem()}
              >
                Add
              </button>
            </div>
          </div>
        </li>
      </ul>
    </div>
  );
}

const formatDate = (date: Date): string => {
  return new Date(date).toLocaleDateString("en-gb", {
    year: "numeric",
    month: "long",
    day: "numeric",
  });
};
