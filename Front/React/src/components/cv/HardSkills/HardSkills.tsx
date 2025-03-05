import React, {useEffect, useState} from "react";
import "./HardSkills.css"
import axios from "axios";

interface HardSkills {
    hardSkillId : number;
    nom : string;
}

const API = "http://localhost:5064/api"

export default function HardSkills() {

    const [hardSkills, setHardSkills] = useState<HardSkills[]>([])

    useEffect(() => {
        fetchHardSkills().catch()
    }, []);

    const fetchHardSkills = async () => {
        try {
            const reponse = await axios.get<HardSkills[]>(`${API}/hard-skills`);
            console.log("données récuperer", reponse.data);
            setHardSkills(reponse.data);
        }
        catch (error) {
            console.error(error);
        }
    }

    return (
        <div className="HardSkillsCard">
            <p className="TitreCV">Hard Skills</p>
            {hardSkills.map(hardSkill => (
                    <p className="Hd" key={hardSkill.hardSkillId}>{hardSkill.nom}</p>
                ))}
        </div>
    )
}