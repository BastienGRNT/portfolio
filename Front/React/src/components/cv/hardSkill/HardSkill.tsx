import React, {useEffect, useState} from "react";
import "./styleHardSkill.css"
import axios from "axios";

interface HardSkill {
    hardSkillId : number;
    nom : string;
}

const API = "http://localhost:5064/api/hard-skills"

export default function HardSkills() {

    const [hardSkills, setHardSkills] = useState<HardSkill[]>([])

    useEffect(() => {
        fetchHardSkills().catch()
    }, []);

    const fetchHardSkills = async () => {
        try {
            const reponse = await axios.get<HardSkill[]>(API);
            setHardSkills(reponse.data);
        }
        catch (error) {
            console.error(error);
        }
    }

    return (
        <div className="harskill">
            <div className="CvTitreDiv">
                <p className="CvTitre">
                    HardSkills
                </p>
            </div>
            <div className="HardSkillsCard">
                {hardSkills.map(hardSkill => (
                    <div key={hardSkill.hardSkillId} className="HdDiv">
                        <p className="Hd" key={hardSkill.hardSkillId}>{hardSkill.nom}</p>
                    </div>
                ))}
            </div>
        </div>
    )
}