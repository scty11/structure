(function() {
    'use strict';

    angular.module('gadgetsStore', ['storeFilters',
       "ngRoute",'storeCart','angularValidator'
    ])
    .config(function ($routeProvider, $locationProvider) {
			    $routeProvider.when("/gadgets", {
			        templateUrl: "App/Views/gadetsView.html"
                    //controller: "gadgetsCtrl"
			    }).when("/",
			    {
			        templateUrl: "App/Views/gadetsView.html"
			    })
			   .when("/checkout", {
			        templateUrl: "App/Views/checkout.html"                  
			   }).otherwise({
			       templateUrl: "app/views/gadgets.html"
			   });
			    $routeProvider.when("/submitorder", {
			        templateUrl: "app/views/submitOrder.html"
			    });
			    //$routeProvider.when("/complete", {
			    //    templateUrl: "app/views/orderSubmitted.html"
        //});

			    $locationProvider.html5Mode(true);

			});
})();