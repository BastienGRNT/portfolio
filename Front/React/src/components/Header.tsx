import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import "../styles/Header.css";

export default function Header() {
    // Récupère la préférence de thème du localStorage ou utilise la préférence du système
    const [theme, setTheme] = useState(() => {
        const savedTheme = localStorage.getItem('theme');
        if (savedTheme === 'dark' || savedTheme === 'light') {
            return savedTheme;
        }
        // Utilise la préférence du système comme valeur par défaut
        return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
    });

    const isDarkMode = theme === 'dark';

    useEffect(() => {
        document.documentElement.setAttribute('data-theme', theme);
        localStorage.setItem('theme', theme);
    }, [theme]);

    const toggleTheme = () => {
        setTheme(isDarkMode ? 'light' : 'dark');
    };

    return (
        <header className="Header">
            <nav className="Navbar">
                <div className="Liste">
                    <a className="Liste-link">Portfolio</a>
                    <a className="Liste-link">CV</a>
                </div>
                <div className="Titles">
                    <Link to="/" className="Title-link">GRENOT BASTIEN</Link>
                </div>
                <div className="Social">
                    <a href="https://www.linkedin.com/in/bastiengrnt/" target="_blank" rel="noreferrer">
                        <img src="/Logo/linkedin.svg" alt="LinkedIn"/>
                    </a>
                    <a href="https://github.com/BastienGRNT" target="_blank" rel="noreferrer">
                        <img src="/Logo/github.svg" alt="Github"/>
                    </a>
                    <a href="mailto:bastien.grenot@gmail.com" target="_blank" rel="noreferrer">
                        <img src="/Logo/gmail.svg" alt="Email"/>
                    </a>
                    {/* Bouton switch de thème */}
                    <div className="themeChecker">
                        <label className="theme-switch">
                            <input
                                className="toggle-checkbox"
                                type="checkbox"
                                checked={isDarkMode}
                                onChange={toggleTheme}
                            />
                            <div className="toggle-slot">
                                <div className="sun-icon-wrapper">
                                    <div className="iconify sun-icon" data-icon="feather-sun" data-inline="false"></div>
                                </div>
                                <div className="toggle-button"></div>
                                <div className="moon-icon-wrapper">
                                    <div className="iconify moon-icon" data-icon="feather-moon" data-inline="false"></div>
                                </div>
                            </div>
                        </label>
                    </div>
                </div>
            </nav>
        </header>
    );
}