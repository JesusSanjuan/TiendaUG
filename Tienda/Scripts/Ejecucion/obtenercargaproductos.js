$(document).ready(function () {
    $('.product_cart').on('click', function () {        

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