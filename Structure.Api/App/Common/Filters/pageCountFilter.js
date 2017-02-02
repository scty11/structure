(function() {
'use strict';

    angular
        .module('storeFilters')
        .filter('pageCount', pageCount);

    function pageCount() {
        return FilterFilter;

        ////////////////

        function FilterFilter(data, size) {
        if (angular.isArray(data)) {
            var result = [];
            for (var i = 0; i < Math.ceil(data.length / size) ; i++) {
                result.push(i);
            }
            return result;
        } else {
            return data;
        }
    }
    }
})();