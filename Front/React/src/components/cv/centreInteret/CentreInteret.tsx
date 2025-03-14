import React, {useEffect, useState} from "react";
import axios from "axios";
import "./styleCentreInteret.css"


const API = "http://localhost:5064/api/centre-interet"

interface CentreInteret {
    idCentreInteret: number,
    nom: string
}


export default function CentresInteret() {

    const [centreInteret, setCentreInteret] = useState<CentreInteret[]>([])

    useEffect(() => {
        fetchCentresInteret().catch()
    }, []);

    const fetchCentresInteret = async () => {
        try {
            const reponse = await axios.get<CentreInteret[]>(API)
            setCentreInteret(reponse.data)
        }catch(error) {
            console.log(error)
        }
    }

    return (
        <div className="interet">
            <div className="CvTitreDiv">
                <p className="CvTitre">
                    Centre d'interet
                </p>
            </div>
            <div className="CentreInteretCard">
                {centreInteret.map((centreInterets) => (
                    <div className="CentreInteret" key={centreInterets.idCentreInteret}>
                        <p className="CentreInteret">{centreInterets.nom}</p>
                    </div>
                ))}
            </div>
        </div>
    )
}