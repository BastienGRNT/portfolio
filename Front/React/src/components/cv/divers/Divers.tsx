import React, {useEffect, useState} from "react";
import axios from "axios";
import "./styleDivers.css"

const API = "http://localhost:5064/api/divers"

interface Divers {
    diversId : number,
    description: string
}

export default function Divers() {

    const [divers, setDivers] = useState<Divers[]>([])

    useEffect(() => {
        fetchDivers().catch()
    }, []);

    const fetchDivers = async () => {
        try {
            const reponse = await axios.get<Divers[]>(API);
            setDivers(reponse.data);
        } catch (error) {
            console.log(error)
        }
    }

    return (
        <div className="diver">
            <div className="CvTitreDiv">
                <p className="CvTitre">
                    Divers
                </p>
            </div>
            <div className="DiversCard">
                {divers.map((diver) => (
                    <div className="DiversDiv" key={diver.diversId}>
                        <p className="Divers">{diver.description}</p>
                    </div>
                ))}
            </div>
        </div>
    )
}