libraryModule.controller("authorController", function ($scope, $location, libraryService) {
    $scope.add = function (author) {
        libraryService.addAuthor(author).then(function () { $location.url('/Library/Authors'); }, function ()
        { alert('error while adding author at server') });
    };
});