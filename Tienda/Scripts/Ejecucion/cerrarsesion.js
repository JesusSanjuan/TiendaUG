
$(document).ready(function () {
    $('#botoncerrarsesion').on('click', function () {
        alert();
        $.ajax({
            type: "POST",
            url: "Admin1.aspx/cerrarsesion",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ Dato1: "Dato"}),
            success: function (result) {
                var resultado1 = valor[0];
                var resultado2 = valor[1];
                $('#myModal').modal({ show: true });
                if (resultado1 == "true") {

                    $('#imgmodal').html('<img src="../Scripts/Plantilla/images/correcto.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                    $('#txtmodatitle').html("<strong style='vertical - align: middle;'> Borrado exitoso</strong>");
                    $('#texmodal').html("<strong style='vertical - align: middle;'> El produto se borro, exitosamente </strong>");

                    $('#cerrar').click(function () {
                        location.href = "index.aspx";
                    });
                    $("#myModal").on('hide.bs.modal', function () {
                        location.href = "index.aspx";
                    });

                }
                else {
                    $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                    $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error al borrar ->" + resultado2 + "</strong>");
                    $('#texmodal').html("<strong style='vertical - align: middle;'> El producto no se pudo borrar, intente nuevamente </strong>");

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
