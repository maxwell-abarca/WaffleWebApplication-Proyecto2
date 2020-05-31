function vProducto() {

    this.tblProductoId = 'tblProducto';
    this.service = 'producto';
    this.Retrive;
    this.ctrlActions = new ControlActions();
    this.columns = "IdProducto,NombreProducto,IdCategoria,Precio,Imagen,IdComercio,Estado";

    this.RetrieveAll = function () {
        var data;
        data = this.columns.Imagen = $('#Imagen').attr('src');
        this.tblProductoId = data;
        this.ctrlActions.FillTable(this.service, this.tblProductoId, false);
        //this.ctrlActions.GetTableColumsDataName(this.tblProductoId);
    }
    this.Retrive = function() {
        this.ctrlActions.listarProductos(this.service);
    }
    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblProductoId, true);
    }

    this.Update = function () {
        var productoData = {};
        productoData.Imagen = $('#Imagen').attr('src');
        console.log(productoData);
        productoData = this.ctrlActions.GetDataForm('frmRegistro');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, productoData);
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Create = function () {
        var productoData = {};
        var data = sessionStorage.getItem('IdComercio');
        productoData.IdComercio = data;
        productoData = this.ctrlActions.GetDataForm('frmRegistro');
        productoData.Estado = "Activo";
        productoData.Imagen = $('#Imagen').attr('src');
        console.log(productoData);
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, productoData);
    }
    var uploadWidget;

    this.showWidget = function () {
        uploadWidget = cloudinary.openUploadWidget({
            cloudName: "drlznypvr",
            uploadPreset: "lonpzlw8",
            sources: [
                "local",
                "url",
                "camera"
            ],
        }, function (error, result) {
            if (!error && result.event == "success") {
                console.log(result);
                document.querySelector('#Imagen').src = result.info.secure_url;
            }
        });
    }

    

    this.Delete = function () {

        var productoData = {};
        productoData = this.ctrlActions.GetDataForm('frmRegistro');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, productoData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmRegistro', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {
    var vproducto = new vProducto();
    vproducto.RetrieveAll();
});

//function mostrar_datos() {
//    var productoData = {};
//    const tabla = document.querySelector('#tbl_poductos tbody');
//    tabla.innerHTML = '';
//    for (let i = 0; i < productoData.length; i++) {
//    let fila = tabla.insertRow();
//    let celda_id_producto = fila.insertCell();
//    let celda_nombre_producto = fila.insertCell();
//    let celda_categoria = fila.insertCell();
//    let celda_precio = fila.insertCell();
//    let celda_foto = fila.insertCell();
//    let celda_comercio = fila.insertCell();
//    let celda_estado = fila.insertCell();


//    celda_id_producto.innerHTML = productoData.IdProducto;
//    celda_nombre_producto.innerHTML = productoData.NombreProducto;
//    celda_categoria.innerHTML = 'Tabla';
//    celda_precio.innerHTML = 'Tabla';
//    let imagen = document.createElement('img');
//        imagen.classList.add('userPhoto');
//    //if (RetrieveAll[i]['Imagen']) {
//    //    imagen.src = RetrieveAll[i]['foto_perfil'];
//    //}
//    //else {
////    //imagen.src = 'https://res.cloudinary.com/drlznypvr/image/upload/w_1000,c_fill,ar_1:1,g_auto,r_max,bo_5px_solid_red,b_rgb:262c35/v1573891804/yfeboapmgqll4limkxez.jpg';

//        imagen.src = 'userPhoto';
//    //}
//    celda_foto.appendChild(imagen);
//    celda_comercio.innerHTML = 'Tabla';
//    celda_estado.innerHTML = 'Tabla';
//};
////function mostrar_datos() {
////    this.div = document.getElementById('tbl_poductos');
////    var card = '@Html.CtrlCardProductoModel(viewName: "Prueba", id: "id", imageSource: "https://res.cloudinary.com/drlznypvr/image/upload/v1574233973/memnbjj99af7tyc7hieg.png", nombreProducto: "Pizza", nombreComercio: "Pizza Hut", precio: "20000")'

////    this.div.innerHTML(card);
////    //var obj = {};
////    //const producto = document.querySelector('#tbl_poductos');
////    //for (let i = 0; i < obj.length; i++) {
////    //    obj[i.IdProducto];
////    //    obj[i.NombreProduto];
////    //    obj[i.IdCategoria];
////    //    obj[i.Precio];
////    //    obj[i.Imagen];
////    //    obj[i.IdComercio];
////    //    obj[i.Estado];
////    //    appendChild(obj);
////    //}
////    //var celda_id_producto;
////    //celda_id_producto = 'Pizza supremita';
////    //var celda_nombre_producto;
////    //celda_nombre_producto = 'Pizza suprema';
////    //'<div class="contenedor_producto">' + '<div class="contenedor_nombre_producto">' +
////    //    '<p>' + celda_id_producto + '</p>' + '</div>' + '<img src="' + celda_nombre_producto + '"alt="Imagen Producto">' +
////    //    '<div class="contenedor_nombre_comercio">' + '<p>' + celda_nombre_producto + '</p>' + '</div>' + '<div class="contenedor_precio">' +
////    //    '<p>' + celda_nombre_producto + '</p>' + '</div>' + '</div>'

//}
//$(document).ready(function () {
//    mostrar_datos();
//});