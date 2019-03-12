$(document).ready(function () {

    $('#Borrar').on('click', function () {
        var idproducto = document.getElementById("idenPrinc").value;

        if (idproducto.length == 0)
        {
            $('#myModal').modal({ show: true });
            $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
            $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Seleccione un producto</strong>");
            $('#texmodal').html("<strong style='vertical - align: middle;'> Seleccione en la tabla un producto para poder elminarlo </strong>");
        }
        else
        {
            $.ajax({
                type: "POST",
                url: "Admin2.aspx/eliminarproducto",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                data: JSON.stringify({ idProductos: idproducto }),
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
                            location.href = "Admin2.aspx";
                        });
                        $("#myModal").on('hide.bs.modal', function () {
                            location.href = "Admin2.aspx";
                        });

                    }
                    else {
                        $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                        $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error al borrar </strong>");
                        $('#texmodal').html("<strong style='vertical - align: middle;'> El producto no se pudo borrar, intente nuevamente, error ->" + resultado2 +" </strong>");
                        
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



    $('#Mod').on('click', function () {
        var Identificador = document.getElementById("idenPrinc").value;
        if (Identificador.length == 0) {
            $('#myModal').modal({ show: true });
            $('#imgmodal').html('<img src="../Scripts/Plantilla/images/pregunta.png" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
            $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Seleecion de la tabla</strong>");
            $('#texmodal').html("<strong style='vertical - align: middle;'> Seleccione un articulo de la tabla</strong>");

        }
        else {
                    var Descrip = document.getElementById("Descripcion").value;
                    var Cantida = document.getElementById("Cant").value;
                    var Color = document.getElementById('Col').value;
                    var Precio = document.getElementById('Prec').value;
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

                    if (Descrip.length == 0 || Cantida.length == 0 || Color.length == 1 || Precio.length == 0 || Codigo.length == 0 || Talla == "Ninguno") {
                        $('#myModal').modal({ show: true });
                        $('#imgmodal').html('<img src="../Scripts/Plantilla/images/pregunta.png" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                        $('#txtmodatitle').html("<strong style='vertical - align: middle;'> Falta informacion</strong>");
                        $('#texmodal').html("<strong style='vertical - align: middle;'> Faltan algunos campos por ingresar</strong>");
                    }
                    else {

                        $.ajax({
                            type: "POST",
                            url: "Admin2.aspx/modificar",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            data: JSON.stringify({ Cantidad: Cantida, Codig: Codigo, Descript: Descrip, Precio: Precio, Color: Color, Talla: Talla, idProductos: Identificador}),
                            success: function (result) {
                                var valor = JSON.parse(result.d);
                                var resultado1 = valor[0];
                                var resultado2 = valor[1];
                                $('#myModal').modal({ show: true });
                                if (resultado1 == "true") {

                                    $('#imgmodal').html('<img src="../Scripts/Plantilla/images/correcto.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                                    $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Modificacion exitoso</strong>");
                                    $('#texmodal').html("<strong style='vertical - align: middle;'> El produto " + Descrip + ", se dio ha modificado, exitosamente </strong>");
                                   

                                    $('#cerrar').click(function () {
                                        location.href = "Admin2.aspx";
                                    });
                                    $("#myModal").on('hide.bs.modal', function () {
                                        location.href = "Admin2.aspx";
                                    });
                                }
                                else {
                                    $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                                    $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error al borrar</strong>");
                                    $('#texmodal').html("<strong style='vertical - align: middle;'> El producto no se puede modificar, intente nuevamente. ->" + resultado2 + "</strong>");
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
