import React from "react";
import "./styleSocial.css";

export default function Social() {
    return (
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
        </div>
    )
}