(function () {
    "use strict";

    var app = angular.module("appAgenda");

    var agendaUserController = function ($scope, agendaService, $routeParams) {

        var onGetAgendaComplete = function (data) {
            $scope.agendaList = data;
        };

        var onError = function (reason) {
            $scope.error = reason;
        };

        $scope.user = $routeParams.user;
        agendaService.getAgenda($scope.user).then(onGetAgendaComplete, onError);
    };

    app.controller("agendaUserController", agendaUserController);

})();