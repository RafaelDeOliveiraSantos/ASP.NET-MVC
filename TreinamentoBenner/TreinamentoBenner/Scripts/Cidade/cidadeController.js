var app = angular.module("app", []);

app.controller("CidadeController", function($scope, $http, params) {
    function clear() {
        $scope.cidade = {};
        $scope.editting = false;
        $scope.cidadeEditing = null;
    }

    $http.get(params.urlList).success(function(response) {
        $scope.cidades = response;
        clear();
    });

    $scope.add = function () {
        $http.post(params.urlAdd, $scope.cidade).success(function(response) {
            if (response.Status) {
                $scope.cidades.push(response.Model);
                clear();
            }
        });
    }

    $scope.edit = function(cidade) {
        $scope.cidade = cidade;
        $scope.cidade.splice($scope.cidades.indexOf(cidade), 1);
        $scope.editting = true;
        $scope.cidadeEditing = cidade;
    }

    $scope.cancel = function() {
        $scope.cidades.push($scope.cidadeEditing);
        clear();
    }

    $scope.remove = function() {
        $http.post(params.urlRemove, { Id: cidade.Id }).success(function(response) {
            if (response.Status) {
                $scope.cidades.slice($scope.cidades.indexOf(cidade), 1);
            }
        });
    }
});