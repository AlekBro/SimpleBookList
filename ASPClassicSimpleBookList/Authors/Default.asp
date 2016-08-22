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
	<script src="/Scripts/jquery-ui-1.11.4.js"></script>
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
                <a class="navbar-brand" href=''>Home</a>
                <a class="navbar-brand" href=''>Home</a>
                <a class="navbar-brand" =''>Home</a>
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
<div id="dialogContainer"></div>
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
	</tr>
</thead>

<tbody>




<% 

Dim ConnString

'define the connection string, specify database driver
ConnString="DRIVER={SQL Server Native Client 11.0};SERVER=MAINPC;UID=sa;" & _ 
"PWD=Passw0rd;DATABASE=SimpleBookList"



Sub GetAllRecordsFromDB(columnsArray)


	'declare the variables 
	Dim Connection
	Dim ConnString
	Dim Recordset
	Dim SQLBooks

	'define the connection string, specify database driver
	ConnString="DRIVER={SQL Server Native Client 11.0};SERVER=MAINPC;UID=sa;" & _ 
	"PWD=Passw0rd;DATABASE=SimpleBookList"

	'declare the SQL statement that will query the database
	SQLBooks = "SELECT * FROM AuthorsView"


	'create an instance of the ADO connection and recordset objects
	Set Connection = Server.CreateObject("ADODB.Connection")
	Set Recordset = Server.CreateObject("ADODB.Recordset")


	'Open the connection to the database
	Connection.Open ConnString

	'Open the recordset object executing the SQL statement and return records 
	Recordset.Open SQLBooks,Connection

	'first of all determine whether there are any records 
	If Recordset.EOF Then 
		Response.Write("No records returned.") 
	Else 
		
		'if there are records then loop through the fields 
		Do While NOT Recordset.Eof

			Response.write "<tr>"
			For Each column In columnsArray
				Response.write "<td>"
				
				If (column = "Edit") OR (column = "Delete") Then
				Else
						Response.write Recordset(column)
				End If
				
				Response.write "</td>"
				
			Next
				
				Response.write "</tr>"

			Recordset.MoveNext
		Loop
	
	End If

	'close the connection and recordset objects to free up resources
	Recordset.Close
	Set Recordset=nothing
	Connection.Close
	Set Connection=nothing


'myfunction=some value
End Sub 


Dim columns(5)
columns(0) = "Id"
columns(1) = "FirstName"
columns(2) = "LastName"
columns(3) = "BooksNumber"
columns(4) = "Edit"
columns(5) = "Delete"


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