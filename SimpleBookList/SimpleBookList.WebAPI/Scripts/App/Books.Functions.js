
// Add a new row to the table and send a message about the successful creation of Book.
function OnCreateSuccess(response) {
    var booksTable = $('#BooksListTable').dataTable();
    booksTable.fnAddData(response);

    alert("Book has been created!");
    $("#dialogContainer").html("");
}


// http://jsfiddle.net/sxGtM/3/
// http://stackoverflow.com/questions/1184624/convert-form-data-to-javascript-object-with-jquery
$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};


// Update row at the table and send a message about the this successful operation.
function OnEdit() {

    var dataFromForm = $('#EditBookForm').serializeObject();
    var AuthorsIds = $('#EditBookForm #AuthorsIds').serializeArray();
    var AuthorsIdsArray = new Array(AuthorsIds.length);
    AuthorsIds.forEach(function (item, i, arr) {
        AuthorsIdsArray[i] = item.value.toString();
    });

    dataFromForm.AuthorsIds = AuthorsIdsArray;
    var jsonData = JSON.stringify(dataFromForm);
    var url = "/api/Books/" + dataFromForm.Id;

    $.ajax({
        url: url,
        type: 'PUT',
        data: jsonData,
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
            alert("!Error!\n" + "Status: " + response.status + "\n"
                + "Status Text: " + response.statusText + "\n"
                //+ "Response Text: " + response.responseText
                );
        }
    });
};

// Display a message with response text after an unsuccessful request
function OnFailure(response) {
    //alert("!Error!\n" + response.responseJSON.error);
    alert("!Error!\n" + "Status: " + response.status + "\n"
               + "Status Text: " + response.statusText + "\n"
               //+ "Response Text: " + response.responseText
               );
}


function getAllAuthors() {
    // Получение всех Авторов для книги по ajax-запросу
    $.ajax({
        url: '/api/Authors',
        type: 'GET',
        dataType: 'json',
        async: false,
        cache: false,
        timeout: 30000,
        success: function (result) {
            //WriteResponse(data);
            var authorsDropDown = $('#AuthorsIds');
            authorsDropDown.empty();
            $(result.data).each(function () {
                $(document.createElement('option'))
                    .attr('value', this.Id)
                    .text(this.Name)
                    .appendTo(authorsDropDown);
            });

            SetMultiselect();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function SetMultiselect() {
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
}

function deleteFunc(obj, event) {
    event.preventDefault();
    event.stopPropagation();
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
            alert("!Error!\n" + "Status: " + response.status + "\n"
                + "Status Text: " + response.statusText + "\n"
                //+ "Response Text: " + response.responseText
                );
        }
    });

};