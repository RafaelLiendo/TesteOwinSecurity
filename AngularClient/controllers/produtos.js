angular.module('MyApp')
    .controller('ProdutosController',
        function ($scope, $auth, toastr, Produtos) {
            $scope.gridOptions = {
                columnDefs: [
                  { field: 'id' },
                  { field: 'nome' },
                  { field: 'preco' }
                ]
            };

            Produtos.getProdutos()
                .then(function(response) {
                    $scope.gridOptions.data = response.data;
                })
                .catch(function(response) {
                    toastr.error(response.data.message, response.status);
                });
        });
