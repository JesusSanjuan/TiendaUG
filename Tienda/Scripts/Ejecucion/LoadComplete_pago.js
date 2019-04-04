function operacion(valorcarrito, precio_total, precio_envio) {
    var Valor = JSON.parse(JSON.stringify(valorcarrito));
    var subtotal = precio_total - precio_envio;
    $('#Subtotal').text("$" + subtotal);
    if (precio_envio === 0) {
        $('#Envio').text("Gratuito");
    } else {
        $('#Envio').text("$"+precio_envio);
    }
   
    $('#Total').text("$"+precio_total);
    if (Valor !== 0) {
        $("#contadorcompras").show();
        $('#contadorcompras').text(Valor);
    }
}