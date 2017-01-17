app.controller('APIController', function ($scope, APIService) {

    getBooks();

    function getBooks() {
        var servCall = APIService.getBooks();
        servCall.then(function (d) {
            $scope.resp = d;
        }, function (error) {
            console.log('Oops! Something went wrong while fetching the data.')
        });
    }

});