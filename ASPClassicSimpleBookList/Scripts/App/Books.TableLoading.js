﻿// Формируем DataTable
$(document).ready(function () {

    var getNumberForItem = function (data, type, full, meta) {
        return new Number(data);
    };

    var getStringForItem = function (data, type, full, meta) {
        if (data) {
            return new String(data);
        } else {
            return "-";
        }
    };

    // Получаем и форматируем дату для поля
    var getDataForItem = function (data, type, full, meta) {
        if (data === null | data === "" | typeof data == 'undefined') {
            return "";
        } else {
            var date = new Date(data);
            return getFormattedDate(date);
        }
    };

    // Функция для форматирования даты
    function getFormattedDate(date) {
        var year = date.getFullYear();
        var month = (1 + date.getMonth()).toString();
        month = month.length > 1 ? month : '0' + month;
        var day = date.getDate().toString();
        day = day.length > 1 ? day : '0' + day;
        return month + '/' + day + '/' + year;
    }

    // Получаем и форматируем ссылку на редактирование
    var getEditLinkForItem = function (data, type, full, meta) {
        return '<a href="/Edit/?BookId=' + data.Id + '" value="' + data.Id + '">Edit</a>';
    };

    // Получаем и форматируем ссылку на удаление
    var getDeleteLinkForItem = function (data, type, full, meta) {
        return '<a href="/Delete/?BookId=' + data.Id + '" value="' + data.Id + '">Delete</a>';
    };


    var booksTable = $('#BooksListTable').DataTable({
        "processing": true, // for show progress bar
        "serverSide": false, // for process server side
        //"filter": false, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "paging": true, // ??
        "deferRender": true, // ??
        //"stateSave": true, // restore table state on page reload.

        "aoColumns": [
            { "data": "Id", "render": getNumberForItem, "visible": false, "searchable": false },
            { "data": "Name", "render": getStringForItem, "class": "dt-head-center dt-body-center" },
            { "data": "ReleaseDate", "render": getDataForItem, "class": "dt-head-center dt-body-center" },
            { "data": "Pages", "render": getNumberForItem, "class": "dt-head-center dt-body-center" },
            { "data": "Rating", "render": getNumberForItem, "class": "dt-head-center dt-body-center" },
            { "data": "Authors", "render": getStringForItem, "class": "dt-head-center dt-body-center" },
            { "data": "Publisher", "render": getStringForItem, "class": "dt-head-center dt-body-center" },
            { "data": "ISBN", "render": getStringForItem, "class": "dt-head-center dt-body-center" },
            { "data": null, "render": getEditLinkForItem, "class": "dt-head-center dt-body-center", "sortable": false },
            { "data": null, "render": getDeleteLinkForItem, "class": "dt-head-center dt-body-center", "sortable": false }
        ],
        // Отключить втроенный поиск: (так отключается и фильтрация)
        //"bFilter": false
        

    });


});