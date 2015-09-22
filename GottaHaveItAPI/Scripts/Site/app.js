var gottaHaveItApp = angular.module('gottaHaveItApp', ['ui.router']);

// Configure routes...
gottaHaveItApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/home');

    $stateProvider
        // HOME STATES AND NESTED VIEWS
        .state('home', {
            url: '/home',
            templateUrl: '/partials/partial-home.html',
            controller: 'EventsController'
        })
        .state('about', {

        });        
});



gottaHaveItApp.controller('EventsController', function ($scope, $http) {
    $http.get("/api/events").success(function (data) {
        $scope.Events = data;
    });
});