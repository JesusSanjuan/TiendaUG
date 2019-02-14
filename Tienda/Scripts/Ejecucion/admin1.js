$(document).ready(function () {


    $('#Button1').on('click', function () {//obtener datos cuando el periodo cambie
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
   

    });

}); 
