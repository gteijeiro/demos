(function () {
    "use strict";

    var app = angular.module("appAgenda");

    var agendaNewController = function ($scope, agendaService, $routeParams, $location) {

        $scope.user = $routeParams.user;
        $scope.newAgenda = {};
        
        var onAgendaAddComplete = function (data) {
            $location.path("/user/" + $scope.user);
        };

        var onErrorE = function (reason) {
            $scope.error = reason;
        };

        $scope.addAgenda = function () {
            $scope.newAgenda.user = $scope.user;
            agendaService.addAgenda($scope.newAgenda).then(onAgendaAddComplete);
        };

    };

    app.controller("agendaNewController", agendaNewController);

})();