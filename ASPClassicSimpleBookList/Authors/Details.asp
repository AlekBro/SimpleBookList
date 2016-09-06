<!-- #include virtual = "Header.asp" -->
<!-- #include virtual = "SqlConnect.asp" -->

<script src="/Scripts/App/Authors.TableLoading.js"></script>

<h2>Authors List</h2>
<hr />

<%

dim AuthorId
AuthorId = Request.QueryString("AuthorId")

    ' Turn on error Handling
    On Error Resume Next
	
	Dim Result
	Result = GetAuthorsListFromDB(AuthorId)
	
    ' Error Handler
    If ((Err.Number <> 0) OR ISNULL(Result)) Then
    	Response.write ("<h1>Error! Such Author is not exist!</h1>")
    	response.write("<h4 style='margin-top:2em;'><a href='/Authors/'>Return to list</a></h4>")
    Else
		For Each row In Result
			Response.write ("<h2>" & row("FirstName") & " " & row("LastName") & "</h2>")
			Response.write ("<div><hr /><dl class='dl-horizontal'><dt>FirstName</dt><dd>" & row("FirstName") & "</dd>")
			Response.write ("<dt>LastName</dt><dd>" & row("LastName") & "</dd>")
			Response.write ("<dt>BooksNumber</dt><dd>" & row("BooksNumber") & "</dd>")
	    	Response.write ("</dl></div>")
		Next
	End If



%>

<hr />


<!-- #include virtual = "Footer.asp" -->
