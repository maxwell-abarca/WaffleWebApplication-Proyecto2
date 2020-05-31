function Card () {
    this.generateCard = function (service, URL, listName, objName, onClick, razorElement) {
        function getObjData(btn) {
            var element = btn.id;
            var list = JSON.parse(sessionStorage.getItem(listName));
            sessionStorage.setItem(objName, JSON.stringify(list[element]));
            onClick();
        }

        var user = JSON.parse(sessionStorage.getItem('usuario'));
        
        function createStringFromTemplate(template, variables) {
            return template.replace(new RegExp("\{([^\{]+)\}", "g"), function (_unused, varName) {
                return variables[varName];
            });
        }

        let retrieve = () => {
            var ctrlActions = new ControlActions();
            var ImageSource;
            var CommerceName;
            var ProductName;
            var Price;

            ctrlActions.GetToApi(service + URL + comercio.CedulaJuridica, callback = (response) => {
                for (var i = 0; i < response.length; i++) {
                    sessionStorage.setItem(listName, JSON.stringify(response));
                    var tmpObj = response[i];

                    ImageSource = tmpObj.Imagen;
                    CommerceName = comercio.NombreComercial;
                    ProductName = tmpObj.NombreProducto;
                    Price = tmpObj.Precio;

                    function GetDynamicProducts() {
                        return createStringFromTemplate(
                            "'" + razorElement + "'",
                            //'@Html.CtrlCardProductoCom(viewName: "listaProductos", id: "{id}", ImageSource: "{ImageSource}", NombreComercio: "{CommerceName}", NombreProducto: "{ProductName}", PrecioProducto: "{Price}")',
                            {
                                ImageSource: ImageSource,
                                CommerceName: CommerceName,
                                ProductName: ProductName,
                                OnClickFunction: 'getObjData(this)',
                                Price: Price,
                                id: i
                            }
                        );
                    }
                    document.getElementById('listaProductos').insertAdjacentHTML("afterend", GetDynamicProducts());
                }
            }, errorFunction = () => {
                console.log('error');
            });
        }
        retrieve();
    };
}
// pasar esto
/*function getProductData(btn) {
    var producto = btn.id;

    var listaProductos = JSON.parse(sessionStorage.getItem('listaProductos'));
    sessionStorage.setItem('producto', JSON.stringify(listaProductos[producto]));

    window.location.href = 'InicioComercio';
}
$(document).ready(function () {
    var user = JSON.parse(sessionStorage.getItem('usuario'));
    var comercio = JSON.parse(sessionStorage.getItem('comercio'));
    function createStringFromTemplate(template, variables) {
        return template.replace(new RegExp("\{([^\{]+)\}", "g"), function (_unused, varName) {
            return variables[varName];
        });
    }

    let retrieveAllProducts = () => {
        var ctrlActions = new ControlActions();
        var ImageSource;
        var CommerceName;
        var ProductName;
        var Price;
        var loop = 0;

        ctrlActions.GetToApi(service + URL + comercio.CedulaJuridica, callback = (response) => {
            for (var i = 0; i < response.length; i++) {
                sessionStorage.setItem('listaProductos', JSON.stringify(response));
                var tmpProduct = response[i];

                ImageSource = tmpProduct.Imagen;
                CommerceName = comercio.NombreComercial;
                ProductName = tmpProduct.NombreProducto;
                Price = tmpProduct.Precio;

                function GetDynamicProducts() {
                    return createStringFromTemplate(
                        '@Html.CtrlCardProductoCom(viewName: "listaProductos", id: "{id}", ImageSource: "{ImageSource}", NombreComercio: "{CommerceName}", NombreProducto: "{ProductName}", PrecioProducto: "{Price}")',
                        {
                            ImageSource: ImageSource,
                            CommerceName: CommerceName,
                            ProductName: ProductName,
                            OnClickFunction: 'getProductData(this)',
                            Price: Price,
                            id: i
                        }
                    );
                }
                document.getElementById('listaProductos').insertAdjacentHTML("afterend", GetDynamicProducts());
            }
        }, errorFunction = () => {
            console.log('error');
        });
    }
    retrieveAllProducts();
});*/