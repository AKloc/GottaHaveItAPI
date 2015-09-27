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
        .state('channelDetails', {
            url: '/channels/{channelID}',
            templateUrl: '/partials/partial-channelDetails.html',
            controller: 'ChannelDetailsController'
        })
        .state('events', {
            url: '/events',
            templateUrl: '/partials/partial-events.html',
            controller: 'EventsController'
        })
        .state('eventDetails', {
            url: '/events/{eventID}',
            templateUrl: '/partials/partial-eventDetails.html',
            controller: 'EventDetailsController'
        })
        .state('locations', {
            url: '/locations',
            templateUrl: '/partials/partial-locations.html',
            controller: 'LocationsController'
        })
        .state('locationDetails', {
            url: '/locations/{locationID}',
            templateUrl: '/partials/partial-locationDetails.html',
            controller: 'LocationDetailsController'
        })
        .state('searchDetails', {
            url: '/search/{searchQuery}',
            templateUrl: '/partials/partial-search.html',
            controller: 'SearchController'
        })
        .state('about', {
            url: '/about',
            templateUrl: 'partials/partial-about.html'
        });        
});


// Need to know about all of the events and channels JUST FOR COUNTS. Also add a function to allow page "redirects" from the search bar and button.
gottaHaveItApp.controller('NavBarController', function ($scope, $http, $location) {
    $scope.ChangeRoute = function (newPath) {
        $location.path(newPath);
    };

    $http.get("/api/events").success(function (data) {
        $scope.Events = data;
    });

    $http.get("/api/channels").success(function (data) {
        $scope.Channels = data;
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

gottaHaveItApp.controller('EventDetailsController', function ($scope, $http, $stateParams) {
    var eventID = $stateParams.eventID;

    $http.get("/api/events/" + eventID).success(function (data) {
        $scope.Event = data;
    });
});

gottaHaveItApp.controller('ChannelsController', function ($scope, $http) {
    $http.get("/api/channels").success(function (data) {
        $scope.Channels = data;
    });
});

gottaHaveItApp.controller('ChannelDetailsController', function ($scope, $http, $stateParams) {
    var channelID = $stateParams.channelID;

    $http.get("/api/channels/" + channelID).success(function (data) {
        $scope.Channel = data;
    });
});

gottaHaveItApp.controller('LocationsController', function ($scope, $http) {
    $http.get("/api/locations").success(function (data) {
        $scope.Locations = data;
    });
});

gottaHaveItApp.controller('LocationDetailsController', function ($scope, $http, $stateParams) {
    var locationID = $stateParams.locationID;

    $http.get("/api/locations/" + locationID).success(function (data) {
        $scope.Location = data;
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