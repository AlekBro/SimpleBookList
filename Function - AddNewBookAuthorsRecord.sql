IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'AddNewBookAuthorsRecord') 
    BEGIN
        DROP PROCEDURE [dbo].[AddNewBookAuthorsRecord];
    END;

GO

CREATE PROCEDURE [dbo].AddNewBookAuthorsRecord
                                          ( 
				@BookId int,
				@AuthorId int
                                          )

AS
BEGIN

	INSERT INTO BookAuthors(Book_Id, Author_Id) VALUES (@BookId, @AuthorId);

    RETURN;
END;