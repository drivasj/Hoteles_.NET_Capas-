window.onload = function () {
    listarMarca();
}

function listarMarca() {
    pintar({
        url: "Marca/listarMarca",
        id:"divTabla",
        cabeceras: ["IIDMARCA", "NOMBREMARCA", "DESCRIPCION"],
        propiedades: ["IIDMARCA", "NOMBREMARCA", "DESCRIPCION"],
        editar: true,
        eliminar: true,
        propiedadId: "IIDMARCA",
        urlEliminar: "Marca/eliminarMarca",
        parametroEliminar: "iidmarca",
        urlRecuperar: "Marca/recuperarMarca",
        parametroRecuperar: "idmarca",
    }, {

        busqueda: true,
        url: "Marca/FiltarMarcaPorNombre",
        nombreparametro: "nombreMarca",
        type: "text",
        button: false,
        id: "txtnombremarca",
      //  placeholder: "Ingrese nombre "

    }, {
        id: "frmMarca",
        type: "fieldset",
        urlGuardar: "Marca/guardarMarca",
        legend: "Datos de la Marca",
        formulario: [
            [
                {
                    class: "mb-3 col-md-5",
                    label: "Id Marca",
                    name: "IIDMARCA",
                    value: 0,
                    readonly: true
                },
                {
                    class: "mb-3 col-md-7",
                    label: "Nombre Marca",
                    name: "NOMBREMARCA"
                }

            ],
            [
                {
                    class: "col-md-12",
                    type: "textarea",
                    label: "Descripcion Marca",
                    name: "DESCRIPCION",
                    rows: "5",
                    cols: "20"

                }
            ],
            [
                {
                    class: "col-md-12",
                    label: "Seleccione una Opciòn",
                    type: "checkbox",
                    labels: ["Excelente Estado", "Buen Estado", "Mal estado"],
                    values: ["1", "2", "3"],
                 //   ids: ["rbExcelente", "rbBuen", "rbMal"],
                    name: "IIDMARCA",
                    checked: "rbBuen"
                }
            ]
        ]

    })
}