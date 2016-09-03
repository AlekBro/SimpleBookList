<!-- #include virtual = "Header.asp" -->

<!-- #include virtual = "SqlConnect.asp" -->


<hr />

<%

Function EditBook(RequestContext)
	Dim Result
	Result = false
	
	DIM SqlEditBook
	SqlEditBook = "DECLARE @BookId int EXEC [dbo].[EditBook] @Id = " & RequestContext.Form("Id") 
	SqlEditBook = SqlEditBook &	", @Name = N'" & RequestContext.Form("Name") 
	SqlEditBook = SqlEditBook & "', @ReleaseDate = N'" & RequestContext.Form("ReleaseDate")
	SqlEditBook = SqlEditBook &	"', @Pages = " & RequestContext.Form("Pages") 
	
	SqlEditBook = SqlEditBook & ", @Rating = " & RequestContext.Form("Rating")
	
	if (ISNULL(RequestContext.Form("Publisher")) OR (RequestContext.Form("Publisher")="")) Then
		SqlEditBook = SqlEditBook & ", @Publisher = NULL"
	Else
		SqlEditBook = SqlEditBook & ", @Publisher = N'" & RequestContext.Form("Publisher") & "'"
	End IF

	if (ISNULL(RequestContext.Form("ISBN")) OR (RequestContext.Form("ISBN")="")) Then
		SqlEditBook = SqlEditBook & ", @ISBN = NULL"
	Else
		SqlEditBook = SqlEditBook & ", @ISBN = N'" & RequestContext.Form("ISBN") & "'"
	End IF
	
	SqlEditBook = SqlEditBook & ", @AuthorsIDs = N'" & RequestContext.Form("AuthorsIds") & "'"

	SqlEditBook = SqlEditBook & ", @BookId = @BookId OUTPUT SELECT @BookId as N'BookId'"

	
	Dim ResArray
	ResArray = SendSqlRequest(SqlEditBook)

	If IsNull(ResArray) Then
		response.write("Book is wrong!")
		Result = false
	Else
		Result = true
	end if
	
	EditBook = Result
	
End Function


If (Request.Form.Count > 0) Then

	Dim EditBookResult
	EditBookResult = EditBook(Request)

	If (EditBookResult) Then
		response.write("<h1>Book is updated!</h1>")
		response.write("<h4 style='margin-top:2em;'><a href='/'>Return to list</a></h4>")
	Else
		response.write("<h1>Error while editing Book!</h1>")
		response.write("<h4 style='margin-top:2em;'><a href='/'>Return to list</a></h4>")
	End if

End If


%>

<!-- #include virtual = "Footer.asp" -->
