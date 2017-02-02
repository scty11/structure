(function() {
'use strict';

    angular
        .module('gadgetsStore')
        .controller('checkoutCtrl', checkoutCtrl);

    checkoutCtrl.$inject = ['$scope','DataService','$location'];
    function checkoutCtrl($scope, DataService,$location) {
        
        $scope.shipping = {};
        ////////////////

       $scope.sendOrder = function(){
            DataService.sendOrder($scope.shipping)
            .then(function(result) {
                $location.path('/');
            })
            .catch(function(error) {
                $log.warn(error);
            });
       }
    }
})();