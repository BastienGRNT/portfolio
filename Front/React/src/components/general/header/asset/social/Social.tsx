import React from "react";
import "./styleSocial.css";
import {Github, Linkedin, UserProfile} from "../svg/Svg";

export default function Social() {
    return (
        <div className="HeaderIcon">
            <a href="https://www.linkedin.com/in/bastiengrnt/" target="_blank" rel="noreferrer">
                <Linkedin/>
            </a>
            <a href="https://github.com/BastienGRNT" target="_blank" rel="noreferrer">
                <Github/>
            </a>
            <a href="mailto:bastien.grenot@gmail.com" target="_blank" rel="noreferrer">
                <UserProfile/>
            </a>
        </div>
    )
}