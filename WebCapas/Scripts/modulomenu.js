window.onload = function () {
    listarModuloMenu();
}


function listarModuloMenu() {
    pintar({
        popup: true,
        editar: true,
        eliminar: true,
        idpopup: "staticBackdrop1",
        sizepopup: "modal-lg",
        url: "ModuloMenu/listarModuloTipoUsuario",
        id: "divTabla",
        cabeceras: ["ID", "Rol", "Nombre", "Controlador", "Acción"],
        name: "listaModuloMenu",
        propiedades: ["iidmenuMM", "nombrerol", "mensajeMM", "controladorMM", "accionMM"],
        //Para modificar   
        urlEliminar: "ModuloMenu/DeshabilitarModulo",
        parametroEliminar: "iidmenuD",
        urlRecuperar: "ModuloMenu/recuperarModulo",
        // recuperarexcepcion: ["nombreproducto"], //ingrese el name que no se quiere recuperar
        iscallbackeditar: true,
        callbackeditar: function (res) {
            //Cosas Adicionales que queramos hacer 
            // document.getElementById("lblTituloForm").innerHTML = "Producto";
        },
        parametroRecuperar: "iidmenuR",
        propiedadId: "iidmenuMM"
    }, null,
        //{
        //    busqueda: true,
        //    //filtro
        //    url: "Producto/filtrarProductoPorCategoria",
        //    nombreparametro: "iidcategoria",
        //    type: "combobox",
        //    name: "listaCategoria",
        //    displaymember: "nombre",
        //    valuemember: "iidcategoria",
        //    button: true,
        //    id: "cboCategoriaFormulario"
        //    //  placeholder:"Ingrese nombre cama"
        //},
        {
            urlGuardar: "ModuloMenu/guardarModulo",
            type: "popup",
            titulo: "Modulo Menu",
            tituloconfirmacionguardar: "Desea guardar el Modulo?",
            id: "frmModulo",

            //limpiarexepcion:[""],  //["iidproducto"], //Recibimos el array con los que no queramos limpiar
            formulario: [
                [
                    {
                        class: "mb-3 col-md-6",
                        label: "ID",
                        name: "iidmenuMM",
                        value: 0,
                        readonly: true
                    },
                    {
                        class: "col-md-6",
                        type: "combobox",
                        label: "Tipo Usuario",
                        datasource: "listaTipoUsuario",
                        name: "iidtipousuario",
                        id: "cboTipoUsuario",
                        propiedadMostrar: "nombre",
                        propiedadId: "iidtipousuario",
                        classControl: "o"
                    },
                ],
                [
                    {
                        class: "col-md-4",
                        type: "combobox",
                        label: "Nombre",
                        datasource: "listaModulo",
                        name: "mensajeMM",
                        id: "cboNombreModulo",
                        propiedadMostrar: "nombre",
                        propiedadId: "nombre",
                        classControl: "o"
                    },
                    {
                  
                        class: "col-md-4",
                        type: "combobox",
                        label: "Controlador",
                        datasource: "listaModulo",
                        name: "controladorMM",
                        id: "cboComtroladorModulo",
                        propiedadMostrar: "controller",
                        propiedadId: "controller",
                        classControl: "o"
                    },
                    {
                    
                        class: "col-md-4",
                        type: "combobox",
                        label: "Acción",
                        datasource: "listaModulo",
                        name: "accionMM",
                        id: "cboAccionModulo",
                        propiedadMostrar: "accion",
                        propiedadId: "accion",
                        classControl: "o"
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
