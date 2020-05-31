var lat, lng;

function Direcciones() {
    this.service = 'DireccionUsuario';
    this.ctrlActions = new ControlActions();

    this.AgregarDireccion = () => {
        var dir = {};
        var obj = JSON.parse(sessionStorage.getItem('usuario'));
        dir.Latitud = lat;
        dir.Longitud = lng;
        dir.IdUsuario = obj.Cedula;
        console.log(dir)
        this.ctrlActions.PostToAPI(this.service, dir);
        switch (obj.IdRol) {
            case 2:
                window.location.href = 'InicioTransportista';
                break;
            case 3:
                window.location.href = 'InicioDuenoComercio';
                break;

        }

    }
}



$(document).ready(function () {
    var map = new GMaps({
        el: '#map',
        zoom: 10,
        lat: 9.932542,
        lng: -84.031055,
        click: GetLocation
    });

    function SetLocation(e) {
        map.addMarker({
            lat: e.latLng.lat(),
            lng: e.latLng.lng(),
            title: "Dirección"
        });
    }

    function GetLocation(e) {
        if (map.markers.length == 1) {
            map.removeMarkers();
            SetLocation(e);
        } else {
            SetLocation(e);
        }
        lat = e.latLng.lat();
        lng = e.latLng.lng();
        console.log(lat, lng);
    }
});