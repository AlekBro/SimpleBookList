IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'EditBook') 
    BEGIN
        DROP PROCEDURE [dbo].[EditBook];
    END;

GO

CREATE PROCEDURE [dbo].EditBook
                                          ( 
				@Id int,
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

		UPDATE [dbo].Books 
		SET Name = @Name, ReleaseDate = @ReleaseDate, Pages = @Pages, Rating = @Rating, Publisher = @Publisher, ISBN = @ISBN
		WHERE Id = @Id;
		
		SET @BookId = @Id;

		DELETE FROM BookAuthors WHERE Book_Id = @BookId;

		Declare @OneAuthorID varchar(20) = null
		WHILE LEN(@AuthorsIDs) > 0
		BEGIN
			IF PATINDEX('%,%',@AuthorsIDs) > 0
				BEGIN
					SET @OneAuthorID = SUBSTRING(@AuthorsIDs, 0, PATINDEX('%,%',@AuthorsIDs))
					SET @AuthorsIDs = SUBSTRING(@AuthorsIDs, LEN(@OneAuthorID + ',') + 1,
																 LEN(@AuthorsIDs))
				END
			ELSE
				BEGIN
					SET @OneAuthorID = @AuthorsIDs
					SET @AuthorsIDs = NULL
				END
	
			INSERT INTO BookAuthors(Book_Id, Author_Id) VALUES (@BookId, @OneAuthorID);
		END


	COMMIT TRAN

	
    RETURN;
END;