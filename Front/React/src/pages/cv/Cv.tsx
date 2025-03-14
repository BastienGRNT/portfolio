import Technos from "../../components/cv/techno/Techno";
import ExperiencePro from "../../components/cv/experiencePro/ExperiencePro";
import HardSkills from "../../components/cv/hardSkill/HardSkill";
import Etudes from "../../components/cv/etude/Etude";
import Formations from "../../components/cv/formation/Formation";
import Divers from "../../components/cv/divers/Divers";
import CentresInteret from "../../components/cv/centreInteret/CentreInteret";
import "./styleCv.css";
import Langage from "../../components/cv/techno/Langage";

export default function Cv() {
    return (
        <div className="container">
            <Technos/>
            <ExperiencePro/>
            <div className="rightColumn">
                <HardSkills/>
                <Etudes/>
            </div>
            <Formations/>
            <Divers/>
            <CentresInteret/>
            <Langage/>
        </div>
    );
}