function Flotillas() {
    this.tblFlotillasId = 'tblFlotillas';
    this.service = 'Flotilla';
    this.ctrlActions = new ControlActions();
    this.Registrar = function () {
        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        var flotilla = {};
        flotilla = this.ctrlActions.GetDataForm('registro_flotilla')
        flotilla.CedulaDueno = obj.Cedula;
        this.ctrlActions.PostToAPI(this.service, flotilla);
        this.ReloadTable();

    }
    this.Eliminar = function () {
        var flotilla = {};
        flotilla = this.ctrlActions.GetDataForm('registro_flotilla');
        this.ctrlActions.DeleteToAPI(this.service, flotilla);
        this.ReloadTable();
    }
    this.Actualizar = function () {
        var flotilla = {};
        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        flotilla = this.ctrlActions.GetDataForm('registro_flotilla');
        flotilla.CedulaDueno = obj.Cedula;
        this.ctrlActions.PutToAPI(this.service, flotilla);
        this.ReloadTable();
    }
    this.RetrieveAll = function () {
        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        this.ctrlActions.FillTable(this.service + '/?CedulaDueno=' + obj.Cedula, this.tblFlotillasId, false);
    }
    this.ReloadTable = function () {
        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        this.ctrlActions.FillTable(this.service + '/?CedulaDueno=' + obj.Cedula, this.tblFlotillasId, true);

    }
    this.BindFields = function (data) {
        this.ctrlActions.BindFields('registro_flotilla', data);
    }

}
$(document).ready(function () {
    var flotillas = new Flotillas();
    flotillas.RetrieveAll();

})



