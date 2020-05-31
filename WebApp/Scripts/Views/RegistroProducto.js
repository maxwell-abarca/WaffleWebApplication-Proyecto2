function RegistroProducto() {
    this.service = 'producto';
    this.ctrlActions = new ControlActions();
    this.columns = "IdProducto,NombreProducto,IdCategoria,Precio,Imagen,IdComercio,Estado";
    this.mIdProducto = document.getElementById('mIdProducto');
    this.mNombreProducto = document.getElementById('mNombreProducto');
    this.mIdCategoria = document.getElementById('mselectCategoria');
    this.mPrecio = document.getElementById('mPrecio');
    this.mImagen = document.getElementById('m_img_producto');
    this.mEstado = document.getElementById('mEstado');
    $('#mEstado').append('<option value="EST_ACTIVO">Activo</option>');
    $('#mEstado').append('<option value="EST_INACTIVO">Inactivo</option>'); 

    this.comercio = JSON.parse(sessionStorage.getItem('comercio'));

    this.Create = function () {

        //if (validacion() == true) {
        //    console.log("error");
        //} else {
        var productoData = {};

        productoData = this.ctrlActions.GetDataForm('frmRegistro');
        productoData.CedulaComercio = Number(this.comercio.CedulaJuridica);
        productoData.IdCategoria = $('#selectCategoria').children("option:selected").val();
        var comercio = JSON.parse(sessionStorage.getItem('comercio'));
        productoData.CedulaComercio = comercio.CedulaJuridica;
        productoData.Estado = "EST-ACTIVO";

        productoData.Imagen = $('#img_producto').attr('src');
        console.log(productoData);
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, productoData);
        vaciarCampos();
        //}
    }
    let validacion = () => {
        let error = false;
        const IdProducto = $('#txtIdProducto').val();
        const nombreProducto = $('#txtNombreProducto').val();
        const categoria = $('#txtIdCategoria').val();
        const precio = $('#txtPrecio').val();


        if (IdProducto == "") {
            error = true;
            $('#txtIdProducto').attr("style", "border-color:red");
        } else {
            error = false;
            $('#txtIdProducto').attr("style", "border-color:none");
        }
        if (nombreProducto == "") {
            error = true;
            $('#txtNombreProducto').attr("style", "border-color:red");
        } else {
            error = false;
            $('#txtNombreProducto').attr("style", "border-color:none");
        }
        if (categoria == "") {
            error = true;
            $('#txtIdCategoria').attr("style", "border-color:red");
        } else {
            error = false;
            $('#txtIdCategoria').attr("style", "border-color:none");
        }
        if (precio == "") {
            error = true;
            $('#txtPrecio').attr("style", "border-color:red");
        } else {
            error = false;
            $('#txtPrecio').attr("style", "border-color:none");
        }
        return error;
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
                document.querySelector('#img_producto').src = result.info.secure_url;
            }
        });
    }
    var showWidgetEdit;

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
                document.querySelector('#m_img_producto').src = result.info.secure_url;
            }
        });
    }

    this.Edit = function () {
        var inputs = ["mIdProducto", "mNombreProducto", "mPrecio"];
        var result = this.validateEmpty(inputs);
        var productoData = {};

        productoData.IdProducto = this.mIdProducto.value;
        productoData.NombreProducto = this.mNombreProducto.value;
        productoData.IdCategoria = this.mIdCategoria.value;
        productoData.Precio = this.mPrecio.value;
        productoData.Imagen = this.mImagen.src;
        productoData.Estado = this.mEstado.value;

        if (result == true) {
            console.log('Inputs incompletos');
        } else {
            this.ctrlActions.PutSync(this.service, productoData, errorFunction = () => {
                console.log('Error en el PUT');
            });
            window.location.reload();
        }
    }
}
function vaciarCampos() {
    $('#txtIdProducto').val("");
    $('#txtNombreProducto').val("");
    $('#txtIdCategoria').val("");
    $('#txtPrecio').val("");
    $('#img_producto').attr("src", "https://res.cloudinary.com/drlznypvr/image/upload/v1575522337/productoImagen_jubvk7.png");
}
$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    this.ctrlActions.GetToApi('categoria', callback = (response) => {
        for (var i = 0; i < response.length; i++) {
            var tmpCategoria = response[i];

            $('#selectCategoria').append('<option value="' + tmpCategoria.IdCategoria + '">' + tmpCategoria.NombreCategoria + '</option>');
            $('#mselectCategoria').append('<option value="' + tmpCategoria.IdCategoria + '">' + tmpCategoria.NombreCategoria + '</option>');
            $('#selectFiltrar').append('<option value="0">Todas</option>');
            $('#selectFiltrar').append('<option value="' + tmpCategoria.IdCategoria + '">' + tmpCategoria.NombreCategoria + '</option>');
            $('#mEstado').append('<option value="EST_ACTIVO">Activo</option>');
            $('#mEstado').append('<option value="EST_INACTIVO">Inactivo</option>'); 
        }
    });
});








