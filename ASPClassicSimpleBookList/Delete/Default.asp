<!-- #include virtual = "Header.asp" -->
<!-- #include virtual = "SqlConnect.asp" -->

<%

sub GetAuthorsList(BookId)
	Dim SQLAuthors, SQLAuthorsString
	SQLAuthors = "SELECT Authors.Id, Authors.FirstName, Authors.LastName FROM Authors INNER JOIN BookAuthors ON BookAuthors.Author_Id = Authors.Id Where BookAuthors.Book_Id ="
	SQLAuthorsString = SQLAuthors & BookId
	
	Dim ResArray
	ResArray = SendSqlRequest(SQLAuthorsString)

	If IsNull(ResArray) Then
    	Response.write ("")
	Else
		Dim Lenght
		Lenght = ubound(ResArray)
		Dim k
		k = 0
		For Each oneRow In ResArray
			if ( k < Lenght) Then
				response.write( "<span>" & oneRow("FirstName") & " " & oneRow("LastName") & "</span>" & " | ")
			Else
				response.write( "<span>" & oneRow("FirstName") & " " & oneRow("LastName") & "</span>")
			End if
			k = k + 1
		Next
	End If

end sub


dim BookId
BookId = Request.QueryString("BookId")
dim BookDelete
BookDelete = Request.QueryString("BookDelete")

If ((Not (BookId = "")) AND (Not (ISNULL(BookId))) AND (IsNumeric(BookId)) AND (Not (IsEmpty(BookId))) ) Then 
	Dim FindBookQuery
	FindBookQuery = "SELECT * FROM Books WHERE Id =" & BookId
	
	Dim FindBookResult
	FindBookResult = SendSqlRequest(FindBookQuery)
     
	If IsNull(FindBookResult) Then
		Response.write ("<h1>Error! Such Book is not exist!</h1>")
		response.write("<h4 style='margin-top:2em;'><a href='/'>Return to list</a></h4>")
	Else
	
		If (BookDelete = "true") Then 
			Dim DeleteBookQuery
			DeleteBookQuery = "DECLARE	@Id int EXEC [dbo].[DeleteBook] @BookId = " & BookId & ", @Id = @Id OUTPUT SELECT	@Id as N'@Id'"

			Dim DeleteResp
			DeleteResp = SendSqlRequest(DeleteBookQuery)

			If (IsNull(DeleteResp) = false) Then
				Response.write ("<h3>Book successfully deleted!</h3>")
				response.write("<h4 style='margin-top:2em;'><a href='/'>Return to list</a></h4>")
			Else
				Response.write ("<h3>Error while deleting!</h3>")
				response.write("<h4 style='margin-top:2em;'><a href='/'>Return to list</a></h4>")
			End If
		Else
		
			Response.write ("<h3>Are you sure you want to delete this Book?</h3>")

			Response.write ("<dl class='dl-horizontal'>")
			Response.write ("<dt>Name</dt><dd>" & FindBookResult(0)("Name")  & "</dd>")
			Response.write ("<dt>Release Date</dt><dd>" & FindBookResult(0)("ReleaseDate")  & "</dd>")
			Response.write ("<dt>Pages</dt><dd>" & FindBookResult(0)("Pages")  & "</dd>")
			Response.write ("<dt>Rating</dt><dd>" & FindBookResult(0)("Rating")  & "</dd>")
			Response.write ("<dt>Publisher</dt><dd>" & FindBookResult(0)("Publisher")  & "</dd>")
			Response.write ("<dt>ISBN</dt><dd>" & FindBookResult(0)("ISBN")  & "</dd>")
			Response.write ("<dt>Authors</dt><dd>")
			GetAuthorsList(BookId)
			Response.write ("</dd>")
			
			Response.write ("</dl>")
			
			Response.write ("<form action='' method='GET' id='DeleteBookForm' method='post'>")
			Response.write ("<input type='hidden' name='BookId' value='"& BookId & "'>")
			Response.write ("<input type='hidden' name='BookDelete' value='true'>")
			
			Response.write ("<div class='form-group'><div class='form-actions no-color'>")
			Response.write ("<input type='submit' value='Delete' class='btn btn-default' style='margin:1em;'>")
			Response.write ("<input type='button' value='Cancel' onclick=""javascript:location.href='/'"" class='btn btn-default' id='CancelButton' style='margin:1em;'>")
			Response.write ("</div></div>")
		End if
	End If

End if



%>




<!-- #include virtual = "Footer.asp" -->