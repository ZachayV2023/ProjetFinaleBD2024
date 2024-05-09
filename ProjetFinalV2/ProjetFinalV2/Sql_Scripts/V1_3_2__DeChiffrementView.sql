-- View for decrypted emails
CREATE VIEW VueEmailsDechiffres AS
SELECT
    IdUtilisateur,
    CONVERT(nvarchar(255), DecryptByPassPhrase('YourEncryptionKey123', EmailEncrypted)) AS EmailDecrypted
FROM
    Utilisateur;
GO
