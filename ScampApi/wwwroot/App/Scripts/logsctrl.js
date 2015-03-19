'use strict';
angular.module('scamp')
.controller('resourcesCtrl', ['$scope', '$location', 'logsSvc', 'adalAuthenticationService', function ($scope, $location, logsSvc, adalService) {
    $scope.currentRouteName = 'Logs';
}]);