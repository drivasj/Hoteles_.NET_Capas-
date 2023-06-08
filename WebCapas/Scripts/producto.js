window.onload = function () {
    listarProducto();
   // llenarComboMarca();
}

function llenarComboMarca() {
    fetchGet("Marca/listarMarca", function (data) {
        llenarCombo(data, "cboMarca", "nombreMarca", "iidMarca")

    })
}


function listarProducto() {
    pintar({
        popup: true,
        editar: true,
        eliminar: true,
        idpopup: "staticBackdrop1",
        sizepopup: "modal-lg",
        url: "Producto/listarProductoMarca",
        id: "divTabla",
        cabeceras: ["ID Producto", "Nombre Producto ", "Nombre Marca", "Precio Venta", "Stock", "Denominación"],
        name: "listaProducto",
        propiedades: ["iidproducto", "nombreproducto", "nombremarca", "precioventa", "stock", "denominacion"],
        //Para modificar   
        urlEliminar: "Producto/eliminarProducto",
        parametroEliminar: "iidproducto",
        urlRecuperar: "Producto/recuperarProducto",
       // recuperarexcepcion: ["nombreproducto"], //ingrese el name que no se quiere recuperar
        iscallbackeditar: true,
        callbackeditar: function (res) {
            //Cosas Adicionales que queramos hacer 
           // document.getElementById("lblTituloForm").innerHTML = "Producto";
        },
        parametroRecuperar: "iidproducto",
        propiedadId: "iidproducto"
    },
        {
            busqueda: true,
            //filtro
            url: "Producto/filtrarProductoPorCategoria",
            nombreparametro: "iidcategoria",
            type: "combobox",
            name: "listaCategoria",
            displaymember: "nombre",
            valuemember: "iidcategoria",
            button: true,
            id: "cboCategoriaFormulario"
            //  placeholder:"Ingrese nombre cama"
        }, {
            urlGuardar: "Producto/GuardarDatos",
            type: "popup",
            titulo: "Producto",
            tituloconfirmacionguardar:"Desea guardar el producto?",
            id: "frmProducto",
       
            //limpiarexepcion:[""],  //["iidproducto"], //Recibimos el array con los que no queramos limpiar
            formulario: [
                [
                    {
                        class: "mb-3 col-md-6",
                        label: "Id Producto",
                        name: "iidproducto",
                        value: 0,
                        readonly: true
                    },
                    {
                        class: "mb-3 col-md-6",
                        label: "Nombre Producto",
                        name: "nombreproducto",
                        classControl: "o max-100 min-3"
                    },

                    {
                        class: "col-md-6",
                        type: "combobox",
                        label: "Marca",
                        datasource: "listaMarca",
                        name: "iidmarca",
                        id: "cboMarca",
                        propiedadMostrar: "NOMBREMARCA",
                        propiedadId: "IIDMARCA",
                        classControl: "o"
                    },
                    {
                        class: "col-md-6",
                        type: "combobox",
                        label: "Categoria",
                        datasource: "listaCategoria",
                        name: "iidcategoria",
                        id: "cboCategoria",
                        propiedadMostrar: "nombre",
                        propiedadId: "iidcategoria",
                        classControl: "o"
                    }
                ],
                [
                    {
                        class: "col-md-12",
                        type: "textarea",
                        label: "Descripción Producto",
                        name: "descripcion",
                        rows: "5",
                        cols: "20",
                        classControl: "o"
                    }
                ],
                [
                    {
                        type:"number",
                        class: "col-md-4",
                        label: "Precio Venta",
                        name: "precioventa",
                        classControl: "o sndc"
                    },
                    {
                        type: "number",
                        class: "col-md-4",
                        label: "Precio Compra",
                        name: "preciocompra",
                        classControl: "o sndc"
                    },
                    {
                        type: "number",
                        class: "col-md-4",
                        label: "Stock",
                        name: "stock",
                        classControl: "o snc"
                    }
                ]
               
            ]
    }
  )
}



//function Buscar() {
//    var nombreproducto = get("txtnombreproducto")
//    pintar({
//        url: "Producto/FiltarProductoPorNombre/?nombreproducto=" + nombreproducto,
//        id: "divTabla",
//        cabeceras: ["ID Producto", "Nombre Producto ", "Nombre Marca", "Precio Venta", "Stock", "Denominación"],
//        propiedades: ["iidproducto", "nombreproducto", "nombremarca", "precioventa", "stock", "denominacion"]
//    }
//        //,
//        //{
//        //busqueda: true,
//        //url: "Producto/FiltrarProducto",
//        //nombreparametro:"nombre",
//        //type: "text",
//        //id: "txtnombrecama",
//        //placeholder:"Ingrese nombre cama"
//        //}
//    )
//}

function BuscarProductoMarca() {
    var iidmarca = get("cboMarca")
    pintar({
        url: "Producto/filtrarProductoPorMarca/?iidmarca=" + iidmarca,
        id: "divTabla",
        cabeceras: ["Id Producto", "Nombre", "Nombre Marca", "Precio",
            "Stock", "Denominacion"],
        propiedades: ["iidproducto", "nombreproducto", "nombremarca",
            "precioventa", "stock", "denominacion"]
    })
}
