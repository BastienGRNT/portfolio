import React, {useEffect, useState} from "react";
import axios from "axios";
import "./styleTechno.css"

const API = "http://localhost:5064/api/technologies"

interface Techno {
    "technologieId": number,
    "nom": string,
    "iconePath": string
}

export default function Technos() {

    const [technos, setTechno] = useState<Techno[]>([]);

    useEffect(() => {
        fetchTechno().catch()
    }, []);

    const fetchTechno = async () => {
        try {
            const reponse = await axios.get<Techno[]>(API);
            setTechno(reponse.data);
        } catch (error) {
            console.log(error)
        }
    }

    return(
        <div className="TechnoCompetenceCard">
            <p className="TitreCV"> Technologies</p>
            {technos.map(techno => (
                <div className="TechnoCompetence" key={techno.technologieId}>
                    <img src={techno.iconePath} alt={techno.nom} />
                    <p className="TechnoNom">{techno.nom}</p>
                </div>
            ))}
        </div>
    )
}