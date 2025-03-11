import React from "react";
import { Link } from "react-router-dom";
import "./styleLink.css"


export default function Links() {
    return (
        <div className="Link">
            <Link to="/portfolio" className="link-porfolio">Portfolio</Link>
            <Link to="/cv" className="link-cv">CV</Link>
        </div>
    )
}