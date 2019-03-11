function operacion(Vectordeproductos) {
   
    $(document).ready(function () {
       // alert(Vectordeproductos);
       // alert(JSON.stringify(Vectordeproductos));
        var Vector = JSON.parse(JSON.stringify(Vectordeproductos)); 
        var Dato = Vector[2][3];      
        alert(Dato);
    });
}

