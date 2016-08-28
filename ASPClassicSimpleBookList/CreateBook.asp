﻿<!DOCTYPE html>
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
	<link rel="stylesheet" href="/Styles/multi-select.css">
	
	
	<script src="/Scripts/jquery-2.2.3.js"></script>
	<script src="/Scripts/jquery-ui.js"></script>
	<script src="/Scripts/jquery.validate.js"></script>
	<script src="/Scripts/jquery.validate.unobtrusive.js"></script>
	
	<script src="/Scripts/jquery.dataTables.js"></script>
	<script src="/Scripts/bootstrap.js"></script>
	<script src="/Scripts/jquery.multi-select.js"></script>
	
	<script src="/Scripts/App/Books.Functions.js"></script>
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
            </div>
        </div>
    </div>
    <div class="container body-content">



<h1 id="booksTitle">SimpleBookList</h1>
<h2>Books List</h2>

<hr />
<div id="dialogContainer"></div>
<hr />

<!-- #include file ="SqlConnect.asp" -->

<%


'declare the variables 
Dim Connection
Dim Recordset


'create an instance of the ADO connection and recordset objects
Set Connection = Server.CreateObject("ADODB.Connection")
Set Recordset = Server.CreateObject("ADODB.Recordset")


If (Request.Form.Count > 0) Then

	Response.write (Request.Form.Count)
	Response.write ("<br><br>")

  For Each sItem In Request.Form
    Response.Write(sItem)
    Response.Write(" - [" & Request.Form(sItem) & "]" & "<br>")
  Next


'AuthorsIds - [12, 16, 14]

Dim SqlFindAuthorQuery
Dim ResArray

Dim SqlFindAuthor
SqlFindAuthor = "SELECT Id FROM Authors WHERE Id="

Response.write ("<br><br>")
For each AuthorId in Request.Form("AuthorsIds")
	SqlFindAuthorQuery = SqlFindAuthor & AuthorId
	Response.write (SqlFindAuthorQuery)
	Response.write ("<br>")
	
	ResArray = SendSqlRequest(SqlFindAuthorQuery)
	If IsNull(ResArray) Then
		response.write("Authors is wrong!")
		response.end
	End If
Next
Response.write ("<br><br>")


DIM SqlAddNewBook
SqlAddNewBook = "DECLARE @BookId int EXEC [dbo].[AddNewBook] @Name = N'" & Request.Form("Name") & "'," & "@ReleaseDate = N'" & Request.Form("ReleaseDate") & "'," & "@Pages = " & Request.Form("Pages") 
SqlAddNewBook = SqlAddNewBook & ", @Rating = " & Request.Form("Rating")
if (ISNULL(Request.Form("Publisher")) OR (Request.Form("Publisher")="")) Then
	SqlAddNewBook = SqlAddNewBook & ", @Publisher = NULL"
Else
	SqlAddNewBook = SqlAddNewBook & ", @Publisher = N'" & Request.Form("Publisher") & "', "
End IF

if (ISNULL(Request.Form("ISBN")) OR (Request.Form("ISBN")="")) Then
	SqlAddNewBook = SqlAddNewBook & ", @ISBN = NULL"
Else
	SqlAddNewBook = SqlAddNewBook & ", @ISBN = N'" & Request.Form("ISBN") & "', "
End IF

SqlAddNewBook = SqlAddNewBook & ", @BookId = @BookId OUTPUT SELECT @BookId as N'BookId'"


Response.Write("<br><br>") 
Response.Write(SqlAddNewBook) 
Response.Write("<br><br>") 


Dim ResArray2
ResArray2 = SendSqlRequest(SqlAddNewBook)

Dim AddAuthorQuery
If IsNull(ResArray2) Then
		response.write("Book is wrong!")
		response.end
	Else
	For each AuthorId in Request.Form("AuthorsIds")
		AddAuthorQuery = "EXEC [dbo].[AddNewBookAuthorsRecord] @BookId = " & ResArray2(0)("BookId") & ", @AuthorId = " & AuthorId
		response.write(AddAuthorQuery)
		Response.Write("<br><br>")
	Next
end if



End If

%>






<form action="/CreateBook.asp" data-ajax-method="POST" id="CreateBookForm" method="post">
<div class="form-horizontal">
        <h4>Add new Book</h4>
        <hr>


<div class="form-group">
    <label class="control-label col-md-2" for="Name">Name</label>
    <div class="col-md-10">
        <input class="form-control text-box single-line" data-val="true" data-val-length="The field Name must be a string with a maximum length of 300." data-val-length-max="300" data-val-required="The Name field is required." id="Name" name="Name" type="text" value="">
        <span class="field-validation-valid text-danger" data-valmsg-for="Name" data-valmsg-replace="true"></span>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-md-2" for="ReleaseDate">Release Date</label>
    <div class="col-md-10">
        <input class="form-control" data-val="true" data-val-date="The field Release Date must be a date." data-val-required="The Release Date field is required." id="ReleaseDate" name="ReleaseDate" type="text" value="">
        <span class="field-validation-valid text-danger" data-valmsg-for="ReleaseDate" data-valmsg-replace="true"></span>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-md-2" for="Pages">Pages</label>
    <div class="col-md-10">
        <input class="form-control" data-val="true" data-val-number="The field Pages must be a number." data-val-range="Page number cannot be 0 or less." data-val-range-max="2147483647" data-val-range-min="1" data-val-required="The Pages field is required." id="Pages" name="Pages" type="text" value="">
        <span class="field-validation-valid text-danger" data-valmsg-for="Pages" data-valmsg-replace="true"></span>
    </div>
</div>

<div class="form-group">
    <label class="control-label col-md-2" for="Rating">Rating</label>
    <div class="col-md-10">
        <select class="form-control" data-val="true" data-val-number="The field Rating must be a number." data-val-range="Rating is must be between 0 and 10" data-val-range-max="10" data-val-range-min="0" data-val-required="The Rating field is required." id="Rating" name="Rating"><option value="0">0</option>
<option value="1">1</option>
<option value="2">2</option>
<option value="3">3</option>
<option value="4">4</option>
<option value="5">5</option>
<option value="6">6</option>
<option value="7">7</option>
<option value="8">8</option>
<option value="9">9</option>
<option value="10">10</option>
</select>
        <span class="field-validation-valid text-danger" data-valmsg-for="Rating" data-valmsg-replace="true"></span>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-md-2" for="Publisher">Publisher</label>
    <div class="col-md-10">
        <input class="form-control text-box single-line" data-val="true" data-val-length="The field Publisher must be a string with a maximum length of 100." data-val-length-max="100" id="Publisher" name="Publisher" type="text" value="">
        <span class="field-validation-valid text-danger" data-valmsg-for="Publisher" data-valmsg-replace="true"></span>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-md-2" for="ISBN">ISBN</label>
    <div class="col-md-10">
        <input class="form-control text-box single-line" data-val="true" data-val-length="The field ISBN must be a string with a maximum length of 100." data-val-length-max="100" data-val-requiredif="The ISBN field is required when Publisher was entered." data-val-requiredif-dependentproperty="Publisher" id="ISBN" name="ISBN" type="text" value="">
        <span class="field-validation-valid text-danger" data-valmsg-for="ISBN" data-valmsg-replace="true"></span>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-md-2" for="Authors">Authors</label>
    <div class="col-md-10">

        <select class="searchableMultiselect" id="AuthorsIds" multiple="multiple" name="AuthorsIds">
<%


Dim SQLAuthors
'declare the SQL statement that will query the database
SQLAuthors = "SELECT * FROM Authors"






'Open the connection to the database
Connection.Open ConnString

'Open the recordset object executing the SQL statement and return records 
Recordset.Open SQLAuthors, Connection


If Recordset.EOF Then 
	Response.Write("No Authors") 
Else 
	
	'if there are records then loop through the fields 
	Do While NOT Recordset.Eof

		Response.Write("<option value='" & Recordset("Id") & "'>" & Recordset("FirstName") & " " & Recordset("LastName") & "</option>")

		
		Recordset.MoveNext
	Loop

End If

'close the connection and recordset objects to free up resources
Recordset.Close
Connection.Close



%>


</select>


        <span class="field-validation-valid text-danger" data-valmsg-for="Authors" data-valmsg-replace="true"></span>
    </div>
</div>
<div class="form-group">
    <div class="col-md-offset-2 col-md-10">
        <input type="submit" value="Submit" class="btn btn-default">
        <input type="button" value="Cancel" class="btn btn-default" id="CancelButton">
    </div>
</div>

    </div>
</form>



<script type="text/javascript">
    $(document).ready(function () {
    
    // Set From and To fields as datepickers
	$("#ReleaseDate").datepicker({ dateFormat: 'mm/dd/yy' });


    $('.searchableMultiselect').multiSelect({
        selectableHeader: "<input type='text' class='search-input' autocomplete='off' placeholder='try \"12\"'>",
        selectionHeader: "<input type='text' class='search-input' autocomplete='off' placeholder='try \"4\"'>",
        afterInit: function (ms) {
            var that = this,
                $selectableSearch = that.$selectableUl.prev(),
                $selectionSearch = that.$selectionUl.prev(),
                selectableSearchString = '#' + that.$container.attr('id') + ' .ms-elem-selectable:not(.ms-selected)',
                selectionSearchString = '#' + that.$container.attr('id') + ' .ms-elem-selection.ms-selected';

            that.qs1 = $selectableSearch.quicksearch(selectableSearchString)
            .on('keydown', function (e) {
                if (e.which === 40) {
                    that.$selectableUl.focus();
                    return false;
                }
            });

            that.qs2 = $selectionSearch.quicksearch(selectionSearchString)
            .on('keydown', function (e) {
                if (e.which == 40) {
                    that.$selectionUl.focus();
                    return false;
                }
            });
        },
        afterSelect: function () {
            this.qs1.cache();
            this.qs2.cache();
        },
        afterDeselect: function () {
            this.qs1.cache();
            this.qs2.cache();
        }
    });
		
		
    });
</script>















        <hr />
        <footer>
            <p>&copy; My ASP.Classic Application</p>
        </footer>
    </div>


</body>
</html>
