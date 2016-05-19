angular.module("FilesListApp").directive('loading', function () {
    return {
        restrict: 'E',
        replace: true,
        template: '<div class="loading"></div>',
        link: function (scope, element, attr) {
            scope.$watch('loading', function (val) {
                if (val)
                   $(element).show();
                else
                   $(element).hide();
            });
        }
    }
})