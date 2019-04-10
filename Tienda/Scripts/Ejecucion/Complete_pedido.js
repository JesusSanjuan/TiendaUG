     $(function () {
        $(document).on('click', 'input[type="button"]', function (event) {
            let name = this.name;
            //console.log("Se presionó el Boton con Id :" + name);
            $('#O1').show();
            $('#O2').show();
            $.ajax({
                type: "POST",
                url: "pedidos.aspx/Consulta_pedido_user",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                data: JSON.stringify({ numpedido: name}),
                success: function (result) {
                    $("#PedidosLista2").html("");
                    var MatrizProductos = JSON.parse(result.d);
                    var j = 1;
                    for (var i = 0; i < MatrizProductos.length; i++) {
                        $("#PedidosLista2").append(
                            " <tr>" +" <th scope='row'>" + j + "</th>" +
                            " <td>" + MatrizProductos[i][0] + "</td>" +
                            " <td>" + MatrizProductos[i][1] + "</td>" +
                            " <td>" + MatrizProductos[i][2] + "</td>" +
                            " <td>" + MatrizProductos[i][3] + "</td>" +
                            " <td>" + MatrizProductos[i][4] + "</td>" +
                            " <td>" + MatrizProductos[i][5] + "</td>" +
                            " <td> <img src='Scripts/littlecloset/images/" + MatrizProductos[i][6] + "' alt='Imagen del producto' width='50' height='50'></td>" +
                            " </tr> ");
                        j++;
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


        });
    });

