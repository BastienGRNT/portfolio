import Links from "./asset/links/Links"
import Social from "./asset/social/Social";
import Titles from "./asset/title/Title";
import SwitchTheme from "./asset/SwitchTheme/SwitchTheme";
import {MenuBurger} from "./asset/menuburger/MenuBurger";
import "./styleHeader.css";

export default function Header() {

    return (
        <header className="Header">
            <nav className="Navbar">
                <MenuBurger/>
                <div className="HeaderLinksComponant">
                    <Links/>
                </div>
                <Titles/>
                <div className="HeaderSocialComponant">
                    <Social/>
                </div>
                <div className="HeaderThemeComponant">
                    <SwitchTheme/>
                </div>
            </nav>
        </header>
    );
}