(function () {
    var app = angular.module("gemStore", []);

    app.controller("StoreController", ['$http', function ($http) {
        //this.products = gems;
        var store = this;
        store.products = [];

        $http.get('/URL/resourse.json').
            success(function (data) {
                store.products = data;

            });

        $http.post('/URL/resourse.json', { param: 'value' }).
           success(function (data) {
               store.products = data;

           });

        $http.delete('/URL/resourse.json').
          success(function (data) {
              store.products = data;

          });

    }]);

   

    app.controller("PanelController", function () {
        this.tab = 1;

        this.selectTab = function (setTab) {
            this.tab = setTab;
        }

        this.isSelected = function (checkTab) {
            return this.tab === checkTab;
        }

    });

    app.controller('GalleryController', function () {
        this.current = 0;
        this.setCurrent = function (newGallery) {
            this.current = newGallery || 0;
        };
    });

    app.controller('ReviewController', function () {
        this.review = {};

        this.addReview = function (product) {
            this.review.createdOn = Date.now();
            product.reviews.push(this.review);
            this.review = {};
        };
    });

    app.directive("productTite", function () {
        return {
            restrict: 'E', //E = Element <product-tite></product-tite>
            templateUrl: 'app/templates/product-tittle.html'
        };

        //return {
        //    restrict: 'A', A= Atribute    <h3 product-tite> </h3>
        //    templateUrl: 'app/templates/product-tittle.html'
        //};
    });

    app.directive("productPanels", function () {
        return {
            restrict: 'E', //E = Element <product-tite></product-tite>
            templateUrl: 'app/templates/product-panels.html',
            controler: function () {
                this.tab = 1;

                this.selectTab = function (setTab) {
                    this.tab = setTab;
                }

                this.isSelected = function (checkTab) {
                    return this.tab === checkTab;
                }
            },
            controllerAS:'panel'
        };

     
    });

    var gems = [{
        name: 'Azurite',
        description: "Some gems have hidden qualities beyond their luster, beyond their shine... Azurite is one of those gems.",
        shine: 8,
        price: 110.50,
        rarity: 7,
        color: '#CCC',
        faces: 14,
        images: [
          "app/img/gema Azul Claro.jpg",
          "images/gem-05.gif",
          "images/gem-09.gif"
        ],
        reviews: [
            {
                stars: 5,
                body: "I love this product",
                author: "joe@qwe.com"
            },
            {
                stars: 1,
                body: "This product sucks",
                author: "tim@hater.com"
            }
        ]
    }, {
        name: 'Bloodstone',
        description: "Origin of the Bloodstone is unknown, hence its low value. It has a very high shine and 12 sides, however.",
        shine: 9,
        price: 22.90,
        rarity: 6,
        color: '#EEE',
        faces: 12,
        images: [
          "images/gem-01.gif",
          "images/gem-03.gif",
          "images/gem-04.gif"
        ],
        reviews: [
            {
                stars: 5,
                body: "I love this product",
                author: "joe@qwe.com"
            },
            {
                stars: 1,
                body: "This product sucks",
                author: "tim@hater.com"
            }
        ]
    }, {
        name: 'Zircon',
        description: "Zircon is our most coveted and sought after gem. You will pay much to be the proud owner of this gorgeous and high shine gem.",
        shine: 70,
        price: 1100,
        rarity: 2,
        color: '#000',
        faces: 6,
        images: [
          "images/gem-06.gif",
          "images/gem-07.gif",
          "images/gem-10.gif"
        ],
        reviews: [
            {
                stars: 5,
                body: "I love this product",
                author: "joe@qwe.com"
            },
            {
                stars: 1,
                body: "This product sucks",
                author: "tim@hater.com"
            }
        ]
    }];
})();

