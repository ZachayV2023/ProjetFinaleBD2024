-- View for encrypted emails
CREATE VIEW VueEmailsChiffres AS
SELECT
    IdUtilisateur,
    EmailEncrypted
FROM
    Utilisateur;
GO