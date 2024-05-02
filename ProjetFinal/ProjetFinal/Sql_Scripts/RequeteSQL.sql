/* *****************************************************************************************************************************
TP04 --> Partie 4  (9 pts) : Remise Rencontre 13
Ceci va inclure:

	- Les requ�tes pour les 5 questions. Chaque requ�te est associ�e � une question sp�cifique et con�ue pour r�pondre aux crit�res d'�valuation.

	- Une vue pertinente et suffisamment complexe.

	- Une fonction r�pondant � une interrogation sp�cifique ou initialisant un nouveau champ.

	- Deux proc�dures :
		Une pour la g�n�ralisation d'une requ�te d�j� r�alis�e.
		Une autre pour la cr�ation d'une proc�dure stock�e (incluant les requ�tes pour visualiser les deux proc�dures).

	- Un d�clencheur (trigger) comprenant un SELECT, un INSERT et un SELECT.
***************************************************************************************************************************** */ 

USE DevLibraryDB;

-- *****************************************************************************************************************************
-- SECTION 1 - 5 REQU�TES
-- *****************************************************************************************************************************

-- Quels sont les noms et les dates d'inscription des utilisateurs qui habitent au USA, tri�s par date d'inscription croissante ?
-- S�lection des noms et dates d'inscription des utilisateurs r�sidant en France, tri�s par ordre croissant de date d'inscription.
SELECT Nom, DateInscription
FROM Utilisateur
WHERE Pays = 'USA'
ORDER BY DateInscription;

-- Quel est le nombre total de critiques pour chaque biblioth�que ?
-- Calcul du nombre total de critiques pour chaque biblioth�que
SELECT Biblioth�que.Nom, COUNT(Critique.IdCritique) AS NombreCritiques
FROM Biblioth�que
INNER JOIN Critique ON Biblioth�que.IdBiblioth�que = Critique.IdBiblioth�que
GROUP BY Biblioth�que.Nom;

-- Quelles sont les biblioth�ques qui ont re�u plus de 5 critiques ?
-- S�lection des biblioth�ques ayant une moyenne de notation des critiques sup�rieure � 4
SELECT Biblioth�que.Nom, AVG(Critique.Rating) AS MoyenneNotation
FROM Biblioth�que
INNER JOIN Critique ON Biblioth�que.IdBiblioth�que = Critique.IdBiblioth�que
GROUP BY Biblioth�que.Nom
HAVING AVG(Critique.Rating) > 3;

-- Quels sont les noms des utilisateurs et les noms des biblioth�ques pour lesquelles ils ont �crit des critiques, ainsi que les messages de ces critiques ?
-- S�lection des noms des utilisateurs, noms des biblioth�ques et messages des critiques
SELECT Utilisateur.Nom AS NomUtilisateur, Biblioth�que.Nom AS NomBiblioth�que, Critique.Message
FROM Utilisateur
INNER JOIN Critique ON Utilisateur.Nom = Critique.NomUtilisateur
INNER JOIN Biblioth�que ON Critique.IdBiblioth�que = Biblioth�que.IdBiblioth�que;

-- S�lection du nom de la fonction ayant le plus grand nombre de lignes de code dans chaque biblioth�que
SELECT f.Nom, f.NombreLignesDeCode, f.IdBiblioth�que
FROM Fonction f
WHERE f.NombreLignesDeCode = (
    SELECT MAX(f2.NombreLignesDeCode)
    FROM Fonction f2
    WHERE f2.IdBiblioth�que = f.IdBiblioth�que
);

-- *****************************************************************************************************************************
-- SECTION 2 - CR�ATION DE LA VUE & S�LECTION
-- *****************************************************************************************************************************

-- Vue : Vue listant les biblioth�ques avec le nombre total de critiques et la moyenne des notations.
CREATE VIEW VueBibliothequeCritiques AS
SELECT
    Biblioth�que.Nom,
    COUNT(Critique.IdCritique) AS NombreCritiques,
    AVG(Critique.Rating) AS MoyenneNotation
FROM
    Biblioth�que
    INNER JOIN Critique ON Biblioth�que.IdBiblioth�que = Critique.IdBiblioth�que
GROUP BY
    Biblioth�que.Nom;

-- Select pour demontrer la vue.
SELECT * FROM VueBibliothequeCritiques;

-- *****************************************************************************************************************************
-- SECTION 3 - Cr�ation d'une fonction.
-- *****************************************************************************************************************************

CREATE FUNCTION TotalCritiques(@IdBiblioth�que INT)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM Critique
        WHERE IdBiblioth�que = @IdBiblioth�que
    );
END;

SELECT dbo.TotalCritiques(1) AS TotalCritiques;

-- *****************************************************************************************************************************
-- SECTION 4 - PROC�DURE 1
-- *****************************************************************************************************************************

--Proc�dure stock�e 1 : Proc�dure retournant les critiques pour une biblioth�que donn�e.
CREATE PROCEDURE GetCritiques @IdBiblioth�que INT
AS
BEGIN
    SELECT Message, Rating
    FROM Critique
    WHERE IdBiblioth�que = @IdBiblioth�que;
END;

-- execution de la procedure
EXEC GetCritiques 1;

-- *****************************************************************************************************************************
-- SECTION 4 - PROC�DURE 2
-- *****************************************************************************************************************************

-- Proc�dure stock�e 2 : Proc�dure utilisant la fonction TotalCritiques pour retourner le nombre total de critiques pour une biblioth�que donn�e.
CREATE PROCEDURE GetTotalCritiques @IdBiblioth�que INT
AS
BEGIN
    SELECT dbo.TotalCritiques(@IdBiblioth�que) AS TotalCritiques;
END;

-- execution de la procedure
EXEC GetTotalCritiques 1;

-- *****************************************************************************************************************************
-- SECTION 5 - TRIGGER, SELECT, INSERT, SELECT
-- *****************************************************************************************************************************

-- D�clencheur augmentant le compteur de t�l�chargements de la biblioth�que lorsqu'un utilisateur t�l�charge une biblioth�que.
CREATE TRIGGER IncrementTelechargements
ON UtilisateurBiblioth�que
AFTER INSERT
AS
BEGIN
    UPDATE Biblioth�que
    SET TotalTelechargements = TotalTelechargements + 1
    WHERE IdBiblioth�que IN (SELECT IdBiblioth�que FROM inserted);
END;

-- Avant l'insertion
SELECT IdBiblioth�que, TotalTelechargements FROM Biblioth�que;

-- Insertion pour le d�clencheur
INSERT INTO UtilisateurBiblioth�que (IdUtilisateur, IdBiblioth�que, DateTelechargement)
VALUES (1, 1, GETDATE());

-- Apr�s l'insertion
SELECT IdBiblioth�que, TotalTelechargements FROM Biblioth�que;