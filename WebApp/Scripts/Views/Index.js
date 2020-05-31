function Index() {
    this.RegistroUsuario = function () {
        sessionStorage.setItem('IdRol', 4);
        window.location.href = 'http://localhost:44301/Home/RegistroUsuario';
    }
    this.RegistroTransportista = function () {
        sessionStorage.setItem('IdRol', 2);
        window.location.href = 'http://localhost:44301/Home/RegistroTransportista';
    }
    this.RegistroDuenoComercio = function () {
        sessionStorage.setItem('IdRol', 3);
        window.location.href = 'http://localhost:44301/Home/RegistroDuenoComercio';
    }
    this.RegistroAdmin = function () {
        sessionStorage.setItem('IdRol', 1);
        window.location.href = 'http://localhost:44301/Home/RegistroAdmin';
    } 
}