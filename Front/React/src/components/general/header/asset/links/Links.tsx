import React from "react";
import { Link } from "react-router-dom";
import "./styleLink.css"


export default function Links() {
    return (
        <div className="HeaderLink">
            <Link to="/portfolio" className="header-link-porfolio">Portfolio</Link>
            <Link to="/cv" className="header-link-cv">CV</Link>
        </div>
    )
}