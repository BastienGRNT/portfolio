import React, { useEffect, useState } from "react";
import axios from "axios";

const API_UPLOAD = "http://51.83.75.252:5240/api/techno/all";

interface UplaodTechno {
    idUploadTechno: number;
    name: string;
    httpPath: string;
}

interface ImageSelectProps {
    value: string;
    onChange: (value: string) => void;
}

export default function ImageSelect({ value, onChange }: ImageSelectProps) {

    const [uploads, setUpload] = useState<UplaodTechno[]>([])

    useEffect(() => {
        fetchUploads().catch();
    }, []);

    const fetchUploads = async () => {
        try {
            const response = await axios.get<UplaodTechno[]>(API_UPLOAD);
            setUpload(response.data);
        } catch (error) {
            console.log(error);
        }
    }

    return (
        <select value={value} onChange={(e) => onChange(e.target.value)}>
            <option value="">-- Selectionner un langage --</option>
            {uploads.map((upload) => (
                <option key={upload.idUploadTechno} value={upload.httpPath}>
                    {upload.name}
                </option>
            ))}
        </select>
    );
}