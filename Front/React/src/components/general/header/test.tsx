import React, {useState, useEffect, useRef, JSX} from 'react';
import { MenuBurgerSvg } from "./asset/Svg/Svg";
import Links from "./asset/links/Links";
import Social from "./asset/social/Social";
import SwitchTheme from "./asset/SwitchTheme/SwitchTheme";
import "./test.css";

export function MenuBurger(): JSX.Element {
    const [isOpen, setIsOpen] = useState<boolean>(false);
    const buttonRef = useRef<HTMLButtonElement>(null);
    const menuRef = useRef<HTMLDivElement>(null);

    const toggleMenu = (): void => {
        setIsOpen(!isOpen);
    };

    // Fermer le menu si on clique en dehors
    useEffect(() => {
        const handleClickOutside = (event: MouseEvent): void => {
            if (
                isOpen &&
                menuRef.current &&
                buttonRef.current &&
                !menuRef.current.contains(event.target as Node) &&
                !buttonRef.current.contains(event.target as Node)
            ) {
                setIsOpen(false);
            }
        };

        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        };
    }, [isOpen]);

    return (
        <div className="burger-container">
            <button
                ref={buttonRef}
                className="burger-icon"
                onClick={toggleMenu}
                aria-expanded={isOpen}
                aria-label="Menu de navigation"
            >
                <MenuBurgerSvg/>
            </button>

            <div
                ref={menuRef}
                className={`burger-menu ${isOpen ? 'open' : ''}`}
                aria-hidden={!isOpen}
            >
                <div className="menu-items">
                    <Links />
                    <Social />
                    <SwitchTheme />
                </div>
            </div>
        </div>
    );
}