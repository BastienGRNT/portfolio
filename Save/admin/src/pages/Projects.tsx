import React, { useEffect, useState } from "react";
import axios from "axios";
import "../styles.css";

const API_URL = "http://localhost:5245/api/";

interface Project {
    idProject: number;
    title: string;
    description: string;
    githubLink: string;
    webLink: string;
}

interface Uploadable {
    id: number;
    name: string;
}

interface UploadFormProps {
    label: string;
    formState: { name: string; file: File | null };
    setFormState: React.Dispatch<React.SetStateAction<{ name: string; file: File | null }>>;
    onSubmit: () => void;
}

interface DropdownProps {
    label: string;
    items: Uploadable[];
    selected: number[];
    setSelected: React.Dispatch<React.SetStateAction<number[]>>;
}

export default function Projects() {
    const [projects, setProjects] = useState<Project[]>([]);
    const [showForm, setShowForm] = useState(false);
    const [newProject, setNewProject] = useState({ title: "", description: "", githubLink: "", webLink: "" });

    const [images, setImages] = useState<Uploadable[]>([]);
    const [technos, setTechnos] = useState<Uploadable[]>([]);
    const [selectedImages, setSelectedImages] = useState<number[]>([]);
    const [selectedTechnos, setSelectedTechnos] = useState<number[]>([]);

    const [showImageForm, setShowImageForm] = useState(false);
    const [showTechnoForm, setShowTechnoForm] = useState(false);
    const [newImage, setNewImage] = useState<{ name: string; file: File | null }>({ name: "", file: null });
    const [newTechno, setNewTechno] = useState<{ name: string; file: File | null }>({ name: "", file: null });

    useEffect(() => {
        fetchProjects().catch();
        fetchData("image/all", setImages).catch();
        fetchData("techno/all", setTechnos).catch();
    }, []);

    const fetchProjects = async () => {
        try {
            const response = await axios.get(`${API_URL}project/all`);
            setProjects(response.data);
        } catch (error) {
            console.error("Erreur lors de la récupération des projets", error);
        }
    };

    const fetchData = async (endpoint: string, setState: React.Dispatch<React.SetStateAction<Uploadable[]>>) => {
        try {
            const response = await axios.get(`${API_URL}${endpoint}`);
            setState(
                response.data.map((item: any) => ({
                    id: item.idUploadImage || item.idUploadTechno,
                    name: item.name
                }))
            );
        } catch (error) {
            console.error(`Erreur lors de la récupération de ${endpoint}`, error);
        }
    };

    const handleDeleteProject = async (id: number) => {
        if (!window.confirm("Es-tu sûr de vouloir supprimer ce projet ?")) return;
        try {
            await axios.delete(`${API_URL}project/${id}`);
            setProjects((prev) => prev.filter((p) => p.idProject !== id));
        } catch (error) {
            console.error("Erreur lors de la suppression du projet", error);
        }
    };

    const handleAddProject = async () => {
        const projectData = {
            title: newProject.title.trim(),
            description: newProject.description.trim(),
            githubLink: newProject.githubLink.trim(),
            webLink: newProject.webLink.trim(),
            imageIds: selectedImages,
            technoIds: selectedTechnos
        };

        try {
            await axios.post(`${API_URL}project/add`, projectData, { headers: { "Content-Type": "application/json" } });
            setShowForm(false);
            setNewProject({ title: "", description: "", githubLink: "", webLink: "" });
            setSelectedImages([]);
            setSelectedTechnos([]);
            await fetchProjects();
        } catch (error) {
            console.error("Erreur lors de l'ajout du projet", error);
        }
    };

    const handleUpload = async (type: "image" | "techno", data: { name: string; file: File | null }, setShowForm: React.Dispatch<React.SetStateAction<boolean>>, fetchFunction: () => Promise<void>) => {
        if (!data.name || !data.file) {
            alert(`Veuillez renseigner un nom et sélectionner un fichier pour ${type}.`);
            return;
        }

        const formData = new FormData();
        formData.append("Name", data.name);
        formData.append("File", data.file);

        try {
            await axios.post(`${API_URL}${type}/upload`, formData, {
                headers: { "Content-Type": "multipart/form-data" },
            });
            setShowForm(false);
            await fetchFunction();
        } catch (error) {
            console.error(`Erreur lors de l'ajout de ${type}`, error);
        }
    };

    return (
        <div className="container">
            <h1>Gestion des projets</h1>

            <button className="primary" onClick={() => setShowForm(!showForm)}>
                {showForm ? "Annuler" : "Ajouter un projet"}
            </button>

            {showForm && (
                <div className="form-container">
                    <h2>Ajouter un projet</h2>
                    {["title", "description", "githubLink", "webLink"].map((field) => (
                        <div className="form-group" key={field}>
                            <label>{field}</label>
                            <input type="text" value={newProject[field as keyof typeof newProject]} onChange={(e) => setNewProject({ ...newProject, [field]: e.target.value })} />
                        </div>
                    ))}

                    <Dropdown label="Images" items={images} selected={selectedImages} setSelected={setSelectedImages} />
                    <Dropdown label="Technologies" items={technos} selected={selectedTechnos} setSelected={setSelectedTechnos} />

                    <button className="primary" onClick={handleAddProject}>Ajouter le projet</button>
                </div>
            )}

            <button className="secondary" onClick={() => setShowImageForm(!showImageForm)}>Ajouter une image</button>
            {showImageForm && (
                <UploadForm label="Nouvelle image" formState={newImage} setFormState={setNewImage} onSubmit={() => handleUpload("image", newImage, setShowImageForm, () => fetchData("image/all", setImages))} />
            )}

            <button className="secondary" onClick={() => setShowTechnoForm(!showTechnoForm)}>Ajouter une techno</button>
            {showTechnoForm && (
                <UploadForm label="Nouvelle techno" formState={newTechno} setFormState={setNewTechno} onSubmit={() => handleUpload("techno", newTechno, setShowTechnoForm, () => fetchData("techno/all", setTechnos))} />
            )}

            <table>
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Titre</th>
                    <th>Description</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {projects.map((project) => (
                    <tr key={project.idProject}>
                        <td>{project.idProject}</td>
                        <td>{project.title}</td>
                        <td>{project.description}</td>
                        <td>
                            <button className="danger" onClick={() => handleDeleteProject(project.idProject)}>
                                Supprimer
                            </button>
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}

const Dropdown: React.FC<DropdownProps> = ({ label, items, selected, setSelected }) => (
    <div className="form-group">
        <label>{label}</label>
        <select multiple onChange={(e) => setSelected(Array.from(e.target.selectedOptions, (option) => Number(option.value)))}>
            {items.map((item) => (
                <option key={item.id} value={item.id}>{item.name}</option>
            ))}
        </select>
    </div>
);

const UploadForm: React.FC<UploadFormProps> = ({ label, formState, setFormState, onSubmit }) => (
    <div className="form-container">
        <h3>{label}</h3>
        <input type="text" placeholder="Nom" value={formState.name} onChange={(e) => setFormState({ ...formState, name: e.target.value })} />
        <input type="file" onChange={(e) => setFormState({ ...formState, file: e.target.files?.[0] || null })} />
        <button className="primary" onClick={onSubmit}>Ajouter</button>
    </div>
);
