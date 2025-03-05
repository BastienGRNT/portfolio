import React, { useState, useEffect } from "react";
import axios from "axios";
import ExperienceSelect from "./ExperienceSelect";
import DeleteButton from "./DeleteCompetenceButton";
import "./styleCompetenceAdmin.css";

const API = "http://localhost:5064/api/competence-experience";

interface Competence {
    competenceId: number;
    competence: string;
    experienceId: number;
}

interface NewCompetence {
    competence: string;
    experienceId: number;
}

export default function CompetenceAdmin() {
    const [competences, setCompetences] = useState<Competence[]>([]);
    const [newCompetence, setNewCompetence] = useState<NewCompetence>({
        competence: "",
        experienceId: 0,
    });

    useEffect(() => {
        fetchCompetences().catch();
    }, []);

    const fetchCompetences = async () => {
        try {
            const response = await axios.get<Competence[]>(API);
            setCompetences(response.data);
        } catch (error) {
            console.log("Erreur lors de la récupération des compétences :", error);
        }
    };

    const PostCompetences = async () => {
        if (newCompetence.competence && newCompetence.experienceId) {
            try {
                const response = await axios.post(`${API}/competence-experience`, newCompetence);
                setCompetences([...competences, response.data]);
                setNewCompetence({ competence: "", experienceId: 0 });
            } catch (error) {
                console.log("Erreur lors de l'ajout de la compétence :", error);
            }
        }
    };

    return (
        <div className="CompetencesAdminContainer">
            <h2>Gestion des Compétences par Expérience</h2>

            <div className="AddCompetenceForm">
                <input
                    type="text"
                    placeholder="Nom de la compétence"
                    value={newCompetence.competence}
                    onChange={(e) => setNewCompetence({ ...newCompetence, competence: e.target.value })}
                />
                <ExperienceSelect
                    value={newCompetence.experienceId}
                    onChange={(experienceId) =>
                        setNewCompetence({ ...newCompetence, experienceId })
                    }
                />
                <button onClick={PostCompetences}>Ajouter</button>
            </div>

            <table className="CompetencesTable">
                <thead>
                <tr>
                    <th>Nom</th>
                    <th>Expérience</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {competences.map((competence) => (
                    <tr key={competence.competenceId}>
                        <td>{competence.competence}</td>
                        <td>{competence.experienceId}</td>
                        <td>
                            <DeleteButton
                                id={competence.competenceId}
                                onDeleteSuccess={fetchCompetences}
                            />
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}
