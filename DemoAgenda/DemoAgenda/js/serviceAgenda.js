(function () {
    var app = angular.module("appAgenda");
    
    var agendaService = function ($http) {

        var uri = "http://localhost:8551/api/";

        var getAgenda = function (user) {
            return $http.get(uri + "agenda?user=" + user)
                        .then(function (response) {
                            return response.data;
                        });            
        };

        var getAgendaById = function (id) {
            return $http.get(uri + "agenda?id=" + id)
                        .then(function (response) {
                            return response.data;
                        });
        };

        var addAgenda = function(agenda){
           return $http.post(uri + "agenda", agenda)
                .then(function (response) {
                    return response.data;
                });
        };

        return {
            getAgenda: getAgenda,
            getAgendaById: getAgendaById,
            addAgenda : addAgenda
        };
    };

    app.factory("agendaService", agendaService);

})();