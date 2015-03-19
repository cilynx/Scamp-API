'use strict';
angular.module('scamp')
.controller('homeCtrl', ['$scope', 'adalAuthenticationService', '$location', function ($scope, adalService, $location) {
    $scope.currentRouteName = 'home';
    $scope.login = function () {
        adalService.login();
    };
    $scope.logout = function () {
        adalService.logOut();
    };
    $scope.isActive = function (viewLocation) {        
        return viewLocation === $location.path();
    };


    $scope.isLoggedOn = adalService.userInfo.isAuthenticated;

}]);