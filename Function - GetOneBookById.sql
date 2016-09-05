IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'GetOneBookById') 
    BEGIN
        DROP PROCEDURE [dbo].[GetOneBookById];
    END;

GO

CREATE PROCEDURE [dbo].[GetOneBookById](
       @BookId Int
	   )
AS
BEGIN
    
	SELECT * FROM Books Where Id = @BookId;

    RETURN;
END;