<!-- #include virtual = "Header.asp" -->


<!-- #include virtual = "SqlConnect.asp" -->

<%

Function AddNewAuthor(RequestContext)


	Dim SqlAddNewAuthor
	SqlAddNewAuthor = "DECLARE	@AuthorId int EXEC [dbo].[AddNewAuthor] "
	
	If (ISNULL(RequestContext.Form("FirstName")) OR (RequestContext.Form("FirstName")="")) Then
		SqlAddNewAuthor = SqlAddNewAuthor & "@FirstName = NULL "
	Else
		SqlAddNewAuthor = SqlAddNewAuthor & "@FirstName = N'" & RequestContext.Form("FirstName") & "'"
	End If

	If (ISNULL(RequestContext.Form("LastName")) OR (RequestContext.Form("LastName")="")) Then
		SqlAddNewAuthor = SqlAddNewAuthor & ", @LastName = NULL, "
	Else
		SqlAddNewAuthor = SqlAddNewAuthor & ", @LastName = N'" & RequestContext.Form("LastName") & "'"
	End If

	SqlAddNewAuthor = SqlAddNewAuthor & ", @AuthorId = @AuthorId OUTPUT SELECT @AuthorId as N'@AuthorId'"
	
	'response.write(SqlAddNewAuthor)
	'response.write("<br><br>")

	Dim ResArray
	ResArray = SendSqlRequest(SqlAddNewAuthor)


	If IsNull(ResArray) Then
		AddNewAuthor = false
	Else
		AddNewAuthor = true
	End if
	
	
End Function



If (Request.Form.Count > 0) Then

	Dim AddNewAuthorResult
	AddNewAuthorResult = AddNewAuthor(Request)

	If (AddNewAuthorResult) Then
		response.write("<h1>New Author is added!</h1>")
		response.write("<script>$(document).ready(function () { $('#CreateAuthorForm').hide(); });</script>")
	Else
		response.write("<h1>Error while adding new Author!</h1>")
		response.write("<script>$(document).ready(function () { $('#CreateAuthorForm').hide(); });</script>")
	End if


End If

%>




<form action="" method="POST" id="CreateAuthorForm">
    <div class="form-horizontal">
        <h4>Add new Author</h4>
        <hr>

		<div class="form-group">
			<label class="control-label col-md-2" for="FirstName">FirstName</label>
			<div class="col-md-10">
				<input class="form-control text-box single-line" data-val="true" data-val-length="The field FirstName must be a string with a maximum length of 100." data-val-length-max="100" data-val-required="The FirstName field is required." id="FirstName" name="FirstName" type="text" value="">
				<span class="field-validation-valid text-danger" data-valmsg-for="FirstName" data-valmsg-replace="true"></span>
			</div>
		</div>
		<div class="form-group">
			<label class="control-label col-md-2" for="LastName">LastName</label>
			<div class="col-md-10">
				<input class="form-control text-box single-line" data-val="true" data-val-length="The field LastName must be a string with a maximum length of 100." data-val-length-max="100" data-val-required="The LastName field is required." id="LastName" name="LastName" type="text" value="">
				<span class="field-validation-valid text-danger" data-valmsg-for="LastName" data-valmsg-replace="true"></span>
			</div>
		</div>
		<div class="form-group">
			<div class="col-md-offset-2 col-md-10">
				<input type="submit" value="Submit" class="btn btn-default">
				<input type="button" value="Cancel" onclick="javascript:location.href='/'" class="btn btn-default" id="CancelButton">
			</div>
		</div>

    </div>
</form>







<!-- #include virtual = "Footer.asp" -->