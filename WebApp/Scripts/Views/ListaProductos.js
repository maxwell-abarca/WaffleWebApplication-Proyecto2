function ListaProductos() {
    this.tblProductosId = 'tblProductos';
    this.service = 'producto';
    this.ctrlActions = new ControlActions();
    this.columns = "IdProducto,NombreProducto,IdCategoria,Precio,Imagen,IdComercio,Estado"


    this.RetrieveAll = function () {
        this.ctrlActions.FillTableProducto(this.service, this.tblProductosId, false);
    }
    this.ReloadTable = function () {
        this.ctrlActions.FillTableProducto(this.service, this.tblProductosId, true);
    }
}
$(document).ready(function () {
    var listaProductos = new ListaProductos();
    listaProductos.RetrieveAll();
})