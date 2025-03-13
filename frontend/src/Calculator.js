import React, { useState, useEffect } from "react";

function Calculator() {
    const [operation, setOperation] = useState("add");
    const [a, setA] = useState(0);
    const [b, setB] = useState(0);
    const [result, setResult] = useState(null);
    const [history, setHistory] = useState([]);

    useEffect(() => {
        fetch("http://localhost:5000/api/calculator/history")
            .then(response => response.json())
            .then(data => setHistory(data));
    }, []);

    const handleCalculate = async () => {
        const response = await fetch("http://localhost:5000/api/calculator/calculate", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ operation, a, b })
        });
        const data = await response.json();
        setResult(data);
    };

    return (
        <div>
            <h1>Calculator</h1>
            <label>
                Number 1:
                <input type="number" value={a} onChange={(e) => setA(parseInt(e.target.value))} />
            </label>
            <label>
                Operation:
                <select value={operation} onChange={(e) => setOperation(e.target.value)}>
                    <option value="add">+</option>
                    <option value="subtract">-</option>
                    <option value="multiply">*</option>
                    <option value="divide">/</option>
                </select>
            </label>
            <label>
                Number 2:
                <input type="number" value={b} onChange={(e) => setB(parseInt(e.target.value))} />
            </label>
            <button onClick={handleCalculate}>Calculate</button>
            {result !== null && <h2>Result: {result}</h2>}
            <h2>History</h2>
            <ul>
                {history.map((entry, index) => (
                    <li key={index}>{entry.a} {entry.operation} {entry.b} = {entry.result}</li>
                ))}
            </ul>
        </div>
    );
}

export default Calculator;
