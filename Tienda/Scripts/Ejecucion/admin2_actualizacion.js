function operacion(color, talla)
{
    $(document).ready(function () {
        $("#Col").val(color);
        $('#Col').trigger('change');

        alert(talla);

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
    });
 }




