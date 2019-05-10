<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Admin3.aspx.vb" Inherits="Tienda.Admin3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Tienda UG Administrador</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="favicon.ico"/>
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
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/vendor/select2/select2.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/vendor/noui/nouislider.min.css">
<!--===============================================================================================-->
    <link href="Content/bootstrap.css" rel="stylesheet" />
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/css/util.css">
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/cssadmin/main.css">
    <link rel="stylesheet" type="text/css" href="Scripts/Plantilla/cssadmin/login.css">
     <link href="Scripts/Folepond/filepond.css" rel="stylesheet" />
    <link href="https://unpkg.com/filepond-plugin-image-preview/dist/filepond-plugin-image-preview.css" rel="stylesheet">

    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/Ejecucion/Complete_admin3a.js"></script>
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
                    <li class="nav-item">
                            <a class="nav-link" href="Admin3.aspx">Pedidos</a>
                    </li> 
                </ul> 
                <ul class="navbar-nav ml-auto"> 
                     <li class="nav-item">
                        <a class="nav-link btn btn-outline-info d-lg-inline-block mb-3 mb-md-0 ml-md-3" data-toggle="modal" data-target="#cerrarsesion">
                        <i class="fas fa-sign-out-alt"></i>
                            Cerrar Sesion
                        </a>
                    </li>
                </ul> 
            </div> 
        </div> 
    </nav>
</div>
<div class="wrapper">
    <div class="container-contact100">
		<div class="wrap-contact100">
			<form id="form1" class="contact100-form validate-form" runat="server"> 
				<span class="contact100-form-title">
					Tienda UG
				</span>
                <span class="contact100-form-title">
					Consulta y procesamiento de pedido
				</span>
                <div class="wrap-input100 validate-input bg1" >
					<span class="label-input100"> Consulta de informacion</span>                        
                             <asp:GridView ID="GridView1" CssClass="alt table table-bordered"  runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="Numero_Pedido" AlternatingRowStyle-CssClass="alt">
<AlternatingRowStyle ></AlternatingRowStyle> 
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="Estado_Compra" HeaderText="Estado_Compra" SortExpression="Estado_Compra" />
                                        <asp:BoundField DataField="Numero_Pedido" HeaderText="Numero_Pedido" SortExpression="Numero_Pedido" />
                                        <asp:BoundField DataField="Nombre_del_Cliente" HeaderText="Nombre_del_Cliente" SortExpression="Nombre_del_Cliente" />
                                        <asp:BoundField DataField="Fecha_del_Pedido" HeaderText="Fecha_del_Pedido" SortExpression="Fecha_del_Pedido" />
                                        <asp:BoundField DataField="Precio_del_Envio" HeaderText="Precio_del_Envio" SortExpression="Precio_del_Envio" />
                                    </Columns>
                          </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TiendaUGConnectionString %>" SelectCommand="SELECT DISTINCT T1.status_compra AS Estado_Compra, T1.num_pedido AS Numero_Pedido, CONCAT(T2.Nombre,' ', T2.APP,' ', T2.APM)  AS Nombre_del_Cliente, T1.fechapedido AS Fecha_del_Pedido, T1.Precio_envio AS Precio_del_Envio FROM carrito AS T1 INNER JOIN Users AS T2 ON T1.id_usuario = T2.Id_usuario WHERE (T1.status_compra = 'pagado' OR T1.status_compra = 'Enviado')  ORDER BY T1.status_compra DESC">
                    </asp:SqlDataSource>
        
                </div>
                <span class="contact100-form-title">
					Informacion  del pedido seleccionado
				</span>
                
                 <div class="wrap-input100 bg1 rs1-wrap-input100">
					<span class="label-input100">ID Pedido</span>
				   <asp:TextBox ID="idenPrinc" class="input100" type="text" disabled="disabled" style="cursor: none;" runat="server"></asp:TextBox>
               </div>
                <div class="wrap-input100 validate-input bg1 rs1-wrap-input100" >
					<span class="label-input100">Estado de compra </span>
				   <asp:TextBox ID="Estado_compra" class="input100" type="text" disabled="disabled" style="cursor: none;"  runat="server"></asp:TextBox>
               </div>
                <div class="wrap-input100 validate-input bg1" >
					<span class="label-input100"> Nombre del cliente</span>
                    <asp:TextBox ID="Nombre_cliente" class="input100" type="text" disabled="disabled" style="cursor: none;" runat="server"></asp:TextBox>
				</div>
                <div class="wrap-input100 validate-input bg1 rs1-wrap-input100">
					    <span class="label-input100">Fecha del pedido</span>
				            <asp:TextBox ID="Fecha_pedido" class="input100" type="text" disabled="disabled" style="cursor: none;" runat="server"></asp:TextBox>
                </div>
                <div class="wrap-input100 validate-input bg1 rs1-wrap-input100">
					<span class="label-input100">Cantidad de productos</span>
				    <asp:TextBox ID="Cantidad_prod" class="input100" type="text" disabled="disabled" style="cursor: none;"  runat="server"></asp:TextBox>
                </div>

                <div class="wrap-input100 validate-input bg1 rs1-wrap-input100">
					<span class="label-input100">Tipo de envio</span>
				    <asp:TextBox ID="Tipo_envio" class="input100" type="text" disabled="disabled" style="cursor: none;"  runat="server"></asp:TextBox>
                </div>
                <div class="wrap-input100 validate-input bg1 rs1-wrap-input100">
					<span class="label-input100">Precio de envio</span>
				    <asp:TextBox ID="Precio_envio" class="input100" type="text" disabled="disabled" style="cursor: none;"  runat="server"></asp:TextBox>
                </div>
                    <div class="wrap-input100 validate-input bg1" >		
                        <span class="label-input100"> Informacion detallada del pedido</span>                        
                        <div class="table-responsive">       
                             <table class="table table-striped">
                                      <thead>
                                        <tr>
                                            <th scope="col">Numero</th>
                                            <th scope="col">Descripcion</th>
                                            <th scope="col">Precio</th>
                                            <th scope="col">Talla</th>
                                            <th scope="col">Color</th>
                                            <th scope="col">Codigo</th>
                                            <th scope="col">Cantidad compradas</th>
                                            <th scope="col">Imagen</th>
                                        </tr>
                                      </thead>
                                      <tbody id="Articulosconsulta">  
                                      </tbody>
                              </table>  
                        </div>
                  </div>
                        <div class="container-contact100-form-btn" id="BTEnviado" style="display:none;">
					        <button ID="envio_pedido" class="contact100-form-btn"  >
						        <span>
							        Confirmar envio de pedido
							        <i class="fa fa-long-arrow-right m-l-7" aria-hidden="true"></i>
						        </span>
					        </button>
				        </div>
                        <div class="container-contact100-form-btn" id="BTBorrado" style="display:none;" >
					        <button ID="Borrar_pedido" class="contact100-form-btn" runat="server" >
						        <span>
							        Cancelar pedido
							        <i class="fa fa-long-arrow-right m-l-7" aria-hidden="true"></i>
						        </span>
					        </button>
				        </div>
			</form>
		</div>
	</div>
</div>

<div class="modal" id="myModal" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="txtmodatitle"></h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="row">
                <div class="col-3" id="imgmodal"></div>
                <div class="col-9" id="texmodal"></div>                                                                        
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" id="cerrar" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>

<div class="modal fade" id="cerrarsesion" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
    <div class="modal-content">
        <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Te vas tan rapido?</h5>
        <button class="close" type="button" data-dismiss="modal" aria-label="Cancelar">
            <span aria-hidden="true">×</span>
        </button>
        </div>
        <div class="modal-body">Seleccione "Cerrar sesión", está listo para finalizar su sesión actual?</div>
        <div class="modal-footer">
        <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancelar</button>     
        <button class="btn btn-primary" id="botoncerrarsesion" type="button" data-dismiss="modal">Cerrar sesion</button> 
        </div>
    </div>
    </div>
</div>


<!--===============================================================================================-->
	<script src="Scripts/jquery-3.4.1.min.js"></script>
<!--===============================================================================================-->
    <script src="Scripts/bootstrap.min.js"></script>
	<script src="Scripts/Plantilla/vendor/daterangepicker/moment.min.js"></script>
	<script src="Scripts/Plantilla/vendor/daterangepicker/daterangepicker.js"></script>
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
	<script src="Scripts/Plantilla/vendor/countdowntime/countdowntime.js"></script>
	<script src="Scripts/Plantilla/js/main.js"></script>
<!--===============================================================================================-->
    <script src="Scripts/Plantilla/vendor/tilt/tilt.jquery.min.js"></script>
	<script >
		$('.js-tilt').tilt({
			scale: 1.1
		})
	</script>
<!--===============================================================================================-->
    <script src="Scripts/Folepond/filepond-plugin-file-rename.js"></script>
    <script src="https://unpkg.com/filepond-plugin-image-preview/dist/filepond-plugin-image-preview.js"></script>
    <script src="Scripts/Folepond/filepond.js"></script>

    <script src="Scripts/Ejecucion/Complete_admin3.js"></script>
    <script src="Scripts/Ejecucion/cerrarsesion.js"></script>
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
