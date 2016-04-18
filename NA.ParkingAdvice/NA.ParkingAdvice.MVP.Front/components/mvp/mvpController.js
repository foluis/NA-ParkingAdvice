var app = angular.module('myApp', []);

app.controller('mvpController', function ($scope) {   

    $scope.zonas = [
        { "id": "1", "name": "Zona general", "ocupacion": 3, "cupoTotal": 20 },
        { "id": "2", "name": "Zona gerentes", "ocupacion": 1, "cupoTotal": 7 }
    ];

    $scope.zonaSeleccionada = $scope.zonas[0];

    $scope.ocupar = function (idZona, aumentar) {
        //alert(idZona + "- "+ aumentar)
        var modificador = 1;

        if (aumentar == false) {
            modificador = -1
        }
        
        if (idZona == 1) {
            $scope.zonas[0].ocupacion = $scope.zonas[0].ocupacion + modificador;
            //$scope.zonaSeleccionada.Ocupacion = $scope.zonaSeleccionada.Ocupacion + modificador;
        }
        else {
            $scope.zonas[1].ocupacion = $scope.zonas[1].ocupacion + modificador;
            //$scope.zonaSeleccionada.Ocupacion = $scope.zonaSeleccionada.Ocupacion + modificador;
        }
        
    }
});