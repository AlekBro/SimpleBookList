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
				@AuthorsIDs nvarchar(300),
				@BookId  INT OUTPUT
                                          )

AS
BEGIN

	BEGIN TRAN

		INSERT INTO Books (Name, ReleaseDate, Pages, Rating, Publisher, ISBN) VALUES (@Name, @ReleaseDate, @Pages, @Rating, @Publisher, @ISBN);
		SET @BookId = SCOPE_IDENTITY();

		Declare @OneAuthorID varchar(20) = null
		WHILE LEN(@AuthorsIDs) > 0
		BEGIN
			IF PATINDEX('%,%',@AuthorsIDs) > 0
				BEGIN
					SET @OneAuthorID = SUBSTRING(@AuthorsIDs, 0, PATINDEX('%,%',@AuthorsIDs))
					--SELECT @OneAuthorID

					SET @AuthorsIDs = SUBSTRING(@AuthorsIDs, LEN(@OneAuthorID + ',') + 1,
																 LEN(@AuthorsIDs))
				END
			ELSE
				BEGIN
					SET @OneAuthorID = @AuthorsIDs
					SET @AuthorsIDs = NULL
					--SELECT * FROM Authors WHERE Id = @OneAuthorID
				END
			INSERT INTO BookAuthors(Book_Id, Author_Id) VALUES (@BookId, @OneAuthorID);
		END


	COMMIT TRAN

    RETURN;
END;