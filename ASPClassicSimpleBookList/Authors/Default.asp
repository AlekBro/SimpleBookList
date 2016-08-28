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
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div class="container body-content">



<h1 id="booksTitle">SimpleBookList</h1>
<h2>Authors List</h2>

<hr />
<div id="dialogContainer">

<!-- #include virtual = "SqlConnect.asp" -->

<%

dim AuthorId
AuthorId = Request.QueryString("Id")

If ((Not (AuthorId = "")) AND (Not (ISNULL(AuthorId))) AND (IsNumeric(AuthorId)) AND (Not (IsEmpty(AuthorId))) ) Then 
    
	Dim SQLForOneAuthor
	SQLForOneAuthor = "SELECT * FROM AuthorsView WHERE Id =" & AuthorId

	
	Dim ResArrayForOneAuthor
	ResArrayForOneAuthor = SendSqlRequest(SQLForOneAuthor)
    
    'If IsNull(ResArrayForOneAuthor) = false Then
		For Each row In ResArrayForOneAuthor
			Response.write ("<h2>" & row("FirstName") & " " & row("LastName") & "</h2>")
			Response.write ("<div><hr /><dl class='dl-horizontal'><dt>FirstName</dt><dd>" & row("FirstName") & "</dd>")
			Response.write ("<dt>LastName</dt><dd>" & row("LastName") & "</dd>")
			Response.write ("<dt>BooksNumber</dt><dd>" & row("BooksNumber") & "</dd>")
	    	Response.write ("</dl></div>")
		Next
	'End If


    
End if

%>

</div>
<hr />



<table class="table" id="AuthorsListTable" cellspacing="0">
<thead>
	<tr>
		<th>Id</th>
		<th>First Name</th>
		<th>Last Name</th>
		<th>Books Number</th>
		<th>Edit</th>
		<th>Delete</th>
		<th>Details</th>
	</tr>
</thead>

<tbody>




<% 





Sub GetAllRecordsFromDB(columnsArray)

	Dim SQLAuthorsString
	SQLAuthorsString = "SELECT * FROM AuthorsView"

	Dim ResArray
	ResArray = SendSqlRequest(SQLAuthorsString)


	For Each row In ResArray
	Response.write "<tr>"
	
		For Each column In columnsArray
			Response.write "<td>"
			If (column = "Edit") OR (column = "Delete") OR (column = "Details") Then
			Else
				Response.write row(column)
			End If
				Response.write "</td>"
		Next

	Response.write "</tr>"

	Next


End Sub 



Dim columns(6)
columns(0) = "Id"
columns(1) = "FirstName"
columns(2) = "LastName"
columns(3) = "BooksNumber"
columns(4) = "Edit"
columns(5) = "Delete"
columns(6) = "Details"


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