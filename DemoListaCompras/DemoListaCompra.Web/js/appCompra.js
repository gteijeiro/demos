(function () {
    "use strict";

    var app = angular.module("compraApp", ['ngRoute']);

    app.config(function ($routeProvider, $httpProvider) {

        $httpProvider.defaults.useXDomain = true;
        delete $httpProvider.defaults.headers.common['X-Requested-With'];
        delete $httpProvider.defaults.headers.common['Origin'];


        $routeProvider.when("/", {
            controller: "compraController",
            templateUrl: "/DemoCompraWeb/views/compraList.html"
        })

        $routeProvider.when("/compra/edit/:id", {
            controller: "compraController",
            templateUrl: "/DemoCompraWeb/views/compraEdit.html"
        });

        $routeProvider.when("/compra/delete/:id", {
            controller: "compraController",
            templateUrl: "/DemoCompraWeb/views/compraDelete.html"
        });

        $routeProvider.when("/compra/new/", {
            controller: "compraController",
            templateUrl: "/DemoCompraWeb/views/compraNew.html"
        });

        $routeProvider.otherwise({ redirectTo: "/" });
    });
    
})();
