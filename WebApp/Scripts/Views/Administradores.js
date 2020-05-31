function Administradores() {
    this.tblAdministradoresId = 'tblAdministradores';
    this.service = 'Usuario';
    this.ctrlActions = new ControlActions();
    this.columns = "Cedula,Nombre,PrimerApellido,SegundoApellido,FechaNacimiento,Correo,Telefono,FotoPerfil,Estado,TipoIdentificacion"


    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service + '/?IdRol=' + 1, this.tblAdministradoresId, false);
    }
    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service + '/?IdRol=' + 1, this.tblAdministradoresId, true);
    }
    this.BindFields = function (data) {
        sessionStorage.setItem('administrador', JSON.stringify(data));
        this.ctrlActions.BindFields('gestion_administrador', data);
    }
    this.Actualizar = function () {

        var user = {};
        var obj = JSON.parse(sessionStorage.getItem('administrador'));
        user = this.ctrlActions.GetDataForm('gestion_administrador');
        user.Contrasena = obj.Contrasena;
        user.FotoPerfil = obj.FotoPerfil;
        user.CodigoVerificacion = obj.CodigoVerificacion;

        this.ctrlActions.PutToAPI(this.service, user);
        sessionStorage.removeItem('administrador');
    }
}
$(document).ready(function () {
    var administrador = new Administradores();
    administrador.RetrieveAll();

})