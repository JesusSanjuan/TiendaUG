function operacion(color, talla, direccion)
{
    $(document).ready(function () {
        $("#Col").val(color);
        $('#Col').trigger('change');
        switch (true) {
            case talla =="Chica":
                    $("#radio1").prop('checked', true);
                break;
            case talla == "Mediana":
                     $("#radio2").prop('checked', true);
                break;
            case talla == "Grande":
                     $("#radio3").prop('checked', true);
                break;
            case talla == "Extra-Grande":
                     $("#radio4").prop('checked', true);
                break;
            default:
        } 
        $("#mi_imagen").attr("src", "Scripts/littlecloset/images/"+ direccion);
    });
 }




