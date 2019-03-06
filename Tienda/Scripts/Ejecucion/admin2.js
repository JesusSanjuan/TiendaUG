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
                    var resultado = valor[0];
                    $('#myModal').modal({ show: true });
                    if (resultado == "true") {

                        $('#imgmodal').html('<img src="../Scripts/Plantilla/images/correcto.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                        $('#txtmodatitle').html("<strong style='vertical - align: middle;'> Borrado exitoso</strong>");
                        $('#texmodal').html("<strong style='vertical - align: middle;'> El produto se borro, exitosamente </strong>");
                    }
                    else {
                        $('#imgmodal').html('<img src="../Scripts/plantilla/images/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                        $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Error al borrar</strong>");
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
