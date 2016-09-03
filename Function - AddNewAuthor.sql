IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'AddNewAuthor') 
    BEGIN
        DROP PROCEDURE [dbo].[AddNewAuthor];
    END;

GO

CREATE PROCEDURE [dbo].[AddNewAuthor](
       @FirstName NVARCHAR(100),
       @LastName  NVARCHAR(100),
       @AuthorId  [INT] OUTPUT)
AS
BEGIN
    BEGIN TRAN;

    DECLARE @items [INT];
    SET @items = (SELECT COUNT(*)
                  FROM [Authors]
                  WHERE [FirstName] = @FirstName
                        AND [LastName] = @LastName);

    IF @items > 0
        BEGIN
            SET @AuthorId = NULL;
            RETURN;
        END;

    INSERT INTO [Authors]( [FirstName]
                          ,[LastName] )
    VALUES
           (@FirstName
           ,@LastName);

    IF @@error <> 0
        BEGIN
            ROLLBACK;
            SET @AuthorId = NULL;
            RETURN;
        END;

    SET @AuthorId = SCOPE_IDENTITY();

    COMMIT TRAN;

    RETURN;
END;