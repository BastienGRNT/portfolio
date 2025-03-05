import { useNavigate } from "react-router-dom";
import "./Home.css";



export default function Home() {

    const navigate = useNavigate();

    return (
        <div className="Main">
            <div className="Main1">
                <div className="Home1">
                    <p className="Objet">Recherche d’alternance : </p>
                    <p className="Metier">Développeur informatique</p>
                </div>
                <div className="Home2">
                    <p className="ProjetHome">Passionné par la programmation, je conçois, développe et déploie des applications, sites web, logiciels et automatisations. Toujours prêt à relever de nouveaux défis, je cherche un stage pour mettre mes compétences en action. Et si ça matche, je serais aussi partant pour une alternance de deux ans à partir d’octobre 2025</p>
                </div>
            </div>
            <div className="Main2">
                <button className="Bouton" type="button" onClick={() => navigate("/me")}>En savoir plus sur moi</button>
                <a href="https://www.linkedin.com/in/ton-profil" target="_blank" rel="noreferrer">
                    <img src="/Logo/moi.svg" alt="LinkedIn"/>
                </a>
                <button className="Bouton" type="button" onClick={() => navigate("/project")}>Découvrir mes projets</button>
            </div>
        </div>
    )
}