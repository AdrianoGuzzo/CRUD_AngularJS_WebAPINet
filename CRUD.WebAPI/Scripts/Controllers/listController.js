app.controller('listCtrl', function ($scope, $http, $location) {
    debugger
    $scope.list = [];
    $scope.phones = [];
    $scope.loading = true;
    $http.get('/api/contact/list').then(function (result) {
        $scope.loading = false;
        $scope.list = result.data.Data;
    });
    $scope.delete = function (contact) {
        $http.delete('/api/contact/delete/' + contact.Id).then(function (result) {
            if (result.data.Status) {
                var index = $scope.list.indexOf(contact);
                $scope.list.splice(index, 1);
            }
            else {
                alert("Error!!! Olhe o console")
                for (var i in result.data.erros) {
                    console.log(result.data.erros[i].message)
                    console.log(result.data.erros[i].stackTrace)
                }
            }
        });
    }
    $scope.listPhones = function (Id) {
        $http.get('/api/contact/phones/' + Id).then(function (result) {
            if (result.data.Status) {
                $scope.phones = result.data.Data;
                if (result.data.Data.length == 0)
                    alert("Not Found")
            }
            else {
                alert("Error!!! Olhe o console")
                for (var i in result.data.erros) {
                    console.log(result.data.erros[i].message)
                    console.log(result.data.erros[i].stackTrace)
                }
            }
        });
    };
});