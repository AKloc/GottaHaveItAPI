angular.module('gottaHaveItApp', [])
    .controller('EventsController', function ($scope, $http) {

        var Events;

        $http.get("/api/events").success(function (data)
        {
            $scope.Events = data;
        });
    });