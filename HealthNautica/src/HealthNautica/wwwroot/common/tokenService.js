(function (module) {
    'use strict';
    module
    .service('tokenService', tokenService);

    tokenService.$inject = ['$window'];

    function tokenService($window) {
        this.logout = function () {
            $window.localStorage.removeItem('jwtToken');
        };

        this.saveToken = function (token) {
            $window.localStorage['jwtToken'] = token;
        };

        this.getToken = function () {
            return $window.localStorage['jwtToken'];
        };
    }
})(angular.module("hn.physicianApp"));