(function () {
    'use strict';

    angular
        .module('app')
        .controller('borrame2r', borrame2r);

    borrame2r.$inject = ['$scope']; 

    function borrame2r($scope) {
        $scope.title = 'borrame2r';

        activate();

        function activate() { }
    }
})();
