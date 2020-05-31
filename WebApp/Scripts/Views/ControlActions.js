function ControlActions() {

    this.URL_API = "http://localhost:44376/api/";

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }
    this.GetTableColumsDataName = function (tableId) {
        var val = $('#' + tableId).attr("ColumnsDataName");

        return val;
    }

    this.FillTable = function (service, tableId, refresh) {

        if (!refresh) {
            columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];


            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "processing": true,
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    dataSrc: 'Data'
                },
                "columns": arrayColumnsData,
                scrollX: true,
                scrollY: true
            });
        } else {

            $('#' + tableId).DataTable().ajax.reload();
        }
    }

    this.BindFields = function (formId, data) {

        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            this.value = data[columnDataName];

        });

    }
    this.GetDataForm = function (formId) {
        var data = {};
        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            data[columnDataName] = this.value;
        });

        console.log(data);
        return data;
    }
    this.ShowMessage = function (type, message) {
        if (type == 'E') {
            $("#alert_container").removeClass("alert alert-success alert-dismissable")
            $("#alert_container").addClass("alert alert-danger alert-dismissable");
            $("#alert_message").text(message);
        } else if (type == 'I') {
            $("#alert_container").removeClass("alert alert-danger alert-dismissable")
            $("#alert_container").addClass("alert alert-success alert-dismissable");
            $("#alert_message").text(message);
        }
        $('.alert').show();
    };


    this.PostToAPI = function (service, data) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.GetToApi = function (service, callbackFunction, errorFunction) {
        var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
            console.log("Response " + response);
            callbackFunction(response.Data);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                errorFunction();
                console.log("Datos incorrectos.")
            })
    };
    this.Get = function (service, callbackFunction) {
        var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
            console.log("Response " + response);
            callbackFunction(response.Data);
        });
    }

    this.PutToAPI = function (service, data, errorFunction) {
        var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            //ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                errorFunction();
                console.log("Error en el put")
            })
    };

    this.PutSync = function (service, data, errorFunction) {
        var jqxhr = $.putSync(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            //ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                errorFunction();
                console.log("Error en el put")
            })
    };

    this.DeleteToAPI = function (service, data) {
        var jqxhr = $.delete(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.logout = function () {
        localStorage.clear();
        window.location.href = 'Index';
    }
}

$.put = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'PUT',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'
    });
}

$.putSync = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        async: false,
        type: 'PUT',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'
    });
}

$.delete = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'DELETE',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'
    });
}



