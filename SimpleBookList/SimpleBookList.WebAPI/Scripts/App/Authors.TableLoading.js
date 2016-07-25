// Формируем DataTable
$(document).ready(function () {

    var getNumberForItem = function (data, type, full, meta) {
        return new Number(data);
    };

    var getStringForItem = function (data, type, full, meta) {
        return new String(data);
    };

    // Получаем и форматируем ссылку на редактирование
    var getEditLinkForItem = function (data, type, full, meta) {
        return '<a href="#' + data.Id + '" value="' + data.Id + '" onclick="editFunc(this, event)">Edit</a>';
    };

    // Получаем и форматируем ссылку на удаление
    var getDeleteLinkForItem = function (data, type, full, meta) {
        return '<a href="#' + data.Id + '" value="' + data.Id + '" onclick="deleteAuthorFunc(this, event)">Delete</a>';
    };

    var getDetailsLinkForItem = function (data, type, full, meta) {
        return '<a href="#' + data.Id + '" value="' + data.Id + '" onclick="detailsFunc(this, event)">Details</a>';
    };

    // Get DataTable
    var authorsTable = $('#AuthorsListTable').DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        //"filter": false, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "paging": true, // ??
        "deferRender": true, // ??
        "ajax": {
            "url": "/API/Authors/",
            "type": "GET",
            //"datatype": "json"
            "contentType": 'application/json; charset=utf-8',
            //'data': function (data) { return data = JSON.stringify(data); }
        },
        "aoColumns": [
            { "data": "Id", "render": getNumberForItem, "visible": false, "searchable": false },
            { "data": "FirstName", "render": getStringForItem, "class": "dt-head-center dt-body-center" },
            { "data": "LastName", "render": getStringForItem, "class": "dt-head-center dt-body-center" },
            { "data": "BooksNumber", "render": getNumberForItem, "class": "dt-head-center dt-body-center" },
            { "data": null, "render": getEditLinkForItem, "class": "dt-head-center dt-body-center", "sortable": false },
            { "data": null, "render": getDeleteLinkForItem, "class": "dt-head-center dt-body-center", "sortable": false },
            { "data": null, "render": getDetailsLinkForItem, "class": "dt-head-center dt-body-center", "sortable": false }
        ],
    });

});