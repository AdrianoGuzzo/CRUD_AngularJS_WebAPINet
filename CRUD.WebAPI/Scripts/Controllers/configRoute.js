app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "View/List.html"
        })
        .when("/add", {
            templateUrl: "View/Add.html"
        });
});