import React from "react";
import "../styles/Background.css";


export default function Background({ children }: { children: React.ReactNode }) {
    return (
        <div className="Grille">
            {children}
        </div>
    );
}
