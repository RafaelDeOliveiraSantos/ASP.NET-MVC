var app = angular.module("app", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider.when("/list", {
        templateUrl: "/Produto/List",
        controller: "ListController"
    }).when("/create", {
        templateUrl: "/Produto/Edit",
        controller: "EditController"
    }).when("/edit/:id", {
        templateUrl: "/Produto/Edit",
        controller: "EditController"
    }).when("/delete/:id", {
        templateUrl: "/Produto/Delete",
        controller: "DeleteController"
        }).otherwise("/list");
});

app.controller("ListController", function ($scope, $http) {
    $http.get("/Api/Produto").success(function (data) {
        $scope.Produtos = data;
    });
});

app.controller("EditController", function ($scope, $http, $routeParams, $location) {
    var id = $routeParams.id;

    if (id > 0) {
        $scope.title = "Editando produto";
        $http.get("/Api/Produto/" + id).success(function (data) {
            $scope.Produto = data;
        });
    } else {
        $scope.title = "Novo produto";
    }

    $scope.save = function () {
        if ($scope.Produto.Id === 0) {
            $scope.create();
        } else {
            $scope.update();
        }
    }

    $scope.create = function () {
        $http.post("/Api/Produto/", $scope.Produto).success(function () {
            $location.path("/list");
        }).error(function (data) {
            $scope.Error = data.ExceptionMessage;
        });
    }

    $scope.update = function () {
        $http.put("/Api/Produto/", $scope.Produto).success(function () {
            $location.path("/list");
        }).error(function (data) {
            $scope.Error = data.ExceptionMessage;
        });
    }
});

app.controller("DeleteController", function($scope, $http, $routeParams, $location) {
    var id = $routeParams.id;
    $http.get("/Api/Produto/" + id).success(function(data) {
        $scope.Produto = data;
    });

    $scope.delete = function() {
        $http.delete("/Api/Produto/" + id).success(function() {
            $location.path("/list");
        }).error(function(data) {
            $scope.Error = "Erro: " + data;
        });
    }
});