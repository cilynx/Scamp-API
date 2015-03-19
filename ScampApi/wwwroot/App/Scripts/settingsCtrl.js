'use strict';
angular.module('scamp')
.controller('resourcesCtrl', ['$scope', '$location', 'settingsSvc', 'adalAuthenticationService', function ($scope, $location, logsSvc, adalService) {
    $scope.currentRouteName = 'Settings';
}]);