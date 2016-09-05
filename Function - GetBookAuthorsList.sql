IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'GetBookAuthorsList') 
    BEGIN
        DROP PROCEDURE [dbo].[GetBookAuthorsList];
    END;

GO

CREATE PROCEDURE [dbo].[GetBookAuthorsList](
       @BookId Int
	   )
AS
BEGIN
    
	SELECT Authors.Id, Authors.FirstName, Authors.LastName FROM Authors INNER JOIN BookAuthors ON BookAuthors.Author_Id = Authors.Id Where BookAuthors.Book_Id = @BookId;

    RETURN;
END;