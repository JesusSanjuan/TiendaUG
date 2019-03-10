
$(document).ready(function () {
    $('#botoncerrarsesion').on('click', function () {
        $.ajax({
            type: "POST",
            url: "Admin1.aspx/cerrarsesion",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ Dato1: "Hola" }),
            success: function (result) {
                var valor = JSON.parse(result.d);
                var resultado1 = valor[0];
                var resultado2 = valor[1];
                $('#myModal').modal({ show: true });
                if (resultado1 == "true") {
                    
                    location.href = "index.aspx";
                }
                else {
                    $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                    $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error de cierre</strong>");
                    $('#texmodal').html("<strong style='vertical - align: middle;'> La sesion no se pudo realizar, error ->" + resultado2 + " </strong>");

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
