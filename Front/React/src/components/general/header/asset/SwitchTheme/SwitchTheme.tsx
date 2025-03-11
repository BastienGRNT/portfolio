import React, {useEffect, useState} from "react";
import "./styleSwitchTheme.css";

export default function SwitchTheme() {
    const [theme, setTheme] = useState(() => {
        const savedTheme = localStorage.getItem('theme');
        if (savedTheme === 'dark' || savedTheme === 'light') {
            return savedTheme;
        }
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
    )
}