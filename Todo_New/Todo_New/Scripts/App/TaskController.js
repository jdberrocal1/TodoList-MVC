angular.module("Todo")

.controller("TaskController", function ($scope, $http, todoService) {

    todoService.getTask(1).then(function (response) {
        $scope.task = response.data;
    });
    
    todoService.getAllTasks().then(function (response) {
        $scope.tasks = response.data;
    });
});