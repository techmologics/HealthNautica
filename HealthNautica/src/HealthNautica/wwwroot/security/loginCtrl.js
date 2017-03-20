/* --------------------------------------------------------------------------------------------------------------------
 <copyright file="security.testcontroller.js" company="Techmologics">
   Copyright 2017
 </copyright>
 <summary>
 security.testcontroller  js file
 </summary>
 --------------------------------------------------------------------------------------------------------------------*/
//(function (module) {
//    "use strict";
//    function testController($scope) {
//    };
//    module.controller("security.testController", testController);
//    testController.$inject = ["$scope"];

//})(angular.module("hn.physicianApp.security"));


(function (module) {
    "use strict";
    module.controller("loginCtrl", Controller);
    function Controller($location, AuthenticationService) {
        // function Controller($location) {
        var vm = this;
        vm.login = login;

        initController();

        function initController() {
            // reset login status
            //AuthenticationService.Logout();
        };

        function login() {
            debugger;
            // vm.loading = true;
            AuthenticationService.login(vm.username, vm.password, function (result) {
                debugger;
                if (result === true) {
                    $location.path("/");
                } else {
                    vm.error = "Username or password is incorrect";
                    vm.loading = false;
                }
            });
        };

        //Controller.$inject = ["$location", AuthenticationService];
        Controller.$inject = ["$location"];
    }
})(angular.module("hn.physicianApp.security"));