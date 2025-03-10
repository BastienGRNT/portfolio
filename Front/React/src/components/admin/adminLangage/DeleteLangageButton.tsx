import React from "react";
import axios from "axios";

const API = "http://localhost:5064/api/langages";

interface DeleteButtonProps {
    id: number;
    onDeleteSuccess: () => void;
}

export default function DeleteLangagesButton({ id, onDeleteSuccess }: DeleteButtonProps) {
    const handleClick = async () => {
        if (window.confirm("Voulez-vous vraiment supprimer ce langages ?")) {
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
