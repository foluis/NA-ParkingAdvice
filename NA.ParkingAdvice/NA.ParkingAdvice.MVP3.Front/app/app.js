(function () {
    var app = angular.module('app', ['ngRoute'])
        .config(['$routeProvider', function ($routeProvider) {
            $routeProvider                
                .when('/admin',
                    { templateUrl: 'app/admin/index.html' })
                .when('/public',
                    { templateUrl: 'app/public/index.html' })
                .otherwise(
                    { redirectTo: 'app/public/index.html' });
        }]);



    //app.controller('MainController', ['$scope', function ($scope) {
    //    $scope.ejemplo = "aquí ando";
    //}]);
})();