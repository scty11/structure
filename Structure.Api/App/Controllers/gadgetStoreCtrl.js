(function() {
'use strict';

    angular
        .module('gadgetsStore')
        .controller('gadgetStoreCtrl', gadgetStoreCtrl);

    gadgetStoreCtrl.$inject = ['$scope', '$location'];
    function gadgetStoreCtrl($location,$scope) {
     
        
        activate();

        ////////////////

        function activate() { $scope.showFilter = true; }

	    $scope.checkoutComplete = function () {
	        return $location.path() == '/complete';
	    }
    }
})();