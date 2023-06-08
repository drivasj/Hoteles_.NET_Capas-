window.onload = function () {
    listarHabitacion();
    // llenarComboMarca();
}


function listarHabitacion() {
    pintar({
        popup: true,
        editar: true,
        eliminar: true,
        idpopup: "staticBackdrop1",
        sizepopup: "modal-lg",
        url: "Habitacion/listarHabitacionList",
        id: "divTabla",
        cabeceras: ["ID Habitacion", "Nombre Producto ", "Nombre", "Precio Noche", "Numero Personas", "Wifi", "Vista Mar", "Pscina"],
        name: "listaHabitacion",
        propiedades: ["iidhabitacion", "nombre", "precionoche", "numeropersonas", "textotienewifi", "textotienevistaalmar", "textotienepscina"],
        //Para modificar   
        urlEliminar: "Producto/eliminarProducto",
        parametroEliminar: "iidhabitacion",
        urlRecuperar: "Habitacion/recuperarHabitacion",
        // recuperarexcepcion: ["nombreproducto"], //ingrese el name que no se quiere recuperar
        iscallbackeditar: true,
        callbackeditar: function (res) {
            //Cosas Adicionales que queramos hacer 
            // document.getElementById("lblTituloForm").innerHTML = "Producto";
        },
        parametroRecuperar: "idHabitacion",
        propiedadId: "iidhabitacion"
    },
      null, {
        urlGuardar: "Habitacion/guardarHabitacion",
        type: "popup",
        titulo: "Habitacion",
        tituloconfirmacionguardar: "Desea guardar la Habitación ?",
        id: "frmHabitacion",
        //limpiarexepcion:[""],  //["iidproducto"], //Recibimos el array con los que no queramos limpiar
        formulario: [
            [
                { // iidhabitacion
                    class: "mb-3 col-md-6",
                    label: "Id Habitación",
                    name: "iidhabitacion",
                    value: 0,
                    readonly: true
                },
                { // Nombre
                    class: "mb-3 col-md-6",
                    label: "Nombre Habitacion",
                    name: "nombre",
                    classControl: "o max-100 min-3"
                },

                { // Combo Tipo Habitacion
                    class: "col-md-6",
                    type: "combobox",
                    label: "Tipo Habitación",
                    datasource: "listaTipoHabitacion",
                    name: "iidtipohabitacion",
                    id: "cboTipoHabitacion",
                    propiedadMostrar: "nombre",
                    propiedadId: "id",
                    classControl: "o"
                },
                { // Combo Cama
                    class: "col-md-6",
                    type: "combobox",
                    label: "Cama",
                    datasource: "listaCama",
                    name: "iidcama", //HabitacionCLS
                    id: "cboCama",
                    propiedadMostrar: "nombre",
                    propiedadId: "idcama",
                    classControl: "o"
                }
            ],
            [
                { // Combo Hotel
                    class: "col-md-6",
                    type: "combobox",
                    label: "Hotel",
                    datasource: "listaHotel",
                    name: "iidhotel", //HabitacionCLS
                    id: "cboHotel",
                    propiedadMostrar: "nombre",
                    propiedadId: "iidhotel",
                    classControl: "o"
                },
                {
                    type: "text",
                    class: "col-md-6",
                    label: "Descripcion",
                    name: "descripcion",
                    classControl: "o"
                },
            ],
            [
                {
                    type: "number",
                    class: "col-md-4",
                    label: "Numero Personas",
                    name: "numeropersonas",
                    classControl: "o snc"
                },
                {
                    type: "number",
                    class: "col-md-4",
                    label: "Precio Noche",
                    name: "precionoche",
                    classControl: "o sndc"
                },              
            ], [ /////Radio
                { // Vista al mar
                    class: "col-md-4",
                    label: "Seleccione si tiene vista al mar",
                    type: "radio",
                    labels: ["Si", "No"],
                    values: ["1", "0"],
                    ids: ["rbVistaMarSi", "rbVistaMarNo", "rbMal"],
                    name: "tienevistaalmar",
                    // checked: "rbBuen"
                    classControl: "o-1"
                },
                 { // Wifi
                    class: "col-md-4",
                    label: "Seleccione si tiene Wifi",
                    type: "radio",
                    labels: ["Si", "No"],
                    values: ["1", "0"],
                    ids: ["rbWifiSi", "rbWifiNo"],
                     name: "tienewifi",
                    // checked: "rbBuen"
                    classControl: "o-1"
                },
                { // Pscina
                    class: "col-md-4",
                    label: "Seleccione si tiene Pscina",
                    type: "radio",
                    labels: ["Si", "No"],
                    values: ["1", "0"],
                    ids: ["rbPscinaSi", "rbPscinaNo"],
                    name: "tienepscina",
                    // checked: "rbBuen"
                    classControl: "o-1"
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
