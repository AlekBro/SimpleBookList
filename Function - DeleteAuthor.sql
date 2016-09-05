IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'DeleteAuthor') 
    BEGIN
        DROP PROCEDURE [dbo].[DeleteAuthor];
    END;

GO

CREATE PROCEDURE [dbo].[DeleteAuthor](
       @AuthorId [INT])
AS
BEGIN

    DELETE FROM [Authors]
    WHERE [Id] = @AuthorId;

    RETURN;
END;