﻿
<% 

Dim ConnString

'define the connection string, specify database driver
ConnString="DRIVER={SQL Server Native Client 11.0};SERVER=localhost\SQL2012;UID=sa;PWD=Passw0rd;DATABASE=SimpleBookList"
'ConnString="DRIVER={SQL Server Native Client 11.0};SERVER=MAINPC;UID=sa;PWD=Passw0rd;DATABASE=SimpleBookList"


function aspLog(value)
    response.Write("<script language=javascript>console.log('" & value & "'); </script>")
end function


Function CreateAuthorInDB(FirstName, LastName)
	dim Connection
	Set Connection = Server.CreateObject("ADODB.Connection")
	Connection.ConnectionString = ConnString
	Connection.Open
	
	dim cmd
	set cmd = server.CreateObject("adodb.command")

	cmd.ActiveConnection = Connection
	cmd.CommandText = "AddNewAuthor"
	cmd.CommandType = 4
	
	cmd.Parameters.Append cmd.CreateParameter("@FirstName", 202, 1, 100, FirstName)
	cmd.Parameters.Append cmd.CreateParameter("@LastName", 202, 1, 100, LastName)
	cmd.Parameters.Append cmd.CreateParameter("@AuthorId", 3, 4)
	
	cmd.Execute
	
	Dim AuthorId
	AuthorId = cmd.Parameters("@AuthorId").Value
	
	set cmd = nothing
	Connection.Close
	set Connection = nothing
	
	CreateAuthorInDB = AuthorId
	
End Function




Function CreateBookInDB(Name, ReleaseDate, Pages, Rating, Publisher, ISBN, AuthorsIDs)
	dim Connection
	Set Connection = Server.CreateObject("ADODB.Connection")
	Connection.ConnectionString = ConnString
	Connection.Open
	
	dim cmd
	set cmd = server.CreateObject("adodb.command")

	cmd.ActiveConnection = Connection
	cmd.CommandText = "AddNewBook"
	cmd.CommandType = 4
	
	cmd.Parameters.Append cmd.CreateParameter("@Name", 202, 1, 300, Name)
	cmd.Parameters.Append cmd.CreateParameter("@ReleaseDate", 133, 1, , ReleaseDate)
    cmd.Parameters.Append cmd.CreateParameter("@Pages", 3, 1, , Pages)
    cmd.Parameters.Append cmd.CreateParameter("@Rating", 3, 1, , Rating)
	If (ISNULL(Publisher) OR (Publisher = "")) Then
		cmd.Parameters.Append cmd.CreateParameter("@Publisher", 202, 1, 100, null)
	Else
		cmd.Parameters.Append cmd.CreateParameter("@Publisher", 202, 1, 100, Publisher)
	End If
	If (ISNULL(ISBN) OR (ISBN = "")) Then
		cmd.Parameters.Append cmd.CreateParameter("@ISBN", 202, 1, 20, null)
	Else
		cmd.Parameters.Append cmd.CreateParameter("@ISBN", 202, 1, 20, ISBN)
	End If
	If (ISNULL(AuthorsIDs) OR (AuthorsIDs = "")) Then
		cmd.Parameters.Append cmd.CreateParameter("@AuthorsIDs", 202, 1, 300, null)
	Else
		cmd.Parameters.Append cmd.CreateParameter("@AuthorsIDs", 202, 1, 300, AuthorsIDs)
	End If
	
    cmd.Parameters.Append cmd.CreateParameter("@BookId", 3, 4)
	
	cmd.Execute
	
	Dim BookId
	BookId = cmd.Parameters("@BookId").Value
	
	set cmd = nothing
	Connection.Close
	set Connection = nothing
	
	CreateBookInDB = BookId
	
End Function




Function EditBookInDB(Id, Name, ReleaseDate, Pages, Rating, Publisher, ISBN, AuthorsIDs)
	dim Connection
	Set Connection = Server.CreateObject("ADODB.Connection")
	Connection.ConnectionString = ConnString
	Connection.Open
	
	dim cmd
	set cmd = server.CreateObject("adodb.command")

	cmd.ActiveConnection = Connection
	cmd.CommandText = "EditBook"
	cmd.CommandType = 4
	
    cmd.Parameters.Append cmd.CreateParameter("@Id", 3, 1, , Id)
	cmd.Parameters.Append cmd.CreateParameter("@Name", 202, 1, 300, Name)
	cmd.Parameters.Append cmd.CreateParameter("@ReleaseDate", 133, 1, , ReleaseDate)
    cmd.Parameters.Append cmd.CreateParameter("@Pages", 3, 1, , Pages)
    cmd.Parameters.Append cmd.CreateParameter("@Rating", 3, 1, , Rating)
   
   	If (ISNULL(Publisher) OR (Publisher = "")) Then
		cmd.Parameters.Append cmd.CreateParameter("@Publisher", 202, 1, 100, null)
	Else
		cmd.Parameters.Append cmd.CreateParameter("@Publisher", 202, 1, 100, Publisher)
	End If
	If (ISNULL(ISBN) OR (ISBN = "")) Then
		cmd.Parameters.Append cmd.CreateParameter("@ISBN", 202, 1, 20, null)
	Else
		cmd.Parameters.Append cmd.CreateParameter("@ISBN", 202, 1, 20, ISBN)
	End If
	If (ISNULL(AuthorsIDs) OR (AuthorsIDs = "")) Then
		cmd.Parameters.Append cmd.CreateParameter("@AuthorsIDs", 202, 1, 300, null)
	Else
		cmd.Parameters.Append cmd.CreateParameter("@AuthorsIDs", 202, 1, 300, AuthorsIDs)
	End If
   
    cmd.Parameters.Append cmd.CreateParameter("@BookId", 3, 4)
	
	cmd.Execute
	
	Dim BookId
	BookId = cmd.Parameters("@BookId").Value
	
	set cmd = nothing
	Connection.Close
	set Connection = nothing
	
	EditBookInDB = BookId
	
End Function





Function SendSqlRequest(SqlRequest)

	Dim Recordset

	Set Connection = Server.CreateObject("ADODB.Connection")
	Set Recordset = Server.CreateObject("ADODB.Recordset")

	'Open the connection to the database
	Connection.Open ConnString
	
	'Open the recordset object executing the SQL statement and return records 
	Recordset.Open SqlRequest,Connection

	Dim resultDict
	
	Dim ResultArray()
	Dim i
	i = 0
	ReDim ResultArray(i)

	If Recordset.EOF Then
		Recordset.Close
		set Recordset = nothing
		Connection.Close
		set Connection = nothing
		SendSqlRequest = null
	
	Else
		Do While NOT Recordset.Eof

			ReDim Preserve ResultArray(i)
			
			set resultDict = server.createObject("Scripting.Dictionary")
			
			for each x in Recordset.fields
				resultDict.Add x.name, x.value
			next
			
			Set ResultArray(i) = resultDict
			
			i = i + 1
			
			Recordset.MoveNext
		Loop

	Recordset.Close
	set Recordset = nothing
	Connection.Close
	set Connection = nothing
	
	SendSqlRequest = ResultArray
	
	End If

End Function


%>