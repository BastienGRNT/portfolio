import {Link} from "react-router-dom";
import React from "react";
import "./styleTitle.css";

export default function Titles() {
    return (
        <div className="HeaderTitle">
            <Link to="/" className="header-link-title">GRENOT BASTIEN</Link>
        </div>
    )
}