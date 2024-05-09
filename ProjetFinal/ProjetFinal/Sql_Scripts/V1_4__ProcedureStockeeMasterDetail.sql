-- Procedure that takes user ID and returns their library download details
CREATE PROCEDURE GetUserDownloads
    @IdUtilisateur INT
AS
BEGIN
SELECT b.Nom, ub.DateTelechargement
FROM UtilisateurBibliotheque ub
         INNER JOIN Bibliotheque b ON ub.IdBibliotheque = b.IdBibliotheque
WHERE ub.IdUtilisateur = @IdUtilisateur;
END;
GO