
$(document).ready(function () {
    $('#Alta').on('click', function () {
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
        
        if (Descrip.length == 0 || Cantida.length == 0 || Color.length == 1 || Precio.length == 0 || Codigo.length == 0 || Talla == "Ninguno")
        {
            $('#myModal').modal({ show: true });
            $('#imgmodal').html('<img src="../Scripts/Plantilla/images/pregunta.png" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
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
                    $('#myModal').modal({ show: true });
                    if (resultado == "true") {

                        $('#imgmodal').html('<img src="../Scripts/Plantilla/images/correcto.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                        $('#txtmodatitle').html("<strong style='vertical - align: middle;'> Alta exitoso</strong>");
                        $('#texmodal').html("<strong style='vertical - align: middle;'> El produto " + Descrip + ", se dio de alta, exitosamente </strong>");
                        $('#Descripcion').val(""); 
                        $('#Cant').val("");
                        $("#Col").val('0');
                        $('#Col').trigger('change');
                        $('#Lacantidad').val("");
                        $('#Codigo').val("");
                        $("#radio1").prop('checked', false); 
                        $("#radio2").prop('checked', false); 
                        $("#radio3").prop('checked', false); 
                        $("#radio4").prop('checked', false); 


                        $('#cerrar').click(function () {
                            location.href = "Admin1.aspx";
                        });
                        $("#myModal").on('hide.bs.modal', function () {
                            location.href = "Admin1.aspx";
                        });

                       
                    }
                    else {
                        $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                        $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error de alta</strong>");
                        $('#texmodal').html("<strong style='vertical - align: middle;'> El producto no se pudo ingresar, intente nuevamente </strong>");
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

    FilePond.registerPlugin(
        FilePondPluginImagePreview
    );

    const inputElement = document.querySelector('input[type="file"]');

    // create a FilePond instance at the input element location
    const pond = FilePond.create(inputElement);

    // attributes have been set to pond options
   /* console.log(pond.name);  // 'filepond'
    console.log(pond.maxFiles); // 10
    console.log(pond.required); // true
    console.log(pond.files);*/
   

    FilePond.setOptions(
        { 
        allowDrop: false,
        allowReplace: false,
        instantUpload: false,
        server: {
            url: 'Admin1.aspx/prueba'
        },
        fileRenameFunction: file => new Promise(resolve => {            
            resolve(window.prompt('Enter new filename', file.name));
        })
        });

}); 





