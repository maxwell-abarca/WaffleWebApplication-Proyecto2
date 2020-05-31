function Bitacora() {

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
    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var bitacora = new Bitacora();
    bitacora.RetrieveAll();
});

