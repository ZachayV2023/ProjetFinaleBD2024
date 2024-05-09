CREATE VIEW dbo.VueBibliothequeCritiques
AS
SELECT
    ROW_NUMBER() OVER (ORDER BY b.Nom) AS VueBibliothequeCritiqueId,
    b.Nom,
    b.Categorie,
    COUNT_BIG(DISTINCT c.IdCritique) AS NombreCritiques,
    AVG(c.Rating) AS MoyenneNotation,
    COUNT_BIG(DISTINCT m.IdMiseAJour) AS NombreMisesAJour,
    MAX(m.Version) AS DerniereVersion,
    AVG(f.NombreLignesDeCode) AS MoyenneLignesCodeFonctions,
    COUNT_BIG(DISTINCT f.IdFonction) AS NombreFonctions
FROM
    dbo.Bibliotheque b
    INNER JOIN dbo.Critique c ON b.IdBibliotheque = c.IdBibliotheque
    INNER JOIN dbo.MiseAJour m ON b.IdBibliotheque = m.IdMiseAJour
    INNER JOIN dbo.Fonction f ON b.IdBibliotheque = f.IdFonction
GROUP BY
    b.Nom,
    b.Categorie;
GO