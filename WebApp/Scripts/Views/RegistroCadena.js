function RegistroCadena() {
    this.tblCadenasId = 'tblCadenas';
    this.service = 'Cadena';
    this.ctrlActions = new ControlActions();
    this.columns = "CedulaDueno,Nombre";

    this.Registrar = () => {
        if (primera_validacion() == true) {
            console.log("error");
        } else {
            var cadena = {};
            cadena = this.ctrlActions.GetDataForm('collapseRegistro');
            cadena.Logo = $('#img_cadena').attr("src");
            var usuario = JSON.parse(sessionStorage.getItem('usuario'));
            cadena.CedulaDueno = usuario.Cedula;
            this.ctrlActions.PostToAPI(this.service, cadena);
            vaciarCampos();
        }

    }

    this.RetrieveAll = function () {
        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        this.ctrlActions.FillTable(this.service + '/?CedulaDueno=' + obj.Cedula, this.tblCadenasId, false);
    }
    this.ReloadTable = function () {
        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        this.ctrlActions.FillTable(this.service + '/?CedulaDueno=' + obj.Cedula, this.tblCadenasId, true);

    }
    this.BindFields = function (data) {
        this.ctrlActions.BindFields('collapseRegistro', data);
    }


    let primera_validacion = () => {
        let error = false;
        const nombre = $('#txt_nombre').val();

        if (nombre == "") {
            error = true;
            /*  $('#txt_nombre').attr("style","border-color:red")*/

        } else {
            error = false;
            /nombre.classList.remove("is-invalid");/

        }
        return error;

    }

    var uploadWidget;

    this.showWidget = function () {
        uploadWidget = cloudinary.openUploadWidget({
            cloudName: "drlznypvr",
            uploadPreset: "lonpzlw8",
            sources: [
                "local",
                "url"
            ],
        }, function (error, result) {
            if (!error && result.event == "success") {
                console.log(result);
                document.querySelector('#img_cadena').src = result.info.secure_url;
            }
        });
    }
}
function vaciarCampos() {
    $('#txt_nombre').val("");
    $('#img_cadena').attr("src", "https://res.cloudinary.com/drlznypvr/image/upload/v1574313744/1900246_v2m8i1.png");
}
$(document).ready(function () {
    var flotillas = new RegistroCadena();
    flotillas.RetrieveAll();

})