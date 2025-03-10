import React, { useState, useEffect } from "react";
import axios from "axios";
import ImageSelect from "./ImageSelect";
import DeleteLangagesButton from "./DeleteLangageButton";
import "./styleLangageAdmin.css";

const API = "http://localhost:5064/api/langages";

interface Langages {
    langageId : number;
    nom : string;
    iconePath : string;
}

interface NewLangage {
    nom : string;
    iconePath : string;
}

export default function LangageAdmin() {

    const [newLangage, setNewLangage] = useState<NewLangage>({ nom : "", iconePath : "" });
    const [langages, setLangage] = useState<Langages[]>([]);

    useEffect(() => {
        fetchLangages().catch();
    }, []);

    const fetchLangages = async () => {
        try {
            const reponse = await axios.get<Langages[]>(API);
            console.log(reponse.data);
            setLangage(reponse.data);
        } catch (error) {
            console.log(error);
        }
    }

    const postTechno = async () => {
        if (newLangage.nom && newLangage.iconePath) {
            try {
                const reponse = await axios.post(API, newLangage)
                setLangage([...langages, reponse.data]);
                setNewLangage({nom : "", iconePath : "" });
            } catch (error) {
                console.log(error);
            }
        }
    }

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setNewLangage({ ...newLangage, [e.target.name]: e.target.value });
    }
    const handleImageChange = (value: string) => {
        setNewLangage({ ...newLangage, iconePath: value });
    };

    return (
        <div className="LangageAdminContainer">
            <h2>Gestion des Langages</h2>
            <div className="AddLangageForm">
                <input
                    type="text"
                    name="nom"
                    placeholder="Nom du langage"
                    value={newLangage.nom}
                    onChange={handleChange}
                />
                <ImageSelect value={newLangage.iconePath} onChange={handleImageChange} />
                <button onClick={postTechno}>Ajouter</button>
            </div>

            <ul className="LangageList">
                {langages.map((langage) => (
                    <li key={langage.langageId} className="LangageItem">
                        <img src={langage.iconePath} alt={langage.nom} className="LangageImage" />
                        <span>{langage.nom}</span>
                        <DeleteLangagesButton id={langage.langageId} onDeleteSuccess={fetchLangages} />
                    </li>
                ))}
            </ul>
        </div>
    )






}