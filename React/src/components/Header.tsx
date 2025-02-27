import {Link, useNavigate} from "react-router-dom";
import "../styles/Header.css";

export default function Header() {

    const navigate = useNavigate();

    return (
        <header className="Header">
            <nav className="Navbar">
                <div className="Liste">
                    {/* eslint-disable-next-line jsx-a11y/anchor-is-valid */}
                    <a className="Liste-link">Portfolio</a>
                    {/* eslint-disable-next-line jsx-a11y/anchor-is-valid */}
                    <a className="Liste-link">CV</a>
                </div>
                <div className="Titles">
                    {/* eslint-disable-next-line jsx-a11y/anchor-is-valid */}
                    <Link to="/" className="Title-link">GRENOT BASTIEN</Link>
                </div>
                <div className="Social">
                    <a href="https://www.linkedin.com/in/bastiengrnt/" target="_blank" rel="noreferrer"><img src="/Logo/linkedin.svg" alt="LinkedIn"/></a>
                    <a href="https://github.com/BastienGRNT" target="_blank" rel="noreferrer"><img src="/Logo/github.svg" alt="Github"/></a>
                    <a href="mailto:bastien.grenot@gmail.com" target="_blank" rel="noreferrer"><img src="/Logo/gmail.svg" alt="Email"/></a>
                </div>
            </nav>
        </header>
    )
}