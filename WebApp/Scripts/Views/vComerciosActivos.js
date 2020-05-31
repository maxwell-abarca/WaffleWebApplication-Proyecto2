function vComerciosActivos() {

    this.tblComercioId = 'tblComercios';
    this.service = 'comercio';
    this.ctrlActions = new ControlActions();
    this.columns = "CedulaJuridica,CedulaDueno,IdDireccion,IdCategoria,Regimen,Telefono,Horario,Membresia,DireccionEscrita,NombreComercial,Estado,Supervisor";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblComercioId, true);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblComercioId, true);
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {
    var vcomercio = new vComerciosActivos();
    vcomercio.RetrieveAll();
});