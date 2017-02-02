(function() {
'use strict';

    angular
        .module('storeCart')
        .factory('cartService', cartService);

    function cartService() {
        var cartData = [];
        var service = {
            addProduct:addProduct,
            removeProduct:removeProduct,
            getProducts:getProducts
        };
        
        return service;

        ////////////////
        

        function addProduct(id, name, price, category) {
            var addedToExistingItem = false;
            for (var i = 0; i < cartData.length; i++) {
                if (cartData[i].GadgetID == id) {
                    cartData[i].count++;
                    addedToExistingItem = true;
                    break;
                }
            }
            if (!addedToExistingItem) {
                cartData.push({
                    count: 1, GadgetID: id, Price: price, Name: name, CategoryID: category
                });
            }
        };
        function removeProduct (id) {
            for (var i = 0; i < cartData.length; i++) {
                if (cartData[i].GadgetID == id) {
                    cartData.splice(i, 1);
                    break;
                }
            }
        }; 
        function getProducts() {
            return cartData;
        }


    }
})();