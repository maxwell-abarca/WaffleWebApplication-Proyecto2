function vBitacora() {

    this.tblBitacoraId = 'tblBitacora';
    this.service = 'bitacora';
    this.ctrlActions = new ControlActions();
    this.columns = "Usuario,Accion,FechaAccion";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblBitacoraId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblBitacoraId, true);
    }

    this.Create = function () {
        var bitacoraData = {};
        bitacoraData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, bitacoraData);
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {

        var bitacoraData = {};
        bitacoraData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, bitacoraData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Delete = function () {

        var bitacoraData = {};
        bitacoraData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, bitacoraData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vbitacora = new vBitacora();
    vbitacora.RetrieveAll();
});

