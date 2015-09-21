angular.module('gottaHaveItApp', [])
    .controller('EventsController', function ($scope, $http) {

        var Events;

        $http.get("http://localhost:54791/api/events").success(function (data) {
            $scope.Events = data;
        });
    });