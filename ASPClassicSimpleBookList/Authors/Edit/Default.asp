<!-- #include virtual = "Header.asp" -->
<!-- #include virtual = "SqlConnect.asp" -->

<hr />

<%

dim AuthorId
AuthorId = Request.QueryString("AuthorId")

If ((Not (AuthorId = "")) AND (Not (ISNULL(AuthorId))) AND (IsNumeric(AuthorId)) AND (Not (IsEmpty(AuthorId))) ) Then 

	Dim SqlGetAuthor
	SqlGetAuthor = "SELECT * FROM Authors WHERE Id=" & AuthorId
	
	Dim FindAuthorResult
	FindAuthorResult = SendSqlRequest(SqlGetAuthor)
	
	If IsNull(FindBookResult) Then
		Response.write ("<h1>Error! Such Author is not exist!</h1>")
		response.write("<h4 style='margin-top:2em;'><a href='/Authors/'>Return to list</a></h4>")
		Response.end
	End If

End If

%>

<form action="EditAuthor.asp" method="POST">
<div class="form-horizontal">
        <hr>
        <input data-val="true" data-val-number="The field Id must be a number." data-val-required="The Id field is required." id="Id" name="Id" type="hidden" value="<% Response.write (FindAuthorResult(0)("Id")) %>">
        <div class="form-group">
            <label class="control-label col-md-2" for="FirstName">FirstName</label>
            <div class="col-md-10">
                <input class="form-control text-box single-line" data-val="true" data-val-length="The field FirstName must be a string with a maximum length of 100." data-val-length-max="100" data-val-required="The FirstName field is required." id="FirstName" name="FirstName" type="text" value="<% Response.write (FindAuthorResult(0)("FirstName")) %>">
                <span class="field-validation-valid text-danger" data-valmsg-for="FirstName" data-valmsg-replace="true"></span>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-md-2" for="LastName">LastName</label>
            <div class="col-md-10">
                <input class="form-control text-box single-line" data-val="true" data-val-length="The field LastName must be a string with a maximum length of 100." data-val-length-max="100" data-val-required="The LastName field is required." id="LastName" name="LastName" type="text" value="<% Response.write (FindAuthorResult(0)("LastName")) %>">
                <span class="field-validation-valid text-danger" data-valmsg-for="LastName" data-valmsg-replace="true"></span>
            </div>
        </div>
		<div class="form-group">
		    <div class="col-md-offset-2 col-md-10">
		        <input type="submit" value="Submit" class="btn btn-default">
		        <input type="button" value="Cancel" onclick="javascript:location.href='/Authors/'" class="btn btn-default" id="CancelButton">
		    </div>
		</div>
    </div>
</form>

<!-- #include virtual = "Footer.asp" -->
