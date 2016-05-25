(function () {
    'use strict';

    angular
        .module('app')
        .controller('borrame', borrame);

    borrame.$inject = ['$location']; 

    function borrame($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'borrame';

        activate();

        function activate() { }
    }
})();
