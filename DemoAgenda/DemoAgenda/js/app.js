// app.js
(function () {
    "use strict";

    var app = angular.module("appAgenda", ["ngRoute"]);

    app.config(function ($routeProvider) {

        $routeProvider.when("/", {
            controller: "agendaController",
            templateUrl: "/views/agendaView.html"
        })

        $routeProvider.when("/user/:user", {
            controller: "agendaUserController",
            templateUrl: "/views/agendaUserView.html"
        });

        $routeProvider.when("/user/edit/:id", {
            controller: "agendaEditController",
            templateUrl: "/views/agendaEdit.html"
        });

        $routeProvider.when("/user/delete/:id", {
            controller: "agendaDeleteController",
            templateUrl: "/views/agendaDelete.html"
        });

        $routeProvider.when("/user/new/:user", {
            controller: "agendaNewController",
            templateUrl: "/views/agendaNew.html"
        });

            $routeProvider.otherwise({ redirectTo: "/" });
        });

})();