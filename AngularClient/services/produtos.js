angular.module('MyApp')
    .factory('Produtos',
        function ($http, apiUrl) {
            return {
                getProdutos: function() {
                    return $http.get(apiUrl + "/api/Produtos");
                }
            };
        });