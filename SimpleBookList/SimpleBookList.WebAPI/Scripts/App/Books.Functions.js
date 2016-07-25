


// Add a new row to the table and send a message about the successful creation of Book.
function OnCreateBookSuccess(response) {
    var booksTable = $('#BooksListTable').dataTable();
    booksTable.fnAddData(response);

    alert("Book has been created!");
    $("#dialogContainer").html("");
}

// Update Book and send a message about the this successful operation.
function EditBookFunc() {

    var dataFromForm = $('#EditBookForm').serializeObject();
    var AuthorsIds = $('#EditBookForm #AuthorsIds').serializeArray();
    var AuthorsIdsArray = new Array(AuthorsIds.length);
    AuthorsIds.forEach(function (item, i, arr) {
        AuthorsIdsArray[i] = item.value.toString();
    });

    dataFromForm.AuthorsIds = AuthorsIdsArray;

    $.ajax({
        url: "/api/Books/" + dataFromForm.Id,
        type: 'PUT',
        data: JSON.stringify(dataFromForm),
        contentType: "application/json;charset=utf-8",
        success: function (resp) {
            var booksTable = $('#BooksListTable').dataTable();

            row = $.grep(booksTable.fnSettings().aoData, function (obj) {
                return obj._aData.Id == dataFromForm.Id;
            })[0].nTr;

            booksTable.fnUpdate(dataFromForm, $(row).get(0));
            $("#dialogContainer").html("");
            alert('Book Updated Successfully');
        },
        error: function (response) {
            ShowApiError(response);
        }
    });
};

// DeleteBook and send a message about the this successful operation.
function deleteBookFunc(obj, event) {
    event.preventDefault();
    event.stopPropagation();

    $("#delete-dialog-confirm").dialog({
        buttons: {
            "Delete": function () {
                $(this).dialog("close");

                var Id = obj.getAttribute('value');

                $.ajax({
                    url: "/api/Books/" + Id,
                    type: 'DELETE',
                    contentType: "application/json;charset=utf-8",
                    success: function (resp) {
                        var booksTable = $('#BooksListTable').dataTable();

                        row = $.grep(booksTable.fnSettings().aoData, function (obj) {
                            return obj._aData.Id == Id;
                        })[0].nTr;

                        booksTable.fnDeleteRow($(row).get(0));

                        $("#dialogContainer").html("");
                        alert("Book has been deleted!");
                    },
                    error: function (response) {
                        ShowApiError(response);
                    }
                });
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        }
    });

    $("#delete-dialog-confirm").dialog("open");

};