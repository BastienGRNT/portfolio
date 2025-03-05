import React, {useEffect, useState} from "react";
import axios from "axios";
import "../styles/Technos.css"

const API = "http://localhost:5064/api"

interface Technos {
    "technologieId": number,
    "nom": string,
    "iconePath": string
}

export default function Technos() {

    const [technos, setTechno] = useState<Technos[]>([]);

    useEffect(() => {
        fetchTechno().catch()
    }, []);

    const fetchTechno = async () => {
        try {
            const reponse = await axios.get<Technos[]>(`${API}/technologies`);
            console.log(reponse.data);
            setTechno(reponse.data);
        } catch (error) {
            console.log(error)
        }
    }

    return(
        <div className="TechnoCompetenceCard">
            {technos.map(techno => (
                <div className="TechnoCompetence" key={techno.technologieId}>
                    <img src={techno.iconePath} alt={techno.nom} />
                    <p className="TechnoNom">{techno.nom}</p>
                </div>
            ))}
        </div>
    )
}