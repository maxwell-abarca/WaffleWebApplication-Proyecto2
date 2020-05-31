function SolicitudesTransportista() {

    /*this.tblTransportistasId = 'tblTransportistas';
    this.service = 'transportista';
    this.servi = 'membresia';
    this.ctrlActions = new ControlActions();
    this.columns = "Cedula,Nombre,PrimerApellido,Correo,Telefono,Estado,TipoIdentificacion";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service + '/?IdRol=' + 2, this.tblTransportistasId, false);
    }
    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service + '/?IdRol=' + 2, this.tblTransportistasId, true);
    }
    this.BindFields = function (data) {
        sessionStorage.setItem('transportista', JSON.stringify(data));
        this.ctrlActions.BindFields('gestion_transportista', data);
    }*/
    this.Actualizar = function () {

        var user = {};
        var obj = JSON.parse(sessionStorage.getItem('transportista'));
        user = this.ctrlActions.GetDataForm('gestion_transportista');
        user.Contrasena = obj.Contrasena;
        user.FotoPerfil = obj.FotoPerfil;
        user.CodigoVerificacion = obj.CodigoVerificacion;

        this.ctrlActions.PutToAPI(this.service, user);
        sessionStorage.removeItem('transportista');
    }
    this.Update = function () {

        var transportistaData = {};
        //transportistaData.Estado = "EST-RECHAZADO";
        transportistaData = this.ctrlActions.GetDataForm('gestion_transportista');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.servi, transportistaData);
        //Refresca la tabla
        this.ReloadTable();
        vaciarCampos();
    }
    this.Create = function () {
        if (validacion() == true) {
            console.log("error");
        } else {
            var transportistaData = {};
        transportistaData = this.ctrlActions.GetDataForm('gestion_transportista');
            //var data = sessionStorage.getItem('Cedula');
            //transportistaData.Cedula = data;
            console.log(transportistaData);
            //Hace el post al create
        this.ctrlActions.PostToAPI(this.servi, transportistaData);
            vaciarCampos();
        }
    }
}
let validacion = () => {
    let error = false;
    const IdMembresia = $('#txtIdMembresia').val();
    const CedulaUsuario = $('#txtCedulaUsuario').val();
    const CostoMembresia = $('#txtCostoMembresia').val();
    const FechaEmitida = $('#txtFechaEmitida').val();
    const FechaExpiracion = $('#txtFechaExpiracion').val();
    const TarifaBase = $('#txtTarifaBase').val();
    const MontoKilometraje = $('#txtMontoKilometraje').val();
    const Impuesto = $('#txtImpuesto').val();
    const Correo = $('#txtCorreo').val();


    if (IdMembresia == "") {
        error = true;
        $('#txtIdMembresia').attr("style", "border-color:red");
    } else {
        error = false;
        $('#txtIdMembresia').attr("style", "border-color:none");
    }
    if (CedulaUsuario == "") {
        error = true;
        $('#txtCedulaUsuario').attr("style", "border-color:red");
    } else {
        error = false;
        $('#txtCedulaUsuario').attr("style", "border-color:none");
    }
    if (CostoMembresia == "") {
        error = true;
        $('#txtCostoMembresia').attr("style", "border-color:red");
    } else {
        error = false;
        $('#txtCostoMembresia').attr("style", "border-color:none");
    }
    if (FechaEmitida == "") {
        error = true;
        $('#txtFechaEmitida').attr("style", "border-color:red");
    } else {
        error = false;
        $('#txtFechaEmitida').attr("style", "border-color:none");
    }
    if (FechaExpiracion == "") {
        error = true;
        $('#txtFechaExpiracion').attr("style", "border-color:red");
    } else {
        error = false;
        $('#txtFechaExpiracion').attr("style", "border-color:none");
    }
    if (TarifaBase == "") {
        error = true;
        $('#txtTarifaBase').attr("style", "border-color:red");
    } else {
        error = false;
        $('#txtTarifaBase').attr("style", "border-color:none");
    }
    if (MontoKilometraje == "") {
        error = true;
        $('#txtMontoKilometraje').attr("style", "border-color:red");
    } else {
        error = false;
        $('#txtMontoKilometraje').attr("style", "border-color:none");
    }
    if (Impuesto == "") {
        error = true;
        $('#txtImpuesto').attr("style", "border-color:red");
    } else {
        error = false;
        $('#txtImpuesto').attr("style", "border-color:none");
    }
    if (Correo == "") {
        error = true;
        $('#txtCorreo').attr("style", "border-color:red");
    } else {
        error = false;
        $('#txtCorreo').attr("style", "border-color:none");
    }
    return error;
}

$(document).ready(function () {
    var transportista = new SolicitudesTransportista();
    transportista.RetrieveAll();

});
function vaciarCampos() {
    $('#txtIdMembresia').val("");
    $('#txtCedulaUsuario').val("");
    $('#txtCostoMembresia').val("");
    $('#txtFechaEmitida').val("");
    $('#txtFechaExpiracion').val("");
    $('#txtTarifaBase').val("");
    $('#txtMontoKilometraje').val("");
    $('#txtImpuesto').val("");
    $('#txtCorreo').val("");
    }

