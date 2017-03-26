/* --------------------------------------------------------------------------------------------------------------------
 <copyright file="app.js" company="Techmologics">
   Copyright 2017
 </copyright>
 <summary>
 application startup js file
 </summary>
 --------------------------------------------------------------------------------------------------------------------*/
(function () {
    "use strict";
    angular
       .module("hn.physicianApp.security", []);
    angular
       .module("hn.physicianApp.surgery", []);
    angular
       .module("hn.physicianApp.orders", []);
    angular
       .module("hn.physicianApp.schedulers", []);
    angular
       .module("hn.physicianApp.software", []);
    angular
       .module("hn.physicianApp.alerts", []);
    angular
       .module("hn.physicianApp.reports", []);
    angular
       .module("hn.physicianApp", [
        "hn.physicianApp.security",
        "hn.physicianApp.surgery",
        "hn.physicianApp.orders",
        "hn.physicianApp.schedulers",
        "hn.physicianApp.software",
        "hn.physicianApp.alerts",
        "hn.physicianApp.reports",
        "ui.router"
       ]);

})();