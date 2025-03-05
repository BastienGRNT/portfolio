import React, {useEffect, useState} from "react";
import axios from "axios";
import "../styles/Etudes.css"

const API = "http://localhost:5064/api"

interface Etudes {
    etudeId : number;
    description : string,
    titre: string,
    dateDebut: Date,
    dateFin: Date | null,
    lieu: string
}


export default function Etudes() {

    const [etudes, setEtudes] = useState<Etudes[]>([]);

    useEffect(() => {
        fetchEtudes().catch()
    }, []);

    const fetchEtudes = async () => {
        try {
            const reponse = await axios.get<Etudes[]>(`${API}/etudes`);
            console.log(reponse.data)
            setEtudes(reponse.data)
        } catch (error) {
            console.log(error);
        }
    }

    return (
        <div className="EtudesCard">
            {etudes.map((etude) => (
                <div className="EtudeCard" key={etude.etudeId}>
                    <div className="DescEtude">
                        <p className="EtudeTitre">{etude.titre}</p>
                    </div>
                    <div className="EtudeInfo">
                        <time className="dateD">
                            {new Date(etude.dateDebut).toLocaleDateString()}
                        </time>
                        {etude.dateFin !== null ? (
                            <time className="ExpDateF">
                                {new Date(etude.dateFin).toLocaleDateString()}
                            </time>
                        ) : (
                            <p className="DateFinNull">Aujourd'hui</p>
                        )}
                        <p className="Lieux">{etude.lieu}</p>
                    </div>
                </div>
            ))}
        </div>
    )
}