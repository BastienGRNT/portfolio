-- Table des expériences professionnelles
CREATE TABLE Experiences (
                             ExperienceID SERIAL PRIMARY KEY,
                             Titre VARCHAR(50) NOT NULL,
                             Description TEXT, -- Ajout de la description
                             Entreprise VARCHAR(50) NOT NULL,
                             DateDebut DATE NOT NULL,
                             DateFin DATE DEFAULT NULL -- NULL si l'expérience est en cours
);

-- Table des compétences liées aux expériences avec DELETE ON CASCADE
CREATE TABLE CompetencesExperiences (
                                        CompetenceExperienceID SERIAL PRIMARY KEY,
                                        Competence VARCHAR(50) NOT NULL,
                                        ExperienceID INT NOT NULL,
                                        FOREIGN KEY (ExperienceID) REFERENCES Experiences(ExperienceID) ON DELETE CASCADE
);

-- Table des projets
CREATE TABLE Projets (
                         ProjetID SERIAL PRIMARY KEY,
                         Description TEXT NOT NULL
);

-- Table des compétences techniques (Hard Skills)
CREATE TABLE HardSkills (
                            HardSkillID SERIAL PRIMARY KEY,
                            Nom VARCHAR(50) NOT NULL
);

-- Table des études avec gestion dynamique de la date de fin
CREATE TABLE Etudes (
                        EtudeID SERIAL PRIMARY KEY,
                        Description TEXT NOT NULL,
                        Titre VARCHAR(50) NOT NULL,
                        DateDebut DATE NOT NULL,
                        DateFin DATE DEFAULT NULL, -- NULL si les études sont en cours
                        Lieu VARCHAR(50) NOT NULL
);

-- Table des formations professionnelles
CREATE TABLE FormationsProfessionnelles (
                                            FormationID SERIAL PRIMARY KEY,
                                            Nom VARCHAR(100) NOT NULL
);

-- Table des centres d'intérêt
CREATE TABLE CentresInteret (
                                CentreInteretID SERIAL PRIMARY KEY,
                                Nom VARCHAR(50) NOT NULL
);

-- Table divers (pour des informations supplémentaires)
CREATE TABLE Divers (
                        DiversID SERIAL PRIMARY KEY,
                        Description VARCHAR(50)
);

-- Table des technologies utilisées
CREATE TABLE Technologies (
                              TechnologieID SERIAL PRIMARY KEY,
                              Nom VARCHAR(50) NOT NULL,
                              IconePath TEXT NOT NULL
);

CREATE TABLE Competence (
                            Id SERIAL PRIMARY KEY,       -- Identifiant unique (auto-incrémenté)
                            Nom VARCHAR(50) NOT NULL,    -- Nom de la compétence
                            Description TEXT             -- Description de la compétence (facultatif)
);
