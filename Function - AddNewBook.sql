IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'AddNewBook') 
    BEGIN
        DROP PROCEDURE [dbo].[AddNewBook];
    END;

GO

CREATE PROCEDURE [dbo].AddNewBook
                                          ( 
                @Name nvarchar(300),
				@ReleaseDate datetime,
				@Pages int,
				@Rating int,
				@Publisher nvarchar(100),
				@ISBN nvarchar(20),
				@BookId  INT OUTPUT
                                          )

AS
BEGIN

	INSERT INTO Books (Name, ReleaseDate, Pages, Rating, Publisher, ISBN) VALUES (@Name, @ReleaseDate, @Pages, @Rating, @Publisher, @ISBN);

	SET @BookId = SCOPE_IDENTITY()
    RETURN;
END;