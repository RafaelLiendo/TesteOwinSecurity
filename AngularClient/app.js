angular.module('MyApp', ['ngResource', 'ngMessages', 'ngAnimate', 'ngCookies', 'toastr', 'ui.router', 'satellizer', 'ui.grid', 'remoteValidation'])
    .constant("apiUrl", 'http://localhost:62711')
    .config(function($stateProvider, $locationProvider, $urlRouterProvider, $authProvider, apiUrl) {

        /**
         * Helper auth functions
         */
        var skipIfLoggedIn = [
            '$q', '$auth', function($q, $auth) {
                var deferred = $q.defer();
                if ($auth.isAuthenticated()) {
                    deferred.reject();
                } else {
                    deferred.resolve();
                }
                return deferred.promise;
            }
        ];

        var loginRequired = [
            '$q', '$location', '$auth', function($q, $location, $auth) {
                var deferred = $q.defer();
                if ($auth.isAuthenticated()) {
                    deferred.resolve();
                } else {
                    $location.path('/login');
                }
                return deferred.promise;
            }
        ];

        /**
         * App routes
         */
        $stateProvider
            .state('home',
            {
                url: '/',
                controller: 'HomeController',
                templateUrl: 'views/home.html'
            })
            .state('login',
            {
                url: '/login',
                templateUrl: 'views/login.html',
                controller: 'LoginController',
                resolve: {
                    skipIfLoggedIn: skipIfLoggedIn
                }
            })
            .state('signup',
            {
                url: '/signup',
                templateUrl: 'views/signup.html',
                controller: 'SignupController',
                resolve: {
                    skipIfLoggedIn: skipIfLoggedIn
                }
            })
            .state('logout',
            {
                url: '/logout',
                template: null,
                controller: 'LogoutController'
            })
            .state('produtos',
            {
                url: '/produtos',
                templateUrl: 'views/produtos.html',
                controller: 'ProdutosController',
                resolve: {
                    loginRequired: loginRequired
                }
            });
        $urlRouterProvider.otherwise('/');
        $locationProvider.hashPrefix("");

        //AuthConfig
        $authProvider.baseUrl = apiUrl;
        $authProvider.loginUrl = '/token';
        $authProvider.signupUrl = '/api/Account/Register';
        $authProvider.unlinkUrl = '/api/Account/Logout';
        $authProvider.tokenName = 'access_token';
        $authProvider.tokenPrefix = 'restapi';

        $authProvider.facebook({
            clientId: 'self',
            authorizationEndpoint: apiUrl + '/api/Account/ExternalLogin',
            responseType: 'token',
            provider: "Facebook",
            requiredUrlParams: ['provider', 'display', 'scope']
        });
    });
