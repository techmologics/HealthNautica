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
            AuthenticationService.login(vm.username, vm.password)
            .then(function (result) {
                debugger;
                //if (result === true) {
                //$location.path("/Home.html");
                console.log(window.location);
                window.location.href = window.location.protocol + "//" + window.location.host+"/Home.html"
                    'http://www.google.com';

               // } else {
                  //  vm.error = "Username or password is incorrect";
                 //   vm.loading = false;
              //  }
            }, function (result) {
                //Invalid User
            });
        };

        Controller.$inject = ["$location", AuthenticationService];
      //  Controller.$inject = ["$location"];
    }
})(angular.module("hn.physicianApp.security"));