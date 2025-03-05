import React, { useState, useEffect } from "react";
import axios from "axios";
import DeleteButton from "./DeleteHardSkillButton";
import "./styleHardSkillAdmin.css"

const API = "http://localhost:5064/api/hard-skills";

interface HardSkills {
    hardSkillId: number;
    nom: string;
}

interface NewHardSkills {
    nom: string;
}

export default function HardSkillAdmin() {
    const [hardSkills, setHardSkills] = useState<HardSkills[]>([]);
    const [newHardSkill, setNewHardSkill] = useState<NewHardSkills>({
        nom: "",
    });

    useEffect(() => {
        fetchHardSkills().catch();
    }, []);

    const fetchHardSkills = async () => {
        try {
            const reponse = await axios.get<HardSkills[]>(API);
            setHardSkills(reponse.data);
        } catch (error) {
            console.log("Erreur lors de la récupération des hard skills :", error);
        }
    };

    const postHardSkill = async () => {
        if (newHardSkill.nom) {
            try {
                const reponse = await axios.post(API, newHardSkill);
                setHardSkills([...hardSkills, reponse.data]);
                setNewHardSkill({ nom: "" });
            } catch (error) {
                console.log("Erreur lors de l'ajout de la hard skill :", error);
            }
        }
    };

    return (
        <div className="HardSkillsAdminContainer">
            <h2>Gestion des Hard Skills</h2>

            <div className="AddHardSkillForm">
                <input
                    type="text"
                    placeholder="Nom de la hard skill"
                    value={newHardSkill.nom}
                    onChange={(e) => setNewHardSkill({ nom: e.target.value })}
                />
                <button onClick={postHardSkill}>Ajouter</button>
            </div>

            <table className="HardSkillsTable">
                <thead>
                <tr>
                    <th>Nom</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {hardSkills.map((hardSkill) => (
                    <tr key={hardSkill.hardSkillId}>
                        <td>{hardSkill.nom}</td>
                        <td>
                            <DeleteButton
                                id={hardSkill.hardSkillId}
                                onDeleteSuccess={fetchHardSkills} // Rafraîchit la liste après suppression
                            />
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}
