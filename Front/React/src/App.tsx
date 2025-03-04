import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './pages/Home';
import Me from './pages/Me';
import Projects from './pages/Projects';
import Header from './components/Header';
import Background from './components/Background';
import "./styles/styles.css";
import Debug from "./pages/Debug";

export default function App(){
  return (
      <Router>
          <Background>
              <Header />
              <div className="App">
                  <Routes>
                      <Route path="/" element={<Home />} />
                      <Route path="/me" element={<Me />} />
                      <Route path="/project" element={<Projects />} />
                      <Route path="/debug" element={<Debug />} />
                  </Routes>
              </div>
          </Background>
      </Router>
  );
}

