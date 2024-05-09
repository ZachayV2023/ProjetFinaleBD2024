CREATE VIEW VueUserDownloads
AS
SELECT 
    ub.IdUtilisateur,
    b.Nom AS LibraryName,
    ub.DateTelechargement AS DownloadDate
FROM 
    UtilisateurBibliotheque ub
    INNER JOIN Bibliotheque b ON ub.IdBibliotheque = b.IdBibliotheque;
GO