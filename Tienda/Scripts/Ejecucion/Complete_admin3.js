$(document).ready(function () {
          
    $('#envio_pedido').on('click', function () {  
        var numpedido = document.getElementById("idenPrinc").value;
        if (numpedido.length === 0) {
            $('#myModal').modal({ show: true });
            $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
            $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error </strong>");
            $('#texmodal').html("<strong style='vertical - align: middle;'> Seleccione un pedido antes  </strong>");
        }
        else {        
                    $.ajax({
                        type: "POST",
                        url: "Admin3.aspx/Actualizar_Pedido",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        data: JSON.stringify({ numpedido: numpedido}),
                        success: function (result) {
                            var valor = JSON.parse(result.d);
                            var resultado1 = valor[0];
                            var resultado2 = valor[1];
                            $('#myModal').modal({ show: true });
                            if (resultado1 == "true") {

                                $('#imgmodal').html('<img src="../Scripts/Plantilla/images/correcto.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                                $('#txtmodatitle').html("<strong style='vertical - align: middle;'> Cambio de status</strong>");
                                $('#texmodal').html("<strong style='vertical - align: middle;'> El pedido se ha notificado exitosamente como ENVIADO</strong>");

                                $('#cerrar').click(function () {
                                    location.href = "carrito.aspx";
                                });
                                $("#myModal").on('hide.bs.modal', function () {
                                    location.href = "carrito.aspx";
                                });

                            }
                            else {
                                $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                                $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error de status </strong>");
                                $('#texmodal').html("<strong style='vertical - align: middle;'> El pedido no se a podico cambiar de status, intente nuevamente, error ->" + resultado2 + " </strong>");
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
        }
    });
}); 




