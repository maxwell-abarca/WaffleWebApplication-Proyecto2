function InicioSesion() {

    this.email = document.getElementById('inputCorreo');
    this.password = document.getElementById('inputContrasena');
    this.errorMessage = document.getElementById('errorMessage');
    this.service = 'Usuario';
    this.ctrlActions = new ControlActions();

    this.IniciarSesion = function () {
        var data = {};
        data[0] = this.email.value;
        data[1] = this.password.value;

        if (this.email.value === '' || this.password.value === '') {

            if (this.email.value === '' && this.password.value === '') {
                this.email.classList.add("is-invalid");
                this.password.classList.add("is-invalid");
            } else if (this.email.value === '') {
                this.email.classList.add("is-invalid");

            } else if (this.password.value === '') {
                this.password.classList.add("is-invalid");
            }
        } else {
            this.email.classList.remove("is-invalid");
            this.password.classList.remove("is-invalid");
            this.errorMessage.style.display = 'none';
            this.email.classList.add("is-valid");
            this.password.classList.add("is-valid");

            this.ctrlActions.GetToApi(this.service + '/?Correo=' + data[0] + '&Contrasena=' + data[1], callback = (response) => {
                sessionStorage.setItem('usuario', JSON.stringify(response));
                var user = JSON.parse(sessionStorage.getItem('usuario'));

                switch (user.IdRol) {
                    case 1:
                        window.location.href = 'InicioAdmin';
                        break;
                    case 2:
                        window.location.href = 'InicioTransportista';
                        break;
                    case 3:
                        window.location.href = 'InicioDuenoComercio';
                        break;
                    case 4:
                        window.location.href = 'InicioUsuarioFinal';
                        break;
                }

            }, errorFunction = () => {
                this.email.classList.add("is-invalid");
                this.password.classList.add("is-invalid");
                this.errorMessage.style.display = 'block';
            });
        }
    }
}

$(document).keypress(function (e) {
    if (e.which == 13) {
        IniciarSesion();
    }
});

$(document).ready(function () {
    sessionStorage.clear();
});