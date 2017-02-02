(function() {
'use strict';

angular
    .module('gadgetsStore')
    .constant('gadgetsActiveClass', 'btn-primary')
    .constant('gadgetsPageCount', 3)
    .controller('gadetsCtrl', gadetsCtrl);

gadetsCtrl.$inject = ['$scope', 'DataService', '$log', 'gadgetsActiveClass', 'gadgetsPageCount', 'cartService'];
function gadetsCtrl($scope, DataService, $log, gadgetsActiveClass, gadgetsPageCount, cartService) {

    //$scope.categories = {};
    //$scope.gadgets = [];
    var selectedCategory = null;
    $scope.selectedPage = 1;
    $scope.pageSize = gadgetsPageCount;

    activate();

    ////////////////

    function activate() {

        DataService.getCategories()
            .then(function (result) {
                $scope.categories = result;
            })
            .catch(function (error) {
                $log.warn(error);
            });

        DataService.getGadgets()
            .then(function(result) {
                $scope.gadgets = result;
            })
            .catch(function(error) {
                $log.warn(error);
            });
    }


    $scope.selectPage = function (newPage) {
        $scope.selectedPage = newPage;
    }
    $scope.selectCategory = function (newCategory) {
        selectedCategory = newCategory;
        $scope.selectedPage = 1;
    }
    $scope.categoryFilterFn = function (product) {
        return selectedCategory == null || product.CategoryID == selectedCategory;
    }
    $scope.getPageClass = function (page) {
        return $scope.selectedPage == page ? gadgetsActiveClass : "";
    }
    $scope.getCategoryClass = function (category) {
        return selectedCategory == category ? gadgetsActiveClass : "";
    }
    $scope.addProductToCart = function (product) {
        cartService.addProduct(product.GadgetID, product.Name, product.Price, product.CategoryID);
    }    
}
})();