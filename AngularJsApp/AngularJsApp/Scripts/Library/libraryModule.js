var libraryModule = angular.module("libraryModule", []).config(function ($routeProvider, $locationProvider) {

    $routeProvider.when('/Library/Authors', { templateUrl: '/Templates/Author.html', controller: 'libraryController' });
    $routeProvider.when('/Library/Books', { templateUrl: '/Templates/Book.html', controller: 'bookController' });
    $routeProvider.when('/Library/AddAuthor', { templateUrl: '/Templates/AddAuthor.html', controller: 'authorController' });
    $locationProvider.html5Mode(true);
});