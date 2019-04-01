$(document).ready(function () {   
    var totalCompra = 0;
    $('#radio_1').on('click', function () {  
        $('#tipoenvio').text($("#radio_1").val());        
        var total = $("#valorsubtotal").data("subtotal");
        var envio = $("#envio1").data("envio1");
        totalCompra = total + envio;
        $('#TotalFinal').text("$" + totalCompra);
        $('#pasaralacaja').show();
    });
    $('#radio_2').on('click', function () {
        $('#tipoenvio').text($("#radio_2").val());
        var total = $("#valorsubtotal").data("subtotal");
        var envio = $("#envio2").data("envio2");
        totalCompra = total + envio;
        $('#TotalFinal').text("$" + totalCompra);
        $('#pasaralacaja').show();
    });
    $('#radio_3').on('click', function () {
        $('#tipoenvio').text($("#radio_3").val());
        var total = $("#valorsubtotal").data("subtotal");
        var envio = $("#envio3").data("envio3");
        totalCompra = total + envio;
        $('#TotalFinal').text("$" + totalCompra);
        $('#pasaralacaja').show();
    });

    $("#botonBorrar").click(function () {
        $.ajax({
            type: "POST",
            url: "carrito.aspx/borrarCarrito",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ }),
            success: function (result) {
                var valor = JSON.parse(result.d);
                var resultado1 = valor[0];
                var resultado2 = valor[1];
                $('#myModal').modal({ show: true });
                if (resultado1 == "true") {

                    $('#imgmodal').html('<img src="../Scripts/Plantilla/images/correcto.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                    $('#txtmodatitle').html("<strong style='vertical - align: middle;'> Borrado exitoso</strong>");
                    $('#texmodal').html("<strong style='vertical - align: middle;'> Se ha vaciado tu carrito, exitosamente </strong>");

                    $('#cerrar').click(function () {
                        location.href = "carrito.aspx";
                    });
                    $("#myModal").on('hide.bs.modal', function () {
                        location.href = "carrito.aspx";
                    });

                }
                else {                    
                    $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                    $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error al borrar </strong>");
                    $('#texmodal').html("<strong style='vertical - align: middle;'> El producto no se pudo borrar, intente nuevamente, error ->" + resultado2 + " </strong>");
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

    $("#pasaralacaja").click(function () {
        var valor_compra = 0;
        if ($("#radio_1").is(':checked')) {
            valor_compra_envio = 180;
        } 
        if ($("#radio_2").is(':checked')) {
            valor_compra_envio = 105;
        } 
        if ($("#radio_3").is(':checked')) {
            valor_compra_envio = 0;
        } 

        $.ajax({
            type: "POST",
            url: "carrito.aspx/Alta_envio",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ precio_envio: valor_compra_envio, precioTotal : totalCompra  }),
            success: function (result) {
                var valor = JSON.parse(result.d);
                var resultado1 = valor[0];
                var resultado2 = valor[1];
                
                if (resultado1 == "true") {
                    location.href = "pago.aspx";
                }
                else {
                    $('#myModal').modal({ show: true }); 
                    $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                    $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error </strong>");
                    $('#texmodal').html("<strong style='vertical - align: middle;'>Tenemos dificultades para procesar su pedido. Intente nuevamente, error ->" + resultado2 + " </strong>");
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