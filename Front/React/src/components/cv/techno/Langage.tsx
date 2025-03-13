import React, {useEffect, useState} from "react";
import axios from "axios";
import "./styleTechno.css";


const API = "http://localhost:5064/api/langages"

interface Langages {
    "langageId": number,
    "nom": string,
    "iconePath": string
}

export default function Langage() {
    const [langages, setLangage] = useState<Langages[]>([])

    useEffect(() => {
        fetchLangage().catch()
    }, []);

    const fetchLangage = async () => {
        try {
            const reponse = await axios.get(API)
            setLangage(reponse.data);
        } catch (error) {
            console.log(error)
        }
    }

    return (
        <div className="LangageCompetenceCard">
            <div className="CvTitreDiv">
                <p className="CvTitre">
                    Langage
                </p>
            </div>
            {langages.map(langage => (
                <div className="TechnoLangageCompetence" key={langage.langageId}>
                    <img src={langage.iconePath} alt={langage.nom} />
                    <p className="TechnoLangageNom">{langage.nom}</p>
                </div>
            ))}
        </div>
    )

}