<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="Tienda.WebForm1" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<title>Tienda UG</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	 <link href="Content/bootstrap.min.css" rel="stylesheet" />   
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/noui/nouislider.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
<!--===============================================================================================-->
</head>
<body>


	<div class="container-contact100">
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

				<div class="wrap-input100 bg1 rs1-wrap-input100">
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

                <div class="wrap-input100 bg1 rs1-wrap-input100">
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
					<button ID="Button2" class="contact100-form-btn" runat="server" >
						<span>
							Actualizar
							<i class="fa fa-long-arrow-right m-l-7" aria-hidden="true"></i>
						</span>
					</button>
				    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
				</div>
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
	<script src="vendor/select2/select2.min.js"></script>
	<script>
		$(".js-select2").each(function(){
			$(this).select2({
				minimumResultsForSearch: 20,
				dropdownParent: $(this).next('.dropDownSelect2')
			});
			
		})
	</script>
<!--===============================================================================================-->
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="vendor/noui/nouislider.min.js"></script>
	<script>
	    var filterBar = document.getElementById('filter-bar');

	    noUiSlider.create(filterBar, {
	        start: [ 1500, 7500 ],
	        connect: true,
	        range: {
	            'min': 1500,
	            'max': 7500
	        }
	    });

	    var skipValues = [
	    document.getElementById('value2')
	    ];

	    filterBar.noUiSlider.on('update', function( values, handle ) {
	        skipValues[handle].innerHTML = Math.round(values[handle]);
            $('.contact100-form-range-value input[name="from-value"]').val($('#value2').html());
        
        });        
    });


	</script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>

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
