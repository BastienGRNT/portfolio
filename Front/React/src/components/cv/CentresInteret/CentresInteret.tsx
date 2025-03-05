import React, {useEffect, useState} from "react";
import axios from "axios";
import "./CentresInteret.css"


const API = "http://localhost:5064/api"

interface CentresInteret {
    idCentreInteret: number,
    nom: string
}


export default function CentresInteret() {

    const [centreInteret, setCentreInteret] = useState<CentresInteret[]>([])

    useEffect(() => {
        fetchCentresInteret().catch()
    }, []);

    const fetchCentresInteret = async () => {
        try {
            const reponse = await axios.get<CentresInteret[]>(`${API}/centre-interet`)
            console.log(reponse.data)
            setCentreInteret(reponse.data)
        }catch(error) {
            console.log(error)
        }
    }

    return (
        <div className="CentreInteretCard">
            <p className="TitreCV">Centre d'interet</p>
            {centreInteret.map((centreInterets) => (
                <div className="CentreInteret" key={centreInterets.idCentreInteret}>
                    <p className="CentreInteret">{centreInterets.nom}</p>
                </div>
                ))}
        </div>
    )
}