CREATE VIEW VueBibliothequeCritiques AS
SELECT
    Bibliotheque.Nom,
    COUNT(Critique.IdCritique) AS NombreCritiques,
    AVG(Critique.Rating) AS MoyenneNotation
FROM
    Bibliotheque
    INNER JOIN Critique ON Bibliotheque.IdBibliotheque = Critique.IdBibliotheque
GROUP BY
    Bibliotheque.Nom;
GO

-- Select to demonstrate the view.
SELECT * FROM VueBibliothequeCritiques;