-- Assume you're encrypting user emails for demonstration.
ALTER TABLE Utilisateur
    ADD EmailEncrypted VARBINARY(MAX);

UPDATE Utilisateur
SET EmailEncrypted = EncryptByPassPhrase('YourEncryptionKey123', Email);

-- Procedure to decrypt the email
CREATE PROCEDURE GetDecryptedEmail
    @IdUtilisateur INT
AS
BEGIN
SELECT Convert(nvarchar(255), DecryptByPassPhrase('YourEncryptionKey123', EmailEncrypted)) AS DecryptedEmail
FROM Utilisateur
WHERE IdUtilisateur = @IdUtilisateur;
END;
GO