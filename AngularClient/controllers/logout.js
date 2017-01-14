angular.module('MyApp')
    .controller('LogoutController',
        function($location, $auth, $http, $cookies, apiUrl, toastr) {
            //if (!$auth.isAuthenticated()) {
            //    return;
            //}
            $http.post(apiUrl + "/api/Account/Logout")
                .then(function() {
                    return $http.post(apiUrl + "/api/Account/LogoutExternal");
                })
                .then(function () {
                    return $auth.logout();
                })
                .then(function () {
                    $cookies.remove(".AspNet.ExternalCookie");
                    toastr.info('Você saiu com sucesso.');
                    $location.path('/');
                });
        });