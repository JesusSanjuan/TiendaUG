function operacion(valorcarrito, precio_total, precio_envio, numpedido) {

    var Valor = JSON.parse(JSON.stringify(valorcarrito));
    var subtotal = precio_total - precio_envio;
    
    $('#NumeroPedido').text(JSON.parse(JSON.stringify(numpedido)));

    $('#Subtotal').text("$" + subtotal + ".00");
    if (precio_envio === 0) {
        $('#Envio').text("Gratuito");
    } else {
        $('#Envio').text("$" + precio_envio + ".00");
    }
   
    $('#Total').text("$" + precio_total + ".00");
    if (Valor !== 0) {
        $("#contadorcompras").show();
        $('#contadorcompras').text(Valor);
    }
}