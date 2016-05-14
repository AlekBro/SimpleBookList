// Add a new row to the table and send a message about the successful creation of Event.
function OnCreateSuccess(response) {
    var booksTable = $('#BooksListTable').dataTable();
    booksTable.fnAddData(response);

    alert("Event has been created!");
    $("#dialogContainer").html("");
}

function OnCreateFailure(response) {
    alert("!OnCreateFailure!");

    $("#dialogContainer").html(response);
}

// Update row at the table and send a message about the this successful operation.
function OnEditSuccess(response) {
    var booksTable = $('#BooksListTable').dataTable();

    row = $.grep(booksTable.fnSettings().aoData, function (obj) {
        return obj._aData.Id == response.Id;
    })[0].nTr;

    booksTable.fnUpdate(response, $(row).get(0));

    $("#dialogContainer").html("");

    alert("Event has been changed!");
};


// Delete row from the table and send a message about the this successful operation.
function OnDeleteSuccess(response) {
    var booksTable = $('#BooksListTable').dataTable();

    row = $.grep(booksTable.fnSettings().aoData, function (obj) {
        return obj._aData.Id == response;
    })[0].nTr;

    booksTable.fnDeleteRow($(row).get(0));

    $("#dialogContainer").html("");
    alert("Event has been deleted!");

}

// Display a message with response text after an unsuccessful request
function OnFailure(response) {
    alert("!Error!\n" + response.responseJSON.error);
}

