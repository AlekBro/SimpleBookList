<!-- #include virtual = "Header.asp" -->
<!-- #include virtual = "SqlConnect.asp" -->

<hr />

<%

Function EditAuthor(RequestContext)
	Dim Result
	Result = false
	
	DIM SqlEditAuthor
	SqlEditAuthor = "DECLARE @AuthorId int EXEC [dbo].[EditAuthor] @Id = " & RequestContext.Form("Id") 
	
	if (ISNULL(RequestContext.Form("FirstName")) OR (RequestContext.Form("FirstName")="")) Then
		SqlEditAuthor = SqlEditAuthor & ", @FirstName = NULL"
	Else
		SqlEditAuthor = SqlEditAuthor & ", @FirstName = N'" & RequestContext.Form("FirstName") & "'"
	End IF

	if (ISNULL(RequestContext.Form("LastName")) OR (RequestContext.Form("LastName")="")) Then
		SqlEditAuthor = SqlEditAuthor & ", @LastName = NULL"
	Else
		SqlEditAuthor = SqlEditAuthor & ", @LastName = N'" & RequestContext.Form("LastName") & "'"
	End IF

	SqlEditAuthor = SqlEditAuthor & ", @AuthorId = @AuthorId OUTPUT SELECT @AuthorId as N'AuthorId'"

	
	Dim ResArray
	ResArray = SendSqlRequest(SqlEditAuthor)

	If IsNull(ResArray) Then
		Result = false
	Else
		Result = true
	end if
	
	EditAuthor = Result
	
End Function


If (Request.Form.Count > 0) Then

	

	Dim EditAuthorResult
	EditAuthorResult = EditAuthor(Request)

	If (EditAuthorResult) Then
		response.write("<h1>Author is updated!</h1>")
		response.write("<h4 style='margin-top:2em;'><a href='/Authors/'>Return to list</a></h4>")
	Else
		response.write("<h1>Error while editing Author!</h1>")
		response.write("<h4 style='margin-top:2em;'><a href='/Authors/'>Return to list</a></h4>")
	End if


End If



%>

<!-- #include virtual = "Footer.asp" -->
