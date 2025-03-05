import Experiences from "../../components/cv/Experiences/Experiences";
import HardSkills from "../../components/cv/HardSkills/HardSkills";
import Etudes from "../../components/cv/Etudes/Etudes";
import Technos from "../../components/cv/Technos/Technos";
import Formations from "../../components/cv/Formations/Formations";
import Divers from "../../components/cv/Divers/Divers";
import CentresInteret from "../../components/cv/CentresInteret/CentresInteret";
import "./Cv.css"

export default function Debug() {
    return (
        <div className="container">
            <Technos/>
            <Experiences/>
            <HardSkills/>
            <Etudes/>
            <Formations/>
            <Divers/>
            <CentresInteret/>
        </div>
    );
}