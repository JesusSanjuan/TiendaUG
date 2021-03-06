﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pedidos.aspx.vb" Inherits="Tienda.pedidos" %>

<!DOCTYPE html>
<html lang="en">
<head>
<title>Carrito</title>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="description" content="Tienda UG">
<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="favicon.ico"/>
<!--===============================================================================================-->

<link href="Content/bootstrap.min.css" rel="stylesheet" />
<link href="Scripts/littlecloset/plugins/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" type="text/css" href="Scripts/littlecloset/styles/cart.css">
<link rel="stylesheet" type="text/css" href="Scripts/littlecloset/styles/cart_responsive.css">
<link href="Content/bootstrap.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/css/util.css">    
<script src="Scripts/jquery-3.4.1.js"></script>
<script src="Scripts/Ejecucion/LoadComplete_pedido.js"></script>
</head>
<body>
<form id="form2" runat="server">
<!-- Menu -->

<div class="menu">

	<!-- Search -->
	<div class="menu_search">
			<input type="text" class="search_input" placeholder="Buscar Articulo" required="required">
			<button class="menu_search_button"><img src="Scripts/littlecloset/images/search.png" alt=""></button>
	</div>
	<!-- Navigation -->
	<div class="menu_nav">
		<ul>
			<li><a href="#">Dama</a></li>
			<li><a href="#">Caballero</a></li>
			<li><a href="#">Niños</a></li>
			<li><a href="#">Contacto</a></li>
		</ul>
	</div>
	<!-- Contact Info -->
	<div class="menu_contact">
		<div class="menu_phone d-flex flex-row align-items-center justify-content-start">
			<div><div><img src="Scripts/littlecloset/images/phone.svg" alt="https://www.flaticon.com/authors/freepik"></div></div>
			<div>+52 1 951-254-1254</div>
		</div>
		<div class="menu_social">
			<ul class="menu_social_list d-flex flex-row align-items-start justify-content-start">
				<li><a target="_blank" href="http://www.facebook.com"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
				<li><a target="_blank" href="http://www.youtube.com"><i class="fa fa-youtube-play" aria-hidden="true"></i></a></li>
				<li><a target="_blank" href="http://www.google.com"><i class="fa fa-google-plus" aria-hidden="true"></i></a></li>
				<li><a target="_blank" href="http://www.instragram.com"><i class="fa fa-instagram" aria-hidden="true"></i></a></li>
			</ul>
		</div>
	</div>
</div>
<div class="super_container">

	<!-- Header -->

	<header class="header">
		<div class="header_overlay"></div>
		<div class="header_content d-flex flex-row align-items-center justify-content-start">
			<div class="logo">
				<a href="tiendaug.aspx">
					<div class="d-flex flex-row align-items-center justify-content-start">
						<div><img src="Scripts/littlecloset/images/logo_1.png" alt=""></div>
						<div>Tienda UG</div>
					</div>
				</a>	
			</div>
			<div class="hamburger"><i class="fa fa-bars" aria-hidden="true"></i></div>
			<nav class="main_nav">
				<ul class="d-flex flex-row align-items-start justify-content-start">
					<li><a href="#">Dama</a></li>
			        <li><a href="#">Caballero</a></li>
			        <li><a href="#">Niños</a></li>
			        <li><a href="#">Contacto</a></li>
				</ul>
			</nav>
			<div class="header_right d-flex flex-row align-items-center justify-content-start ml-auto">
				<!-- Search -->
				<div class="header_search">
						<input type="text" class="search_input" placeholder="Buscar Articulo" required="required">
						<button class="header_search_button"><img src="Scripts/littlecloset/images/search.png" alt=""></button>
				</div>
				<!-- User -->
				<div class="cart"><a href="usuario.aspx"><div><img src="Scripts/littlecloset/images/user.svg" alt="https://www.flaticon.com/authors/freepik"></div></a></div>
				<!-- Cart -->
				<div class="user"><a href="carrito.aspx"><div><img class="svg" src="Scripts/littlecloset/images/cart.svg" alt="https://www.flaticon.com/authors/freepik"><div id="contadorcompras" style="display:none;">0</div></div></a></div>
                <!-- Cart -->
                <div class="cart"><a href="pedidos.aspx"><div><img src="Scripts/littlecloset/images/shipping-fast-solid.svg" alt="https://www.flaticon.com/authors/freepik"></div></a></div>
				<!-- Cart -->
				<div class="user"><a data-toggle="modal" data-target="#cerrarsesion"><div><img  class="svg" src="Scripts/littlecloset/images/logout.svg" alt="https://www.flaticon.com/authors/freepik"></div></a></div>
				<!-- Phone 
				<div class="header_phone d-flex flex-row align-items-center justify-content-start">
					<div><div><img src="Scripts/littlecloset/images/phone.svg" alt="https://www.flaticon.com/authors/freepik"></div></div>
					<div>+52 1 951-254-1254</div>
				</div>-->
			</div>
		</div>
	</header>

	<div class="super_container_inner">
		<div class="super_overlay"></div>

		<!-- Home -->

		<div class="home">
			<div class="home_container d-flex flex-column align-items-center justify-content-end">
				<div class="home_content text-center">
					<div class="home_title">Tu Carrito de Compras</div>
					<div class="breadcrumbs d-flex flex-column align-items-center justify-content-center">
						<ul class="d-flex flex-row align-items-start justify-content-start text-center">
							<li><a href="tiendaug.aspx">Inicio</a></li>
							<li>Tu Carrito</li>
						</ul>
					</div>
				</div>
			</div>
		</div>

		<!-- Cart -->

		<div class="cart_section">
			<div class="container">
				<div class="row">
					<div class="col">
                             <div class="row" style="padding-bottom:0px">   
                                  <div class="col-sm-6 cart_extra_title">Historial de pedidos </div>
                                  <div class="col-sm-2"></div>
                                  <div class="col-sm-2"> </div> 
                                  <div class="col-sm-2"></div>                              
                             </div>
                             <div class="row" style="padding-bottom:15px">   
                                  <div class="col-sm-6 footer_about_text"><p>Selecciones un pedido para ver sus detalles</></div>
                                  <div class="col-sm-2"></div>
                                  <div class="col-sm-2"> </div> 
                                  <div class="col-sm-2"></div>                              
                             </div>    
                             <div class="row" style="padding-bottom:25px">
                                 <div class="table-responsive">       
                                     <table class="table table-striped">
                                              <thead>
                                                <tr>
                                                    <th scope="col">Seleccion</th>
                                                    <th scope="col">Numero</th>
                                                    <th scope="col">Estado_Compra</th>
                                                    <th scope="col">Numero Pedido</th>
                                                    <th scope="col">Fecha del pedido</th>
                                                    <th scope="col">Tipo de envio</th>
                                                    <th scope="col">Precio del envio</th>
                                                    <th scope="col">Cantidad de productos</th>
                                                </tr>
                                              </thead>
                                              <tbody id="PedidosLista">  
                                              </tbody>
                                      </table>  
                                </div>
                             </div>
                            <div class="row" style="padding-bottom:20px; display:none;" id="O1" >   
                                  <div class="col-sm-6 cart_extra_title">Detalles del pedido</div>
                                  <div class="col-sm-2"></div>
                                  <div class="col-sm-2"> </div> 
                                  <div class="col-sm-2"></div>                              
                            </div>
                            <div class="row" style="padding-bottom:30px; display:none;" id="O2">
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
                                              <tbody id="PedidosLista2">  
                                              </tbody>
                                      </table>  
                                </div>
                             </div>
					</div>
				</div>              
			</div>
		</div>

		<!-- Footer -->

		<footer class="footer">
			<div class="footer_content">
				<div class="container">
					<div class="row">
						
						<!-- About -->
						<div class="col-lg-4 footer_col">
							<div class="footer_about">
								<div class="footer_logo">
									<a href="#">
										<div class="d-flex flex-row align-items-center justify-content-start">
											<div class="footer_logo_icon"><img src="Scripts/littlecloset/images/logo_2.png" alt=""></div>
											<div>Tienda UG</div>
										</div>
									</a>		
								</div>
								<div class="footer_about_text">
									<p>Aplicacion desarrollada para la unidad de aprendizaje, Tecnologias .NET.</>
								</div>
							</div>
						</div>

						<!-- Footer Links -->
						<div class="col-lg-4 footer_col">
							<div class="footer_menu">
								<div class="footer_title">Soporte</div>
								<ul class="footer_list">
									<li>
										<a href="#"><div>Servicio al Cliente<div class="footer_tag_1">En linea ahora</div></div></a>
									</li>
									<li>
										<a href="#"><div>Politica de Devolucion</div></a>
									</li>
									<li>
										<a href="#"><div>Guia de Tallas<div class="footer_tag_2">Recomendado</div></div></a>
									</li>
									<li>
										<a href="#"><div>Terminos y Condiciones</div></a>
									</li>
									<li>
										<a href="#"><div>Contacto</div></a>
									</li>
								</ul>
							</div>
						</div>
						<!-- Footer Contact -->
						<div class="col-lg-4 footer_col">
							<div class="footer_contact">
								<div class="footer_title">Mantente en Contacto</div>
								<div class="newsletter">
										<input type="email" class="newsletter_input" placeholder="Suscríbete a nuestro boletín" required="required">
										<button class="newsletter_button">+</button>
								</div>
								<div class="footer_social">
									<div class="footer_title">Social</div>
									<ul class="footer_social_list d-flex flex-row align-items-start justify-content-start">
										<li><a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
										<li><a href="#"><i class="fa fa-youtube-play" aria-hidden="true"></i></a></li>
										<li><a href="#"><i class="fa fa-google-plus" aria-hidden="true"></i></a></li>
										<li><a href="#"><i class="fa fa-instagram" aria-hidden="true"></i></a></li>
									</ul>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="footer_bar">
				<div class="container">
					<div class="row">
						<div class="col">
							<div class="footer_bar_content d-flex flex-md-row flex-column align-items-center justify-content-start">
								<div class="copyright order-md-1 order-2"><!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
Copyright &copy;<script>document.write(new Date().getFullYear());</script> Todos los derechos reservados | Este diseño fue desarrollado <i class="fa fa-heart-o" aria-hidden="true"></i> por <a href="https://colorlib.com" target="_blank">Colorlib</a>
<!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. --></div>
								<nav class="footer_nav ml-md-auto order-md-2 order-1">
									<ul class="d-flex flex-row align-items-center justify-content-start">
										<li><a href="#">Dama</a></li>
										<li><a href="#">Caballero</a></li>
										<li><a href="#">Contacto</a></li>
									</ul>
								</nav>
							</div>
						</div>
					</div>
				</div>
			</div>
		</footer>
	</div>		
</div>
<!-- Cerrar -->
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
<!-- Cerrar -->
<!-- Borrar -->
<div class="modal fade" id="borrar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
            <h5 class="modal-title" id="exampleBorrar">Borrar</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Cancelar">
                <span aria-hidden="true">×</span>
            </button>
            </div>
            <div class="modal-body">Realmente desea vaciar su carrito?</div>
            <div class="modal-footer">
            <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancelar</button>     
            <button class="btn btn-primary" id="botonBorrar" type="button" data-dismiss="modal">Borrar</button> 
            </div>
        </div>
    </div>
</div>
<!-- Borrar -->    
<!-- Borrador --> 
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
<!-- Borrador --> 
</form>
<script src="Scripts/jquery-3.4.1.min.js"></script>
<script src="Scripts/popper.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<script src="Scripts/littlecloset/plugins/greensock/TweenMax.min.js"></script>
<script src="Scripts/littlecloset/plugins/greensock/TimelineMax.min.js"></script>
<script src="Scripts/littlecloset/plugins/scrollmagic/ScrollMagic.min.js"></script>
<script src="Scripts/littlecloset/plugins/greensock/animation.gsap.min.js"></script>
<script src="Scripts/littlecloset/plugins/greensock/ScrollToPlugin.min.js"></script>
<script src="Scripts/littlecloset/plugins/easing/easing.js"></script>
<script src="Scripts/littlecloset/plugins/parallax-js-master/parallax.min.js"></script>
<script src="Scripts/littlecloset/js/cart.js"></script>
<script src="Scripts/Ejecucion/cerrarsesion.js"></script>
<script src="Scripts/Ejecucion/Complete_pedido.js"></script>
</body>
</html>
