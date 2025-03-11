import Links from "./links/Links"
import Social from "./social/Social";
import Titles from "./title/Title";
import SwitchTheme from "./SwitchTheme/SwitchTheme";
import "./styleHeader.css";

export default function Header() {

    return (
        <header className="Header">
            <nav className="Navbar">
                <Links/>
                <Titles/>
                <Social/>
                <SwitchTheme/>
            </nav>
        </header>
    );
}