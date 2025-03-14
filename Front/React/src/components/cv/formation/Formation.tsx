import React, {useEffect, useState} from "react";
import axios from "axios";
import "./styleFormation.css"

interface Formation {
    formationId: number,
    nom: string;
}


const API = "http://localhost:5064/api/formation"

export default function Formations() {

    const [formations, setFormations] = useState<Formation[]>([]);

    useEffect(() => {
        fetchFormation().catch()
    }, []);

    const fetchFormation = async () => {
        try {
            const reponse = await axios.get<Formation[]>(API);
            setFormations(reponse.data);
        } catch (error) {
            console.log(error);
        }
    }

    return (
        <div className="formation">
            <div className="CvTitreDiv">
                <p className="CvTitre">
                    Formations Pro
                </p>
            </div>
            <div className="FormationCard">
                {formations.map((formation) => (
                    <div className="formationDiv" key={formation.formationId}>
                        <p className="DescFormation">{formation.nom}</p>
                    </div>
                ))}
            </div>
        </div>

    )
}