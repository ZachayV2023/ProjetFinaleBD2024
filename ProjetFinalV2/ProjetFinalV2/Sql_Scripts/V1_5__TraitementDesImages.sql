-- Here, assume you're storing images in the database.
-- This requires setup for FILESTREAM if you're doing this in SQL Server, not covered here.
-- This script just simulates an image handling process.

ALTER TABLE Utilisateur
    ADD ProfileImage VARBINARY(MAX);
GO

-- Assuming you have a function to process images which we cannot simulate in SQL.