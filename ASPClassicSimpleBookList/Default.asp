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
	<script src="/Scripts/jquery.quicksearch.js"></script>

	<script src="/Scripts/App/Books.TableLoading.js"></script>
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
                <a class="navbar-brand" href='/'>Home</a>
                <a class="navbar-brand" href='/Authors/'>Authors List</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a href=''>About</a></li>
                    <li><a href=''>About</a></li>
                </ul>
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div class="container body-content">



<h1 id="booksTitle">SimpleBookList</h1>
<h2>Books List</h2>

<hr />
<div id="dialogContainer"></div>
<hr />

<a href="./CreateBook.asp">Add New Book</a>
<br/><br/>

<table class="table" id="BooksListTable" cellspacing="0">
<thead>
	<tr>
		<th>Id</th>
		<th>Name</th>
		<th>ReleaseDate</th>
		<th>Pages</th>
		<th>Rating</th>
		<th>Authors</th>
		<th>Publisher</th>
		<th>ISBN</th>
		<th>Edit</th>
		<th>Delete</th>
	</tr>
</thead>

<tbody>

<!-- #include file ="SqlConnect.asp" -->


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
				response.write( "<a href='/Authors/?Id=" & oneRow("Id") & "'>" & oneRow("FirstName") & " " & oneRow("LastName") & "</a>" & " | ")
			Else
				response.write( "<a href='/Authors/?Id=" & oneRow("Id") & "'>" & oneRow("FirstName") & " " & oneRow("LastName") & "</a>")
			End if
			k = k + 1
		Next
	End If




end sub




Sub GetAllRecordsFromDB(columnsArray)


	'declare the variables 
	Dim SQLBooks
	Dim ResultArray
	
	'declare the SQL statement that will query the database
	SQLBooks = "SELECT * FROM Books"

	ResultArray = SendSqlRequest(SQLBooks)

    If IsNull(ResultArray) Then
    	Response.write ("")
    Else
		For Each row In ResultArray
		Response.write "<tr>"
			For Each column In columnsArray
					Response.write "<td>"
					If column = "Authors" Then
						Call GetAuthorsList(row("Id"))
					ElseIf (column = "Edit") OR (column = "Delete") Then
						Response.write ""
					Else
							Response.write row(column)
					End If
					Response.write "</td>"
				Next
		Response.write "</tr>"
		Next
	End if

End Sub


Dim columns(9)
columns(0) = "Id"
columns(1) = "Name"
columns(2) = "ReleaseDate"
columns(3) = "Pages"
columns(4) = "Rating"
columns(5) = "Authors"
columns(6) = "Publisher"
columns(7) = "ISBN"
columns(8) = "Edit"
columns(9) = "Delete"


Call GetAllRecordsFromDB(columns)



%>


</tbody>
</table>







        <hr />
        <footer>
            <p>&copy; My ASP.Classic Application</p>
        </footer>
    </div>


</body>
</html>








