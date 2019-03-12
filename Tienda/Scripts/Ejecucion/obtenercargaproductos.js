$(document).ready(function () {
    $('.product_cart').on('click', function () {        
        
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
                $('#myModal').modal({ show: true });
                if (resultado1 === "true") {

                    $('#imgmodal').html('<img src="../Scripts/Plantilla/images/correcto.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                    $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Agregado al carrito</strong>");
                    $('#texmodal').html("<strong style='vertical - align: middle;'> El produto " + Descrip + ", se dio ha modificado, exitosamente </strong>");
                }
                else {
                    $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                    $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error carrito</strong>");
                    $('#texmodal').html("<strong style='vertical - align: middle;'> El producto no se puede agregar al carrito, intente mas tarde. ->" + resultado2 + " </strong>");
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