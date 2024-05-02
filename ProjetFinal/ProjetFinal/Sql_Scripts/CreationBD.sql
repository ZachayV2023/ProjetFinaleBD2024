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

-- 'Biblioth�que'
CREATE TABLE Biblioth�que (
    IdBiblioth�que INT PRIMARY KEY IDENTITY(1,1),
    Nom NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    DateCreation DATE,
    Categorie NVARCHAR(255),
    TotalTelechargements INT DEFAULT 0
);
GO

-- 'Mise � jour'
CREATE TABLE Mise�Jour (
    IdMise�Jour INT PRIMARY KEY IDENTITY(1,1),
    Version NVARCHAR(50),
    DescMise�Jour NVARCHAR(MAX),
    IdBiblioth�que INT,
    FOREIGN KEY (IdBiblioth�que) REFERENCES Biblioth�que(IdBiblioth�que) ON DELETE CASCADE
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
    IdBiblioth�que INT,
    FOREIGN KEY (IdBiblioth�que) REFERENCES Biblioth�que(IdBiblioth�que)
);
GO

-- 'Fonction'
CREATE TABLE Fonction (
    IdFonction INT PRIMARY KEY IDENTITY(1,1),
    Nom NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    NombreLignesDeCode INT,
    DernierUpdate DATE,
    IdBiblioth�que INT,
    FOREIGN KEY (IdBiblioth�que) REFERENCES Biblioth�que(IdBiblioth�que)
);
GO

-- 'R�glageConfig'
CREATE TABLE R�glageConfig (
    IdConfig INT PRIMARY KEY IDENTITY(1,1),
    Theme NVARCHAR(255),
    nomMembre NVARCHAR(255),
    langPref NVARCHAR(50),
    notificationAct BIT DEFAULT 0
);
GO

-- 'UtilisateurBiblioth�que' (table associative)
CREATE TABLE UtilisateurBiblioth�que (
    IdUtilisateur INT,
    IdBiblioth�que INT,
    DateTelechargement DATE,
    PRIMARY KEY (IdUtilisateur, IdBiblioth�que),
    FOREIGN KEY (IdBiblioth�que) REFERENCES Biblioth�que(IdBiblioth�que)
);
GO

-- If 'R�glageConfig' one-to-one avec 'Utilisateur'
--ALTER TABLE Utilisateur
--ADD IdConfig INT UNIQUE,
--CONSTRAINT FK_Utilisateur_Config FOREIGN KEY (IdConfig) REFERENCES R�glageConfig(IdConfig);
--GO