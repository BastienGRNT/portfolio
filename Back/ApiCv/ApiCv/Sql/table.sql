CREATE TABLE Experiences (
                             ExperienceID SERIAL PRIMARY KEY,
                             Titre VARCHAR(50) NOT NULL,
                             Description TEXT, -- Ajout de la description
                             Entreprise VARCHAR(50) NOT NULL,
                             DateDebut DATE NOT NULL,
                             DateFin DATE DEFAULT NULL -- NULL si l'expérience est en cours
);

CREATE TABLE CompetencesExperiences (
                                        CompetenceExperienceID SERIAL PRIMARY KEY,
                                        Competence VARCHAR(50) NOT NULL,
                                        ExperienceID INT NOT NULL,
                                        FOREIGN KEY (ExperienceID) REFERENCES Experiences(ExperienceID) ON DELETE CASCADE
);

CREATE TABLE HardSkill (
                            HardSkillID SERIAL PRIMARY KEY,
                            Nom VARCHAR(50) NOT NULL
);

CREATE TABLE Etude (
                        EtudeID SERIAL PRIMARY KEY,
                        Description TEXT NOT NULL,
                        Titre VARCHAR(50) NOT NULL,
                        DateDebut DATE NOT NULL,
                        DateFin DATE DEFAULT NULL,
                        Lieu VARCHAR(50) NOT NULL
);

CREATE TABLE FormationsProfessionnelles (
                                            FormationID SERIAL PRIMARY KEY,
                                            Nom VARCHAR(100) NOT NULL
);

CREATE TABLE CentreInteret (
                                CentreInteretID SERIAL PRIMARY KEY,
                                Nom VARCHAR(50) NOT NULL
);

CREATE TABLE Divers (
                        DiversID SERIAL PRIMARY KEY,
                        Description VARCHAR(50)
);

CREATE TABLE Technologies (
                              TechnologieID SERIAL PRIMARY KEY,
                              Nom VARCHAR(50) NOT NULL,
                              IconePath TEXT NOT NULL
);

CREATE TABLE Competence (
                            Id SERIAL PRIMARY KEY,
                            Nom VARCHAR(50) NOT NULL,
                            Description TEXT
);

CREATE TABLE Langages (
                              LangagesID SERIAL PRIMARY KEY,
                              Nom VARCHAR(50) NOT NULL,
                              IconePath TEXT NOT NULL
);
