(function () {
    'use strict';

    angular
        .module('parckingApp')
        .controller("PublicController", ['$scope',
            function PublicController($scope)
            {
                //var vm = this;
                $scope.establecimiento = "Definity First";

                $scope.zonas = [
                    { "id": "1", "name": "Zona general", "ocupacion": 3, "cupoTotal": 20 },
                    { "id": "2", "name": "Zona gerentes", "ocupacion": 1, "cupoTotal": 7 }
                ];

                //$scope.zonas = dataService.getZonas();     

                $scope.zonaSeleccionada = $scope.zonas[0];

                $scope.ocupar = function (idZona, aumentar) {
                    //alert(idZona + "- "+ aumentar)
                    var modificador = 1;

                    if (aumentar == false) {
                        modificador = -1
                    }

                    if (idZona == 1) {
                        $scope.zonas[0].ocupacion = $scope.zonas[0].ocupacion + modificador;
                    }
                    else {
                        $scope.zonas[1].ocupacion = $scope.zonas[1].ocupacion + modificador;
                    }
                }
            }]);
})();