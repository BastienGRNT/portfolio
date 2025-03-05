import React, { useState, useEffect } from "react";
import axios from "axios";
import DeleteCentreInteretButton from "./DeleteCentreInteretButton";
import "./styleCentreInteretAdmin.css";

const API = "http://localhost:5064/api/centre-interet";

interface CentreInteret {
    idCentreInteret: number;
    nom: string;
}

interface NewCentreInteret {
    nom: string;
}

export default function CentreInteretAdmin() {
    const [centresInteret, setCentresInteret] = useState<CentreInteret[]>([]);
    const [newCentreInteret, setNewCentreInteret] = useState<NewCentreInteret>({
        nom: "",
    });

    useEffect(() => {
        fetchCentresInteret().catch();
    }, []);

    const fetchCentresInteret = async () => {
        try {
            const response = await axios.get<CentreInteret[]>(API);
            setCentresInteret(response.data);
        } catch (error) {
            console.log("Erreur lors de la récupération des centres d'intérêt :", error);
        }
    };

    const postCentreInteret = async () => {
        if (newCentreInteret.nom) {
            try {
                const response = await axios.post(API, newCentreInteret);
                setCentresInteret([...centresInteret, response.data]);
                setNewCentreInteret({ nom: "" });
            } catch (error) {
                console.log("Erreur lors de l'ajout du centre d'intérêt :", error);
            }
        }
    };

    return (
        <div className="CentresInteretAdminContainer">
            <h2>Gestion des Centres d'Intérêt</h2>

            <div className="AddCentreInteretForm">
                <input
                    type="text"
                    placeholder="Nom du centre d'intérêt"
                    value={newCentreInteret.nom}
                    onChange={(e) => setNewCentreInteret({ nom: e.target.value })}
                />
                <button onClick={postCentreInteret}>Ajouter</button>
            </div>

            <table className="CentresInteretTable">
                <thead>
                <tr>
                    <th>Nom</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {centresInteret.map((centre) => (
                    <tr key={centre.idCentreInteret}>
                        <td>{centre.nom}</td>
                        <td>
                            <DeleteCentreInteretButton
                                id={centre.idCentreInteret}
                                onDeleteSuccess={fetchCentresInteret}
                            />
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}
