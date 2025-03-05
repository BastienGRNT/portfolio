import React, {useEffect, useState} from "react";
import axios from "axios";
import "./Formations.css"

interface Formations {
    formationId: number,
    nom: string;
}


const API = "http://localhost:5064/api"

export default function Formations() {

    const [formations, setFormations] = useState<Formations[]>([]);

    useEffect(() => {
        fetchFormation().catch()
    }, []);

    const fetchFormation = async () => {
        try {
            const reponse = await axios.get<Formations[]>(`${API}/formation`);
            console.log(reponse.data);
            setFormations(reponse.data);
        } catch (error) {
            console.log(error);
        }
    }

    return (
        <div className="FormationCard">
            <p className="TitreCV">Formations Professionnelles</p>
            {formations.map((formation) => (
                <div className="formationDiv" key={formation.formationId}>
                    <p className="formation">{formation.nom}</p>
                </div>
            ))}
        </div>
    )
}