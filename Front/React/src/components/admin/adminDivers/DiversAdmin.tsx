import React, { useState, useEffect } from "react";
import axios from "axios";
import DeleteDiversButton from "./DeleteDiversButton";
import "./styleDiversAdmin.css";

const API = "http://localhost:5064/api/divers";

interface Divers {
    diversId: number;
    description: string;
}

interface NewDivers {
    description: string;
}

export default function DiversAdmin() {
    const [divers, setDivers] = useState<Divers[]>([]);
    const [newDivers, setNewDivers] = useState<NewDivers>({
        description: "",
    });

    useEffect(() => {
        fetchDivers().catch();
    }, []);

    const fetchDivers = async () => {
        try {
            const response = await axios.get<Divers[]>(API);
            setDivers(response.data);
        } catch (error) {
            console.log("Erreur lors de la récupération des divers :", error);
        }
    };

    const postDivers = async () => {
        if (newDivers.description) {
            try {
                const response = await axios.post(API, newDivers);
                setDivers([...divers, response.data]);
                setNewDivers({ description: "" });
            } catch (error) {
                console.log("Erreur lors de l'ajout du divers :", error);
            }
        }
    };

    return (
        <div className="DiversAdminContainer">
            <h2>Gestion des Divers</h2>

            <div className="AddDiversForm">
                <input
                    type="text"
                    placeholder="Description"
                    value={newDivers.description}
                    onChange={(e) => setNewDivers({ description: e.target.value })}
                />
                <button onClick={postDivers}>Ajouter</button>
            </div>

            <table className="DiversTable">
                <thead>
                <tr>
                    <th>Description</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {divers.map((div) => (
                    <tr key={div.diversId}>
                        <td>{div.description}</td>
                        <td>
                            <DeleteDiversButton
                                id={div.diversId}
                                onDeleteSuccess={fetchDivers}
                            />
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}
