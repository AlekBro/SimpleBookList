<!-- #include virtual = "Header.asp" -->

<!-- #include virtual = "SqlConnect.asp" -->


<hr />

<%

Function EditBook(RequestContext)
	
    ' Turn on error Handling
    On Error Resume Next
	
	Dim Result
	Result = EditBookInDB(RequestContext.Form("Id"), RequestContext.Form("Name"), RequestContext.Form("ReleaseDate"), RequestContext.Form("Pages"), RequestContext.Form("Rating"), RequestContext.Form("Publisher"), RequestContext.Form("ISBN"), RequestContext.Form("AuthorsIds"))
	
    ' Error Handler
    If (Err.Number <> 0) OR (IsNull(Result)) Then
        EditBook = false
    Else
	    EditBook = true
	End If
	
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
