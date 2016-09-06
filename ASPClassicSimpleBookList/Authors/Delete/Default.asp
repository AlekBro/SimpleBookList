<!-- #include virtual = "Header.asp" -->
<!-- #include virtual = "SqlConnect.asp" -->
<hr />


<%

dim AuthorId
AuthorId = Request.QueryString("AuthorId")
dim AuthorDelete
AuthorDelete = Request.QueryString("AuthorDelete")

' Turn on error Handling
On Error Resume Next
Dim FindAuthorResult
FindAuthorResult = SelectOneAuthorByIdFromDB(AuthorId)

' Error Handler
If (Err.Number <> 0) OR (IsNull(FindAuthorResult)) Then
	Response.write ("<h1>Error! Such Author is not exist!</h1>")
	response.write("<h4 style='margin-top:2em;'><a href='/'>Return to list</a></h4>")
Else
	If (AuthorDelete = "true") Then 
		
        ' Turn on error Handling
        On Error Resume Next

		DeleteAuthorInDB(AuthorId)

		If (Err.Number <> 0) Then
	        Response.write ("<h3>Error while deleting!</h3>")
			response.write("<h4 style='margin-top:2em;'><a href='/Authors/'>Return to list</a></h4>")		
		Else
	        Response.write ("<h3>Author successfully deleted!</h3>")
			response.write("<h4 style='margin-top:2em;'><a href='/Authors/'>Return to list</a></h4>")	
		End If

	Else
		Response.write ("<h3>Are you sure you want to delete this Author?</h3>")
		
		Response.write ("<dl class='dl-horizontal'>")
		Response.write ("<dt>First Name</dt><dd>" & FindBookResult(0)("FirstName")  & "</dd>")
		Response.write ("<dt>Last Name</dt><dd>" & FindBookResult(0)("LastName")  & "</dd>")
		Response.write ("</dl>")
		
		Response.write ("<form action='' method='GET' id='DeleteAuthorForm' method='post'>")
		Response.write ("<input type='hidden' name='AuthorId' value='"& AuthorId & "'>")
		Response.write ("<input type='hidden' name='AuthorDelete' value='true'>")
		
		Response.write ("<div class='form-group'><div class='form-actions no-color'>")
		Response.write ("<input type='submit' value='Delete' class='btn btn-default' style='margin:1em;'>")
		Response.write ("<input type='button' value='Cancel' onclick=""javascript:location.href='/Authors/'"" class='btn btn-default' id='CancelButton' style='margin:1em;'>")
		Response.write ("</div></div>")
	End if
End If


%>


<!-- #include virtual = "Footer.asp" -->
