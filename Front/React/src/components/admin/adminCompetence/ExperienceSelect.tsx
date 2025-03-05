import React, { useEffect, useState } from "react";
import axios from "axios";

const API = "http://localhost:5064/api";

interface Experience {
    experienceId: number;
    titre: string;
}

interface ExperienceSelectProps {
    value: number;
    onChange: (value: number) => void;
}

export default function ExperienceSelect({ value, onChange }: ExperienceSelectProps) {
    const [experiences, setExperiences] = useState<Experience[]>([]);

    useEffect(() => {
        fetchExperiences().catch();
    }, []);

    const fetchExperiences = async () => {
        try {
            const response = await axios.get<Experience[]>(`${API}/experience`);
            setExperiences(response.data);
        } catch (error) {
            console.log("Erreur lors de la récupération des expériences :", error);
        }
    };

    return (
        <select value={value} onChange={(e) => onChange(parseInt(e.target.value, 10))}>
            <option value={0}>-- Sélectionner une expérience --</option>
            {experiences.map((experience) => (
                <option key={experience.experienceId} value={experience.experienceId}>
                    {experience.titre}
                </option>
            ))}
        </select>
    );
}
