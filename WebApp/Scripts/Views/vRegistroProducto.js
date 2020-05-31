function vRegistroProducto() {
    this.service = 'producto';
    this.ctrlActions = new ControlActions();
    this.columns = "IdProducto,NombreProducto,IdCategoria,Precio,Imagen,IdComercio,Estado";

    this.Create = function () {
        var productoData = {};
        productoData = this.ctrlActions.GetDataForm('frmRegistro');
        var data = sessionStorage.getItem('IdComercio');
        productoData.IdComercio = data;
        productoData.Estado = "Activo";
        productoData.Imagen = $('#imagen_profile').attr('src');
        console.log(productoData);
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, productoData);
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









