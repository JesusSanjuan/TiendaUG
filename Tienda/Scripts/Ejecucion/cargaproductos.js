function operacion(Vectordeproductos) {
   
   
        
       // alert(Vectordeproductos);
       // alert(JSON.stringify(Vectordeproductos));
        var MatrizProductos = JSON.parse(JSON.stringify(Vectordeproductos));         

        for (var i = 0; i < MatrizProductos.length; i++) {
            for (var j = 0; j < MatrizProductos[i].length; j++) {
                var Dato = MatrizProductos [i][j];   
            }           
        }

        $("#Productos").html("<div class='col-xl-4 col-md-6 grid-item sale'>"+
           "<div class='product'>"+
           " <div class='product_image'><img src='Scripts/littlecloset/images/product_3.jpg' alt=''></div>"+
              "  <div class='product_content'>"+
                 "   <div class='product_info d-flex flex-row align-items-start justify-content-start'>"+
                      "  <div>"+
                         "   <div>"+
                               " <div class='product_name'><a href='product.html'>Long Sleeve Jacket</a></div>"+
                             "   <div class='product_category'>In <a href='#'>Category</a></div>"+
                          "  </div>"+
                        "</div>"+
                       " <div class='ml-auto text-right'>"+
                           " <div class='rating_r rating_r_4 home_item_rating'><i></i><i></i><i></i><i></i><i></i></div>"+
                           " <div class='product_price text-right'>$22<span>.99</span></div>"+
                       " </div>"+
                   " </div>"+
                   " <div class='product_buttons'>"+
                       " <div class='text-right d-flex flex-row align-items-start justify-content-start'>"+
                           " <div class='product_button product_fav text-center d-flex flex-column align-items-center justify-content-center'>"+
                               " <div><div><img src='Scripts/littlecloset/images/heart_2.svg' class='svg' alt=''><div>+</div></div></div>"+
                               " </div>"+
                              "  <div class='product_button product_cart text-center d-flex flex-column align-items-center justify-content-center'>"+
                                    "<div><div><img src='Scripts/littlecloset/images/cart.svg' class='svg' alt=''><div>+</div></div></div>"+
                                    "</div>"+
                               " </div>"+
                           " </div>"+
                       " </div>"+
                    "</div>"+
              "  </div>"

    );




    
}

