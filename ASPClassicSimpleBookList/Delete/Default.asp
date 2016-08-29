<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>My ASP Classic Application</title>
	<link rel="stylesheet" href="/Styles/jquery-ui.css">
	<link rel="stylesheet" href="/Styles/jquery.dataTables.css">
	<link rel="stylesheet" href="/Styles/jquery.dataTables_themeroller.css">
    <link rel="stylesheet" href="/Styles/bootstrap.css">	
    <link rel="stylesheet" href="/Styles/site.css">
	<link rel="stylesheet" href="/Styles/bootstrap-theme.css">
	
	<script src="/Scripts/jquery-2.2.3.js"></script>
	<script src="/Scripts/jquery-ui.js"></script>
	<script src="/Scripts/jquery.dataTables.js"></script>
	<script src="/Scripts/bootstrap.js"></script>
	
	<script src="/Scripts/App/Authors.TableLoading.js"></script>
	<script src="/Scripts/jquery.quicksearch.js"></script>
	
	
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href='/'>Books List</a>
                <a class="navbar-brand" href='/Authors/'>Authors List</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a href=''>About</a></li>
                    <li><a href=''>About</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">



<h1 id="booksTitle">SimpleBookList</h1>

<hr />
<div id="dialogContainer">



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
	'Response.write(FindBookQuery)
	
	Dim FindBookResult
	FindBookResult = SendSqlRequest(FindBookQuery)
     
	If IsNull(FindBookResult) Then
		Response.write ("<h1>Error!</h1>")
	Else
	
		If (BookDelete = "true") Then 
			'Response.write(BookDelete & "<br>")
			
			Dim DeleteBookQuery
			DeleteBookQuery = "DECLARE	@Id int EXEC [dbo].[DeleteBook] @BookId = " & BookId & ", @Id = @Id OUTPUT SELECT	@Id as N'@Id'"
			'Response.write(DeleteBookQuery)
			Dim DeleteResp
			DeleteResp = SendSqlRequest(DeleteBookQuery)
			If ((IsNull(DeleteResp) = false) AND ()) Then
				Response.write ("<h3>Book successfully deleted!</h3>")
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

</div>



        <footer>
            <p>&copy; My ASP.Classic Application</p>
        </footer>
    </div>


</body>
</html>