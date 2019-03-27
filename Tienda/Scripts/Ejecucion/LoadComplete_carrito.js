function operacion(Vectordeproductos, valorcarrito) {
    alert(Vectordeproductos);
    var Valor = JSON.parse(JSON.stringify(valorcarrito));
    var VectorProductos = JSON.parse(JSON.stringify(Vectordeproductos));
    if (Valor !== 0) {
        $("#contadorcompras").show();
        $('#contadorcompras').text(Valor);
    }   
}