CREATE PROCEDURE GetCritiques 
@IdBibliotheque INT 
AS 
BEGIN 
    SELECT Message, Rating FROM Critique WHERE IdBibliotheque = @IdBibliotheque; 
END;
GO

-- Execution of the procedure
EXEC GetCritiques 1;
GO

CREATE FUNCTION TotalCritiques(@IdBibliotheque INT)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM Critique
        WHERE IdBibliotheque = @IdBibliotheque
    );
END;
GO

SELECT dbo.TotalCritiques(1) AS TotalCritiques;
GO

CREATE PROCEDURE GetTotalCritiques 
@IdBibliotheque INT 
AS 
BEGIN 
    SELECT dbo.TotalCritiques(@IdBibliotheque) AS TotalCritiques; 
END;
GO

-- Execution of the procedure
EXEC GetTotalCritiques 1;
GO