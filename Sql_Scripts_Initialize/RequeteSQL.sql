/* *****************************************************************************************************************************
TP04 --> Partie 4  (9 pts) : Remise Rencontre 13
Ceci va inclure:

	- Les requêtes pour les 5 questions. Chaque requête est associée à une question spécifique et conçue pour répondre aux critères d'évaluation.

	- Une vue pertinente et suffisamment complexe.

	- Une fonction répondant à une interrogation spécifique ou initialisant un nouveau champ.

	- Deux procédures :
		Une pour la généralisation d'une requête déjà réalisée.
		Une autre pour la création d'une procédure stockée (incluant les requêtes pour visualiser les deux procédures).

	- Un déclencheur (trigger) comprenant un SELECT, un INSERT et un SELECT.
***************************************************************************************************************************** */ 

USE DevLibraryDB;

-- *****************************************************************************************************************************
-- SECTION 1 - 5 REQUÊTES
-- *****************************************************************************************************************************

-- Quels sont les noms et les dates d'inscription des utilisateurs qui habitent au USA, triés par date d'inscription croissante ?
-- Sélection des noms et dates d'inscription des utilisateurs résidant en France, triés par ordre croissant de date d'inscription.
SELECT Nom, DateInscription
FROM Utilisateur
WHERE Pays = 'USA'
ORDER BY DateInscription;

-- Quel est le nombre total de critiques pour chaque bibliothèque ?
-- Calcul du nombre total de critiques pour chaque bibliothèque
SELECT Bibliothèque.Nom, COUNT(Critique.IdCritique) AS NombreCritiques
FROM Bibliothèque
INNER JOIN Critique ON Bibliothèque.IdBibliothèque = Critique.IdBibliothèque
GROUP BY Bibliothèque.Nom;

-- Quelles sont les bibliothèques qui ont reçu plus de 5 critiques ?
-- Sélection des bibliothèques ayant une moyenne de notation des critiques supérieure à 4
SELECT Bibliothèque.Nom, AVG(Critique.Rating) AS MoyenneNotation
FROM Bibliothèque
INNER JOIN Critique ON Bibliothèque.IdBibliothèque = Critique.IdBibliothèque
GROUP BY Bibliothèque.Nom
HAVING AVG(Critique.Rating) > 3;

-- Quels sont les noms des utilisateurs et les noms des bibliothèques pour lesquelles ils ont écrit des critiques, ainsi que les messages de ces critiques ?
-- Sélection des noms des utilisateurs, noms des bibliothèques et messages des critiques
SELECT Utilisateur.Nom AS NomUtilisateur, Bibliothèque.Nom AS NomBibliothèque, Critique.Message
FROM Utilisateur
INNER JOIN Critique ON Utilisateur.Nom = Critique.NomUtilisateur
INNER JOIN Bibliothèque ON Critique.IdBibliothèque = Bibliothèque.IdBibliothèque;

-- Sélection du nom de la fonction ayant le plus grand nombre de lignes de code dans chaque bibliothèque
SELECT f.Nom, f.NombreLignesDeCode, f.IdBibliothèque
FROM Fonction f
WHERE f.NombreLignesDeCode = (
    SELECT MAX(f2.NombreLignesDeCode)
    FROM Fonction f2
    WHERE f2.IdBibliothèque = f.IdBibliothèque
);

-- *****************************************************************************************************************************
-- SECTION 2 - CRÉATION DE LA VUE & SÉLECTION
-- *****************************************************************************************************************************

-- Vue : Vue listant les bibliothèques avec le nombre total de critiques et la moyenne des notations.
CREATE VIEW VueBibliothequeCritiques AS
SELECT
    Bibliothèque.Nom,
    COUNT(Critique.IdCritique) AS NombreCritiques,
    AVG(Critique.Rating) AS MoyenneNotation
FROM
    Bibliothèque
    INNER JOIN Critique ON Bibliothèque.IdBibliothèque = Critique.IdBibliothèque
GROUP BY
    Bibliothèque.Nom;

-- Select pour demontrer la vue.
SELECT * FROM VueBibliothequeCritiques;

-- *****************************************************************************************************************************
-- SECTION 3 - Création d'une fonction.
-- *****************************************************************************************************************************

CREATE FUNCTION TotalCritiques(@IdBibliothèque INT)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM Critique
        WHERE IdBibliothèque = @IdBibliothèque
    );
END;

SELECT dbo.TotalCritiques(1) AS TotalCritiques;

-- *****************************************************************************************************************************
-- SECTION 4 - PROCÉDURE 1
-- *****************************************************************************************************************************

--Procédure stockée 1 : Procédure retournant les critiques pour une bibliothèque donnée.
CREATE PROCEDURE GetCritiques @IdBibliothèque INT
AS
BEGIN
    SELECT Message, Rating
    FROM Critique
    WHERE IdBibliothèque = @IdBibliothèque;
END;

-- execution de la procedure
EXEC GetCritiques 1;

-- *****************************************************************************************************************************
-- SECTION 4 - PROCÉDURE 2
-- *****************************************************************************************************************************

-- Procédure stockée 2 : Procédure utilisant la fonction TotalCritiques pour retourner le nombre total de critiques pour une bibliothèque donnée.
CREATE PROCEDURE GetTotalCritiques @IdBibliothèque INT
AS
BEGIN
    SELECT dbo.TotalCritiques(@IdBibliothèque) AS TotalCritiques;
END;

-- execution de la procedure
EXEC GetTotalCritiques 1;

-- *****************************************************************************************************************************
-- SECTION 5 - TRIGGER, SELECT, INSERT, SELECT
-- *****************************************************************************************************************************

-- Déclencheur augmentant le compteur de téléchargements de la bibliothèque lorsqu'un utilisateur télécharge une bibliothèque.
CREATE TRIGGER IncrementTelechargements
ON UtilisateurBibliothèque
AFTER INSERT
AS
BEGIN
    UPDATE Bibliothèque
    SET TotalTelechargements = TotalTelechargements + 1
    WHERE IdBibliothèque IN (SELECT IdBibliothèque FROM inserted);
END;

-- Avant l'insertion
SELECT IdBibliothèque, TotalTelechargements FROM Bibliothèque;

-- Insertion pour le déclencheur
INSERT INTO UtilisateurBibliothèque (IdUtilisateur, IdBibliothèque, DateTelechargement)
VALUES (1, 1, GETDATE());

-- Après l'insertion
SELECT IdBibliothèque, TotalTelechargements FROM Bibliothèque;