$(document).ready(function () {
    $('.product_cart').on('click', function () {  
        alert("Hola");

        $("#contadorcompras").show();
        var numerocompraanterior = $("#contadorcompras").text();
        var valor = parseInt(numerocompraanterior) + 1;
        $('#contadorcompras').text(valor);
        
        var id_codigo = $(this).data("role");       
        $.ajax({
            type: "POST",
            url: "tiendaug.aspx/compraproducto",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ idCodigo: id_codigo}),
            success: function (result) {
                var valor = JSON.parse(result.d);
                var resultado1 = valor[0];
                var resultado2 = valor[1];
                var Descripcion = valor[2];
                var Color = valor[3];
                var Talla = valor[4];
                var Codigo = valor[5];
                var NuevaCantidadProducto = valor[6];
                

                $('#myModal').modal({ show: true });
                switch (resultado1) {
                    case "true":
                        $('#imgmodal').html('<img src="../Scripts/Plantilla/images/correcto.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                        $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Agregado al carrito</strong>");
                        $('#texmodal').html("<strong style='vertical - align: middle;'> El produto " + Descripcion + " en color: " + Color + ", talla: " + Talla + ", se ha agregado, exitosamente </strong>");
                         break;
                    case "trueRe":
                        $('#imgmodal').html('<img src="../Scripts/Plantilla/images/correcto.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                        $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Agregado al carrito nuevamente</strong>");
                        $('#texmodal').html("<strong style='vertical - align: middle;'> El produto " + Descripcion + " en color: " + Color + ", talla: " + Talla + ", se ha agregado, exitosamente </strong>");
                        break;
                }
                switch (resultado2) {
                    case "error":
                        $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                        $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error carrito</strong>");
                        $('#texmodal').html("<strong style='vertical - align: middle;'> El producto no se puede agregar al carrito, intente mas tarde. ->" + resultado2 + " </strong>");
                        break;
                    case "errorRe":
                        $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                        $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error agregando nuevamente al carrito</strong>");
                        $('#texmodal').html("<strong style='vertical - align: middle;'> El producto no se puede agregar al carrito, intente mas tarde. ->" + resultado2 + " </strong>");
                        break;
                }  
                location.reload();
             /*   var xhr = null;
                xhr =  $.ajax({
                                type: "POST",
                                url: "tiendaug.aspx/reactualizar",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: false,
                                data: JSON.stringify({  }),
                                success: function (result) {   
                                    var MatrizProductos = JSON.parse(result.d);
                                    $("#Productos").empty();
                                    for (var i = 0; i < MatrizProductos.length; i++) {
                                        $("#Productos").append("<div class='col-xl-4 col-md-6 grid-item sale'>" +
                                            "<div class='product'>" +
                                            "<div class='product_image'><img src='Scripts/littlecloset/images/" + MatrizProductos[i][3] + "' alt=''></div>" +
                                            "<div class='product_content'>" +
                                            "   <div class='product_info d-flex flex-row align-items-start justify-content-start'>" +
                                            "  <div>" +
                                            "   <div>" +
                                            " <div class='product_name'><a href='#'>" + MatrizProductos[i][1] + "</a></div>" +
                                            "<div class='product_category'>Color: " + MatrizProductos[i][4] + "</div>" +
                                            "<div class='product_category'>Talla: " + MatrizProductos[i][5] + "</div>" +
                                            "<div class='product_category'>Disponibles: " + MatrizProductos[i][6] + "</div>" +
                                            "<div class='product_category'>En categoria: <a href='#'> Dama </a></div>" +
                                            "  </div>" +
                                            "</div>" +
                                            " <div class='ml-auto text-right'>" +
                                            " <div class='rating_r rating_r_4 home_item_rating'><i></i><i></i><i></i><i></i><i></i></div>" +
                                            " <div class='product_price text-right'>$" + MatrizProductos[i][2] + "<span>.99</span></div>" +
                                            " </div>" +
                                            " </div>" +
                                            " <div class='product_buttons'>" +
                                            " <div class='text-right d-flex flex-row align-items-start justify-content-start'>" +
                                            " <div class='product_button product_fav text-center d-flex flex-column align-items-center justify-content-center'>" +
                                            " <div><div><img src='Scripts/littlecloset/images/heart_2.svg' class='svg' alt=''><div>+</div></div></div>" +
                                            " </div>  " +
                                            "<div class='product_button product_cart text-center d-flex flex-column align-items-center justify-content-center' data-role='" + MatrizProductos[i][0] + "'>" +
                                            "<div><div><img src='Scripts/littlecloset/images/cart.svg' class='svg' alt=''><div>+</div></div></div>" +
                                            "</div>" +
                                            " </div>" +
                                            " </div>" +
                                            " </div>" +
                                            "</div>" +
                                            "</div>");
                                       
                                    }
                                    xhr.abort();
                                    $('.product_cart').on('click', function () {
                                        alert("palabras");
                                    }); 
                                },
                                error: function (result) {
                                    console.log(result.responseText);
                                }
                            }).done(function (data) {
                                console.log(data);
                            }).fail(function (data) {
                                console.log("Error: " + data);
                            });*/
                
                     
            },
            error: function (result) {
                console.log(result.responseText);
            }

        }).done(function (data) {
            console.log(data);
        }).fail(function (data) {
            console.log("Error: " + data);
        });

    });
    
}); 