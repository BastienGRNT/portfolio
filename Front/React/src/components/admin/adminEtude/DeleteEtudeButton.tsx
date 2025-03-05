import React from "react";
import axios from "axios";

const API = "http://localhost:5064/api/etudes";

interface DeleteEtudeButtonProps {
    id: number;
    onDeleteSuccess: () => void;
}

export default function DeleteEtudeButton({ id, onDeleteSuccess }: DeleteEtudeButtonProps) {
    const handleClick = async () => {
        if (window.confirm("Voulez-vous vraiment supprimer cette étude ?")) {
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
