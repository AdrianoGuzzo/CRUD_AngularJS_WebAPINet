app.controller('addCtrl', function ($scope, $http, $location) {
    $scope.list = [];
    $scope.contact = { phones: [] };
    $scope.phone = "";
    $scope.submit = function (contact) {
        contact.birthday = new Date(contact._birthday.split('/')[2], contact._birthday.split('/')[1] - 1, contact._birthday.split('/')[0]);
        $http.post('/api/contact/save', contact).then(function (result) {
            if (result.data.Status)
                $location.path('/');
            else {
                alert("Error!!! Olhe o console")
                for (var i in result.data.erros) {
                    console.log(result.data.erros[i].message)
                    console.log(result.data.erros[i].stackTrace)
                }
            }
        });
    }

    $scope.addPhone = function (phone) {
        if (phone) {
            for (i in $scope.contact.phones)
                if ($scope.contact.phones[i].number == phone) {
                    $scope.phone = "";
                    return;
                }
            $scope.contact.phones.push({ number: phone });
        }
        $scope.phone = "";
    }

});