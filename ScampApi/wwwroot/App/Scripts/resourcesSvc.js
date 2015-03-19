'use strict';
angular.module('scamp')
.factory('resourcesSvc', ['$http','$q', function ($http,$q) {
    return {
        getItems: function () {
            var promise = new Promise(

    function (resolve, reject) {
        //faking this for now

        resolve([
      { id: 1, name: "Resource1", state: "Stopped", groupName: "Group 1", remaining: 0.8 },
      { id: 2, name: "Resource3", state: "Allocated", groupName: "Group 2", remaining: 0.5 }

        ]);
    });
            return promise;

              
                      

//            return $http.get('/api/resources');
        },
        getItem : function(id){
            return $http.get('/api/resources/' + id);
        },
        postItem : function(item){
            return $http.post('/api/resources/', item);
        },
        putItem : function(item){
            return $http.put('/api/resources/', item);
        },
        deleteItem : function(id){
            return $http({
                method: 'DELETE',
                url: '/api/resources/' + id
            });
        }
    };
}]);