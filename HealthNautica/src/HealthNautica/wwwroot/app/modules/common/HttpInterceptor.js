(function (module) {
    app.factory('httpInterceptor', ['$q', function ($q) {
        return {
            request: function (config) {
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
                    //Handling case with list of status codes
                }
                return $q.reject(response);
            }
        };
    }]);

    // pushing interceptor to $httpProvider
    app.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('httpInterceptor');
    }]);

})(angular.module('hn.physicianApp'));

