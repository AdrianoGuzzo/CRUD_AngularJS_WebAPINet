app.controller('editCtrl', function ($scope, $http, $location, $routeParams, base) {
    $scope.Id = $routeParams.Id
    $scope.contact = null;
    $http.get('/api/contact/get/' + $routeParams.Id).then(function (result) {
        base.returnRequest(result, function (Status, Data) {
            if (Status) {
                $scope.contact = Data;
                $scope.contact.Birthday = new Date($scope.contact.Birthday);
            }
        })
    });
    $scope.submit = function (contact) {
        $http.put('/api/contact/update/', contact).then(function (result) {
            base.returnRequest(result, function (Status, Data) {
                if (Status) {
                    $location.path('/');
                }
            })
        });
    }
    $scope.deletePhone = function (phone) {
        debugger;
        if (phone.Id)
            $http.delete('/api/contact/deletePhone/' + phone.Id).then(function (result) {
                base.returnRequest(result, function (Status, Data) {
                    if (Status) {
                        var index = $scope.contact.Phones.indexOf(phone);
                        $scope.contact.Phones.splice(index, 1);
                    }
                })
            });
        else {
            var index = $scope.contact.Phones.indexOf(phone);
            $scope.contact.Phones.splice(index, 1);
        }
    }
    $scope.addPhone = function (phone) {
        if (phone) {
            for (i in $scope.contact.Phones)
                if ($scope.contact.Phones[i].number == phone) {
                    $scope.Phone = "";
                    return;
                }
            $scope.contact.Phones.push({ Number: phone });
        }
        $scope.Phone = "";
    }

});