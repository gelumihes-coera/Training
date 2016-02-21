libraryModule.controller('bookController', function ($scope, $location, libraryService) {
    libraryService.getBooks().then(function (books) { $scope.books = books }, function ()
    { alert('error while fetching books from server') })  
});