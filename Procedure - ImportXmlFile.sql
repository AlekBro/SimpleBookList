IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'GetOrAddAuthorProcedure') 
    BEGIN
        DROP PROCEDURE [dbo].[GetOrAddAuthorProcedure];
    END;

GO

CREATE PROCEDURE [dbo].[GetOrAddAuthorProcedure](
       @FirstName NVARCHAR(100),
       @LastName  NVARCHAR(100),
       @AuthorId  INT OUTPUT)
AS
BEGIN
    DECLARE @ResultAuthorCount INT;

    SET @ResultAuthorCount = (SELECT COUNT(*)
                              FROM [Authors]
                              WHERE [FirstName] = @FirstName
                                    AND [LastName] = @LastName);

    IF @ResultAuthorCount = 0
        BEGIN
            INSERT INTO [Authors]( [FirstName]
                                  ,[LastName] )
            VALUES
                   (@FirstName
                   ,@LastName);
        END;

    SET @AuthorId = (SELECT [Id]
                     FROM [Authors]
                     WHERE [FirstName] = @FirstName
                           AND [LastName] = @LastName);

    RETURN;
END;

GO


IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'GetOrAddBookProcedure') 
    BEGIN
        DROP PROCEDURE [dbo].[GetOrAddBookProcedure];
    END;

GO

CREATE PROCEDURE [dbo].[GetOrAddBookProcedure](
       @Name        NVARCHAR(300),
       @ReleaseDate DATE,
       @Pages       INT,
       @Rating      INT,
       @BookId      INT OUTPUT)
AS
BEGIN
    DECLARE @ResultBookCount INT;

    SET @ResultBookCount = (SELECT COUNT(*)
                            FROM [Books]
                            WHERE [Name] = @Name);

    IF @ResultBookCount = 0
        BEGIN
            INSERT INTO [Books]( [Name]
                                ,[ReleaseDate]
                                ,[Pages]
                                ,[Rating] )
            VALUES
                   (@Name
                   ,@ReleaseDate
                   ,@Pages
                   ,@Rating);
        END;

    SET @BookId = (SELECT [Id]
                   FROM [Books]
                   WHERE [Name] = @Name);

    RETURN;
END;

GO


IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'AddBookAuthorsProcedure') 
    BEGIN
        DROP PROCEDURE [dbo].[AddBookAuthorsProcedure];
    END;

GO

CREATE PROCEDURE [dbo].[AddBookAuthorsProcedure](
       @BookId   INT,
       @AuthorId INT)
AS
BEGIN
    DECLARE @ResultCount INT;

    SET @ResultCount = (SELECT COUNT(*)
                        FROM [BookAuthors]
                        WHERE [Book_Id] = @BookId
                              AND [Author_Id] = @AuthorId);

    IF @ResultCount = 0
        BEGIN
            INSERT INTO [BookAuthors]( [Book_Id]
                                      ,[Author_Id] )
            VALUES
                   (@BookId
                   ,@AuthorId);
        END;
END;

GO

/**************************************
 This is Main Procedure for impart xml 
**************************************/

    IF EXISTS (SELECT TOP 1 *
               FROM [sys].[objects]
               WHERE [name] = N'ImportXmlFileProcedure') 
        BEGIN
            DROP PROCEDURE [dbo].[ImportXmlFileProcedure];
        END;

GO

CREATE PROCEDURE [dbo].[ImportXmlFileProcedure](
       @filePatch NVARCHAR(MAX))
AS
BEGIN

    IF EXISTS (SELECT *
               FROM [INFORMATION_SCHEMA].[TABLES]
               WHERE [TABLE_NAME] = 'XMLwithOpenXML'
                     AND [TABLE_SCHEMA] = 'dbo') 
        DROP TABLE [dbo].[XMLwithOpenXML];
    CREATE TABLE [XMLwithOpenXML]
                                 ( 
                 [Id]      INT IDENTITY
                               PRIMARY KEY,
                 [XMLData] XML
                                 );

    DECLARE @sqlLine AS VARCHAR(MAX);
    SET @sqlLine = N'INSERT INTO XMLwithOpenXML(XMLData)
	SELECT CONVERT(XML, BulkColumn) AS BulkColumn FROM OPENROWSET(BULK '''+@filePatch+''', SINGLE_BLOB) AS x;';
    EXEC (@sqlLine);

    DECLARE @XML AS  XML,
            @hDoc AS INT;
    SELECT @XML = [XMLData]
    FROM [XMLwithOpenXML];
    EXEC [sp_xml_preparedocument] @hDoc OUTPUT,
                                  @XML;

    DECLARE @AuthorId        INT,
            @AuthorFirstName NVARCHAR(100),
            @AuthorlastName  NVARCHAR(100),
            @BookName        NVARCHAR(300),
            @BookReleaseDate DATETIME,
            @BookPages       INT,
            @BookRating      INT;

    DECLARE author_cursor CURSOR
    FOR SELECT [FirstName]
              ,[LastName]
              ,[BookName]
              ,[BookReleaseDate]
              ,[BookPages]
              ,[BookRating]
        FROM OPENXML(@hDoc,'root/Book/Authors/Author') WITH([FirstName] NVARCHAR(100) 'FirstName',[LastName] NVARCHAR(100) 'LastName',[BookName] NVARCHAR(300) '../../Name',[BookReleaseDate] DATETIME '../../ReleaseDate',[BookPages] INT '../../Pages',[BookRating] INT '../../Rating');

    OPEN author_cursor;

    FETCH NEXT FROM author_cursor INTO @AuthorFirstName,
                                       @AuthorlastName,
                                       @BookName,
                                       @BookReleaseDate,
                                       @BookPages,
                                       @BookRating;
    -- Check @@FETCH_STATUS to see if there are any more rows to fetch.
    WHILE @@FETCH_STATUS = 0
        BEGIN

            DECLARE @ResultAuthorId INT;
            EXEC [GetOrAddAuthorProcedure] @FirstName = @AuthorFirstName,
                                           @LastName = @AuthorlastName,
                                           @AuthorId = @ResultAuthorId OUTPUT;

            DECLARE @ResultBookId INT;
            EXEC [GetOrAddBookProcedure] @Name = @BookName,
                                         @ReleaseDate = @BookReleaseDate,
                                         @Pages = @BookPages,
                                         @Rating = @BookRating,
                                         @BookId = @ResultBookId OUTPUT;

            EXEC [AddBookAuthorsProcedure] @BookId = @ResultBookId,
                                           @AuthorId = @ResultAuthorId;

            FETCH NEXT FROM author_cursor INTO @AuthorFirstName,
                                               @AuthorlastName,
                                               @BookName,
                                               @BookReleaseDate,
                                               @BookPages,
                                               @BookRating;
        END;
    CLOSE author_cursor;
    DEALLOCATE author_cursor;

    EXEC [sp_xml_removedocument] @hDoc;

END;

GO