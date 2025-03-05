import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './pages/Home/Home';
import Me from './pages/Me/Me';
import Projects from './pages/Projects/Projects';
import Header from './components/Header/Header';
import Background from './components/Background/Background';
import "./styles/styles.css";
import Debug from "./pages/Me/Debug";
import DebugAdmin from "./pages/DebugAdmin";

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
                      <Route path="/debugadmin" element={<DebugAdmin />} />
                  </Routes>
              </div>
          </Background>
      </Router>
  );
}

