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

// Display a message with response text after an unsuccessful request
function OnFailure(response) {
    //alert("!Error!\n" + response.responseJSON.error);
    alert("!Error!\n" + "Status: " + response.status + "\n"
               + "Status Text: " + response.statusText + "\n"
               //+ "Response Text: " + response.responseText
               );
}

function ShowApiError(response) {
    alert("!Error!\n" + "Status: " + response.status + "\n"
            + "Status Text: " + response.statusText + "\n"
            //+ "Response Text: " + response.responseText
         );
}

// Получение всех Авторов для книги по ajax-запросу
function getAllAuthors() {
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