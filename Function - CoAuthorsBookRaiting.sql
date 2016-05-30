CREATE FUNCTION dbo.СoAuthorsBookRaiting
(
	@searchText text
)
RETURNS @returnTable TABLE
(
	SortId INT IDENTITY PRIMARY KEY,
	CoAuthor int,
	FirstName nvarchar(100),
	LastName nvarchar(100),
	AvegareRating float
)
AS
BEGIN

	declare @AuthorId int
	SET @AuthorId = (SELECT TOP 1 Id FROM Authors WHERE FirstName LIKE @searchText  OR LastName LIKE @searchText)

	/*coauthors-book*/
	DECLARE @coauthorsTable TABLE (Author_Id INT, Book_Id INT)
	INSERT  INTO @coauthorsTable (Author_Id, Book_Id)
	SELECT Author_Id, Book_Id
	FROM BookAuthors WHERE Book_Id in 
	(SELECT Book_Id FROM BookAuthors WHERE Author_Id = @AuthorId)  AND Author_Id != @AuthorId

	/*coauthors-book-rating*/
	DECLARE @coauthorsRatingTable TABLE (Author_Id INT, Average FLOAT)
	INSERT  INTO @coauthorsRatingTable (Author_Id,  Average)
	SELECT Author_Id,  AVG(CAST(Books.Rating as float)) FROM @coauthorsTable LEFT JOIN Books ON Book_Id = Books.Id GROUP BY Author_id

	INSERT INTO @returntable  
	SELECT Author_Id, Authors.FirstName, Authors.LastName, Average 
	FROM @coauthorsRatingTable INNER JOIN Authors on Author_Id = Authors.Id ORDER BY Average

RETURN 
END