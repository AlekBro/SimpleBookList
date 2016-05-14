// Set From and To fields as datepickers
$(function () {
    $("#ReleaseDate").datepicker({ dateFormat: 'mm/dd/yy' });
});

// For work cancel button
$("#CancelButton").click(function () {

    $("#dialogContainer").html("");

});


// Enable validation manually:
$.validator.unobtrusive.parse($('#CreateBookForm'));
var val = $("#CreateBookForm").validate();
val.showErrors();
