function MembreasiaTransportista() {
    this.service = 'Transportista';
    this.ctrlActions = new ControlActions();
}
$(document).ready(function () {

    var transportista = JSON.parse(sessionStorage.tblTransportistas_selected);

    $("#txtNombre")[0].value = transportista.Nombre;
    $("#txtPrimerApellido")[0].value = transportista.PrimerApellido;
    $("#txtSegundoApellido")[0].value = transportista.SegundoApellido;
    $("#txtCedulaUsuario")[0].value = transportista.Cedula;
    $("#txtCorreo")[0].value = transportista.Correo;
    $("#txtTelefono")[0].value = transportista.Telefono;
    $("#dateFechaNacimiento")[0].value = transportista.FechaNacimiento;
    $("#txtTipoVehiculo")[0].value = transportista.TipoVehiculo;
    $("#txtAmigable")[0].value = transportista.TipoVehiculo;
    $("#txtPlaca")[0].value = transportista.Placa;
    $("#txtLatitud")[0].value = transportista.Latititud;
    $("#txtLongitud")[0].value = transportista.Longitud;

});
