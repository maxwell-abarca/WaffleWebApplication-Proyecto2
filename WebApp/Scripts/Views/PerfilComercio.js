var lat, lng;
function PerfilComercio() {
    this.comercio = JSON.parse(sessionStorage.getItem('comercio'));
    //this.profilePhoto = document.getElementById('m_img_comercio').src = this.comercio.Foto;
    //this.cedula = document.getElementById('txtCedulaJuridica').value = this.comercio.CedulaJuridica;
    //this.cedulaDueno = document.getElementById('txtCedulaDueno').value = this.comercio.CedulaDueno;
    //this.categoria = document.getElementById('txtIdCategoria').value = this.comercio.IdCategoria;
    //this.regimen = document.getElementById('txtRegimen').value = this.comercio.RegimenTributario;
    //this.nombre = document.getElementById('txtNombreComercial').value = this.comercio.NombreComercial;
    //this.telefono = document.getElementById('txtTelefono').value = this.comercio.Telefono;
    //this.direccion = document.getElementById('txtDireccionEscrita').value = this.comercio.DireccionEscrita;
    //this.horaApertura = document.getElementById('txtHoraApertura').value = this.comercio.HoraApertura;
    //this.horaCierre = document.getElementById('txtHoraCierre').value = this.comercio.HoraCierre;
    //this.fechaCreacion = document.getElementById('txtFechaCreacion').value = this.comercio.FechaCreacion;
    //this.estado = document.getElementById('txtEstado').value = this.comercio.Estado;
    //this.cadena = document.getElementById('txtIdCadena').value = this.comercio.IdCadena;
    this.service = 'Comercio';
    this.ctrlActions = new ControlActions();

    this.Update = () => {
        var comercioData = {};
        comercioData = this.ctrlActions.GetDataForm('collapseRegistro');
        comercioData.Foto = $('#m_img_comercio').attr('src');
        //comercioData.ID = ActualizarDireccion();
        console.log(comercioData);
        //Hace el post al modificar
        this.ctrlActions.PutToAPI(this.service, comercioData);
    }

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
    var uploadWidget;

    this.showWidgetEdit = function () {
        showWidgetEdit = cloudinary.openUploadWidget({
            cloudName: "drlznypvr",
            uploadPreset: "lonpzlw8",
            sources: [
                "local",
                "url",
                "camera"
            ],
        }, function (error, result) {
            if (!error && result.event == "success") {
                console.log(result);
                document.querySelector('#m_img_comercio').src = result.info.secure_url;
            }
        });
    }
}
$(document).ready(function () {
    this.comercio = JSON.parse(sessionStorage.getItem('comercio'));
    this.profilePhoto = document.getElementById('m_img_comercio').src = this.comercio.Foto;
    this.cedula = document.getElementById('txtCedulaJuridica').value = this.comercio.CedulaJuridica;
    this.cedulaDueno = document.getElementById('txtCedulaDueno').value = this.comercio.CedulaDueno;
    this.categoria = document.getElementById('txtIdCategoria').value = this.comercio.IdCategoria;
    this.nombre = document.getElementById('txtNombreComercial').value = this.comercio.NombreComercial;
    this.regimen = document.getElementById('txtRegimen').value = this.comercio.RegimenTributario;
    this.telefono = document.getElementById('txtTelefono').value = this.comercio.Telefono;
    this.direccion = document.getElementById('txtDireccionEscrita').value = this.comercio.DireccionEscrita;
    this.horaApertura = document.getElementById('txtHoraApertura').value = this.comercio.HoraApertura;
    this.horaCierre = document.getElementById('txtHoraCierre').value = this.comercio.HoraCierre;
    this.fechaCreacion = document.getElementById('txtFechaCreacion').value = this.comercio.FechaCreacion;
    this.estado = document.getElementById('txtEstado').value = this.comercio.Estado;
    this.cadena = document.getElementById('txtIdCadena').value = this.comercio.IdCadena;

    cargarDireccion();
    var map = new GMaps({
        el: '#map',
        zoom: 8,
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
    function cargarDireccion() {
        var obj = JSON.parse(sessionStorage.getItem('comercio'));
        this.ctrlActions = new ControlActions();
        this.ctrlActions.GetToApi('Direccion' + '/?ID=' + obj.IdDireccion, callback = (response) => {
            console.log(response);
            var LatLng = { lat: response.Latitud, lng: response.Longitud }
            map.addMarker({
                position: LatLng,
                title: "Mi direccion"
            })

        });
    }

});