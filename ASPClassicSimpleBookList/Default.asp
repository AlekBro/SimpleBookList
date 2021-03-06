﻿<!-- #include virtual = "Header.asp" -->
<!-- #include virtual = "SqlConnect.asp" -->

<script src="/Scripts/App/Books.TableLoading.js"></script>

<h2>Books List</h2>
<hr />
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

<% 

sub GetAuthorsList(BookId)

	Dim ResArray
    ResArray = SelectBookAuthorsListFromDB(BookId)

	If IsNull(ResArray) Then
    	Response.write ("")
	Else
		Dim Lenght
		Lenght = ubound(ResArray)
		Dim k
		k = 0
		For Each oneRow In ResArray
			if ( k < Lenght) Then
				response.write( "<a href='/Authors/Details.asp?AuthorId=" & oneRow("Id") & "'>" & oneRow("FirstName") & " " & oneRow("LastName") & "</a>" & " | ")
			Else
				response.write( "<a href='/Authors/Details.asp?AuthorId=" & oneRow("Id") & "'>" & oneRow("FirstName") & " " & oneRow("LastName") & "</a>")
			End if
			k = k + 1
		Next
	End If

end sub




Sub GetAllRecordsFromDB(columnsArray)

	Dim SQLBooks
	Dim ResultArray
	
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


<!-- #include virtual = "Footer.asp" -->
