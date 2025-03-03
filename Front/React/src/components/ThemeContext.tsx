import React, { createContext, useState, useEffect } from 'react';

type ThemeContextType = {
    darkMode: boolean;
    toggleDarkMode: () => void;
};

export const ThemeContext = createContext<ThemeContextType>({
    darkMode: false,
    toggleDarkMode: () => {},
});

export const ThemeProvider: React.FC<{children: React.ReactNode}> = ({ children }) => {
    const storedTheme = localStorage.getItem('darkMode');
    const [darkMode, setDarkMode] = useState(storedTheme === 'true');

    const toggleDarkMode = () => {
        setDarkMode(!darkMode);
    };

    useEffect(() => {
        localStorage.setItem('darkMode', String(darkMode));

        if (darkMode) {
            document.documentElement.classList.add('dark');
        } else {
            document.documentElement.classList.remove('dark');
        }
    }, [darkMode]);

    return (
        <ThemeContext.Provider value={{ darkMode, toggleDarkMode }}>
            {children}
        </ThemeContext.Provider>
    );
};