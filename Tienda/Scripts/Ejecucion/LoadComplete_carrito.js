function operacion(Vectordeproductos, valorcarrito) {
    var Valor = JSON.parse(JSON.stringify(valorcarrito));

    if (Valor !== 0) {
        $("#contadorcompras").show();
        $('#contadorcompras').text(Valor);
    }   
}