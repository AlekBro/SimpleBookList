IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'GetOneAuthorById') 
    BEGIN
        DROP PROCEDURE [dbo].[GetOneAuthorById];
    END;

GO

CREATE PROCEDURE [dbo].[GetOneAuthorById](
       @AuthorId Int
	   )
AS
BEGIN
    
	SELECT * FROM Authors Where Id = @AuthorId;

    RETURN;
END;