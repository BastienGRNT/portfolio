import React, { useState, useEffect } from "react";
import axios from "axios";
import DeleteButton from "./DeleteButton";
import "./ExperiencesAdmin.css";

const API = "http://localhost:5064/api";

interface Experience {
    experienceId: number;
    titre: string;
    description: string;
    entreprise: string;
    dateDebut: string;
    dateFin: string | null;
}

interface NewExperience {
    titre: string;
    description: string;
    entreprise: string;
    dateDebut: string;
    dateFin: string | null;
}

export default function ExperienceAdmin() {
    const [experiences, setExperiences] = useState<Experience[]>([]);
    const [newExperience, setNewExperience] = useState<NewExperience>({
        titre: "",
        description: "",
        entreprise: "",
        dateDebut: "",
        dateFin: null,
    });

    useEffect(() => {
        fetchExperiences().catch();
    }, []);

    const fetchExperiences = async () => {
        try {
            const response = await axios.get<Experience[]>(`${API}/experience`);
            setExperiences(response.data);
        } catch (error) {
            console.log("Erreur lors de la récupération des expériences :", error);
        }
    };

    const handleAdd = async () => {
        if (newExperience.titre && newExperience.description && newExperience.dateDebut) {
            try {
                const response = await axios.post(`${API}/experience`, {
                    ...newExperience,
                    dateFin: newExperience.dateFin || null,
                });
                setExperiences([...experiences, response.data]);
                setNewExperience({
                    titre: "",
                    description: "",
                    entreprise: "",
                    dateDebut: "",
                    dateFin: null,
                });
            } catch (error) {
                console.log("Erreur lors de l'ajout de l'expérience :", error);
            }
        }
    };

    return (
        <div className="ExperienceAdminContainer">
            <h2>Gestion des Expériences</h2>

            <div className="AddExperienceForm">
                <input
                    type="text"
                    placeholder="Titre"
                    value={newExperience.titre}
                    onChange={(e) => setNewExperience({ ...newExperience, titre: e.target.value })}
                />
                <input
                    type="text"
                    placeholder="Description"
                    value={newExperience.description}
                    onChange={(e) => setNewExperience({ ...newExperience, description: e.target.value })}
                />
                <input
                    type="text"
                    placeholder="Entreprise"
                    value={newExperience.entreprise}
                    onChange={(e) => setNewExperience({ ...newExperience, entreprise: e.target.value })}
                />
                <input
                    type="date"
                    placeholder="Date de début"
                    value={newExperience.dateDebut}
                    onChange={(e) => setNewExperience({ ...newExperience, dateDebut: e.target.value })}
                />
                <input
                    type="date"
                    placeholder="Date de fin"
                    value={newExperience.dateFin || ""}
                    onChange={(e) =>
                        setNewExperience({
                            ...newExperience,
                            dateFin: e.target.value || null,
                        })
                    }
                />
                <button onClick={handleAdd}>Ajouter</button>
            </div>

            <table className="ExperienceTable">
                <thead>
                <tr>
                    <th>Titre</th>
                    <th>Description</th>
                    <th>Entreprise</th>
                    <th>Date Début</th>
                    <th>Date Fin</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {experiences.map((experience) => (
                    <tr key={experience.experienceId}>
                        <td>{experience.titre}</td>
                        <td>{experience.description}</td>
                        <td>{experience.entreprise}</td>
                        <td>{new Date(experience.dateDebut).toLocaleDateString()}</td>
                        <td>
                            {experience.dateFin
                                ? new Date(experience.dateFin).toLocaleDateString()
                                : "Aujourd'hui"}
                        </td>
                        <td>
                            <DeleteButton
                                id={experience.experienceId}
                                onDeleteSuccess={fetchExperiences}
                            />
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}
