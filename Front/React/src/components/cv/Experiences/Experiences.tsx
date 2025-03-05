import React, {useEffect, useState} from "react";
import axios from "axios";
import "./Experiences.css"

const API = "http://localhost:5064/api"

interface Experience {
    experienceId : number;
    titre : string;
    description : string;
    entreprises : string;
    dateDebut : Date;
    dateFin : Date | null;
    competences : string[];
}

export default function Experiences(){

    const [experiences, setExperiences] = useState<Experience[]>([]);

    useEffect(() => {
        fetchExperiences().catch();
    }, []);


    const fetchExperiences = async () => {

        try {
            const reponse = await axios.get<Experience[]>(`${API}/experience-pro`);
            console.log("données des experiences :", reponse.data);
            setExperiences(reponse.data);
        } catch (error) {
            console.log("erreur lors de la récupération des projets", error);
        }
    }


    return (
        <div className="experiences">
            <p className="TitreCV">Experiences Professionnelles</p>
            <div className="experiences-wrapper">
                {experiences.map((experience) => (
                    <div key={experience.experienceId} className="ExpCard">
                        <div className="DivExpTitre">
                            <p className="ExpTitre">{experience.titre}</p>
                        </div>
                        <div className="DivExpDesc">
                            <p className="ExpDesc">{experience.description}</p>
                            <time className="ExpDateD">
                                {new Date(experience.dateDebut).toLocaleDateString()}
                            </time>
                            {experience.dateFin !== null ? (
                                <time className="ExpDateF">
                                    {new Date(experience.dateFin).toLocaleDateString()}
                                </time>
                            ) : (
                                <p className="ExpDateA">Aujourd'hui</p>
                            )}
                        </div>
                        <div className="ExpCompetenceDiv">
                            {experience.competences.length > 0 && (
                                experience.competences.map((competence, index) => (
                                    <p className="ExpCompetence" key={index}>{competence}</p>
                                ))
                            )}
                        </div>
                    </div>
                ))}
            </div>
        </div>
    )
}