'use strict';
angular.module('scamp')
.factory('dashboardSvc', ['$http', function ($http) {
    var apiPath = '/api/users';
    return {
        getItems: function () {
            return $http.get(apiPath);
        },
        getItem: function (id) {
            return $http.get(apiPath + id);
        },
        postItem: function (item) {
            return $http.post(apiPath, item);
        },
        putItem: function (item) {
            return $http.put(apiPath, item);
        },
        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiPath + id
            });
        }
    };
}]);