// Set From and To fields as datepickers
$(function () {
    $("#ReleaseDate").datepicker({ dateFormat: 'mm/dd/yy' });
});

/*
// Enable validation manually:
$.validator.unobtrusive.parse($('#CreateBookForm'));
var val = $("#CreateBookForm").validate();
val.showErrors();
*/

