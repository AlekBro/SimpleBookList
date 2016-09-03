IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'EditAuthor') 
    BEGIN
        DROP PROCEDURE [dbo].[EditAuthor];
    END;

GO

CREATE PROCEDURE [dbo].[EditAuthor](
       @Id        [INT],
       @FirstName NVARCHAR(100),
       @LastName  NVARCHAR(100),
       @AuthorId  [INT] OUTPUT)
AS
BEGIN

    BEGIN TRAN;

    DECLARE @AuthorsNumber [INT];

    SET @AuthorsNumber = (SELECT COUNT(*)
                          FROM [dbo].[Authors]
                          WHERE [Id] = @Id);

    IF @AuthorsNumber <> 1
        BEGIN
            ROLLBACK;
            SET @AuthorId = NULL;
            RETURN;
        END;

    UPDATE [dbo].[Authors]
    SET [FirstName] = @FirstName,
        [LastName] = @LastName
    WHERE [Id] = @Id;

    IF @@error <> 0
        BEGIN
            ROLLBACK;
            SET @AuthorId = NULL;
            RETURN;
        END;

    SET @AuthorId = @Id;

    COMMIT TRAN;

    RETURN;
END;