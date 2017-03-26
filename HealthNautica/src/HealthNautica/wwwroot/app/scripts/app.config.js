/// <reference path="../../home.html" />
/// <reference path="../../home.html" />
/// <reference path="../../home.html" />
//Refer angular-ui-router.js
//Add ui.router as module dependency to hn.physicianApp

(function (app) {
    app.config([
    "$stateProvider", "$urlRouterProvider", "$locationProvider",
    function ($stateProvider, $urlRouterProvider, $locationProvider) {
        $urlRouterProvider.otherwise("/");
        $stateProvider
        .state("login", {
            url: "/",
            views: {
                "loginContainerView@":
                    {
                        templateUrl: "app/modules/security/login.html"
                    }
                //controller: "hn.physicianApp.security.loginController"
            }
        })
    .state("home", {
        url: "/home",
        //templateUrl: "app/index.html",
        //controller:"homeController",
        views: {
            "mainContainerView@": {
                templateUrl: "app/Home.html"

            }
        },
        //data: {
        //    permission: "Authorize"
        //}
    })
    .state("unauthorized", {
        url: "/unauthorized",
        views: {
            "unAuthContainerView@": {
                templateUrl: "app/modules/common/unauthorized.html"
            }
        }
    })
    }]);

    //app.run(["$rootScope", "$state", "authorizationService", "$locationStorage",
    //   function ($rootScope, $state, authorizationService, $locationStorage) {
    //       $rootScope.copyrightYear = new Date();
    //       var hasRequested = false;
    //       var validateAuthorization = function (event, toState) {
    //           var nextState = toState.name;
    //           var token = $locationStorage.token;
    //           if (token != null && !hasRequested && angular.isDefined(token)) {
    //               authorizationService.chkUserAuthorization()
    //                   .then(function (isAuthorized) {
    //                       if (angular.isDefined(toState.data) && !isAuthorized) {
    //                           event.preventDefault();
    //                           nextState = "default";
    //                           $state.go("unauthorized", {}, false);
    //                       }
    //                       $rootScope.$broadcast("showAuthorizedView", isAuthorized);
    //                       $rootScope.$broadcast("setCurrentState", { nextState: nextState });
    //                   });
    //               hasRequested = true;
    //           }
    //       };

    //       $rootScope.$on("$stateChangeStart", function (event, toState) {
    //           validateAuthorization(event, toState);
    //       });
    //   }
    //]);
})(angular.module("hn.physicianApp"));
