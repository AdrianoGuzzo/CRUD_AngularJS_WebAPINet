app.controller('addCtrl', function ($scope, $http, $location, base) {
    $scope.list = [];
    $scope.contact = { Phones: [] };
    $scope.Phone = "";

    $scope.submit = function (contact) {
        debugger;
        //contact.birthday = base.convertDate(contact._birthday);
        $http.post('/api/contact/save', contact).then(function (result) {
            base.returnRequest(result, function (Status, Data) {
                if (Status)
                    $location.path('/');
            });
        });
    }

    $scope.deletePhone = function (phone) {
        var index = $scope.contact.Phones.indexOf(phone);
        $scope.contact.Phones.splice(index, 1);
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