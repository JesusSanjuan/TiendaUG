function operacion(valorcarrito, precio_total, precio_envio) {
    var Valor = JSON.parse(JSON.stringify(valorcarrito));
    var subtotal = precio_total - precio_envio;
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