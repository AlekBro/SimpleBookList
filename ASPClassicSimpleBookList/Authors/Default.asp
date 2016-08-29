<!-- #include virtual = "Header.asp" -->

<script src="/Scripts/App/Authors.TableLoading.js"></script>


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
    
    If IsNull(ResArrayForOneAuthor) Then
    	Response.write ("No Such Author!")
    Else
		For Each row In ResArrayForOneAuthor
			Response.write ("<h2>" & row("FirstName") & " " & row("LastName") & "</h2>")
			Response.write ("<div><hr /><dl class='dl-horizontal'><dt>FirstName</dt><dd>" & row("FirstName") & "</dd>")
			Response.write ("<dt>LastName</dt><dd>" & row("LastName") & "</dd>")
			Response.write ("<dt>BooksNumber</dt><dd>" & row("BooksNumber") & "</dd>")
	    	Response.write ("</dl></div>")
		Next
	End If


    
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



<!-- #include virtual = "Footer.asp" -->
