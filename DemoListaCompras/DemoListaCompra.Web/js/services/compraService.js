(function () {
    "use strict";

    var app = angular.module("compraApp");

    var compraService = function ($http) {
        
        var uri = "http://localhost/democompra/api/compra";
        //delete $httpProvider.defaults.headers.common['X-Requested-With'];

        var getAllCompra = function () {
            return $http.get(uri)
                        .then(function (response) {
                            return response.data;
                        });
        };

        var getByIdCompra = function (id) {
            return $http.get(uri + "/" + id)
                        .then(function (response) {
                            return response.data;
                        });
        };

        var addCompra = function (compra) {
            return $http.post(uri, compra)
                        .then(function (response) {
                            return response.data;
                        });
        };

        var updateCompra = function (compra) {
            return $http.put(uri, compra)
                        .then(function (response) {
                            return response.data;
                        });
        };

        var deteleCompra = function (id) {
            return $http.delete(uri + "/" + id)
                        .then(function (response) {
                            return response.data;
                        });
        };

        return {
            getAllCompra: getAllCompra,
            getByIdCompra: getByIdCompra,
            addCompra: addCompra,
            updateCompra: updateCompra,
            deteleCompra: deteleCompra
        };
    };

    app.factory("compraService", compraService);
})();


