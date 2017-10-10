app.service('base', function () {
    this.convertDate = function (date) {
        return new Date(date.split('/')[2], date.split('/')[1] - 1, date.split('/')[0]);
    }

    this.returnRequest = function (result, callback) {
        if (result.data.Status)
            callback(true, result.data.Data)
        else {
            alert("Error!!! Olhe o console")
            for (var i in result.data.erros) {
                console.log(result.data.erros[i].message)
                console.log(result.data.erros[i].stackTrace)
            }
            callback(false)
        }
    }
    this.convertDateToInput = function (dateChar) {
        var date = new Date(dateChar);

        var pad = "00"
        var day = "" + date.getDate();
        var day = pad.substring(0, pad.length - day.length) + day

        var month = "" + (date.getMonth()+1);
        var month = pad.substring(0, pad.length - month.length) + month

        return day + "/" + month + "/" + date.getFullYear();
    }
});