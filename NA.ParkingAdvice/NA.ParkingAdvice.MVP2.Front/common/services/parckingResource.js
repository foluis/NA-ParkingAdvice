(function () {
    'use strict';

    angular.module('common.services')
        .factory("parckingResource", ["$resource",
            function PublicController($resource) {
                return $resource("/api/products/:zonaId");
        }]);

   
})();