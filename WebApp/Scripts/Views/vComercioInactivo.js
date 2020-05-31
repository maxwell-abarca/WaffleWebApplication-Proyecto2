function vComercioInactivo() {

    this.tblComercioId = 'tblComercioInactivo';
    this.service = 'comercioInactivo';
    this.ctrlActions = new ControlActions();
    this.columns = "CedulaJuridica,CedulaDueno,IdDireccion,IdCategoria,Regimen,Telefono,Horario,Membresia,DireccionEscrita,NombreComercial,Estado,Supervisor";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblComercioInactivoId, true);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblComercioInactivoId, true);
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {
    var vcomercio = new vComercioInactivo();
    vcomercio.RetrieveAll();
});

