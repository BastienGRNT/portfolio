import React from "react";
import axios from "axios";

const API = "http://localhost:5064/api/centre-interet";

interface DeleteCentreInteretButtonProps {
    id: number;
    onDeleteSuccess: () => void;
}

export default function DeleteCentreInteretButton({ id, onDeleteSuccess }: DeleteCentreInteretButtonProps) {
    const handleClick = async () => {
        if (window.confirm("Voulez-vous vraiment supprimer ce centre d'intérêt ?")) {
            try {
                const deleteUrl = `${API}/${id}`;
                await axios.delete(deleteUrl);
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
