libraryModule.controller("libraryController", function ($scope, libraryService) {
    libraryService.getAuthors().then(function (authors) { $scope.authors = authors }, function ()
    { alert('error while fetching authors from server') })
});