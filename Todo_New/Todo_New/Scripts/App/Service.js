angular.module("Todo")
.service('todoService', function($http) {
    this.getAllTasks = function () {
        /*
        var req = {
            method: 'GET',
            url: 'http://localhost:56273/api/Task/',
            headers: {
                'Content-Type': 'application / json'
            },
            data: {  }
        };*/
        return $http.get("http://localhost:56273/api/Task/");
    }
});