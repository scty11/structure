(function() {
    'use strict';

    angular
        .module('storeCart')
        .directive('cartDetails', cartDetails);

    cartDetails.$inject = ['cartService'];
    function cartDetails(cartService) {
     
        var directive = {
            restrict: "E",
            templateUrl: "App/Common/Cart/cartDetails.html",
            controller: function ($scope) {
                var cartData = cartService.getProducts();
                $scope.total = function () {
                    var total = 0;
                    for (var i = 0; i < cartData.length; i++) {
                        total += (cartData[i].Price * cartData[i].count);
                    }
                    return total;
                }
                $scope.itemCount = function () {
                    var total = 0;
                    for (var i = 0; i < cartData.length; i++) {
                        total += cartData[i].count;
                    }
                    return total;
                }
            }
        };
        return directive;
    }
})();