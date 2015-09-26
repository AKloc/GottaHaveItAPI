var gottaHaveItApp = angular.module('gottaHaveItApp', ['ui.router']);

// Configure routes...
gottaHaveItApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/home');

    $stateProvider
        // HOME STATES AND NESTED VIEWS
        .state('home', {
            url: '/home',
            templateUrl: '/partials/partial-home.html',
            controller: 'HomeController'
        })
        .state('channels', {
            url: '/channels',
            templateUrl: '/partials/partial-channels.html',
            controller: 'ChannelsController'
        })
        .state('events', {
            url: '/events',
            templateUrl: '/partials/partial-events.html',
            controller: 'EventsController'
        })
        /*
        .state('search', {
            url: '/search',
            templateUrl: '/partials/partial-search.html',
            controller: 'SearchController'
        })
        */
        .state('searchDetails', {
            url: '/search/{searchQuery}',
            templateUrl: '/partials/partial-search.html',
            controller: 'SearchController'
        })
        .state('about', {

        });        
});


gottaHaveItApp.controller('NavBarController', function ($scope, $http, $location) {
    $scope.ChangeRoute = function (newPath) {
        $location.path(newPath);
    };

    $http.get("/api/events").success(function (data) {
        $scope.Events = data;
    });
});

gottaHaveItApp.controller('HomeController', function ($scope, $http, $location) {    
    $http.get("/api/events").success(function (data) {
        $scope.Events = data;
    });
});

gottaHaveItApp.controller('EventsController', function ($scope, $http) {
    $http.get("/api/events").success(function (data) {
        $scope.Events = data;
    });
});

gottaHaveItApp.controller('ChannelsController', function ($scope, $http) {
    $http.get("/api/channels").success(function (data) {
        $scope.Channels = data;
    });
});

gottaHaveItApp.controller('SearchController', function ($scope, $http, $stateParams) {
    var searchQuery = $stateParams.searchQuery;

    $http.get("/api/search/" + searchQuery).success(function (data) {
        $scope.SearchResults = data;
    });
});

gottaHaveItApp.controller('SearchControllerDetails', function ($scope, $http, $stateParams) {

    var check = $stateParams.searchQuery;

    $http.get("/api/search").success(function (data) {
        $scope.SearchResults = data;
    });
});