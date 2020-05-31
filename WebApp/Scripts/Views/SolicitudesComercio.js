function SolicitudesComercio() {

    this.tblComercioId = 'tblComercio';
    this.service = 'comercio';
    this.servi = 'membresiaComercio';
    this.ctrlActions = new ControlActions();
    this.columns = "CedulaJuridica,CedulaDueno,NombreComercial,Estado";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblComercioId, false);
    }
    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblComercioId, true);
    }
    this.BindFields = function (data) {
        sessionStorage.setItem('comercio', JSON.stringify(data));
        this.ctrlActions.BindFields('gestion_comercio', data);
    }
    this.Update = function () {

        var comercioData = {};
        comercioData = this.ctrlActions.GetDataForm('gestion_comercio');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.servi, comercioData);
        //Refresca la tabla
        this.ReloadTable();
        vaciarCampos();
    }
    this.Create = function () {
        if (validacion() == true) {
            console.log("error");
        } else {
            var comercioData = {};
            comercioData = this.ctrlActions.GetDataForm('gestion_comercio');
            //var data = sessionStorage.getItem('Cedula');
            //transportistaData.Cedula = data;
            console.log(comercioData);
            //Hace el post al create
            this.ctrlActions.PostToAPI(this.servi, comercioData);
            vaciarCampos();
        }
    }
}
let validacion = () => {
    let error = false;
    const IdMembresia = $('#txtIdMembresia').val();
    const CedulaComercio = $('#txtCedulaComercio').val();
    const CostoMembresia = $('#txtCostoMembresia').val();
    const FechaEmitida = $('#txtFechaEmitida').val();
    const FechaExpiracion = $('#txtFechaExpiracion').val();
    const Comision = $('#txtComision').val();
    const Impuesto = $('#txtImpuesto').val();
    const Correo = $('#txtCorreo').val();


    if (IdMembresia == "") {
        error = true;
        $('#txtIdMembresia').attr("style", "border-color:red");
    } else {
        error = false;
        $('#txtIdMembresia').attr("style", "border-color:none");
    }
    if (CedulaComercio == "") {
        error = true;
        $('#txtCedulaComercio').attr("style", "border-color:red");
    } else {
        error = false;
        $('#txtCedulaComercio').attr("style", "border-color:none");
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
    if (Comision == "") {
        error = true;
        $('#txtComision').attr("style", "border-color:red");
    } else {
        error = false;
        $('#txtComision').attr("style", "border-color:none");
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
    var comercio = new SolicitudesComercio();
    comercio.RetrieveAll();

});
function vaciarCampos() {
    $('#txtIdMembresia').val("");
    $('#txtCedulaComercio').val("");
    $('#txtCostoMembresia').val("");
    $('#txtFechaEmitida').val("");
    $('#txtFechaExpiracion').val("");
    $('#txtComision').val("");
    $('#txtImpuesto').val("");
    $('#txtCorreo').val("");
}

