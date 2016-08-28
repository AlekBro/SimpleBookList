
<% 

Dim ConnString

'define the connection string, specify database driver
'ConnString="DRIVER={SQL Server Native Client 11.0};SERVER=localhost\SQL2012;UID=sa;PWD=Passw0rd;DATABASE=SimpleBookList"

ConnString="DRIVER={SQL Server Native Client 11.0};SERVER=MAINPC;UID=sa;PWD=Passw0rd;DATABASE=SimpleBookList"


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












Function ExecuteSqlRequest(SqlRequest)

	Dim Connection
	Dim dataArray

	Set Connection = Server.CreateObject("ADODB.Connection")
	
	'Open the connection to the database
	Connection.Open ConnString

	set dataArray = Connection.Execute(SqlRequest)

	Connection.Close
	set Connection = nothing
	
	ExecuteSqlRequest = dataArray
	
	response.write("!<br />")
	
	
End Function 




Function RunSQLReturnRS(SQLstmt, params())
    On Error Resume next

    ''//Create the ADO objects
    Dim rs , cmd
    Set rs = server.createobject("ADODB.Recordset")
    Set cmd = server.createobject("ADODB.Command")

    ''//Init the ADO objects  & the stored proc parameters
    cmd.ActiveConnection = GetConnectionString()
    cmd.CommandText = SQLstmt
    cmd.CommandType = adCmdText
    cmd.CommandTimeout = 900 

    ''// propietary function that put params in the cmd
    collectParams cmd, params

    ''//Execute the query for readonly
    rs.CursorLocation = adUseClient
    rs.Open cmd, , adOpenForwardOnly, adLockReadOnly
    If err.number > 0 then
        BuildErrorMessage()
        exit function
    end if

    ''// Disconnect the recordset
    Set cmd.ActiveConnection = Nothing
    Set cmd = Nothing
    Set rs.ActiveConnection = Nothing

    ''// Return the resultant recordset
    Set RunSQLReturnRS = rs

End Function




Function GetSqlRS(strSQL)
  'this function returns a disconnected RS

  'Set some constants
  Dim adOpenStatic,adUseClient,adLockBatchOptimistic
  adOpenStatic = 3    
  adUseClient = 3
  adLockBatchOptimistic = 4 

  Dim adLockReadOnly, adOpenForwardOnly, SQLCommandTimeout
  adLockReadOnly = 1
  adOpenForwardOnly = 0
  SQLCommandTimeout = 600
  
  'Declare our variables
  Dim oConn
  Dim oRS

  'Open a connection
  Set oConn = Server.CreateObject("ADODB.Connection")

    'Create the Recordset object
  Set oRS = Server.CreateObject("ADODB.Recordset")

  oConn.Open ConnString

  oRS.CursorLocation = adUseClient

  'Populate the Recordset object with a SQL query
  ' objRecordset.Open source,actconn,cursortyp,locktyp,opt
  oRS.Open strSQL, oConn, adOpenForwardOnly,adLockReadOnly

  'Disconnect the Recordset
  oRS.ActiveConnection = Nothing

  'Return the Recordset
  GetRS = oRS

  'Clean up...
  oConn.Close
  oRS.Close
  Set oConn = Nothing
  Set oRS = Nothing


End Function






function disconnRS(SQL)

Dim adLockReadOnly, adUseClient, adOpenForwardOnly, SQLCommandTimeout
adLockReadOnly = 1
adOpenForwardOnly = 0
adUseClient=3
SQLCommandTimeout = 600

Dim Conn, oRs
Set Conn = Server.CreateObject("ADODB.Connection")
Conn.Open ConnString
Conn.CommandTimeout = SQLCommandTimeout

Set oRs = Server.CreateObject("ADOR.RecordSet")
oRs.CursorLocation = adUseClient
oRs.Open SQL,Conn,adOpenForwardOnly,adLockReadOnly

oRs.ActiveConnection = Nothing

disconnRS = oRs

Conn.Close()
Set Conn = Nothing

End Function








%>