var usuario = JSON.parse(sessionStorage.getItem('usuario'));
var usernameLabel = document.getElementById('username');
var userPhoto = document.getElementById('userPhoto');
this.ctrlActions = new ControlActions();

$(document).ready(function () {
    if (usuario === null) {
        window.location.href = 'InicioSesion';
    } else if (usernameLabel != null || userPhoto != null) {
        usernameLabel.innerHTML = usuario.Nombre + ' ' + usuario.PrimerApellido;
        userPhoto.src = usuario.FotoPerfil;
    }
});

function logout() {
    sessionStorage.clear();
    window.location.href = 'Index';
}