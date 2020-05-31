function vTransportistaActivo() {

    this.tblUsuariosId = 'tblTransportistaActivo';
    this.service = 'usuario';
    this.ctrlActions = new ControlActions();
    this.columns = "Cedula,Nombre,PrimerApellido,SegundoApellido,FechaNacimiento,Correo,Contrasena,Telefono,FotoPerfil,Estado,TipoIdentificacion,CodigoVerificacion,IdRol";

    this.RetrieveAll = function () {   

        this.ctrlActions.FillTable(this.service, this.tblUsuariosId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblUsuariosId, true);
    }

    this.Create = function () {
        var usuariosData = {};
        usuariosData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, usuariosData);
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {

        var usuariosData = {};
        usuariosData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, usuariosData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Delete = function () {

        var usuariosData = {};
        usuariosData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, usuariosData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vusuario = new vTransportistaActivo();
    vusuario.RetrieveAll();
});

