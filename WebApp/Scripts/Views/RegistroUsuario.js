function RegistroUsuario() {

    this.service = 'Usuario';
    this.ctrlActions = new ControlActions();
    this.columns = "Cedula,Nombre,PrimerApellido,SegundoApellido,FechaNacimiento,Correo,Contrasena,Telefono,FotoPerfil,Estado,TipoIdentificacion,CodigoVerificacion";

    //this.RegistroAdmin = function () {
    //    sessionStorage.setItem('IdRol', 1);
    //    window.location.href = 'http://localhost:44301/Home/RegistroAdmin';
    //} 
    this.Siguiente = () => {
        if (primera_validacion() == false) {
            $('#primer_formulario').hide();
            $('#primer_formulario_2').show();
        }
    }
    this.SiguienteV1 = () => {
        if (segunda_validacion() == false) {
            var correo = $('#txt_correo').val();
            var usuario = this.ctrlActions.GetToApi(this.service + '/?Correo=' + correo, callback = (response) => {
                console.log("el correo ya existe");
                $('#txt_correo').addClass("is-invalid");
            }, errorFunction = () => {
                $('#txt_correo').removeClass("is-invalid");
                $('#primer_formulario_2').hide();
                $('#segundo_formulario').show();
            });
        }
    }
    this.Atras = () => {
        $('#segundo_formulario').hide();
        $('#primer_formulario_2').show();
    }

    this.Verificar = () => {
        var usuario = {};
        if (segunda_validacion() == true) {
            console.log("error");
        } else {
            usuario = this.ctrlActions.GetDataForm('registro_usuario');
            usuario.Estado = "EST_INACTIVO";
            usuario.FotoPerfil = $('#imagen_profile').attr("src");
            usuario.IdRol = sessionStorage.getItem("IdRol");
            console.log(usuario.CodigoVerificacion);
            if (document.getElementById('radio_nacional').checked) {
                usuario.tipoIdentificacion = $('#radio_nacional').val();
                console.log(usuario.tipoIdentificacion);
            } else if (document.getElementById('radio_extranjero').checked) {
                usuario.tipoIdentificacion = $('#radio_extranjero').val();
                console.log(usuario.tipoIdentificacion);
            }

            console.log(usuario);

            this.ctrlActions.PostToAPI(this.service, usuario);
            sessionStorage.clear();
        }
    }

    this.Ingresar = () => {
        var codigo = $('#txt_codigo').val();
        var usuario = this.ctrlActions.GetToApi(this.service + '/?Codigo=' + codigo, callback = (response) => {
            sessionStorage.setItem('usuario', JSON.stringify(response));
            var obj = JSON.parse(sessionStorage.getItem('usuario'));

            switch (obj.IdRol) {
                case 1:
                    window.location.href = 'InicioAdmin';
                    break;
                case 2:
                    window.location.href = 'RegistroVehiculo';
                    break;
                case 3:
                    window.location.href = 'Direcciones';
                    break;
                case 4:
                    window.location.href = 'InicioUsuarioFinal';
                    break;

                default:

                    break;
            }
        },
            errorFunction = () => {

            });
    }

    let segunda_validacion = () => {
        let error = false;
        let error2 = false;
        const fechaNacimiento = $('#date_fecha_nacimiento').val();
        const correo = $('#txt_correo').val();
        const contrasena = $('#txt_contrasena').val();
        const contrasena2 = $('#txt_contrasena_2').val();
        if (fechaNacimiento == "") {
            error = true;
            $('#date_fecha_nacimiento').addClass("is-invalid");

        } else {
            error = false;
            $('#date_fecha_nacimiento').removeClass("is-invalid");
        }
        if (correo == "" || validateEmail(correo) == false) {
            error = true;
            $('#txt_correo').addClass("is-invalid");
        } else {
            error = false;
            $('#txt_correo').removeClass("is-invalid");
        }
        if (contrasena == "") {
            error2 = true;
            $('#txt_contrasena').addClass("is-invalid");
            $('#txt_contrasena_2').addClass("is-invalid");

        } else if (contrasena != contrasena2 || contrasena2 != contrasena) {
            error2 = true;
            $('#txt_contrasena').addClass("is-invalid");
            $('#txt_contrasena_2').addClass("is-invalid");

        } else if (contrasena.length < 7) {
            error2 = true;
            $('#txt_contrasena').addClass("is-invalid");
            $('#txt_contrasena_2').addClass("is-invalid");
        } else if (error == true) {
            error2 = true;
            $('#txt_contrasena').removeClass("is-invalid");
            $('#txt_contrasena_2').removeClass("is-invalid");
        } else if (error == false) {
            error2 = false;
        }
        return error2;
    }

    let primera_validacion = () => {
        let error = false;
        let error2 = false;
        const cedula = $('#txt_cedula').val();
        const nombre = $('#txt_nombre').val();
        const primerApellido = $('#txt_primer_apellido').val();
        const segundoApellido = $('#txt_segundo_apellido').val();
        if (!$('#radio_nacional').is(':checked') && !$('#radio_extranjero').is(':checked')) {
            error = true;
            console.log(error);
            $('#radio_nacional').addClass("is-invalid");
            $('#radio_extranjero').addClass("is-invalid");

        } else {
            error = false;
            console.log(error);
            $('#radio_nacional').removeClass("is-invalid");
            $('#radio_extranjero').removeClass("is-invalid");
        }
        if (cedula == "") {
            error = true;
            $('#txt_cedula').addClass("is-invalid");

        } else {
            error = false;
            $('#txt_cedula').removeClass("is-invalid");
        }
        if (nombre == "") {
            error = true;
            $('#txt_nombre').addClass("is-invalid");

        } else {
            error = false;
            $('#txt_nombre').removeClass("is-invalid");
        }
        if (primerApellido == "") {
            error = true;
            $('#txt_primer_apellido').addClass("is-invalid");

        } else {
            error = false;
            $('#txt_primer_apellido').removeClass("is-invalid");
        }
        if (segundoApellido == "") {
            error2 = true;
            $('#txt_segundo_apellido').addClass("is-invalid");
        } else if (error == true) {
            error2 = true;
            $('#txt_segundo_apellido').removeClass("is-invalid");
        } else if (error == false) {
            error2 = false;
        }

        return error2;
    }



    var uploadWidget;

    this.showWidget = function () {
        uploadWidget = cloudinary.openUploadWidget({
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
                document.querySelector('#imagen_profile').src = result.info.secure_url;
            }
        });
    }
}
function validateEmail(correo) {
    return /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i.test(correo)
}
$(document).ready(function () {
    $('#primer_formulario_2').hide();
    $('#segundo_formulario').hide();

})
