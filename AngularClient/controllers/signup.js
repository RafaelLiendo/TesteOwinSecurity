angular.module('MyApp')
    .controller('SignupController',
        function ($scope, $location, apiUrl, $auth, toastr, $httpParamSerializerJQLike) {
            var tests = {
                RequireNonLetterOrDigit: "[_\\W]",
                RequireDigit: "\\d",
                RequireLowercase: "[a-z]",
                RequireUppercase: "[A-Z]"
            }

            //concat tests
            $scope.passwordPattern = Object.keys(tests)
                .map(function(key) {
                    return "(?=.*" + tests[key] + ")";
                })
                .join("") + ".*";

            $scope.uniqueEmailValidation = apiUrl + "/api/Account/IsUniqueEmail";

            $scope.signup = function() {
                $auth.signup($scope.user)
                    //.then(function (response) {
                    //    var payload = {
                    //        grant_type: "password",
                    //        userName: $scope.user.email,
                    //        password: $scope.user.password
                    //    };

                    //    var options = {
                    //        data: $httpParamSerializerJQLike(payload),
                    //        headers: {
                    //            'Content-Type': 'application/x-www-form-urlencoded'
                    //        }
                    //    }
                    //    return $auth.login(null, options);
                    //})
                    .then(function(response) {
                        $location.path('/login');
                        toastr.info('Conta criada com sucesso.');
                    })
                    .catch(function(response) {
                        toastr.error(response.data.message);
                    });
            };
        });