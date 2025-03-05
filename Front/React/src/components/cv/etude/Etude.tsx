import React, {useEffect, useState} from "react";
import axios from "axios";
import "./styleEtude.css"

const API = "http://localhost:5064/api/etudes"

interface Etude {
    etudeId : number;
    description : string,
    titre: string,
    dateDebut: Date,
    dateFin: Date | null,
    lieu: string
}


export default function Etudes() {

    const [etudes, setEtudes] = useState<Etude[]>([]);

    useEffect(() => {
        fetchEtudes().catch()
    }, []);

    const fetchEtudes = async () => {
        try {
            const reponse = await axios.get<Etude[]>(API);
            setEtudes(reponse.data)
        } catch (error) {
            console.log(error);
        }
    }

    return (
        <div className="EtudesCard">
            <p className="TitreCV">Etudes</p>
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