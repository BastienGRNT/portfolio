import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Projects from "./pages/Projects";


export default function App() {
  return (
      <Router>
        <div className="p-6">
          <nav className="mb-4">
            <Link to="/projects" className="mr-4">Projets</Link>
          </nav>

          <Routes>
            <Route path="/projects" element={<Projects />} />
          </Routes>
        </div>
      </Router>
  );
}

