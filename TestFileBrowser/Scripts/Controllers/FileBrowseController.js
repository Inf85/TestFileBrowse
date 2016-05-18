var app = angular.module("FilesListApp", ["ngRoute"]);

app.controller("FilesListController",

   function ($scope, $http) {
      $http.get('/api/files').success(function (data) {

          $scope.files = data._drvList.Root_Items;
          $scope.PathDir = data._drvList.Path_dir;

      }).error(function (data) {
          alert('Ошибка');
      });

      $scope.NavigateFolder = function (folder) {

          $scope.path = folder;
          $scope.loading = true;

          $http({ url: '/api/files/getfile', params: { root: folder } }).success(function (data) {
                  $scope.files = data._fileBrowse.Root_Items;
                  $scope.PathDir = data._fileBrowse.Path_dir;
                  $scope.sizes = data.fc;
                  $scope.loading = false;
          }).error(function (data) {
              $scope.loading = false;
              alert('Ошибка');
          });

      }
        }

);
