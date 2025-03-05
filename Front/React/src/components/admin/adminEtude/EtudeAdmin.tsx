import React, { useState, useEffect } from "react";
import axios from "axios";
import DeleteEtudeButton from "./DeleteEtudeButton";
import "./styleEtudeAdmin.css";

const API = "http://localhost:5064/api/etudes";

interface Etude {
    etudeId: number;
    description: string;
    titre: string;
    dateDebut: string;
    dateFin: string | null;
    lieu: string;
}

interface NewEtude {
    description: string;
    titre: string;
    dateDebut: string;
    dateFin: string | null;
    lieu: string;
}

export default function EtudeAdmin() {
    const [etudes, setEtudes] = useState<Etude[]>([]);
    const [newEtude, setNewEtude] = useState<NewEtude>({
        description: "",
        titre: "",
        dateDebut: "",
        dateFin: null,
        lieu: "",
    });

    useEffect(() => {
        fetchEtudes().catch();
    }, []);

    const fetchEtudes = async () => {
        try {
            const reponse = await axios.get<Etude[]>(API);
            setEtudes(reponse.data);
        } catch (error) {
            console.log("Erreur lors de la récupération des études :", error);
        }
    };

    const postEtude = async () => {
        if (newEtude.titre && newEtude.description && newEtude.dateDebut && newEtude.lieu) {
            try {
                const etudeData = {
                    ...newEtude,
                    dateFin: newEtude.dateFin || null,  // Envoie null si la date de fin est vide
                };
                const reponse = await axios.post(API, etudeData);
                setEtudes([...etudes, reponse.data]);
                setNewEtude({
                    description: "",
                    titre: "",
                    dateDebut: "",
                    dateFin: null,
                    lieu: "",
                });
            } catch (error) {
                console.log("Erreur lors de l'ajout de l'étude :", error);
            }
        }
    };

    return (
        <div className="EtudesAdminContainer">
            <h2>Gestion des Études</h2>

            <div className="AddEtudeForm">
                <input
                    type="text"
                    placeholder="Titre"
                    value={newEtude.titre}
                    onChange={(e) => setNewEtude({ ...newEtude, titre: e.target.value })}
                />
                <input
                    type="text"
                    placeholder="Description"
                    value={newEtude.description}
                    onChange={(e) => setNewEtude({ ...newEtude, description: e.target.value })}
                />
                <input
                    type="text"
                    placeholder="Lieu"
                    value={newEtude.lieu}
                    onChange={(e) => setNewEtude({ ...newEtude, lieu: e.target.value })}
                />
                <input
                    type="date"
                    placeholder="Date de début"
                    value={newEtude.dateDebut}
                    onChange={(e) => setNewEtude({ ...newEtude, dateDebut: e.target.value })}
                />
                <input
                    type="date"
                    placeholder="Date de fin"
                    value={newEtude.dateFin || ""}
                    onChange={(e) =>
                        setNewEtude({
                            ...newEtude,
                            dateFin: e.target.value || null,  // Met à jour avec null si vide
                        })
                    }
                />
                <button onClick={postEtude}>Ajouter</button>
            </div>

            <table className="EtudesTable">
                <thead>
                <tr>
                    <th>Titre</th>
                    <th>Description</th>
                    <th>Lieu</th>
                    <th>Date Début</th>
                    <th>Date Fin</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {etudes.map((etude) => (
                    <tr key={etude.etudeId}>
                        <td>{etude.titre}</td>
                        <td>{etude.description}</td>
                        <td>{etude.lieu}</td>
                        <td>{new Date(etude.dateDebut).toLocaleDateString()}</td>
                        <td>
                            {etude.dateFin
                                ? new Date(etude.dateFin).toLocaleDateString()
                                : "En cours"}
                        </td>
                        <td>
                            <DeleteEtudeButton
                                id={etude.etudeId}
                                onDeleteSuccess={fetchEtudes}
                            />
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}
