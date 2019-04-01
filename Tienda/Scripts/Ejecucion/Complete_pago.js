$(document).ready(function () {
    var totalCompra = 0;
    $('#radio_1P').on('click', function () {       
        $('#Button_Pedido').show();
    });
    $('#radio_2P').on('click', function () {
       
        $('#Button_Pedido').show();
    });
    $('#radio_3P').on('click', function () {
        
        $('#Button_Pedido').show();
    });

    $("#Button_Pedido").click(function () {
       $.ajax({
            type: "POST",
           url: "pago.aspx/Pago_Pedido",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({}),
            success: function (result) {
                var valor = JSON.parse(result.d);
                var resultado1 = valor[0];
                var resultado2 = valor[1];
                $('#myModal').modal({ show: true });
                if (resultado1 == "true") {
                    $('#imgmodal').html('<img src="../Scripts/Plantilla/images/correcto.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                    $('#txtmodatitle').html("<strong style='vertical - align: middle;'> Pago Exitoso</strong>");
                    $('#texmodal').html("<strong style='vertical - align: middle;'> Se ha realizado el pago Exitosamente </strong>");

                    $('#cerrar').click(function () {
                        location.href = "tiendaug.aspx";
                    });
                    $("#myModal").on('hide.bs.modal', function () {
                        location.href = "tiendaug.aspx";
                    });

                }
                else {
                    $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                    $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error en el pago </strong>");
                    $('#texmodal').html("<strong style='vertical - align: middle;'> Intente realizar mas tarde su pago, error ->" + resultado2 + " </strong>");
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