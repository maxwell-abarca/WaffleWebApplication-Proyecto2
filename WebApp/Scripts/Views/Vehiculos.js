function Vehiculos() {
    this.tblVehiculosId = 'tblVehiculos';
    this.service = 'Vehiculo';
    this.ctrlActions = new ControlActions();

    this.RegistrarVehiculo = function () {
        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        vehiculo = {};
        vehiculo = this.ctrlActions.GetDataForm('registro_vehiculo');
        vehiculo.TipoVehiculo = $('#selectTipo').children("option:selected").val();
        vehiculo.CedulaDueno = obj.Cedula;
        vehiculo.IdFlotilla = $('#selectFlotilla').children("option:selected").val();
        this.ctrlActions.PostToAPI(this.service, vehiculo);
    }
    this.EliminarVehiculo = function () {
        vehiculo = {};
        vehiculo = this.ctrlActions.GetDataForm('registro_vehiculo');
        this.ctrlActions.DeleteToAPI(this.service, vehiculo);
    }
    this.ActualizarVehiculo = function () {
        vehiculo = {};
        vehiculo = this.ctrlActions.GetDataForm('registro_vehiculo');
        vehiculo.TipoVehiculo = $('#selectTipo').children("option:selected").val();
        vehiculo.IdFlotilla = $('#selectFlotilla').children("option:selected").val();
        this.ctrlActions.PutToAPI(this.service, vehiculo);
    }
    this.RetrieveAll = function () {
        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        this.ctrlActions.FillTable(this.service + '/?CedulaDueno=' + obj.Cedula, this.tblVehiculosId, false);
        console.log(obj.Cedula);
    }
    this.ReloadTable = function () {
        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        this.ctrlActions.FillTable(this.service + '/?CedulaDueno=' + obj.Cedula, this.tblVehiculosId, true);
        console.log(obj.Cedula);
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('registro_vehiculo', data);
    }

}
$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var vehiculos = new Vehiculos();
    vehiculos.RetrieveAll();
    var obj = JSON.parse(sessionStorage.getItem('usuario'));

    this.ctrlActions.GetToApi('Flotilla' + '/?CedulaDueno=' + obj.Cedula, callback = (response) => {


        for (var i = 0; i < response.length; i++) {
            var tmpFlotilla = response[i];
            $('#selectFlotilla').append('<option value="' + tmpFlotilla.Id + '">' + tmpFlotilla.Nombre + '</option>')
        }

    });
    $('#selectTipo').append('<option value=Automovil>Automovil</option>');
    $('#selectTipo').append('<option value=Motocicleta>Motocicleta</option>');
    $('#selectTipo').append('<option value=Bicicleta>Bicicleta</option>');

})





/* var flotilla = {};
        var vehiculo = {};

        vehiculo.TipoVehiculo = $('#selectTipo').children(":checked").val();

        console.log(flotilla);*/

/*Si la flotilla existe que no haga nada*/
/*Si la flotilla existe pero el vehículo no entonces que haga un post del vehiculo y que no haga nada con flotillas*//*

this.ctrlActions.GetToApi(this.service + '/?Nombre=' + flotilla.Nombre, callback = (response1) => {
    vehiculo.IdFlotilla = response1.Id;
    this.ctrlActions.PostToAPI('vehiculo', vehiculo);
}, errorFunction = () => {
    this.ctrlActions.PostToAPI(this.serviceFloti);

});*/