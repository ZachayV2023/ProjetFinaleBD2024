-- Creating indexes based on common queries
CREATE INDEX IX_Utilisateur_City ON Utilisateur(Ville);
CREATE INDEX IX_Bibliotheque_Category ON Bibliotheque(Categorie);
GO