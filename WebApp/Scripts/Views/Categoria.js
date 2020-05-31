function Categoria() {

    this.tblCategoriaId = 'tblCategoria';
    this.service = 'categoria';
    this.ctrlActions = new ControlActions();
    this.columns = "IdCategoria,NombreCategoria";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblCategoriaId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblCategoriaId, true);
    }

    this.Create = function () {
        if (validacion() == true) {
            console.log("error");
        } else {
            var categoriaData = {};
            categoriaData = this.ctrlActions.GetDataForm('collapseRegistro');
            //Hace el post al create
            this.ctrlActions.PostToAPI(this.service, categoriaData);
            vaciarCampos();
        }
    }

    this.Update = function () {

        var categoriaData = {};
        categoriaData = this.ctrlActions.GetDataForm('collapseRegistro');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, categoriaData);
        //Refresca la tabla
        this.ReloadTable();
        vaciarCampos();
    }

    this.Delete = function () {

        var categoriaData = {};
        categoriaData = this.ctrlActions.GetDataForm('collapseRegistro');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, categoriaData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('collapseRegistro', data);
    }

    let validacion = () => {
        let error = false;
        const IdCategoria = $('#txtIdCategoria').val();
        const nombreCategoria = $('#txtNombreCategoria').val();

        if (IdCategoria == "") {
            error = true;
            $('#txtIdCategoria').attr("style", "border-color:red");
        } else {
            error = false;
            $('#txtIdCategoria').attr("style", "border-color:none");
        }
        if (nombreCategoria == "") {
            error = true;
            $('#txtNombreCategoria').attr("style", "border-color:red");
        } else {
            error = false;
            $('#txtNombreCategoria').attr("style", "border-color:none");
        }
        return error;
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vcategoria = new Categoria();               
    vcategoria.RetrieveAll();
});
function vaciarCampos() {
    $('#txtIdCategoria').val("");
    $('#txtNombreCategoria').val("");
}

