import ExperiencePro from "../../components/cv/experiencePro/ExperiencePro";
import HardSkills from "../../components/cv/hardSkill/HardSkill";
import Etudes from "../../components/cv/etude/Etude";
import Technos from "../../components/cv/techno/Techno";
import Formations from "../../components/cv/formation/Formation";
import Divers from "../../components/cv/divers/Divers";
import CentresInteret from "../../components/cv/centreInteret/CentreInteret";
import "./styleCv.css"

export default function Debug() {
    return (
        <div className="container">
            <Technos/>
            <ExperiencePro/>
            <HardSkills/>
            <Etudes/>
            <Formations/>
            <Divers/>
            <CentresInteret/>
        </div>
    );
}