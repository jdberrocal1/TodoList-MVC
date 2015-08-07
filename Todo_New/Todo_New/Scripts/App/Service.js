angular.module("Todo")
.service('todoService', function($http) {
    this.getAllTasks = function () {

        return $http.get("http://localhost:56273/api/Task");
    };

    this.getTask = function (id) {
        return $http.get("http://localhost:56273/api/Task/" + id);
    };
});