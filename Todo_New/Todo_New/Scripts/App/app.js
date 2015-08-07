angular.module("Todo", ['ngRoute'])
	/*.config(function ($routeProvider, $compileProvider) {
	    $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|ftp|mailto|itms-services):/);
	    $routeProvider
		//router for the app
			.when("/", {
			    controller: "LoginController",
			    templateUrl: "templates/login.html"
			})

			.when("/dashboard", {
			    controller: "DashController",
			    templateUrl: "templates/dashboard.html"
			})
			.when("/users", {
			    controller: "UsersController",
			    templateUrl: "templates/users.html"
			})
			.when("/account", {
			    controller: "AccountController",
			    templateUrl: "templates/account.html"
			})
			.when("/createproject", {
			    controller: "CreateProjectController",
			    templateUrl: "templates/createproject.html"
			})
			.when("/editproject", {
			    controller: "EditProjectController",
			    templateUrl: "templates/editproject.html"
			})
			.otherwise({
			    redirectTo: '/'
			});
	})
*/