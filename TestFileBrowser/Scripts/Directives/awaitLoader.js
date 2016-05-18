angular.module("FilesListApp").directive('loading', function () {
    return {
        restrict: 'E',
        replace: true,
        template: '<div class="loading"><img src="../Content/loading.gif" >sdfdsdsf</div>',
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