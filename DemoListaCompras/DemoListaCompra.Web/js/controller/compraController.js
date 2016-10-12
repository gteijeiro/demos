(function () {
    "use strict";

    var app = angular.module("compraApp");

    var compraController = function ($scope, compraService, $location, $filter, $routeParams) {

        $scope.compra = {};
        $scope.error = "";

        var onError = function (reason) {
            $scope.error = reason.data.Message;
        };
        
        var onCompleteAction = function (data) {
            $scope.compra = {};
            $location.path("/");
        }

        var onGetAllCompraComplete = function (data) {
            $scope.compraList = data;
        };  
         
        $scope.addNew = function () {
            compraService.addCompra($scope.compra).then(onCompleteAction, onError);
        };

        $scope.editCompra = function () {
            $scope.compra.id = $routeParams.id;
            compraService.updateCompra($scope.compra).then(onCompleteAction, onError);
        }

        $scope.deleteCompra = function () {
            compraService.deteleCompra($scope.compra.id).then(onCompleteAction, onError)
        }

        $scope.loadListCompra = function () {
            compraService.getAllCompra().then(onGetAllCompraComplete, onError);
        };

        $scope.loadNewCompra = function () {
            $scope.compra = {};
            $scope.compra.amount = 0;
        };

        $scope.loadCompra = function () {
            var idCompra = $routeParams.id;
            compraService.getByIdCompra(idCompra).then(onLoadCompraComplete, onError);
        }

        var onLoadCompraComplete = function (data) {
            $scope.compra = data;
        }

        $scope.upAmount = function () {
            $scope.compra.amount++;
        };

        $scope.downAmount = function () {
            $scope.compra.amount--;
        };

    }

    app.controller("compraController", compraController);

})();