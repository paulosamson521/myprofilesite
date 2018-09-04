angular.module("umbraco").controller("ImageGalleryGuide.controller",
    function ($scope) {

        //map images on init to create collection of objects 
        //that satisfies the umb-lightbox component
        $scope.model.images = $scope.model.config.imagePaths.map(function (imagePath) {
            var imageValue = imagePath.value;
            return {
                source: imageValue,
                thumbnail: imageValue + "?height=200"//if umbraco image, resize it
            };
        });;

        //open lightbox
        $scope.model.openLightbox = function (itemIndex, items) {
            $scope.model.lightbox = {
                show: true,
                activeIndex: itemIndex,
                items: items
            };
        }

        //close lightbox
        $scope.model.closeLightbox = function () {
            $scope.model.lightbox.show = false;
            $scope.model.lightbox = null;
        }
    });