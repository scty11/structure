(function() {
'use strict';

    angular
        .module('gadgetsStore')
        .factory('DataService', DataService);

    DataService.$inject = ['$q', '$http','cartService'];
    function DataService($q,$http,cartService) {
        var service = {
            getGadgets:getGadgets,
            getCategories:getCategories,
            sendOrder:sendOrder
        };
        
        return service;

        ////////////////
        function getGadgets() { 
            return $http.get('/api/Gadgets')
            .then(complete)
            .catch(failed);
        }

        function getCategories(){
            return $http.get('/api/categories')
            .then(complete)
            .catch(failed);
        } 

        function sendOrder(shippingDetails){

            var order = angular.copy(shippingDetails);
            order.getGadgets = cartService.GetProducts();
            return $http.post('/api/Order', order)
            .then(complete)
            .catch(failed);

        }   

        function complete(data, status, headers, config) {
            return data.data;
        }

        function failed(e) {
            var newMessage = 'failed';
            if (e.data && e.data.description) {
                newMessage = newMessage + '\n' + e.data.description;
                e.data.description = newMessage;
            }
            return $q.reject(e);
        }

    }
})();