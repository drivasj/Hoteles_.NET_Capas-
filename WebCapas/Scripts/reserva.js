window.onload = function () {
    listarHoteles();
}

function listarHoteles() {
    var contenido = "";
    var hotel;
    var obj;
    fetchGet("Hotel/listarHotel", function (rpta) {

        contenido += "<h3 style='color: #4f5b69; ''><em>Hoteles Disponibles</em></h3>"
        contenido += "<hr style='color: #0056b2;' />"
        contenido += "<div class='row'>"
        for (var i = 0; i < rpta.length; i++) {
            obj = rpta[i];
            hotel = ` 
        <div class='col-md-4'>
             <div class="card" style="width: 18rem;">
                <img src="${obj.fotobase64}" class="card-img-top" alt="...">
             <div class="card-body">
                 <h5 class="card-title">${obj.nombre}</h5>
                <a onclick='VerHabitacionHotel(${obj.iidhotel},"${obj.nombre}")' class="btn btn-primary">Ver Habitaciones</a>
                </div>
            </div>
        </div>

            `;



            contenido += hotel;
        }
        contenido += "</div>"
        document.getElementById("divHoteles").innerHTML = contenido;
    })
  

   
}

function VerHabitacionHotel(id,nombre) {
    var contenido = "";
    fetchGet("Habitacion/recuperarHabitacionPorIdHotel/?iidhotel=" + id, function (rpta) {
       contenido += "<h2 class='text-center'> " + nombre +" </h2>"
        contenido += "<button class='btn btn-dark mb-4' onclick='VolverHotel()'>Volver Pantalla Hotel</button>"
        var obj;
        contenido += "<div class='row'>"
        for (var i = 0;  i < rpta.length; i++) {
            obj = rpta[i];
            contenido += `
                     <div class='col-md-3'>
                     <div style="width:240px;height:auto;background-color:green"
                  class="card d-flex justify-content-center align-items-center p-2 m-2">
                             <label style="font-size:18px;font-weight:bold" class='text-white'> Nº ${obj.nombre} </label>
                                <div class='mt-2 mb-2' style='width:100%; height:2px;background-color:white;'></div>
                              <label style="font-size:18px;font-weight:bold" class='text-white'> Precio :
                                  ${obj.precionoche} </label>
                              <label style="font-size:18px;font-weight:bold" class='text-white'> Capacidad :
                                   ${obj.numeropersonas} personas </label>
                             <label style="font-size:18px;font-weight:bold" class='text-white'> Piscina? :
                                 ${obj.textotienepscina} </label>
                             <label style="font-size:18px;font-weight:bold" class='text-white'> Wifi :
                                 ${obj.textotienewifi} </label>
                            <label style="font-size:18px;font-weight:bold" class='text-white'> Vista al mar :
                                 ${obj.textotienevistaalmar} </label>

                    <button class='btn btn-info mt-2' onclick='Reservar(${JSON.stringify(obj)}, ${id},"${nombre}")'>Reservar</button>

                     </div>

                    </div>
                        `;
        }
        contenido += "</div>"
        document.getElementById("divHoteles").innerHTML = contenido;

    })


}

function Reservar(objHabitacion,idhotel,nombrehotel) {
  //  console.log(objHabitacion);

    var contenido = "";
    contenido += "<h2 class='text-center'> Nº "  + objHabitacion.nombre + " </h2>"
    contenido += `<button class='btn btn-dark mb-4' onclick='VerHabitacionHotel(${idhotel},"${nombrehotel}")'>Volver Habitación</button> `
    contenido += "<button class='btn btn-dark mb-4' onclick='VolverHotel()'>Volver Pantalla Hotel</button>"

    contenido += `
  <form id="frmReserva" method="post">
 <fieldset class="container mb-3">

    <legend>Datos de Reserva</legend>
  

        <div class="row">         
            <div class=" mb-3 col-md-4">
                <label>Nombre Hotel</label>
                <input type="text" class="form-control o max-40 min-4" value="${nombrehotel}"
                     readonly />
            </div>

            <div class=" mb-3 col-md-4">
                <label>Nombre Habitación</label>
                <input type="text" class="form-control o max-40 min-4"  value="${objHabitacion.nombre}"
                        readonly />
            </div>

             <div class=" mb-3 col-md-4">
                <label>Nombre Habitación</label>
                <input type="text" class="form-control o max-40 min-4" id="txtprecionoche"  value="${objHabitacion.precionoche}"
                    name="preciohabitacion"    readonly />
            </div>        
        </div>

       <div class="row">
            <div class=" mb-3 col-md-3">
                <label>Piscina</label>
                <input type="text" class="form-control o max-40 min-4" value="${objHabitacion.textotienepscina}"
                       readonly />
            </div>

            <div class=" mb-3 col-md-3">
                <label>Wifi</label>
                <input type="text" class="form-control o max-40 min-4"  value="${objHabitacion.textotienewifi}"
                        readonly />
            </div>

             <div class=" mb-3 col-md-3">
                <label>Vista al mar</label>
                <input type="text" class="form-control o max-40 min-4"  value="${objHabitacion.textotienevistaalmar}"
                        readonly />
            </div>

            <div class=" mb-3 col-md-3">
                <label>Aforo</label>
                <input type="text" class="form-control o max-40 min-4"  value="${objHabitacion.numeropersonas}"
                      readonly />
            </div>
        </div>
<!-------------------------iid--------------------------------->
       <div class="row" style="display:none">
            <div class=" mb-3 col-md-3">
                <label>Id Hotel</label>
                <input type="text" class="form-control o max-40 min-4" value="${idhotel}"
                   name="iidhotel"    readonly />
            </div>

            <div class=" mb-3 col-md-3">
                <label>Id Habitacion</label>
                <input type="text" class="form-control o max-40 min-4" id="iidhabitacionreserva"
                    value="${objHabitacion.iidhabitacion}"
                    name="iidhabitacion"    readonly />
            </div>        
        </div>
  </fieldset>
     <fieldset class="container mb-3">
        <legend>Fecha de Reserva</legend>
        <div class="row">

            <div class=" mb-3 col-md-3">
            <label>Fecha Inicio</label>
                <input type="date" class="form-control" id="txtfechainicio"
                  name="fechainicio" />
             </div>

            <div class=" mb-3 col-md-3">
            <label>Fecha Fin</label>
                <input type="date" class="form-control" id="txtfechafin"
                  name="fechafin" />
             </div>
            <div class=" mb-3 col-md-3 d-flex align-items-center mt-4">
                <button type="button" class="btn btn-primary"
                onclick="Calcular()">Calcular Costo</button>
            </div>
        </div>
         <div class="row">
            <div class=" mb-3 col-md-3">
            <label>Número Dia</label>
               <input type="text" class="form-control o max-40 min-4" id="txtnumerodia"
                 name="cantidadnoches" readonly />
             </div>
         <div class=" mb-3 col-md-3">
            <label>Total</label>
               <input type="text" class="form-control o max-40 min-4" id="txtnumerototal"
                 name="total" readonly />
             </div>
         </div>
   
</fieldset>
    </form>
    <button class="btn btn-primary" onclick="GuardarDatos()">Aceptar</button>
    <button class="btn btn-danger" onclick="Limpiar()">Limpiar</button>

            <div id="calendar">
            
            </div>


                `

    document.getElementById("divHoteles").innerHTML = contenido;
    listarCalendario()
}

function listarCalendario() {
    var iidhabitacion = get("iidhabitacionreserva")
    fetchGet("Reserva/recuperarReservaHabitacion/?iidhabitacion=" + iidhabitacion, function (data) {

        var calendarEl = document.getElementById("calendar");
        var calendar = new FullCalendar.Calendar(calendarEl, {
            initialView: 'dayGridMonth',
            events:data
        })
        calendar.render();
    })
    
}

function GuardarDatos() {
    Confirmacion("Desea guardar el registro ?", "Confirmar Guardar Datos", function (res) {
        var frmReserva = document.getElementById("frmReserva");
        var frm = new FormData(frmReserva);
        fetchPostText("Reserva/guardarReserva", frm, function (res) {
            if (res == "1") {
                Correcto("Se reservo correctamente")
                listarHoteles();
                //  Limpiar();
            }
        })  
    })
}




function VolverHotel() {
    listarHoteles();
}

function Calcular() {
    var numerodias = diasRangoFecha(get("txtfechainicio"), get("txtfechafin")) * 1
    set("txtnumerodia", numerodias)
    var total = get("txtprecionoche") * 1 * numerodias
    //donde lo escribo el resultado
    set("txtnumerototal", total)
}