IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'BookAuthors') 
    BEGIN
        DROP TABLE [dbo].[BookAuthors];
    END;

GO

IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'Authors') 
    BEGIN
        DROP TABLE [dbo].[Authors];
    END;

GO

IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'Books') 
    BEGIN
        DROP TABLE [dbo].[Books];
    END;

GO

CREATE TABLE [dbo].[Authors]
                            ( 
             [Id]        INT IDENTITY(1,1)
                             NOT NULL,
             [FirstName] NVARCHAR(100) NOT NULL,
             [LastName]  NVARCHAR(100) NOT NULL,
             CONSTRAINT [PK_dbo.Authors] PRIMARY KEY CLUSTERED([Id] ASC),
             CONSTRAINT [FullName_dbo.Authors] UNIQUE([FirstName],[LastName])
                            );

CREATE TABLE [dbo].[Books]
                          ( 
             [Id]          INT IDENTITY(1,1)
                               NOT NULL,
             [Name]        NVARCHAR(300) NOT NULL,
             [ReleaseDate] DATETIME NOT NULL,
             [Pages]       INT NOT NULL,
             [Rating]      INT NOT NULL,
             CONSTRAINT [PK_dbo.Books] PRIMARY KEY CLUSTERED([Id] ASC),
             CONSTRAINT [Name_dbo.Books] UNIQUE([Name])
                          );

CREATE TABLE [dbo].[BookAuthors]
                                ( 
             [Book_Id]   INT NOT NULL,
             [Author_Id] INT NOT NULL,
             CONSTRAINT [PK_dbo.BookAuthors] PRIMARY KEY CLUSTERED([Book_Id] ASC,[Author_Id] ASC),
             CONSTRAINT [FK_dbo.BookAuthors_dbo.Books_Book_Id] FOREIGN KEY([Book_Id]) REFERENCES [dbo].[Books]([Id]) ON DELETE CASCADE,
             CONSTRAINT [FK_dbo.BookAuthors_dbo.Authors_Author_Id] FOREIGN KEY([Author_Id]) REFERENCES [dbo].[Authors]([Id]) ON DELETE CASCADE
                                );