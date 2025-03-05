import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Accueil from './pages/accueil/Accueil';
import Cv from './pages/cv/Cv';
import Projects from './pages/project/Projects';
import Header from './components/general/header/Header';
import Background from './components/general/background/Background';
import Debug from "./pages/cv/Debug";
import DebugAdmin from "./pages/admin/DebugAdmin";
import "./styles/styles.css";

export default function App(){
  return (
      <Router>
          <Background>
              <Header />
              <div className="App">
                  <Routes>
                      <Route path="/" element={<Accueil />} />
                      <Route path="/me" element={<Cv />} />
                      <Route path="/project" element={<Projects />} />
                      <Route path="/debug" element={<Debug />} />
                      <Route path="/debugadmin" element={<DebugAdmin />} />
                  </Routes>
              </div>
          </Background>
      </Router>
  );
}

