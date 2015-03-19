'use strict';
angular.module('scamp')
.controller('dashboardCtrl', ['$scope', '$location', 'dashboardSvc', 'adalAuthenticationService', function ($scope, $location, dashboardSvc, adalService) {
    $scope.currentRouteName = 'Dashboard';
    $scope.userList = null;

    $scope.populate = function() {
        console.log(dashboardSvc);
        dashboardSvc.getItems().success(function (results) {
            $scope.userList = results;
            $scope.loadingMessage = "";
        }).error(function (err) {
            $scope.error = err;
            $scope.loadingMessage = "";
        })
    };

}]);