import React, {useEffect, useState} from 'react';
import axios from "axios";
import "../styles/Project.css";

const API = "http://51.83.75.252:5240/api"

interface Project {
    idProject : number;
    title : string;
    description : string;
    githubLink : string;
    webLink : string;
    imagePaths : string[];
    technoPaths : string[];
}


export default function Projects() {

    const [projects, setProjects] = useState<Project[]>([]);

    useEffect(() => {
        fetchProjects().catch();
    }, []);

    const fetchProjects = async () => {
        try {
            const reponse = await axios.get<Project[]>(`${API}/project/all`);
            console.log("Données des projets :", reponse.data);
            setProjects(reponse.data);
        } catch (error) {
            console.error("Erreur lors de la récuperations des projets", error);
        }
    };

    return (
        <div className="Projet">
            {projects.map((project) => (
                <div key={project.idProject} className="Card">
                    <div className="TitleDiv">
                        <p className="Title">{project.title}</p>
                    </div>
                    <div className="TechnoDiv">
                        <p className="Techno">Technos :</p>
                        {project.technoPaths.length > 0 && (
                            project.technoPaths.map((path, index) => (
                                <img key={index} src={path} alt={`Techno, ${index}`} className="TechnoImg" />
                            ))
                        )}
                    </div>
                    <div className="ImageDiv">
                        {project.imagePaths.length > 0 && (
                            project.imagePaths.map((path, index) => (
                                <img key={index} src={path} alt={`Image, ${index}`} className="ImageImg" />
                            ))
                        )}
                    </div>
                    <div className="GitDiv">
                        <a href={project.githubLink} target="_blank" rel="noreferrer" className="GitImg">
                            <img src="/Logo/github.svg" alt="GitHub" className="GithubImg"/>
                        </a>
                        <a href={project.githubLink} target="_blank" rel="noopener noreferrer" className="Github">Voir le repo sur Github</a>
                    </div>
                    <div className="WebDiv">
                        {project.webLink ? (
                            <>
                                <a href={project.webLink} target="_blank" rel="noreferrer" className="WImg"><img src="/Logo/web.svg" alt="Web" className="WebImg"/></a>
                                <a href={project.webLink} target="_blank" rel="noopener noreferrer" className="Web">Voir le site web</a>
                            </>
                        ) : (
                            <p></p>
                        )}
                    </div>
                </div>
            ))}
        </div>
    )
}