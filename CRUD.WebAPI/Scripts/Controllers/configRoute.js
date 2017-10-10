app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "View/List.html"
        })
        .when("/add", {
            templateUrl: "View/Add.html"
        }).when("/edit/:Id", {
            templateUrl: "View/Edit.html"
        });
});