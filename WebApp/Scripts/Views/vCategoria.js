
function vCategoria() {
    this.tblCategoriasId = 'tblCategorias';
    this.service = 'Categoria';
    this.ctrlActions = new ControlActions();
    this.columns = "Id,Nombre";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblCategoriasId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblCategoriasId, true);
    }

    this.Registrar = () => {
        var categoria = {};
        if (Validacion()) {
            console.log("El espacio de nombre no debe estar vacio.");
        } else {
            categoria = this.ctrlActions.GetDataForm('registro_categoria');
            this.ctrlActions.PostToApi(this.service, categoria);
        }
    }

    this.Validacion = () => {
        let error = false;
        //const id = $('#txt_id').val();
        const nombre = $('#txt_nombre').val();

        error = (nombre == "");

        if (error) {
            $('#txt_nombre').attr("style", "border-color:red");
        } else {
            $('#txt_nombre').attr("style", "border-color:none");
        }
        return error;
    }

}
function VaciarCampos() {
    $('#txt_nombre').val("");
}
function Cancelar() {
    window.location.href = 'PanelAdmin';
}
$(document).ready(function () {
    VaciarCampos;
    $('#formulario').hide();
    $('#tblCategoria').show();
})