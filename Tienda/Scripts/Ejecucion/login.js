
$('#Inicio').on('click', function () {//obtener datos cuando el periodo cambie

    var usuarioLogin = document.getElementById("usert").value;
    var passwordLogin = document.getElementById("password").value;

        $.ajax({
            type: "POST",
            url: "login.aspx/testmethod",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ User: usuarioLogin, Password: passwordLogin}),
            success: function (result) {

                
                var valor = JSON.parse(result.d);  
                var id_user = valor[0];
                var tipo_user = valor[1];
                switch (tipo_user) {
                    case "Administrador":
                        window.location.href = 'Admin1.aspx';
                        break;
                    case "Usuario":
                        window.location.href = 'User.aspx';
                        break;
                    case "SU":
                        document.getElementById('Validacion').innerHTML = 'Nuevo valor';

                        $(document).ready(function () {

                            $('#myModal').modal({ show: true });


                        });
                        break;
                    default:
                       
                    // code block
                }


                var sId = tipo_user;
                writeCookie('sessionId', sId, 1);
            },
            error: function (result) {
                console.log(result.responseText);
            }

        }).done(function (data) {
            console.log(data);
        }).fail(function (data) {
            console.log("Error: " + data);
            });
        

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


