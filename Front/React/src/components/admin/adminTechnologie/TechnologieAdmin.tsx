import React, { useState, useEffect } from "react";
import axios from "axios";
import IconSelect from "./IconSelect";
import DeleteTechnologieButton from "./DeleteTechnologieButton";
import "./styleTechnologieAdmin.css";

const API = "http://localhost:5064/api/technologies";

interface Technos {
    technologieId: number;
    nom: string;
    iconePath: string;
}

interface NewTechno {
    nom: string;
    iconePath: string;
}

export default function TechnologieAdmin() {
    const [newTechno, setNewTechno] = useState<NewTechno>({ nom: "", iconePath: "" });
    const [technos, setTechnos] = useState<Technos[]>([]);

    useEffect(() => {
        fetchTechnos().catch();
    }, []);

    const fetchTechnos = async () => {
        try {
            const response = await axios.get<Technos[]>(API);
            setTechnos(response.data);
        } catch (error) {
            console.log(error);
        }
    };

    const postTechno = async () => {
        if (newTechno.nom && newTechno.iconePath) {
            try {
                const response = await axios.post(API, newTechno);
                setTechnos([...technos, response.data]);
                setNewTechno({ nom: "", iconePath: "" });
            } catch (error) {
                console.log(error);
            }
        }
    };

    // Gère les changements dans les inputs
    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setNewTechno({ ...newTechno, [e.target.name]: e.target.value });
    };

    // Gère le changement dans le select du composant IconSelect
    const handleIconChange = (value: string) => {
        setNewTechno({ ...newTechno, iconePath: value });
    };

    return (
        <div className="TechnoAdminContainer">
            <h2>Gestion des Technologies</h2>

            <div className="AddTechnoForm">
                <input
                    type="text"
                    name="nom"
                    placeholder="Nom de la technologie"
                    value={newTechno.nom}
                    onChange={handleChange}
                />
                <IconSelect value={newTechno.iconePath} onChange={handleIconChange} />
                <button onClick={postTechno}>Ajouter</button>
            </div>

            <ul className="TechnoList">
                {technos.map((techno) => (
                    <li key={techno.technologieId} className="TechnoItem">
                        <img src={techno.iconePath} alt={techno.nom} className="TechnoIcon" />
                        <span>{techno.nom}</span>
                        <DeleteTechnologieButton
                            id={techno.technologieId}
                            onDeleteSuccess={fetchTechnos}
                        />
                    </li>
                ))}
            </ul>
        </div>
    );
}
