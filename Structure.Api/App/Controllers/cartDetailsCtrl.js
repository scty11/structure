(function() {
'use strict';

    angular
        .module('gadgetsStore')
        .controller('cartDetailsCtrl', cartDetailsCtrl);

    cartDetailsCtrl.$inject = ['$scope', 'cartService'];
    function cartDetailsCtrl($scope,cartService) {
       
        

        activate();

        ////////////////

        function activate() {
            $scope.cartData = cartService.getProducts();
        }

        $scope.total = function () {
            var total = 0;
            for (var i = 0; i < $scope.cartData.length; i++) {
                total += ($scope.cartData[i].Price * $scope.cartData[i].count);
            }
            return total;
        }

        $scope.remove = function (id) {
            cartService.removeProduct(id);
        }
    }
})();