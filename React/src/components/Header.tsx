import "../styles/Header.css";

export default function Header() {
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
                    <a className="Title-link">GRENOT Bastien</a>
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