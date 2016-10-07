(function(){
  
    "use strict";

    var app = angular.module("appAgenda");
            
    var agendaController = function ($scope, $location) {

        $scope.search = function () {
            $location.path("/user/" + $scope.user);
        };
    };

    app.controller("agendaController", agendaController);
})();