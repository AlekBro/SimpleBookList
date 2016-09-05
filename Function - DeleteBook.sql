IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'DeleteBook') 
    BEGIN
        DROP PROCEDURE [dbo].[DeleteBook];
    END;

GO

CREATE PROCEDURE [dbo].[DeleteBook](
       @BookId [INT])
AS
BEGIN

    DELETE FROM [Books]
    WHERE [Id] = @BookId;

    RETURN;

END;