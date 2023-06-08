window.onload = function () {
    listarHotel();
}

function listarHotel() {
    pintar({
        popup: true,
        url: "Hotel/listarHotel",
        id: "divTabla",
        cabeceras: ["Id Hotel", "Nombre Hotel", "Dirección", "Foto"],
        propiedades: ["iidhotel", "nombre", "direccion","fotobase64"],
        editar: true,
        sizepopup: "modal-lg",
        eliminar: false,
        urlEliminar: "Cama/eliminarCama",
        parametroEliminar: "iidcama",
        urlRecuperar: "Hotel/recuperarHotel",
        parametroRecuperar: "iidhotel",
        propiedadId: "iidhotel",
        columnaimg: ["fotobase64"],
        nuevo: true
    },
        null
        , {
            type: "popup",
            id: "frmHotel",
            titulo: "Hotel",
            urlGuardar: "Hotel/guardarHotel",
            legend: "Datos del Hotel",
            formulario: [
                [
                    { // label
                        class: "mb-3 col-md-6",
                        label: "Id Hotel",
                        name: "iidhotel",
                        value: 0,

                        readonly: true
                    },
                    { // "Nombre Hotel",

                        class: "mb-3 col-md-6",
                        label: "Nombre Hotel",
                        name: "nombre",
                        classControl: "o max-50 min-3"
                    }

                ],
                [
                    { // Descripción
                        class: "col-md-6",
                        type: "textarea",
                        label: "Descripcion Hotel",
                        name: "descripcion",
                        rows: "5",
                        cols: "20",
                        classControl: "o max-50 min-3"
                    },
                    { // Dirección
                        class: "col-md-6",
                        type: "textarea",
                        label: "Dirección Hotel",
                        name: "direccion",
                        rows: "5",
                        cols: "20",
                        classControl: "o max-70 min-10" 
                    }
                ],
                [
                    {
                     
                        label: "Foto Hotel",
                        type: "file",                    
                        name: "fotodata",
                        preview: true,
                        imgwidth: 200,
                        imgheight: 200,
                        imgClass:"o",
                        namefoto:"fotobase64"
                    }
                   
                ]
            ]
        })
}