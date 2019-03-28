$(document).ready(function () {   
    $('#radio_1').on('click', function () {  
        $('#tipoenvio').text($("#radio_1").val());

        var id_codigo = $("div").data("subtotal");
        alert(id_codigo.toString());
    });
    $('#radio_2').on('click', function () {
        $('#tipoenvio').text($("#radio_2").val());
    });
    $('#radio_3').on('click', function () {
        $('#tipoenvio').text($("#radio_3").val());
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
                    $('#texmodal').html("<strong style='vertical - align: middle;'> El produto se borro, exitosamente </strong>");

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

}); 