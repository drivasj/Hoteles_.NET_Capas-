window.onload = function () {
    listarTipoUsuario();
}

function listarTipoUsuario() {
    pintar({
        url: "TipoUsuario/listarTipoUsuario",
        id: "divTabla",
        cabeceras: ["Código Usuario", "Nombre", "Descripcion"],
        propiedades: ["iidtipousuario", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        urlEliminar: "Cama/eliminarCama",
        parametroEliminar: "iidcama",
    //    urlRecuperar: "Cama/recuperarCama",
       // parametroRecuperar: "idcamita",
        propiedadId: "iidtipousuario",
        nuevo: true,
        callbacknuevo: function () {
            agregarTipoUsuario();
        }
    });
}

function agregarTipoUsuario(id=0) {
    fetchGet("Pagina/listarPaginas", function (res){
        pintar({
            id: "divTabla",
           // editar: true,
        }, null, {
            id: "frmTipoUsuario",
            callbackOnload: function () {
                if (id > 0) {
                  //  alert("Editar")
                    recuperarGenericoEspecifico("TipoUsuario/recuperarTipoUsuario/?iidtipousuario=" + id,"frmTipoUsuario")
                }
            },
            type: "fieldset",
            urlGuardar: "TipoUsuario/guardarTipoUsuario",
            legend: "Datos del Tipo Usuario",
            regresar: true,
            callbackregresar: function () {
                listarTipoUsuario()
            },
            callbackGuardarDatos: function () {
                listarTipoUsuario()
            },
            formulario: [
                [
                    {
                        class: "mb-3 col-md-5",
                        label: "Id Tipo Usuario",
                        name: "iidtipousuario",
                        value: 0,

                        readonly: true
                    },
                    {
                        class: "mb-3 col-md-7",
                        label: "Nombre Tipo Usuario",
                        name: "nombre",
                        classControl: "o max-50 min-3"
                    }

                ],
                [
                    {
                        class: "col-md-12",
                        type: "textarea",
                        label: "Descripcion Tipo Usuario",
                        name: "descripcion",
                        rows: "5",
                        cols: "20",
                        classControl: "o max-70 min-10" // Validacion de campo

                    }
                ],
                [
                    {
                        class: "col-md-12",
                        type: "list",
                        label: "Seleccione Paginas",
                        id: "divPintado",

                        name: "idpaginas",
                        cabeceras: ["ID Página", "Nombre"],
                        propiedades: ["iidpagina", "nm_pag"],
                        propiedadId:"iidpagina",
                        data: res
                    }
                ]
            ]
        })
    })  
}

function Editar(id) {
   // alert(id);
    agregarTipoUsuario(id);
}

    