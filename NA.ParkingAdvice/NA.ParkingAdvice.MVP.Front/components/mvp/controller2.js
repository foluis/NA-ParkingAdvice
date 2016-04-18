(function () {
    'use strict';

    angular
        .module('app')
        .controller('controller2', controller2);

    controller2.$inject = ['$location']; 

    function controller2($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'controller2';

        activate();

        function activate() { }
    }
})();
