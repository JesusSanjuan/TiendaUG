function operacion(Vectordeproductos, valorcarrito) {
    var Valor = JSON.parse(JSON.stringify(valorcarrito));  

    if (Valor !== 0) {    
        $("#contadorcompras").show();
        $('#contadorcompras').text(Valor);
    }

    var MatrizProductos = JSON.parse(JSON.stringify(Vectordeproductos));         
    for (var i = 0; i < MatrizProductos.length; i++) { 
                $("#Productos").append("<div class='col-xl-4 col-md-6 grid-item sale'>"+
                    "<div class='product'>"+
                    "<div class='product_image'><img src='Scripts/littlecloset/images/" + MatrizProductos[i][3]+"' alt=''></div>"+
                  "<div class='product_content'>"+
                     "   <div class='product_info d-flex flex-row align-items-start justify-content-start'>"+
                          "  <div>"+
                             "   <div>"+
                               " <div class='product_name'><a href='#'>"+ MatrizProductos[i][1]+"</a></div>"+
                                        "<div class='product_category'>Color: " + MatrizProductos[i][4] + "</div>" +
                                        "<div class='product_category'>Talla: " + MatrizProductos[i][5] + "</div>" +
                                        "<div class='product_category'>Disponibles: " + MatrizProductos[i][6] + "</div>" +
                                        "<div class='product_category'>En categoria: <a href='#'> Dama </a></div>"+
                              "  </div>"+
                            "</div>"+
                           " <div class='ml-auto text-right'>"+
                               " <div class='rating_r rating_r_4 home_item_rating'><i></i><i></i><i></i><i></i><i></i></div>"+
                            " <div class='product_price text-right'>$" + MatrizProductos[i][2]+"<span>.99</span></div>"+
                           " </div>"+
                       " </div>"+
                       " <div class='product_buttons'>"+
                           " <div class='text-right d-flex flex-row align-items-start justify-content-start'>"+
                               " <div class='product_button product_fav text-center d-flex flex-column align-items-center justify-content-center'>"+
                                   " <div><div><img src='Scripts/littlecloset/images/heart_2.svg' class='svg' alt=''><div>+</div></div></div>"+
                                     " </div>  " +
                                            "<div class='product_button product_cart text-center d-flex flex-column align-items-center justify-content-center' data-role='" + MatrizProductos[i][0] +"'>"+
                                                   "<div><div><img src='Scripts/littlecloset/images/cart.svg' class='svg' alt=''><div>+</div></div></div>"+
                                            "</div>" +
                                   " </div>"+
                               " </div>"+
                           " </div>"+
                        "</div>"+
                  "</div>");
        }
}



