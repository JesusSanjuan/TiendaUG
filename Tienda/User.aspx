<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="User.aspx.vb" Inherits="Tienda.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Tienda UG Usuario</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->
	<link rel="icon" type="image/png" href="Scripts/imagenes/favicon.ico"/>
<!--===============================================================================================-->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />    
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/fonts/iconic/css/material-design-iconic-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/vendor/animate/animate.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/vendor/select2/select2.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/vendor/noui/nouislider.min.css">
<!--===============================================================================================-->
    <link href="Content/bootstrap.css" rel="stylesheet" />
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/css/util.css">
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/css/main.css">
    <link rel="stylesheet" type="text/css" href="Scripts/Plantilla/css/login.css">
<!--===============================================================================================-->
</head>
<body>

    
<nav class="navbar navbar-expand-lg navbar-dark bg-dark">   
    <div class="container">
          <a class="navbar-brand" href="User.aspx"><b>TIENDA UG</b></a>
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
          </button>
 
        <div class="collapse navbar-collapse" id="navbarSupportedContent">     
            <ul class="navbar-nav mr-auto">       
                 <li class="nav-item">
                        <a class="nav-link" href="User.aspx">INICIO <span class="sr-only">(current)</span></a>
                 </li>       
                <li class="nav-item">
                        <a class="nav-link" href="#">Opcion 1</a>
                </li> 
                <li class="nav-item">
                        <a class="nav-link" href="#">Opcion 2</a>
                </li> 
            </ul> 
            <form class="form-inline my-2 my-lg-0">
                  <input class="form-control mr-sm-2" type="text" placeholder="Buscar ..." aria-label="Buscar ...">
                  <button class="btn btn-outline-primary my-2 my-sm-0" type="submit">BUSCAR</button>
            </form> 
            <a class="btn btn-outline-info d-lg-inline-block mb-3 mb-md-0 ml-md-3" href="login.aspx">CERRAR SESION</a> 
         </div> 
      </div> 
</nav>
    <div class="container-contact100">
		<div class="wrap-contact100">
			<form id="form1" class="contact100-form validate-form" runat="server"> 
				<span class="contact100-form-title">
					Tienda UG					
				</span>
                <div class="wrap-input100 validate-input bg1" data-validate="Porfavor ingrese la descripcion del producto">
					<span class="label-input100"> Consulta de informacion</span>                        
                             <asp:GridView ID="GridView1" CssClass="alt table table-bordered"  runat="server" AutoGenerateColumns="False" DataKeyNames="Id_codigo" DataSourceID="SqlDataSource1" AlternatingRowStyle-CssClass="alt">
<AlternatingRowStyle ></AlternatingRowStyle> 
                                    <Columns>
                                        <asp:CommandField  ButtonType="Image"   ShowSelectButton="True"/>
                                        <asp:BoundField DataField="Id_codigo" HeaderText="Id_codigo" InsertVisible="False" ReadOnly="True" SortExpression="Id_codigo" />
                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                                        <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color" />
                                        <asp:BoundField DataField="Talla" HeaderText="Talla" SortExpression="Talla" />
                                        <asp:BoundField DataField="id_imagen" HeaderText="id_imagen" SortExpression="id_imagen" />
                                    </Columns>
                          </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TiendaUGConnectionString %>" SelectCommand="SELECT * FROM [UG]"></asp:SqlDataSource>
        
                </div>

                <span class="contact100-form-title">
					Informacion cargada
				</span>
			</form>
		</div>
	</div>



<!--===============================================================================================-->
	<script src="Scripts/jquery-3.3.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.js"></script>
<!--===============================================================================================-->
	<script src="Scripts/Plantilla/vendor/select2/select2.min.js"></script>
	<script>
		$(".js-select2").each(function(){
			$(this).select2({
				minimumResultsForSearch: 20,
				dropdownParent: $(this).next('.dropDownSelect2')
			});
			
		})
	</script>
<!--===============================================================================================-->
	<script src="Scripts/Plantilla/vendor/daterangepicker/moment.min.js"></script>
	<script src="Scripts/Plantilla/vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="Scripts/Plantilla/vendor/countdowntime/countdowntime.js"></script>
	<script src="Scripts/Plantilla/js/main.js"></script>

<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-23581568-13"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'UA-23581568-13');
</script>
</body>
</html>