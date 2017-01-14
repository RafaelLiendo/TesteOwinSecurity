angular.module('MyApp')
    .controller('LoginController',
        function ($scope, $location, $auth, $http, toastr, apiUrl, $httpParamSerializerJQLike) {
            $scope.login = function () {

                var payload = angular.extend({}, $scope.user, {
                    grant_type: "password"
                });

                var options = {
                    data: $httpParamSerializerJQLike(payload),
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                }

                $auth.login(null, options)
                    .then(function () {
                        toastr.success('Login efetuado com sucesso!');
                        $location.path('/');
                    })
                    .catch(function (error) {
                        toastr.error(error.data.message, error.status);
                    });
            };
            $scope.authenticate = function (provider) {
                $auth.authenticate(provider)
                    //.then(function () {
                    //    return $http.get(apiUrl + "/api/Account/UserInfo");
                    //})
                    .then(function (response) {
                        console.log(response);
                        toastr.success('Entrou com sucesso usando o ' + provider + '!');
                        $location.path('/');
                    })
                    .catch(function (error) {
                        if (error.message) {
                            toastr.error(error.message);
                        } else if (error.data) {
                            toastr.error(error.data.message, error.status);
                        } else {
                            toastr.error(error);
                        }
                    });
            };
        });
