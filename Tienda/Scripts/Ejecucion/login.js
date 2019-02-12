
$('#Inicio').on('click', function () {//obtener datos cuando el periodo cambie

        

        $.ajax({
            type: "POST",
            url: "login.aspx/testmethod",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ Valor: "Hola ke hace"}),
            success: function (result) {
                
                var meses = JSON.parse(result.d); 
                alert(meses);
              //  alert(meses);
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


