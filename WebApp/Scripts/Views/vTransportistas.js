function vTransportistas() {

    this.tblTransportistaId = 'tblTransportistaInactivo';
    this.service = 'transporistaInactivo';
    this.ctrlActions = new ControlActions();
    this.columns = "Cedula,Nombre,PrimerApellido,SegundoApellido,FechaNacimiento,Correo,Telefono,FotoPerfil,Estado,TipoIdentificacion,IdRol";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblTransportistaId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblTransportistaId, true);
    }

    this.Create = function () {
        var transportistaData = {};
        usuariosData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, transportistaData);
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {

        var transportistaData = {};
        transportistaData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, transportistaData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Delete = function () {

        var transportistaData = {};
        transportistaData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, transportistaData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vtransportista = new vTransportistas();
    vtransportista.RetrieveAll();
});

