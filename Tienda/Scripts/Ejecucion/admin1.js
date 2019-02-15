
$(document).ready(function () {


    $('#Alta').on('click', function () {//obtener datos cuando el periodo cambie
    var Descrip = document.getElementById("Descripcion").value;
    var Cantida = document.getElementById("Cant").value;
    var Color = document.getElementById('Col').value;
    var Precio = document.getElementById('Lacantidad').value;
    var Codigo = document.getElementById('Codigo').value;
    var Talla = "";
        
    switch (true) {
        case $("#radio1").is(':checked'):
            Talla = "Chica";
            break;
        case $("#radio2").is(':checked'):
            Talla = "Mediana";
            break;
        case $("#radio3").is(':checked'):
            Talla = "Grande";
            break;
        case $("#radio4").is(':checked'):
            Talla = "Extra-Grande";
            break;
        default:
            Talla = "Ninguno";
        }  
        
        if (Descrip.length == 0 || Cantida.length == 0 || Color.length == 0 || Precio.length == 0 || Codigo.length == 0 || Talla == "Ninguno")
        {
            $('#myModal').modal({ show: true });
            $('#imgmodal').html('<img src="../Scripts/imagenes/pregunta.png" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
            $('#txtmodatitle').html("<strong style='vertical - align: middle;'> Falta informacion</strong>");
            $('#texmodal').html("<strong style='vertical - align: middle;'> Faltan algunos campos por ingresar</strong>");
        }
        else
        {

            $.ajax({
                type: "POST",
                url: "Admin1.aspx/altaproducto",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                data: JSON.stringify({ Cantidad: Cantida, Codig: Codigo, Descrip: Descrip, Precio: Precio, Color: Color, Talla: Talla }),
                success: function (result) {
                    var valor = JSON.parse(result.d);
                    var resultado = valor[0];
                    alert(resultado);
                    $('#myModal').modal({ show: true });
                    if (resultado == "true") {

                        $('#imgmodal').html('<img src="../Scripts/imagenes/correcto.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                        $('#txtmodatitle').html("<strong style='vertical - align: middle;'> Alta exitoso</strong>");
                        $('#texmodal').html("<strong style='vertical - align: middle;'> El produto " + Descrip + ", se dio de alta exitosamente </strong>");
                    }
                    else {
                        $('#imgmodal').html('<img src="../Scripts/imagenes/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                        $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error de alta</strong>");
                        $('#texmodal').html("<strong style='vertical - align: middle;'> El producto no se pudo ingresar, intente mas tarde </strong>");
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
