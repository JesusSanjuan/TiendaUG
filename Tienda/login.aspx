<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="Tienda.WebForm3" %>
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">

<!------ Include the above in your HEAD tag ---------->

<!DOCTYPE html>
<html>
<head>
	<title>Inicio de Sesion Tienda UG</title>
   <!--Made with love by Mutiullah Samim -->
   
	<!--Bootsrap 4 CDN-->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <!--Fontawesome CDN-->
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous">
	<!--Custom styles-->
	<link rel="stylesheet" type="text/css" href="Scripts/Plantilla/css/login.css">
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
<div class="container">
	<div class="d-flex justify-content-center h-100">
		<div class="card">
			<div class="card-header">
				<h3>Inicio de Sesion</h3>
				<div class="d-flex justify-content-end social_icon">
					<span><i class="fab fa-facebook-square"></i></span>
					<span><i class="fab fa-google-plus-square"></i></span>
					<span><i class="fab fa-twitter-square"></i></span>
				</div>
			</div>
			<div class="card-body" >
				<form runat="server">
					<div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-user"></i></span>
						</div>
						 <asp:TextBox ID="usert" class="form-control" type="text"  placeholder="Nombre de usuario" runat="server"></asp:TextBox>
					</div>
					<div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-key"></i></span>
						</div>
                         <asp:TextBox ID="password" class="form-control"  type="password"  placeholder="Contraseña " runat="server"></asp:TextBox>
					</div>
					<div class="row align-items-center remember">
						<input type="checkbox">Recordarme
					</div>
					<div class="form-group">
                        <input type="button" class="btn float-right login_btn" value="Inicio de Sesion" id="Inicio">                    
					</div>
                      
				</form>
			</div>
			<div class="card-footer">
				<div class="d-flex justify-content-center links">
					No tiene una cuenta?<a href="#">Registrate</a>
				</div>
				<div class="d-flex justify-content-center">
					<a href="#">No recuerdas tu contrase­ña?</a>
				</div>
			</div>
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
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>
    
    <script src="Scripts/Ejecucion/login.js"></script>
  

</body>
</html>
