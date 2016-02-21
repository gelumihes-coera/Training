libraryModule.directive('buyBook', function () {
    return {
        restrict: 'E',
        scope: {},
        templateUrl: '../Templates/Order.html',

        link: function (scope, element, attrs) {
            scope.buttonText = "Buy",
            scope.ordered = false,

            scope.buy = function () {
                element.toggleClass('btn-active')
                if (scope.ordered) {
                    scope.buttonText = "Buy";
                    scope.ordered = false;
                } else {
                    scope.buttonText = "Ordered";
                    scope.ordered = true;
                }
            }
        }
    };
});