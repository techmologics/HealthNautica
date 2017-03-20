(function (module) {
    // Move this response Handling to Respective Service
    module.factory('HttpInterceptor', ['$q', '$localStorage', '$sessionStorage', function ($q, $localStorage, $sessionStorage) {
        return {
            request: function (config) {
                //Token Check and add
                return config;
            },
            requestError: function (rejection) {
                return $q.reject(rejection);
            },
            response: function (response) {
                return response;
            },
            responseError: function (response) {
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
    app.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('HttpInterceptor');
    }]);

})(angular.module('hn.physicianApp'));