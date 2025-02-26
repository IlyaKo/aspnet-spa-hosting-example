import { useEffect, useState } from "react";

interface Expense {
  amount: number;
  description: string;
  date: string;
}

export default function App() {
  const [expenses, setExpenses] = useState<Expense[]>([]);

  useEffect(() => {
    fetch("http://localhost:5249/api/expenses")
      .then((response) => response.json())
      .then((data) => setExpenses(data))
      .catch((error) => console.error("Error fetching expenses:", error));
  }, []);

  const total = expenses.reduce((acc, expense) => acc + expense.amount, 0);

  return (
    <div>
      <ul className="m-2">
        {expenses.map((expense, index) => (
          <li key={index}>
            <div className="card my-2 p-4">
              <div className="card-body">
                <p className="card-title is-size-4 has-text-weight-semibold">
                  {expense.description}
                </p>
                <p
                  className={`card-text my-1 is-size-3 ${
                    expense.amount >= 0 ? "has-text-success" : "has-text-danger"
                  }`}
                >{`${Math.abs(expense.amount)} $`}</p>
                <p className="card-text my-1 is-size-5 has-text-weight-light">
                  {new Date(expense.date).toLocaleDateString("en-gb", {
                    year: "numeric",
                    month: "long",
                    day: "numeric",
                  })}
                </p>
              </div>
            </div>
          </li>
        ))}
        {expenses.length > 0 && (
          <li>
            <div className="card p-5">
              <div className="card-body">
                <p className="card-title is-size-2 has-text-info has-text-weight-bold">
                  {"Total: "}
                  <span
                    className={`card-text ${
                      total >= 0 ? "has-text-success" : "has-text-danger"
                    }`}
                  >{`${total} $`}</span>
                </p>
              </div>
            </div>
          </li>
        )}
      </ul>
    </div>
  );
}
