IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'AuthorsView') 
    BEGIN
        DROP VIEW [dbo].[AuthorsView];
    END;

GO

CREATE VIEW [dbo].[AuthorsView]
AS
SELECT [dbo].[Authors].[Id]
      ,[dbo].[Authors].[FirstName]
      ,[dbo].[Authors].[LastName]
      ,COUNT(DISTINCT [dbo].[BookAuthors].[Book_Id]) AS [BooksNumber]
FROM [dbo].[Authors]
     FULL OUTER JOIN [dbo].[BookAuthors] ON [dbo].[Authors].[Id] = [dbo].[BookAuthors].[Author_Id]
GROUP BY [dbo].[Authors].[Id]
        ,[dbo].[Authors].[FirstName]
        ,[dbo].[Authors].[LastName];

GO