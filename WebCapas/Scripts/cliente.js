window.onload = function () {
    listarCliente();
}

function listarCliente() {
    pintar({
        url: "Cliente/listarCliente",
        id:"divTabla",
        cabeceras: ["IIDCLIENTE", "APPATERNO ", "APMATERNO", "EMAIL", "DIRECCION ", "TELEFONO", ],
        propiedades: ["IIDCLIENTE", "APPATERNO", "APMATERNO", "EMAIL", "DIRECCION", "TELEFONOFIJO"]
    })
}