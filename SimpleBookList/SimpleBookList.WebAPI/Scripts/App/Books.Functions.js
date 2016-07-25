
// https://blogs.msdn.microsoft.com/simonince/2011/02/04/conditional-validation-in-asp-net-mvc-3/
/*
$.validator.addMethod('requiredif',
    function (value, element, parameters) {
        debugger;
        var id = '#' + parameters['dependentproperty'];

        // get the target value (as a string, 
        // as that's what actual value will be)
        var targetvalue = parameters['targetvalue'];
        targetvalue =
          (targetvalue == null ? '' : targetvalue).toString();

        debugger;
        // get the actual value of the target control
        // note - this probably needs to cater for more 
        // control types, e.g. radios
        var control = $(id);
        var controltype = control.attr('type');
        var actualvalue =
            controltype === 'checkbox' ?
            control.prop('checked').toString() :
            control.val();

        // if the condition is true, reuse the existing 
        // required field validator functionality
        if (targetvalue === actualvalue)
            return $.validator.methods.required.call(
              this, value, element, parameters);

        return true;
    }
);

$.validator.unobtrusive.adapters.add(
    'requiredif',
    ['dependentproperty', 'targetvalue'],
    function (options) {
        options.rules['requiredif'] = {
            dependentproperty: options.params['dependentproperty'],
            targetvalue: options.params['targetvalue']
        };
        options.messages['requiredif'] = options.message;
    });

$.validator.addMethod('greaterthanorequalto',
    function (value, element, parameters) {
        var dependentproperty = '#' + parameters['dependentdate'];
        var dependentValue = $(dependentproperty).val();

        var dependentPropertyDate = Date.parse(dependentValue);
        var currentPropertyDate = Date.parse(value);

        if (currentPropertyDate < dependentPropertyDate) {
            return false;
        }
        return true;
    }
);

$.validator.unobtrusive.adapters.add(
    'greaterthanorequalto',
    ['dependentdate'],
    function (options) {
        options.rules['greaterthanorequalto'] = {
            dependentdate: options.params['dependentdate']
        };
        options.messages['greaterthanorequalto'] = options.message;
    });

*/



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