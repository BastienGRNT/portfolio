import React, { useContext } from 'react';
import { ThemeContext } from './ThemeContext';
import '../styles/DarkModeToggle.css'; // Si vous voulez des styles spécifiques

const DarkModeToggle: React.FC = () => {
    const { darkMode, toggleDarkMode } = useContext(ThemeContext);

    return (
        <button
            onClick={toggleDarkMode}
            className="dark-mode-toggle"
            aria-label={darkMode ? "Activer le mode clair" : "Activer le mode sombre"}
        >
            {darkMode ? '☀️' : '🌙'}
        </button>
    );
};

export default DarkModeToggle;