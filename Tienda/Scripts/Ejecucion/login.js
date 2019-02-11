
    $('#Prueba').on('click', function () {//obtener datos cuando el periodo cambie

        var data = {};
        data.param1 = "Hola";

        $.ajax({
            type: "POST",
            url: "login.aspx/testmethod",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify(data),
            success: function (result) {
                var meses = JSON.parse(result.d); 
                alert(meses);
            },
            error: function (result) {
                console.log(result.responseText);
            }

        }).done(function (data) {
            //console.log(data);
        }).fail(function (data) {
            console.log("Error: " + data);
            });
        

    });
