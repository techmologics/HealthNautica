(function (module) {
    // Move this response Handling to Respective Service
    // module.factory('HttpInterceptor', ['$q', '$localStorage', '$sessionStorage', function ($q, $localStorage, $sessionStorage) {
    module.factory('HttpInterceptor', ['$q', 'tokenService', function ($q, tokenService) {
        return {
            request: function (config) {
                debugger;
                //Token Check and add
                var token = tokenService.getToken();
                if (token) {
                    config.headers.Authorization = 'Bearer ' + token;
                }
                return config;

            },
            requestError: function (rejection) {
                return $q.reject(rejection);
            },
            response: function (response) {
                debugger;
                if (response.data.token) {
                    tokenService.saveToken(response.data.token);
                }
            },
            responseError: function (response) {
                debugger;
                var httpStatusCode = '';
                if (response.status !== undefined) {
                    httpStatusCode = response.status;
                }
                else {
                    httpStatusCode = 400;
                }
                switch (httpStatusCode) {
                    case -1:
                    case 408:
                    case 401:
                        //Redirect to current which will eventually redirect to Identity Server.
                        window.location.reload();
                        break;
                    case 302:
                    case 404:
                    default:
                        break;
                }
                return $q.reject(response);
            }
        };
    }]);
    // pushing interceptor to $httpProvider
    module.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('HttpInterceptor');
    }]);

})(angular.module('hn.physicianApp'));