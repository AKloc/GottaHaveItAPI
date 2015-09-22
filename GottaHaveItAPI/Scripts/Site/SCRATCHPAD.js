var gottaHaveItApp = angular.module('gottaHaveItApp', ['ngRoute']);

// Configure routes...
gottaHaveItApp.config(function ($routeProvider) {
    $routeProvider

        // route for the contact page
        .when('/', {
            templateUrl: 'pages/events.html',
            controller: 'EventsController'
        });
});



gottaHaveItApp.controller('EventsController', function ($scope, $http) {
    $http.get("/api/events").success(function (data) {
        $scope.Events = data;
    });
});