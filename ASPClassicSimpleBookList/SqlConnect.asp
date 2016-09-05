<% 

Dim ConnString

'define the connection string, specify database driver
ConnString="DRIVER={SQL Server Native Client 11.0};SERVER=localhost\SQL2012;UID=sa;PWD=Passw0rd;DATABASE=SimpleBookList"
'ConnString="DRIVER={SQL Server Native Client 11.0};SERVER=MAINPC;UID=sa;PWD=Passw0rd;DATABASE=SimpleBookList"


function aspLog(value)
    response.Write("<script language=javascript>console.log('" & value & "'); </script>")
end function


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