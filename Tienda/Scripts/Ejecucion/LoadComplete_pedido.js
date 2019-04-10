function operacion(valorcarrito, matrizPedido) {
    var Valor = JSON.parse(JSON.stringify(valorcarrito));    
    var MatrizProductos = JSON.parse(JSON.stringify(matrizPedido));  
    if (Valor !== 0) {
        $("#contadorcompras").show();
        $('#contadorcompras').text(Valor);
    }   


    var j = 1;
    for (var i = 0; i < MatrizProductos.length; i++) {
        $("#PedidosLista").append(
            " <tr>" +
            " <td><input type='button' id='" + j + "' name='" + MatrizProductos[i][1] +"' value='Selecciona'  class='btn btn-primary'></td>" +
            " <th scope='row'>" + j + "</th>" +
            " <td>" + MatrizProductos[i][0] + "</td>" +
            " <td>" + MatrizProductos[i][1] + "</td>" +
            " <td>" + MatrizProductos[i][2] + "</td>" +
            " <td>" + MatrizProductos[i][3] + "</td>" +
            " <td>" + MatrizProductos[i][4] + "</td>" +
            " <td>" + MatrizProductos[i][5] + "</td>" +
            " </tr> ");
        j++;
    }

}