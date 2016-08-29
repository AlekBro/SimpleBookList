IF EXISTS (SELECT TOP 1 *
           FROM [sys].[objects]
           WHERE [name] = N'AddNewAuthor') 
    BEGIN
        DROP PROCEDURE [dbo].[AddNewAuthor];
    END;

GO

CREATE PROCEDURE [dbo].AddNewAuthor
                                          ( 
                @FirstName nvarchar(100),
				@LastName nvarchar(100),
				@AuthorId  INT OUTPUT
                                          )

AS
BEGIN
	Declare @items int
	SET @items = (SELECT COUNT(*) FROM Authors WHERE FirstName = @FirstName AND LastName = @LastName);

	IF(@items > 0)
	RETURN;
	
	INSERT INTO Authors (FirstName, LastName) VALUES (@FirstName, @LastName);

	SET @AuthorId = SCOPE_IDENTITY()
    RETURN;
END;