//const { get } = require("jquery")

window.onload = function () {
    listarTipoHabitacion();
}
var objetoConf;
function listarTipoHabitacion() {
    objetoConf = {
        url: "TipoHabitacion/lista", id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        PropiedadId: "id",
        paginar:true
    }
    pintar(objetoConf)
}

function Buscar() {
    var nombretipohabitacion = get("txtnombretipohabitacion")
    var Descripcion = get("txtDescripcion")
    objetoConf.url =
        "TipoHabitacion/FiltarTipohabitacionPorNombre/?" + "nombrehabitacion=" + nombretipohabitacion + "&DESCRIPCION=" + Descripcion,
    pintar(objetoConf) 
}

function Limpiar() {
   /* setN("id", "")
    setN("nombre", "")
    setN("descripcion", "") */

    LimpiarDatos("frmTipoHabitacion")
    Correcto("Funciono")
}

function GuardarDatos() {
    
    var error = ValidarObligatorios("frmTipoHabitacion")
    if (error != "") {
        Error(error);
        return;
    }
    var error = ValidarLongitudMaxima("frmTipoHabitacion");
    if (error != "") {
        Error(error);
        return;
    }

    var error = ValidarLongitudMinima("frmTipoHabitacion");
    if (error != "") {
        Error(error);
        return;
    }
  /** 
   *  Validacion forma 1
   *  var nombre = getN("nombre")
    var descripcion = getN("descripcion")

    //Validacion
    if (nombre == "") {
        Error("Debe ingresar el nombre");
        return;
    }
    if (descripcion == "") {
        Error("Debe ingresar la descripción");
        return;
    }*/

    Confirmacion("Desea guardar el registro ?", "Confirmar Guardar Datos", function (res) {
        var frmTipoHabitacion = document.getElementById("frmTipoHabitacion");
        var frm = new FormData(frmTipoHabitacion);
        fetchPostText("TipoHabitacion/GuardarDatos", frm, function (res) {
            if (res == "1") {
                listarTipoHabitacion();
                Limpiar();
            }
        })
    })

    

  /*  fetch("TipoHabitacion/GuardarDatos", {
        method: "POST",
        body: frm
    }).then(res => res.text())
        .then(res => {
            if (res == "1") {
                listarTipoHabitacion();
            }          
    }) */

   
}

// Editar
function Editar(id) {

 /*   fetchGet("TipoHabitacion/recuperarTipoHabitacion/?id=" + id, function (res) {
        setN("id", res.id)
        setN("nombre", res.nombre)
        setN("descripcion",res.descripcion)
    }) */

   recuperarGenerico("TipoHabitacion/recuperarTipoHabitacion/?id=" + id, "frmTipoHabitacion");
}

//Eliminar
function Eliminar(id) {
    Confirmacion("Desea eliminar el tipo de habitación ?", "Confirmar eliminación", function (res) {

        fetchGetText("TipoHabitacion/EliminarTipoHabitacion/?id=" + id, function (rpta) {
            if (rpta == "1") {
                Correcto("Se elimino correctamente");
                listarTipoHabitacion();
                Limpiar();
            }
        })
    })
}