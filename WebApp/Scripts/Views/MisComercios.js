var dir = {};
var lat, lng;
var addressID;
var uploadWidget;

this.user = JSON.parse(sessionStorage.getItem('usuario'));

function registroComercio() {
    this.legalID = document.getElementById('inputCedulaJuridica');
    this.commerceName = document.getElementById('inputNombreComercio');
    this.cadena = document.getElementById('selectCadena');
    this.category = document.getElementById('selectCategoria');
    this.phone = document.getElementById('inputTelefono');
    this.imgComercio = document.getElementById('comercioImagen');
    this.opening = document.getElementById('inputHoraApertura');
    this.closing = document.getElementById('inputHoraCierre');
    this.creationDate = document.getElementById('inputFecha');
    this.address = document.getElementById('inputUbicacionEscrita');
    this.regime = document.getElementById('regimen');
    this.imgComercio = document.getElementById('comercioImagen');
    this.addressID;
    this.firstDiv = document.getElementById('first');
    this.secondDiv = document.getElementById('second');
    this.divListaComercios = document.getElementById('listaComercios');
    this.user = JSON.parse(sessionStorage.getItem('usuario'));
    this.service = 'Comercio';
    this.ctrlActions = new ControlActions();

    this.validateEmpty = (inputArray) => {
        let resp = true;
        var error = 0;
        for (i in inputArray) {
            if (inputArray.hasOwnProperty(i)) {
                id = inputArray[i];
                var input = $("#" + id);
                if (input) {
                    if (input.val().length < 1) {
                        input.addClass("is-invalid");
                        error++;
                    } else {
                        input.removeClass("is-invalid");
                        input.addClass("is-valid");
                    }
                } else {
                    console.log('No se encontro: ' + id);
                    error++;
                }
            }
        }
        if (error == 0) {
            resp = false;
        }
        return resp;
    }

    this.cleanFields = (inputArray) => {
        for (i in inputArray) {
            if (inputArray.hasOwnProperty(i)) {
                id = inputArray[i];
                var input = $("#" + id);
                if (input) {
                    if (input.val().length > 1) {
                        input.val("");
                    }
                } else {
                    console.log('No se encontro: ' + id);
                }
            }
        }
    }

    this.next = () => {
        var inputs = ["inputCedulaJuridica", "inputNombreComercio", "inputTelefono"];
        var result = this.validateEmpty(inputs);
        if (result == true) {
            console.log('Inputs incompletos');
        } else {
            this.firstDiv.style.display = 'none';
            this.secondDiv.style.display = 'flex';
        }
    }

    this.showWidget = () => {
        uploadWidget = cloudinary.openUploadWidget({
            cloudName: "drlznypvr",
            uploadPreset: "lonpzlw8",
            sources: [
                "local",
                "url"
            ],
        }, function (error, result) {
            if (!error && result.event == "success") {
                console.log(result);
                document.getElementById('comercioImagen').src = result.info.secure_url;
            }
        });
    }

    this.newComercio = () => {
        var inputs = ["inputUbicacionEscrita", "inputHoraApertura", "inputHoraCierre", "inputFecha"];
        var result = this.validateEmpty(inputs);
        var com = {};
        com.CedulaJuridica = Number(this.legalID.value);
        com.CedulaDueno = Number(this.user.Cedula);
        com.IdCadena = Number(this.cadena.value);
        com.IdCategoria = Number(this.category.value);
        com.NombreComercial = this.commerceName.value;
        com.RegimenTributario = this.regime.src;
        com.Telefono = this.phone.value;
        com.DireccionEscrita = this.address.value;
        com.HoraApertura = this.opening.value;
        com.HoraCierre = this.closing.value;
        com.FechaCreacion = this.creationDate.value;
        com.Estado = 'EST-INACTIVO';
        com.Foto = this.imgComercio.src;

        com.Latitud = lat;
        com.Longitud = lng;
        if (result == true) {
            console.log('Inputs incompletos');
        } else {
            this.ctrlActions.PostToAPI(this.service, com);
        }
    }
}

$(document).ready(function () {
    this.ctrlActions = new ControlActions();

    var map = new GMaps({
        el: '#map',
        zoom: 10,
        lat: 9.932542,
        lng: -84.031055,
        click: GetLocation
    });

    function SetLocation(e) {
        map.addMarker({
            lat: e.latLng.lat(),
            lng: e.latLng.lng(),
            title: "Dirección"
        });
    }

    function GetLocation(e) {
        if (map.markers.length == 1) {
            map.removeMarkers();
            SetLocation(e);
        } else {
            SetLocation(e);
        }
        lat = e.latLng.lat();
        lng = e.latLng.lng();
        console.log(lat, lng);
    }

    this.ctrlActions.GetToApi('Cadena/?CedulaDueno=' + user.Cedula, callback = (response) => {
        for (var i = 0; i < response.length; i++) {
            var tmpCadena = response[i];
            $('#selectCadena').append('<option value="' + tmpCadena.ID + '">' + tmpCadena.Nombre + '</option>');
        }
    });

    this.ctrlActions.GetToApi('categoria', callback = (response) => {
        for (var i = 0; i < response.length; i++) {
            var tmpCategoria = response[i];

            $('#selectCategoria').append('<option value="' + tmpCategoria.IdCategoria + '">' + tmpCategoria.NombreCategoria + '</option>');
        }
    });
});