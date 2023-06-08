window.onload = function () {
    listarTipoUsuario();
}

function listarTipoUsuario() {
    pintar({
        url: "TipoUsuario/listarTipoUsuario",
        id: "divTabla",
        cabeceras: ["ID Rol", "Nombre", "Descripcion"],
        propiedades: ["iidtipousuario", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        urlEliminar: "Cama/eliminarCama",
        parametroEliminar: "iidcama",
        //    urlRecuperar: "Cama/recuperarCama",
        // parametroRecuperar: "idcamita",
        propiedadId: "iidtipousuario",
        nuevo: false,
        callbacknuevo: function () {
            agregarTipoUsuario();
        }
    });
}

function agregarTipoUsuario(id = 0) {
    fetchGet("Pagina/listarPaginas", function (res) {
        pintar({
            id: "divTabla",
            // editar: true,
        }, null, {
            id: "frmTipoUsuario",
            callbackOnload: function () {
                if (id > 0) {
                    //  alert("Editar")
                    recuperarGenericoEspecifico("TipoUsuarioPaginaMenu/recuperarTipoUsuarioMenu/?iidtipousuario=" + id, "frmTipoUsuario")
                }
            },
            type: "fieldset",
            urlGuardar: "TipoUsuarioPaginaMenu/guardarTipoUsuarioMenu",
            legend: "Detalles del Rol",
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
                        label: "ID Rol",
                        name: "iidtipousuario",
                        value: 0,
                        readonly: true
                    },
                    {
                        class: "mb-3 col-md-7",
                        label: "Nombre Rol",
                        name: "nombre",
                        classControl: "o max-50 min-3",
                        readonly: true
                    }

                ],
                [
                    {
                        class: "col-md-12",
                        type: "list",
                        label: "Seleccione las Páginas del Menu",
                        id: "divPintado",

                        name: "idpaginas",
                        cabeceras: ["ID Página", "Nombre"],
                        propiedades: ["iidpagina", "mensaje"],
                        propiedadId: "iidpagina",
                        data: res,

                       //name: "nameP",
                       //cabeceras: ["ID Página", "Nombre", "accion"],
                       //propiedades: ["iidpagina", "mensaje", "accion"],
                       //propiedadId: "iidpagina",
                       //data: res
                    }
                    //{
                    //    class: "col-md-6",
                    //    type: "list",
                    //    label: "Seleccione las Páginas del Menu",
                    //    id: "divPintado",

                    //    name: "nameP",
                    //    cabeceras: ["ID Página", "Nombre", "accion"],
                    //    propiedades: ["iidpagina", "mensaje", "accion"],
                    //    propiedadId: "iidpagina",
                    //    data: res,

                    //    //name: "nameP",
                    //    //cabeceras: ["ID Página", "Nombre", "accion"],
                    //    //propiedades: ["iidpagina", "mensaje", "accion"],
                    //    //propiedadId: "iidpagina",
                    //    //data: res
                    //}
                ]
            ]
        })
    })
}

function Editar(id) {
    // alert(id);
    agregarTipoUsuario(id);
}

