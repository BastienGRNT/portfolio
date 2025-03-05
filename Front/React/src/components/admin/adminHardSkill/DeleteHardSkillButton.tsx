import React from "react";
import axios from "axios";

const API = "http://localhost:5064/api/hard-skills";

interface DeleteHardSkillButtonProps {
    id: number;
    onDeleteSuccess: () => void;
}

export default function DeleteHardSkillButton({ id, onDeleteSuccess }: DeleteHardSkillButtonProps) {
    const handleClick = async () => {
        if (window.confirm("Voulez-vous vraiment supprimer cette Hard Skill ?")) {
            try {
                await axios.delete(`${API}/${id}`);
                onDeleteSuccess();
            } catch (error) {
                console.log("Erreur lors de la suppression :", error);
            }
        }
    };

    return (
        <button className="DeleteButton" onClick={handleClick}>
            Supprimer
        </button>
    );
}
