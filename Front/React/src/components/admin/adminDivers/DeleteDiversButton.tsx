import React from "react";
import axios from "axios";

const API = "http://localhost:5064/api/divers";

interface DeleteDiversButtonProps {
    id: number;
    onDeleteSuccess: () => void;
}

export default function DeleteDiversButton({ id, onDeleteSuccess }: DeleteDiversButtonProps) {
    const handleClick = async () => {
        if (window.confirm("Voulez-vous vraiment supprimer cet élément ?")) {
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
