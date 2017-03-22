(function (module) {
    'use strict';
    module
    .factory('tokenService', tokenService);

    tokenService.$inject = ['$window'];

    function tokenService($window) {
        var self = this;
        self.logout = function () {
            $window.localStorage.removeItem('jwtToken');
        };

        self.saveToken = function (token) {
            $window.localStorage['jwtToken'] = token;
        };

        self.getToken = function () {
            return $window.localStorage['jwtToken'];
        };
    }
})(angular.module("hn.physicianApp"));