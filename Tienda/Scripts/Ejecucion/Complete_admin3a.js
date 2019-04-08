function operacion(matrizproductos)
{
    $(document).ready(function () {

        var MatrizProductos = JSON.parse(JSON.stringify(matrizproductos));
       
        var j = 1;
        for (var i = 0; i < MatrizProductos.length; i++) {
            alert(MatrizProductos[i][0]);
            $("#Articulosconsulta").append(
               " < tr >" +
                   " <th scope='row'>"+ j +"</th>"+
                   " <td>" + MatrizProductos[i][0] +"</td>"+
                   " <td>" + MatrizProductos[i][1] +"</td>"+
                   " <td>" + MatrizProductos[i][2] +"/td>" +
                   " <th>" + MatrizProductos[i][3] +"</th>" +
                   " <td>" + MatrizProductos[i][4] +"</td>" +
                   " <td>" + MatrizProductos[i][5] +"</td>" +
                   " <td>" + MatrizProductos[i][6] +"</td>" +
                " </tr > ");
            j++;
        }

    });
 }




