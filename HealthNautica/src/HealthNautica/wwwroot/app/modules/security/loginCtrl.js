/* --------------------------------------------------------------------------------------------------------------------
 <copyright file="security.testcontroller.js" company="Techmologics">
   Copyright 2017
 </copyright>
 <summary>
 security.testcontroller  js file
 </summary>
 --------------------------------------------------------------------------------------------------------------------*/
(function (module) {
    "use strict";
    function testController($scope) {
    };
    module.controller("security.testController", testController);
    testController.$inject = ["$scope"];

})(angular.module("hn.physicianApp.security"));


(function (module) {
    "use strict";
    module.controller("loginCtrl", Controller);
    function Controller($location, AuthenticationService) {
        var vm = this;
        vm.login = login;

        initController();

        function initController() {
            // reset login status
            AuthenticationService.Logout();
        };

        function login() {
            vm.loading = true;
            AuthenticationService.Login(vm.username, vm.password, function (result) {
                if (result === true) {
                    $location.path("/");
                } else {
                    vm.error = "Username or password is incorrect";
                    vm.loading = false;
                }
            });
        };

        Controller.$inject = ["$location", AuthenticationService];
    }
})(angular.module("hn.physicianApp.security"));