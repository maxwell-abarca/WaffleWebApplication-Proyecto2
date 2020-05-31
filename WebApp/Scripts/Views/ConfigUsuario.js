var lat, lng;
function configUser() {
    this.user = JSON.parse(sessionStorage.getItem('usuario'));
    this.identificationType = document.getElementById('TipoIdentificacionUsuario').value = this.user.TipoIdentificacion;
    this.identification = document.getElementById('CedulaUsuario').value = this.user.Cedula;
    this.name = document.getElementById('NombreUsuario').value = this.user.Nombre;
    this.lastname1 = document.getElementById('PrimerApellidoUsuario').value = this.user.PrimerApellido;
    this.lastname2 = document.getElementById('SegundoApellidoUsuario').value = this.user.SegundoApellido;
    this.birthdate = document.getElementById('FechaNacimientoUsuario').value = this.user.FechaNacimiento;
    this.age = document.getElementById('EdadUsuario').value = 20;
    this.email = document.getElementById('CorreoElectronicoUsuario').value = this.user.Correo;
    this.profilePhoto = document.getElementById('profilePhoto').src = this.user.FotoPerfil;
    this.btnUpdate = document.getElementById('btnUpdate');
    this.password = document.getElementById('ContrasenaNueva');
    this.passwordConfirm = document.getElementById('ContrasenaVerificacion');
    this.btnUpdatePassword = document.getElementById('btnUpdatePassword');
    this.errorMessage = document.getElementById('errorMessage');
    this.successMessage = document.getElementById('successMessage');
    this.service = 'Usuario';
    this.ctrlActions = new ControlActions();

    this.newPassword = () => {
        var user = JSON.parse(sessionStorage.getItem('usuario'));
        if (this.password.value === this.passwordConfirm.value && this.password.value.length > 7) {
            user.Contrasena = this.password.value;
            this.password.classList.add("is-valid");
            this.passwordConfirm.classList.add("is-valid");

            this.ctrlActions.PutToAPI(this.service, user, error = () => {
                console.log('ERROR');
                this.password.classList.add("is-invalid");
                this.passwordConfirm.classList.add("is-invalid");
            });

            this.errorMessage.style.display = 'none';
            this.successMessage.style.display = 'block';

        } else {
            this.successMessage.style.display = 'none';
            this.errorMessage.style.display = 'block';
            this.password.classList.add("is-invalid");
            this.passwordConfirm.classList.add("is-invalid");

        }
    }

    this.updateInfo = () => {
        this.name.value = this.user.Nombre;
        this.lastname1.value = this.user.PrimerApellido;
        this.lastname2.value = this.user.SegundoApellido;
        this.profilePhoto.src = this.user.FotoPerfil;
    }
    this.ActualizarDireccion = () => {
        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        var direccion = {};
        direccion.Latitud = lat;
        direccion.Longitud = lng;
        direccion.IdUsuario = obj.Cedula;
        this.ctrlActions.PutToAPI('DireccionUsuario', direccion);
    }
}

$(document).ready(function () {
    this.user = JSON.parse(sessionStorage.getItem('usuario'));
    this.identificationType = document.getElementById('TipoIdentificacionUsuario').value = this.user.TipoIdentificacion;
    this.identification = document.getElementById('CedulaUsuario').value = this.user.Cedula;
    this.name = document.getElementById('NombreUsuario').value = this.user.Nombre;
    this.lastname1 = document.getElementById('PrimerApellidoUsuario').value = this.user.PrimerApellido;
    this.lastname2 = document.getElementById('SegundoApellidoUsuario').value = this.user.SegundoApellido;
    this.birthdate = document.getElementById('FechaNacimientoUsuario').value = this.user.FechaNacimiento;
    this.age = document.getElementById('EdadUsuario').value = 20;
    this.email = document.getElementById('CorreoElectronicoUsuario').value = this.user.Correo;
    this.profilePhoto = document.getElementById('profilePhoto').src = this.user.FotoPerfil;
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
        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        this.ctrlActions = new ControlActions();
        this.ctrlActions.GetToApi('DireccionUsuario' + '/?IdUsuario=' + obj.Cedula, callback = (response) => {
            console.log(response);
            var LatLng = { lat: response.Latitud, lng: response.Longitud }
            map.addMarker({
                position: LatLng,
                title: "Mi direccion"
            })

        });
    }

});