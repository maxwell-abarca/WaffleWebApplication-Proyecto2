function RecuperarContrasena() {
    this.email = document.getElementById('inputCorreo');
    this.errorMessageEmail = document.getElementById('errorMessageEmail');
    this.firstDiv = document.getElementById('firstDiv');
    this.secondDiv = document.getElementById('secondDiv');
    this.codeInput = document.getElementById('inputCodigo');
    this.password = document.getElementById('inputContrasenaNueva');
    this.passwordConfirm = document.getElementById('inputContrasenaConfirmar');
    this.service = 'Usuario';
    this.ctrlActions = new ControlActions();

    this.verifyEmail = (valor) => {
        var expresion = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
        if (expresion.test(valor)) {
            this.email.classList.add("is-valid");
            this.ctrlActions.GetToApi(this.service + '/?Correo=' + valor, callback = (response) => {
                sessionStorage.setItem('usuario', JSON.stringify(response));

                this.firstDiv.style.display = 'none';
                this.secondDiv.style.display = 'block';
            }, errorFunction = () => {
                this.email.classList.add("is-invalid");
                this.errorMessageEmail.style.display = 'block';
            });
        } else {
            this.email.classList.add("is-invalid");
            this.errorMessageEmail.style.display = 'block';
        }
    }

    this.next = () => {
        this.verifyEmail(this.email.value);
    }

    this.ChangePassword = () => {
        var user = JSON.parse(sessionStorage.getItem('usuario'));

        if (this.codeInput.value == user.CodigoVerificacion) {
            this.codeInput.classList.add("is-valid");

            if (this.password.value === this.passwordConfirm.value && this.password.value.length > 7) {
                this.password.classList.add("is-valid");
                this.passwordConfirm.classList.add("is-valid");
                user.Contrasena = this.password.value;

                this.ctrlActions.PutToAPI(this.service, user, error = () => {
                    console.log('ERROR');
                    this.password.classList.add("is-invalid");
                    this.passwordConfirm.classList.add("is-invalid");
                });

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
            }
            else {
                this.password.classList.add("is-invalid");
                this.passwordConfirm.classList.add("is-invalid");
            }
        } else {
            this.codeInput.classList.add("is-invalid");
        }
    }
}