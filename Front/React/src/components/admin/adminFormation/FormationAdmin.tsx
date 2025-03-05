import React, { useState, useEffect } from "react";
import axios from "axios";
import DeleteFormationButton from "./DeleteFormationButton";
import "./styleFormationAdmin.css";

const API = "http://localhost:5064/api/formation";

interface Formation {
    formationId: number;
    nom: string;
}

interface NewFormation {
    nom: string;
}

export default function FormationAdmin() {
    const [formations, setFormations] = useState<Formation[]>([]);
    const [newFormation, setNewFormation] = useState<NewFormation>({
        nom: "",
    });

    useEffect(() => {
        fetchFormations().catch();
    }, []);

    const fetchFormations = async () => {
        try {
            const response = await axios.get<Formation[]>(API);
            setFormations(response.data);
        } catch (error) {
            console.log("Erreur lors de la récupération des formations :", error);
        }
    };

    const postFormation = async () => {
        if (newFormation.nom) {
            try {
                const response = await axios.post(API, newFormation);
                setFormations([...formations, response.data]);
                setNewFormation({ nom: "" });
            } catch (error) {
                console.log("Erreur lors de l'ajout de la formation :", error);
            }
        }
    };

    return (
        <div className="FormationsAdminContainer">
            <h2>Gestion des Formations</h2>

            <div className="AddFormationForm">
                <input
                    type="text"
                    placeholder="Nom de la formation"
                    value={newFormation.nom}
                    onChange={(e) => setNewFormation({ nom: e.target.value })}
                />
                <button onClick={postFormation}>Ajouter</button>
            </div>

            <table className="FormationsTable">
                <thead>
                <tr>
                    <th>Nom</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {formations.map((formation) => (
                    <tr key={formation.formationId}>
                        <td>{formation.nom}</td>
                        <td>
                            <DeleteFormationButton
                                id={formation.formationId}
                                onDeleteSuccess={fetchFormations}
                            />
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}
