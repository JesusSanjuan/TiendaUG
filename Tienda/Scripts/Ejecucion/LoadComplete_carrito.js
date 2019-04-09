function operacion(Vectordeproductos, valorcarrito, numpedido) {
    var Valor = JSON.parse(JSON.stringify(valorcarrito));   
    $('#Num_Pedido').text(numpedido);
    if (Valor !== 0) {
        $("#contadorcompras").show();
        $('#contadorcompras').text(Valor);
    }   
    var subtotal=0;
    var VectorProductos = JSON.parse(JSON.stringify(Vectordeproductos));  
    if (VectorProductos.length == 0) {
        $("#Lista").append(" <br/> <br/> <br/><div class='cart_extra_title' style='display:table-cell;vertical-align:middle;'>Aun no hay productos agregados en el carrito</div> <br/> <br/> <br/>");
        $('#con_pedidos').hide();
        $('#limpiarcompras').hide();

    } else {
        $('#limpiarcompras').show();
        for (var i = 0; i < VectorProductos.length; i++) {
            var totalporproducto = VectorProductos[i][3] * VectorProductos[i][6];
            subtotal = subtotal + VectorProductos[i][3] * VectorProductos[i][6];
            $("#Lista").append("<ul class= 'cart_items_list'>" +
                "<li class='cart_item item_list d-flex flex-lg-row flex-column align-items-lg-center align-items-start justify-content-lg-end justify-content-start'> " +
                "<div class='product d-flex flex-lg-row flex-column align-items-lg-center align-items-start justify-content-start mr-auto'>" +
                "<div><div class='product_number'>1</div></div>" +
                "<div><div class='product_image'><img src='Scripts/littlecloset/images/" + VectorProductos[i][5] + "' alt=''></div></div>" +
                "<div class='product_name_container'>" +
                "<div class='product_name'><a href='#'>" + VectorProductos[i][0] + "</a></div>" +
                "<div class='product_text'>Segunda línea para información adicional</div>" +
                "</div>" +
                "</div>" +
                "<div class='product_color product_text'><span>Color: </span>" + VectorProductos[i][1] + "</div>" +
                "<div class='product_size product_text'><span>Size: </span>" + VectorProductos[i][2] + "</div>" +
                "<div class='product_price product_text'><span>Price: </span>$" + VectorProductos[i][3] + "</div>" +
                "<div class='product_quantity_container'>" +
                "<div class='product_quantity ml-lg-auto mr-lg-auto text-center'>" +
                "<span class='product_text product_num'>" + VectorProductos[i][6] + "</span>" +
                "<div class='qty_sub qty_button trans_200 text-center'><span>-</span></div>" +
                "<div class='qty_add qty_button trans_200 text-center'><span>+</span></div>" +
                "</div>" +
                "</div>" +
                "<div class='product_total product_text' data-role" + i + "='" + totalporproducto + "'><span>Total: </span>$" + totalporproducto + "</div>" +
                "</li>" +
                "</ul>");
        }
    }
    $('#Subtotal').append("<div id='valorsubtotal' data-subtotal='" + subtotal +"'> $" + subtotal+".00</div>");
}