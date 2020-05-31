
function Promociones() {
    this.tblPromocionesId = 'tblPromociones';
    this.ctrlActions = new ControlActions();
    this.service = 'Promocion';
    this.columns = "Codigo,Producto,Descuento,Estado";

    this.RetrieveAll = function () {
        var obj = JSON.parse(sessionStorage.getItem('comercio'))
        this.ctrlActions.FillTable(this.service + '/?IdComercio=' + obj.CedulaJuridica, this.tblPromocionesId, false);
    }
    this.ReloadTable = function () {
        var obj = JSON.parse(sessionStorage.getItem('comercio'))
        this.ctrlActions.FillTable(this.service + '/?IdComercio=' + obj.CedulaJuridica, this.tblPromocionesId, true);
    }

    this.Registrar = function () {
        var obj = JSON.parse(sessionStorage.getItem('comercio'));
        var promocion = {};
        promocion = this.ctrlActions.GetDataForm('registro_promocion');
        promocion.IdProducto = $('#selectProducto').children("option:selected").val();
        promocion.Estado = $('#selectEstado').children("option:selected").val();
        promocion.IdComercio = obj.CedulaJuridica;
        console.log(promocion);

        if (validar() == false) {
            this.ctrlActions.PostToAPI(this.service, promocion);
            this.ReloadTable();
        } else {
            console.log("error");
        }

    }
    this.Actualizar = function () {
        var promocion = {};
        promocion = this.ctrlActions.GetDataForm('registro_promocion');
        promocion.IdProducto = $('#selectProducto').children("option:selected").val();
        promocion.Estado = $('#selectEstado').children("option:selected").val();
        if (validar() == false) {
            this.ctrlActions.PutToAPI(this.service, promocion);
            this.ReloadTable();
        } else {
            console.log("error");
        }
    }
    this.Eliminar = function () {
        var promocion = {};
        promocion = this.ctrlActions.GetDataForm('registro_promocion');
        promocion.IdProducto = $('#selectProducto').children("option:selected").val();
        promocion.Estado = $('#selectEstado').children("option:selected").val();
        if (validar() == false) {
            console.log(promocion);
            this.ctrlActions.DeleteToAPI(this.service, promocion);
            this.ReloadTable();
        } else {
            console.log("error");
        }
    }


    let validar = () => {
        let error = false;
        const codigo = $('#inputCodigo').val();
        const descuento = $('#inputDescuento').val();
        if (codigo == "") {
            error = true;
            $('#inputCodigo').addClass('is-invalid');

        } else {
            error = false;
            $('#inputCodigo').addClass("is-valid");
        }
        if (descuento == "") {
            error = true;
            $('#inputDescuento').addClass("is-invalid")

        } else {
            error = false;
            $('#inputDescuento').addClass("is-valid");
        }
        return error;
    }
    this.BindFields = function (data) {
        this.ctrlActions.BindFields('registro_promocion', data);
    }



}
$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var obj = JSON.parse(sessionStorage.getItem('comercio'))
    this.ctrlActions.GetToApi('producto' + '/?CedulaComercio=' + obj.CedulaJuridica, callback = (response) => {
        for (var i = 0; i < response.length; i++) {
            var tmpProducto = response[i];

            $('#selectProducto').append('<option value="' + tmpProducto.IdProducto + '">' + tmpProducto.NombreProducto + '</option>');
        }
    });
    $('#selectEstado').append('<option value="Activo">Activo</option>');
    $('#selectEstado').append('<option value="Inactivo">Inactivo</option>');

    var promociones = new Promociones();
    promociones.RetrieveAll();

});




