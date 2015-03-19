'use strict';
angular.module('scamp', ['ngRoute','AdalAngular'])
.config(['$routeProvider', '$httpProvider', 'adalAuthenticationServiceProvider', function ($routeProvider, $httpProvider, adalProvider) {

    $routeProvider.when("/Home", {
        controller: "homeCtrl",
        templateUrl: "/App/Views/Home.html",
    }).when("/dashboard", {
        controller: "dashboardCtrl",
        templateUrl: "/App/Views/Dashboard.html",
        requireADLogin: true,
    }).when("/resources", {
        controller: "resourcesCtrl",
        templateUrl: "/App/Views/Resources.html",
    }).when("/logs", {
        controller: "logsCtrl",
        templateUrl: "/App/Views/Logs.html",
    }).when("/settings", {
        controller: "settingsCtrl",
        templateUrl: "/App/Views/Settings.html",
    }).otherwise({ redirectTo: "/Home" });


    if (scampConfig.settings.clientId === null)
        console.error("Missing $env:APPSETTING_ClientId");
    if (scampConfig.settings.tenantId === null)
        console.error("Missing $env:APPSETTING_TenantId");

    

    adalProvider.init(
        {
            tenant: scampConfig.settings.tenantId,
            clientId: scampConfig.settings.clientId,
            extraQueryParameter: scampConfig.settings.extraQueryParameter,
            cacheLocation: scampConfig.settings.cacheLocation,
            redirectUri: scampConfig.settings.redirectUri
        },
        $httpProvider
        );
   
}]);
