function Transportistas() {
    this.tblTransportistasId = 'tblTransportistas';
    this.service = 'Usuario';
    this.ctrlActions = new ControlActions();
    this.columns = "Cedula,Nombre,PrimerApellido,SegundoApellido,FechaNacimiento,Correo,Telefono,FotoPerfil,Estado,TipoIdentificacion"

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service + '/?IdRol=' + 2, this.tblTransportistasId, false);
    }
    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service + '/?IdRol=' + 2, this.tblTransportistasId, true);
    }
    this.BindFields = function (data) {
        sessionStorage.setItem('transportista', JSON.stringify(data));
        this.ctrlActions.BindFields('gestion_transportista', data);
    }
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


}
$(document).ready(function () {
    var transportista = new Transportistas();
    transportista.RetrieveAll();

})