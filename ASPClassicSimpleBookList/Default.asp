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
		<th id="OnlyEditRight">Edit</th>
		<th id="OnlyEditRight">Delete</th>
	</tr>
</thead>

<tbody>

<!-- #include file ="SqlConnect.asp" -->


<% 



' create a dictionary object
dim companies
set companies = server.createObject("Scripting.Dictionary")

' add the companies
companies.add "Key1", "Company1"
companies.add "Key2", "Company2"
companies.add "Key3", "Company3"

' iteration example
dim key
for each key in companies.keys
    response.write key & " = " & companies.item(key)
next



sub GetAuthorsList(BookId) 

	'declare the variables 
	Dim Connection2

	Dim RecordsetAuthors
	Dim SQLAuthors, SQLAuthorsString

	SQLAuthors = "SELECT Authors.Id, Authors.FirstName, Authors.LastName FROM Authors INNER JOIN BookAuthors ON BookAuthors.Author_Id = Authors.Id Where BookAuthors.Book_Id ="

	Set Connection2 = Server.CreateObject("ADODB.Connection")
	Set RecordsetAuthors = Server.CreateObject("ADODB.Recordset")

	Dim AuthorsArray()

	SQLAuthorsString = SQLAuthors & BookId

	'Response.write (SQLAuthorsString)

	'Open the connection to the database
	Connection2.Open ConnString

	'Open the recordset object executing the SQL statement and return records 
	RecordsetAuthors.Open SQLAuthorsString,Connection2

	Dim i
	i = 0
	ReDim AuthorsArray(i)
	Do While NOT RecordsetAuthors.Eof

		AuthorsArray(i) ="<a href='/Authors/?Id=" & RecordsetAuthors("Id") & "'>" & RecordsetAuthors("FirstName") & " " & RecordsetAuthors("LastName") & "</a>"
		i = i + 1
		ReDim Preserve AuthorsArray(i)
		RecordsetAuthors.MoveNext
	Loop
	
	

	For k = 0 To i - 1
		if k < i - 1 Then
  			response.write(AuthorsArray(k) & " | ")
  		Else
  			response.write(AuthorsArray(k))
  		End If
	Next

	RecordsetAuthors.Close
	'Set Recordset=nothing
	Connection2.Close
	'Set Connection=nothing


end sub




Sub GetAllRecordsFromDB(columnsArray)


	'declare the variables 
	Dim SQLBooks
	Dim Recordset
	
	'declare the SQL statement that will query the database
	SQLBooks = "SELECT * FROM Books"

	response.write("!<br />")

	Recordset = SendSqlRequest(SQLBooks)	
	'Recordset = disconnRS(SQLBooks)	
	
	for each x in rs.fields
	response.write(Recordset.name)
	response.write(" = ")
	response.write(Recordset.value)
	next
	
	response.write("!!<br />")
	
	aspLog(SQLBooks)
	
		response.write("!!!<br />")	
		'if there are records then loop through the fields 
		if	Recordset.Eof then
			response.write("!!!!<br />")	
		End if
		
		
		Do While NOT Recordset.Eof
			response.write("!!!!<br />")	
			Response.write "<tr>"
			For Each column In columnsArray
				Response.write "<td>"

				If column = "Authors" Then

					Call GetAuthorsList(Recordset("Id"))

					'Response.write Recordset(column)
				
				ElseIf (column = "Edit") OR (column = "Delete") Then
					Response.write ""
				Else
						Response.write Recordset(column)
				End If
				
				Response.write "</td>"
				
			Next
				
				Response.write "</tr>"

			Recordset.MoveNext
		Loop
	
	

	
	


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








