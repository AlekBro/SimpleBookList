IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'EditBook') 
    BEGIN
        DROP PROCEDURE [dbo].[EditBook];
    END;

GO

CREATE PROCEDURE [dbo].[EditBook](
       @Id          [INT],
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

    UPDATE [dbo].[Books]
    SET [Name] = @Name,
        [ReleaseDate] = @ReleaseDate,
        [Pages] = @Pages,
        [Rating] = @Rating,
        [Publisher] = @Publisher,
        [ISBN] = @ISBN
    WHERE [Id] = @Id;

    IF @@error <> 0
        BEGIN
            ROLLBACK;
            SET @BookId = NULL;
            RETURN;
        END;

    SET @BookId = @Id;

    DELETE FROM [BookAuthors]
    WHERE [Book_Id] = @BookId;

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