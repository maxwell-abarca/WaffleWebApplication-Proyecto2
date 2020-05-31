function vPrueba() {
    this.cardId = 'CardProducto';
    this.service = 'producto';
    this.listaproductos;
    this.ctrlActions = new ControlActions();

    function Producto() {
        this.div = document.getElementById('ListaProducto');
            var card = '@Html.CtrlCardProductoModel(viewName: "vProducto", id: "id", imageSource: "https://res.cloudinary.com/drlznypvr/image/upload/v1574233973/memnbjj99af7tyc7hieg.png", nombreProducto: "nombreProducto", nombreComercio: "nombreCormercio", precio: "2000")'
            this.div.innerHTML = card;
    }
    $(document).ready(function () {
        Producto();
    });
}