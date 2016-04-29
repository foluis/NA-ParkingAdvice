/// <reference path="../../components/mvp/controller.js" />

var myApp = angular.module("myApp", ["ngRoute"]);

myApp.config(function ($routeProvider) {
    $routeProvider
        .when("/public", {
            templateUrl: "components/mvp/public/public.html",
            controller: "counterController"
        })
         .when("/admin", {
             templateUrl: "components/mvp/admin/admin.html",
             controller: "counterController"
         })
        .otherwise({
            redirectTo: "/public"
        });
});

myApp.factory("dataService", function () {
   var zonas = [
        { "id": "1", "name": "Zona general", "ocupacion": 3, "cupoTotal": 20 },
        { "id": "2", "name": "Zona gerentes", "ocupacion": 1, "cupoTotal": 7 }
   ];
   return {
       getZonas: function () {
           return zonas;
       }        
   }
});

myApp.controller("counterController", function ($scope, dataService) {
    $scope.establecimiento = "Definity First";

    //$scope.zonas = [
    //    { "id": "1", "name": "Zona general", "ocupacion": 3, "cupoTotal": 20 },
    //    { "id": "2", "name": "Zona gerentes", "ocupacion": 1, "cupoTotal": 7 }
    //];

    $scope.zonas = dataService.getZonas();

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
});