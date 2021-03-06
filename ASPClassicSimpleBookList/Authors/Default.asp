<!-- #include virtual = "Header.asp" -->
<!-- #include virtual = "SqlConnect.asp" -->

<script src="/Scripts/App/Authors.TableLoading.js"></script>

<h2>Authors List</h2>
<hr />
<hr />
<a href="./CreateAuthor.asp">Add New Author</a>
<br/><br/>

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
    If IsNull(ResArray) Then
    	Response.write ("")
    Else
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
	End If

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


<!-- #include virtual = "Footer.asp" -->
