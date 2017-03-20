(function (module) {
    'use strict';

    module
        .factory('AuthenticationService', AuthenticationService);

    AuthenticationService.$inject = ['$http'];

    function AuthenticationService($http) {
        var service = {
            login: login
        };

        return service;

        function login(username, password) {
            $http({
                method: 'POST',
                url: '/api/login',
                data: {
                    username: username,
                    password: password

                },
                headers: { 'Content-Type': 'application/json' }
            }).then(function (response) {
                debugger;

            }, function (response) {

            });
        }
    }
})(angular.module("hn.physicianApp.security"));