IF EXISTS (SELECT TOP 1 *
           FROM sys.objects
           WHERE [name] = N'GetAuthorsList') 
    BEGIN
        DROP PROCEDURE [dbo].[GetAuthorsList];
    END;

GO

CREATE PROCEDURE [dbo].[GetAuthorsList](
       @AuthorId [INT])
AS
BEGIN

    SELECT [dbo].[Authors].[Id]
          ,[dbo].[Authors].[FirstName]
          ,[dbo].[Authors].[LastName]
          ,COUNT(DISTINCT [dbo].[BookAuthors].[Book_Id]) AS [BooksNumber]
    FROM [dbo].[Authors]
         FULL OUTER JOIN [dbo].[BookAuthors] ON [dbo].[Authors].[Id] = [dbo].[BookAuthors].[Author_Id]
	WHERE [dbo].[Authors].[Id] = @AuthorId
    GROUP BY [dbo].[Authors].[Id]
            ,[dbo].[Authors].[FirstName]
            ,[dbo].[Authors].[LastName];

    RETURN;

END;