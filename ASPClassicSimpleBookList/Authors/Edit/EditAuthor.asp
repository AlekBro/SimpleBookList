<!-- #include virtual = "Header.asp" -->
<!-- #include virtual = "SqlConnect.asp" -->

<hr />

<%

Function EditAuthor(RequestContext)

    ' Turn on error Handling
    On Error Resume Next
	
	Dim Result
	Result = EditAuthorInDB(RequestContext.Form("Id"), RequestContext.Form("FirstName"), RequestContext.Form("LastName"))
	
    ' Error Handler
    If (Err.Number <> 0) OR (IsNull(Result)) Then
        EditAuthor = false
    Else
	    EditAuthor = true
	End If

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
