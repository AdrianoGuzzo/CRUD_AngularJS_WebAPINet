app.controller('listCtrl', function ($scope, $http, $location, base) {
    $scope.list = [];
    $scope.phones = [];
    $scope.loading = true;
    $http.get('/api/contact/list').then(function (result) {
        base.returnRequest(result, function (Status, Data) {
            if (Status) {
                $scope.loading = false;
                $scope.list = result.data.Data;
            }
        });
    });
    $scope.delete = function (contact) {
        $http.delete('/api/contact/delete/' + contact.Id).then(function (result) {
            base.returnRequest(result, function (Status, Data) {
                if (Status) {
                    var index = $scope.list.indexOf(contact);
                    $scope.list.splice(index, 1);
                }
            })
        });

    }
    $scope.listPhones = function (Id) {
        $http.get('/api/contact/phones/' + Id).then(function (result) {
            base.returnRequest(result, function (Status, Data) {
                if (Status) {
                    $scope.phones = Data;
                    if (Data.length == 0)
                        alert("Not Found")
                }
            })
        });
    };
});