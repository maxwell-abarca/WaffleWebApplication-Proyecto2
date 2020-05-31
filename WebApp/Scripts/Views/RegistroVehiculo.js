function RegistroVehiculo() {
    this.service = 'Vehiculo';
    this.ctrlActions = new ControlActions();
    this.Registrar = function () {

        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        var vehiculo = {};
        var flotilla = {};
        if (validate() == false) {
            vehiculo = this.ctrlActions.GetDataForm('registro_vehiculo');
            vehiculo.CedulaDueno = obj.Cedula;
            vehiculo.TipoVehiculo = $('#selectTipo').children("option:selected").val();
            flotilla.Nombre = $('#inputFlotilla').val();
            flotilla.CedulaDueno = obj.Cedula;
            this.ctrlActions.PostToAPI('Flotilla', flotilla);
            this.ctrlActions.PostToAPI(this.service, vehiculo);
            window.location.href = 'Direcciones';
        } else {
            console.log("error");
        }
    }
    let validate = function () {
        let error = false;
        const placa = $('#inputPlaca').val();
        const marca = $('#inputMarca').val();
        const modelo = $('#inputModelo').val();
        const tipoVehiculo = $('#selectTipo').children("option:selected").val();
        if (placa == "" && tipoVehiculo == 'Automovil') {
            error = true;
            $('#inputPlaca').addClass("is-invalid");
        } else if (placa == "" && tipoVehiculo == 'Bicicleta') {
            error = false;
            $('#inputPlaca').removeClass("is-invalid");
        }
        if (marca == "") {
            error = true;
            $('#inputMarca').addClass("is-invalid");
        } else {
            error = false;
            $('#inputMarca').removeClass("is-invalid");
        }
        if (modelo == "") {
            error = true;
            $('#inputModelo').addClass("is-invalid");
        } else {
            error = false;
            $('#inputModelo').removeClass("is-invalid");
        }
        return error;

        console.log(error);
    }

}
$(document).ready(function () {
    $('#selectTipo').append('<option value="Bicicleta">Bicicleta</option>')
    $('#selectTipo').append('<option value="Automovil">Automovil</option>')
    $('#selectTipo').append('<option value="Motocicleta">Motocicleta</option>')

    $('label[for=inputPlaca]').hide();
    $('#inputPlaca').hide();

    $('#selectTipo').change(function () {
        var select = $('#selectTipo').val();
        if (select == 'Automovil' || select == 'Motocicleta') {
            $('label[for=inputPlaca]').show();
            $('#inputPlaca').show();
        } else if (select == 'Bicicleta') {
            $('#inputPlaca').hide();
            $('label[for=inputPlaca]').hide();
        }

    })




})





