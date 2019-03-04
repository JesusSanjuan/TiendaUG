
$('#Inicio').on('click', function () {//obtener datos cuando el periodo cambie
    var usuarioLogin = document.getElementById("usert").value;
    var passwordLogin = document.getElementById("password").value;
    if (usuarioLogin.length == 0 || passwordLogin.length == 0)
    {
        $(document).ready(function () {
            $('#myModal').modal({ show: true });
            $('#imgmodal').html('<img src="../Scripts/imagenes/pregunta.png" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
            $('#txtmodatitle').html("<strong style='vertical - align: middle;'> Credenciales</strong>");
            $('#texmodal').html("<strong style='vertical - align: middle;'> Ingrese sus credenciales </strong>");
        });
    }
    else
    {
        $.ajax({
            type: "POST",
            url: "index.aspx/testmethod",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ User: usuarioLogin, Password: passwordLogin }),
            success: function (result) {
                var valor = JSON.parse(result.d);
                var id_user = valor[0];
                var tipo_user = valor[1];
                var sId = tipo_user;
                switch (tipo_user) {
                    case "Administrador":
                        window.location.href = 'Admin1.aspx';
                        
                        writeCookie('sessionId', sId, 1);

                        break;
                    case "Usuario":
                        window.location.href = 'category.aspx';
                        break;
                    case "SU":
                        $(document).ready(function () {
                            $('#myModal').modal({ show: true });
                            $('#imgmodal').html('<img src="../Scripts/imagenes/alerta.gif" class="img-fluid" width="100" height="100" alt="Responsive image"/>');
                            $('#txtmodatitle').html("<strong style='vertical - align: middle;'>Verifique sus credenciales</strong>");
                            $('#texmodal').html("<strong style='vertical - align: middle;'> Verifique sus credenciales </strong>");
                        });
                        break;
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


function writeCookie(name, value, days) {
    var date, expires;
    if (days) {
        date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    } else {
        expires = "";
    }
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var i, c, ca, nameEQ = name + "=";
    ca = document.cookie.split(';');
    for (i = 0; i < ca.length; i++) {
        c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1, c.length);
        }
        if (c.indexOf(nameEQ) == 0) {
            return c.substring(nameEQ.length, c.length);
        }
    }
    return '';
}


