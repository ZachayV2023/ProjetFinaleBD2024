-- Script DDL!

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DevLibraryDB')
BEGIN
    CREATE DATABASE DevLibraryDB;
END;
GO

USE DevLibraryDB;
GO

-- 'Utilisateur'
CREATE TABLE Utilisateur (
    IdUtilisateur INT PRIMARY KEY IDENTITY(1,1),
    Nom NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    DateInscription DATE NOT NULL,
    LangagesDeProgrammation NVARCHAR(MAX),
    BibliothequesPreferees NVARCHAR(MAX),
    Rue NVARCHAR(255),
    Ville NVARCHAR(255),
    Pays NVARCHAR(255),
    CodePostal NVARCHAR(20)
);
GO

CREATE UNIQUE INDEX UX_Utilisateur_Email ON Utilisateur(Email) WHERE Email IS NOT NULL;
GO

-- 'Bibliothèque'
CREATE TABLE Bibliothèque (
    IdBibliothèque INT PRIMARY KEY IDENTITY(1,1),
    Nom NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    DateCreation DATE,
    Categorie NVARCHAR(255),
    TotalTelechargements INT DEFAULT 0
);
GO

-- 'Mise à jour'
CREATE TABLE MiseÀJour (
    IdMiseÀJour INT PRIMARY KEY IDENTITY(1,1),
    Version NVARCHAR(50),
    DescMiseÀJour NVARCHAR(MAX),
    IdBibliothèque INT,
    FOREIGN KEY (IdBibliothèque) REFERENCES Bibliothèque(IdBibliothèque) ON DELETE CASCADE
);
GO

-- 'Critique'
CREATE TABLE Critique (
    IdCritique INT PRIMARY KEY IDENTITY(1,1),
    Date DATE,
    Message NVARCHAR(MAX),
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    NomUtilisateur NVARCHAR(255),
    ReplyCritique NVARCHAR(MAX),
    IdBibliothèque INT,
    FOREIGN KEY (IdBibliothèque) REFERENCES Bibliothèque(IdBibliothèque)
);
GO

-- 'Fonction'
CREATE TABLE Fonction (
    IdFonction INT PRIMARY KEY IDENTITY(1,1),
    Nom NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    NombreLignesDeCode INT,
    DernierUpdate DATE,
    IdBibliothèque INT,
    FOREIGN KEY (IdBibliothèque) REFERENCES Bibliothèque(IdBibliothèque)
);
GO

-- 'RéglageConfig'
CREATE TABLE RéglageConfig (
    IdConfig INT PRIMARY KEY IDENTITY(1,1),
    Theme NVARCHAR(255),
    nomMembre NVARCHAR(255),
    langPref NVARCHAR(50),
    notificationAct BIT DEFAULT 0
);
GO

-- 'UtilisateurBibliothèque' (table associative)
CREATE TABLE UtilisateurBibliothèque (
    IdUtilisateur INT,
    IdBibliothèque INT,
    DateTelechargement DATE,
    PRIMARY KEY (IdUtilisateur, IdBibliothèque),
    FOREIGN KEY (IdBibliothèque) REFERENCES Bibliothèque(IdBibliothèque)
);
GO

-- If 'RéglageConfig' one-to-one avec 'Utilisateur'
--ALTER TABLE Utilisateur
--ADD IdConfig INT UNIQUE,
--CONSTRAINT FK_Utilisateur_Config FOREIGN KEY (IdConfig) REFERENCES RéglageConfig(IdConfig);
--GO