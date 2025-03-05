import React from "react";
import "./styleBackground.css";


export default function Background({ children }: { children: React.ReactNode }) {
    return (
        <div className="Grille">
            {children}
        </div>
    );
}
