CREATE TABLE UploadImage (
                             IdUploadImage SERIAL PRIMARY KEY,
                             Name VARCHAR(255) NOT NULL,
                             Extension VARCHAR(25) NOT NULL,
                             FinalName VARCHAR(255) NOT NULL,
                             FinalPath TEXT NOT NULL,
                             FullPath TEXT NOT NULL,
                             HttpPath TEXT NOT NULL UNIQUE
);

CREATE TABLE UploadTechno (
                              IdUploadTechno SERIAL PRIMARY KEY,
                              Name VARCHAR(100) NOT NULL UNIQUE,
                              Extension VARCHAR(25) NOT NULL,
                              FinalName VARCHAR(255) NOT NULL,
                              FinalPath TEXT NOT NULL,
                              FullPath TEXT NOT NULL,
                              HttpPath TEXT NOT NULL UNIQUE
);

CREATE TABLE Project (
                         IdProject SERIAL PRIMARY KEY,
                         Title VARCHAR(255) NOT NULL,
                         Description TEXT NOT NULL,
                         GithubLink TEXT NOT NULL,
                         WebLink TEXT NOT NULL,
                         CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                         UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE ProjectImage (
                              IdProject INT,
                              IdUploadImage INT,
                              PRIMARY KEY (IdProject, IdUploadImage),
                              FOREIGN KEY (IdProject) REFERENCES Project(IdProject) ON DELETE CASCADE,
                              FOREIGN KEY (IdUploadImage) REFERENCES UploadImage(IdUploadImage) ON DELETE CASCADE
);

CREATE TABLE ProjectTechno (
                               IdProject INT,
                               IdUploadTechno INT,
                               PRIMARY KEY (IdProject, IdUploadTechno),
                               FOREIGN KEY (IdProject) REFERENCES Project(IdProject) ON DELETE CASCADE,
                               FOREIGN KEY (IdUploadTechno) REFERENCES UploadTechno(IdUploadTechno) ON DELETE CASCADE
);
