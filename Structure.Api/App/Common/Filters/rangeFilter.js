(function() {
'use strict';

    angular
        .module('storeFilters')
        .filter('range', range);
    range.$inject = ['$filter'];
    function range($filter) {
        return FilterFilter;

        ////////////////

        function FilterFilter(data, page, size) {
        if (angular.isArray(data) && angular.isNumber(page) && angular.isNumber(size)) {
            var start_index = (page - 1) * size;
            if (data.length < start_index) {
                return [];
            } else {
                return $filter("limitTo")(data.splice(start_index), size);
            }
        } else {
            return data;
        }
    }
    }
})();