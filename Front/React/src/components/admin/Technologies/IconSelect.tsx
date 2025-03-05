import React, { useEffect, useState } from "react";
import axios from "axios";

const API_UPLOAD = "http://51.83.75.252:5240/api";

interface UploadTechno {
    idUploadTechno: number;
    name: string;
    httpPath: string;
}

interface IconSelectProps {
    value: string;
    onChange: (value: string) => void;
}

export default function IconSelect({ value, onChange }: IconSelectProps) {
    const [uploads, setUploads] = useState<UploadTechno[]>([]);

    useEffect(() => {
        fetchUploads().catch();
    }, []);

    const fetchUploads = async () => {
        try {
            const response = await axios.get<UploadTechno[]>(`${API_UPLOAD}/techno/all`);
            setUploads(response.data);
        } catch (error) {
            console.log(error);
        }
    };

    return (
        <select value={value} onChange={(e) => onChange(e.target.value)}>
            <option value="">-- Sélectionner une icône --</option>
            {uploads.map((upload) => (
                <option key={upload.idUploadTechno} value={upload.httpPath}>
                    {upload.name}
                </option>
            ))}
        </select>
    );
}
