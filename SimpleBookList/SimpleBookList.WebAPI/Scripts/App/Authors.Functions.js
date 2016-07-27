
// Add a new row to the table and send a message about the successful creation of Author.
function OnCreateAuthorSuccess(response) {
	var authorsTable = $('#AuthorsListTable').dataTable();
	authorsTable.fnAddData(response);

	alert("Author has been created!");
	$("#dialogContainer").html("");
}

// Update Author and send a message about the this successful operation.
function EditAuthorFunc() {

	var dataFromForm = $('#EditAuthorForm').serializeObject();

    // Manual Validation
	$.validator.unobtrusive.parse($('#EditAuthorForm'));
	$('#EditAuthorForm').validate();

	if ($('#EditAuthorForm').valid()) {
	    $.ajax({
	        url: "/api/Authors/" + dataFromForm.Id,
	        type: 'PUT',
	        data: JSON.stringify(dataFromForm),
	        contentType: "application/json;charset=utf-8",
	        success: function (resp) {
	            var authorsTable = $('#AuthorsListTable').dataTable();

	            row = $.grep(authorsTable.fnSettings().aoData, function (obj) {
	                return obj._aData.Id == dataFromForm.Id;
	            })[0].nTr;

	            authorsTable.fnUpdate(dataFromForm, $(row).get(0));
	            $("#dialogContainer").html("");
	            alert('Author Updated Successfully');
	        },
	        error: function (response) {
	            ShowApiError(response);
	        }
	    });
	}
};

// DeleteAuthor and send a message about the this successful operation.
function deleteAuthorFunc(obj, event) {
	event.preventDefault();
	event.stopPropagation();

	$("#delete-dialog-confirm").dialog({
		buttons: {
			"Delete": function () {
				$(this).dialog("close");

				var Id = obj.getAttribute('value');

				$.ajax({
					url: "/api/Authors/" + Id,
					type: 'DELETE',
					contentType: "application/json;charset=utf-8",
					success: function (resp) {
						var authorsTable = $('#AuthorsListTable').dataTable();

						row = $.grep(authorsTable.fnSettings().aoData, function (obj) {
							return obj._aData.Id == Id;
						})[0].nTr;

						authorsTable.fnDeleteRow($(row).get(0));

						$("#dialogContainer").html("");
						alert("Author has been deleted!");
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