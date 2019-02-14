<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Admin1.aspx.vb" Inherits="Tienda.WebForm1" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<title>Tienda UG Administrador</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->
	<link rel="icon" type="image/png" href="Plantilla/images/icons/favicon.ico"/>
<!--===============================================================================================-->
	 <link href="Content/bootstrap.min.css" rel="stylesheet" />   
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Plantilla/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Plantilla/fonts/iconic/css/material-design-iconic-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Plantilla/vendor/animate/animate.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Plantilla/vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Plantilla/vendor/select2/select2.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Plantilla/vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Plantilla/vendor/noui/nouislider.min.css">
<!--===============================================================================================-->
    <link href="Content/bootstrap.css" rel="stylesheet" />
	<link rel="stylesheet" type="text/css" href="Plantilla/css/util.css">
	<link rel="stylesheet" type="text/css" href="Plantilla/css/main.css">
    <link rel="stylesheet" type="text/css" href="Plantilla/css/login.css">
<!--===============================================================================================-->
</head>
<body>
<div class="header">
</div>
<div class="menu">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">   
        <div class="container">
              <a class="navbar-brand" href="Admin1.aspx"><b>TIENDA UG</b></a>
              <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
              </button>
 
            <div class="collapse navbar-collapse" id="navbarSupportedContent">     
                <ul class="navbar-nav mr-auto">    
                    <li class="nav-item">
                            <a class="nav-link" href="Admin1.aspx">Alta</a>
                    </li> 
                    <li class="nav-item">
                            <a class="nav-link" href="Admin2.aspx">Consulta..</a>
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
</div>
<div class="wrapper">
	<div class="container-contact100 wrapper">
		<div class="wrap-contact100">
			<form id="form1" class="contact100-form validate-form" runat="server"> 
				<span class="contact100-form-title">
					Tienda UG
				</span>

				<div class="wrap-input100 validate-input bg1" data-validate="Porfavor ingrese la descripcion del producto">
					<span class="label-input100"> DESCRIPCION DEL PRODUCTO*</span>
                    <asp:TextBox ID="Descripcion" class="input100" type="text"  placeholder="Describa el producto... " runat="server"></asp:TextBox>
				</div>

				<div class="wrap-input100 validate-input bg1 rs1-wrap-input100" data-validate = "Por favor ingrese la cantidad de producto">
					<span class="label-input100">Cantidad *</span>
				    <asp:TextBox ID="Cant" class="input100" type="text"  placeholder="Ingrese la cantidad de producto " runat="server"></asp:TextBox>
                </div>

				<div class="wrap-input100 bg1 validate-input rs1-wrap-input100" data-validate = "Seleccione el color">
					<span class="label-input100">Color *</span>
					    <div>
                            <asp:DropDownList ID="Col"  class="js-select2" runat="server">
                                <asp:ListItem Enabled="true" Text="Seleccione el color del producto" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Azul" Value="Azul"></asp:ListItem>
                                <asp:ListItem Text="Rojo" Value="Rojo"></asp:ListItem>
                                <asp:ListItem Text="Amarillo" Value="Amarillo"></asp:ListItem>
                            </asp:DropDownList>
						    <div class="dropDownSelect2"></div>
					    </div>
				</div>

			     <div class="wrap-input100 validate-input bg1 rs1-wrap-input100" data-validate = "Por favor ingrese el precio del producto">
					    <span class="label-input100">Precio *</span>
				            <asp:TextBox ID="Lacantidad" class="input100" type="text"  placeholder="Ingrese el precio del producto " runat="server"></asp:TextBox>
                </div>

                <div class="wrap-input100 validate-input bg1 rs1-wrap-input100" data-validate = "Por favor ingrese el codigo">
					<span class="label-input100">Codigo *</span>
				   <asp:TextBox ID="Codigo" class="input100" type="text"  placeholder="Ingrese el codigo " runat="server"></asp:TextBox>
               </div>

				<div class="w-full dis-block js-show-service">
					<div class="wrap-contact100-form-radio">
						<span class="label-input100">De que talla es el producto?</span>

						<div class="contact100-form-radio m-t-15">
							<input class="input-radio100" id="radio1" type="radio" name="type-product" value="chica" runat="server">
							<label class="label-radio100" for="radio1">
								Chica
							</label> 
						</div>

						<div class="contact100-form-radio">
							<input class="input-radio100" id="radio2" type="radio" name="type-product" value="mediana" runat="server">
							<label class="label-radio100" for="radio2">
								Mediana
							</label>
						</div>

						<div class="contact100-form-radio">
							<input class="input-radio100" id="radio3" type="radio" name="type-product" value="grande" runat="server">
							<label class="label-radio100" for="radio3">
								Grande
							</label>
						</div>
                        <div class="contact100-form-radio">
							<input class="input-radio100" id="radio4" type="radio" name="type-product" value="extragrande" runat="server">
							<label class="label-radio100" for="radio4">
								Extra-Grande
							</label>
						</div>
					</div>
				</div>


				<div class="wrap-input100 validate-input bg1" data-validate = "Direccion de la imagen">
					<span class="label-input100">Imagen</span>
                    <asp:FileUpload ID="FileUpload1" class="input100" runat="server" />
				</div>

				<div class="container-contact100-form-btn" >
					<button ID="Alta" class="contact100-form-btn" runat="server" >
						<span>
							Alta de producto
							<i class="fa fa-long-arrow-right m-l-7" aria-hidden="true"></i>
						</span>
					</button>
                    <button ID="Button1" class="contact100-form-btn" runat="server" >
						<span>
							Alta de producto
							<i class="fa fa-long-arrow-right m-l-7" aria-hidden="true"></i>
						</span>
					</button>
				</div>
			</form>
		</div>
	</div>
</div>


<!--===============================================================================================-->
	<script src="Scripts/jquery-3.3.1.min.js"></script>
<!--===============================================================================================-->
	<script src="Plantilla/vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.js"></script>
    <script src="Plantilla/vendor/daterangepicker/moment.min.js"></script>
	<script src="Plantilla/vendor/daterangepicker/daterangepicker.js"></script>
    <script src="Scripts/Ejecucion/admin1.js"></script>
<!--===============================================================================================-->
	<script src="Plantilla/vendor/select2/select2.min.js"></script>
	<script>
		$(".js-select2").each(function(){
			$(this).select2({
				minimumResultsForSearch: 20,
				dropdownParent: $(this).next('.dropDownSelect2')
			});
			
		})
	</script>
<!--===============================================================================================-->
	<script src="Plantilla/vendor/countdowntime/countdowntime.js"></script>
    <script src="Plantilla/js/main.js"></script>
<!--===============================================================================================-->
	

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
