IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'AddNewBook') 
    BEGIN
        DROP PROCEDURE [dbo].[AddNewBook];
    END;

GO

CREATE PROCEDURE [dbo].[AddNewBook](
       @Name        NVARCHAR(300),
       @ReleaseDate DATETIME,
       @Pages       [INT],
       @Rating      [INT],
       @Publisher   NVARCHAR(100),
       @ISBN        NVARCHAR(20),
       @AuthorsIDs  NVARCHAR(300),
       @BookId      [INT] OUTPUT)
AS
BEGIN

    BEGIN TRAN;

    INSERT INTO [Books]( [Name]
                        ,[ReleaseDate]
                        ,[Pages]
                        ,[Rating]
                        ,[Publisher]
                        ,[ISBN] )
    VALUES
           (@Name
           ,@ReleaseDate
           ,@Pages
           ,@Rating
           ,@Publisher
           ,@ISBN);

    IF @@error <> 0
        BEGIN
            ROLLBACK;
            SET @BookId = NULL;
			RETURN;
        END;

    SET @BookId = SCOPE_IDENTITY();

    DECLARE @OneAuthorID VARCHAR(20) = NULL;
    WHILE LEN(@AuthorsIDs) > 0
        BEGIN
 
            IF PATINDEX('%,%',@AuthorsIDs) > 0
                BEGIN
                    SET @OneAuthorID = SUBSTRING(@AuthorsIDs,0,PATINDEX('%,%',@AuthorsIDs));
                    SET @AuthorsIDs = SUBSTRING(@AuthorsIDs,LEN(@OneAuthorID+',')+1,LEN(@AuthorsIDs));
                END;
            ELSE
                BEGIN
                    SET @OneAuthorID = @AuthorsIDs;
                    SET @AuthorsIDs = NULL;
                END;

            INSERT INTO [BookAuthors]( [Book_Id]
                                      ,[Author_Id] )
            VALUES
                   (@BookId
                   ,@OneAuthorID);

            IF @@error <> 0
                BEGIN
                    ROLLBACK;
                    SET @BookId = NULL;
					RETURN;
                END;

        END;

    COMMIT TRAN;

    RETURN;
END;