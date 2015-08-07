angular.module("Todo")

.controller("TaskController", function ($scope, $http, todoService) {
    
    $scope.tasks = ["hello", "world"];
    todoService.getAllTasks().then(function (response) {
        $scope.tasks = response.data;
    });
});