<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="Tienda.WebForm5" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<title>Tienda UG</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="favicon.ico"/>
<!--===============================================================================================-->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />    
<!--===============================================================================================-->
    <link href="Scripts/Plantilla/fonts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
<!--===============================================================================================-->
    <link href="Scripts/Plantilla/vendor/animate/animate.css" rel="stylesheet" />
<!--===============================================================================================-->	
    <link href="Scripts/Plantilla/vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" />
<!--===============================================================================================-->
    <link href="Scripts/Plantilla/vendor/select2/select2.min.css" rel="stylesheet" />
<!--===============================================================================================-->
    <link href="Scripts/Plantilla/css/main.css" rel="stylesheet" />
    <link href="Scripts/Plantilla/css/util.css" rel="stylesheet" />
<!--===============================================================================================-->
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Scripts/Plantilla/css/util.css">
</head>
<body>
	
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-pic js-tilt" data-tilt>
					<img src="Scripts/Plantilla/images/img-01.png" alt="IMG">
				</div>

				<form class="login100-form validate-form">
					<span class="login100-form-title">
						Inicio de Sesion
					</span>

					<div class="wrap-input100 validate-input" data-validate = "Ingrese el nombre de usuario">
						<input id="usert" class="input100" type="text" name="email" placeholder="Usuario">
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-envelope" aria-hidden="true"></i>
						</span>
					</div>

					<div class="wrap-input100 validate-input" data-validate = "Contraseña requerida">
						<input id="password" class="input100" type="password" name="pass" placeholder="Contraseña">
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-lock" aria-hidden="true"></i>
						</span>
					</div>
					
					<div class="container-login100-form-btn">
						<button class="login100-form-btn" id="Inicio">							
                                Iniciar sesión
						</button>
					</div>

					<div class="text-center p-t-12">
						<span class="txt1">
							Olvidaste?
						</span>
						<a class="txt2" href="#">
							Usuario/ Contraseña?
						</a>
					</div>

					<div class="text-center p-t-136">
						<a class="txt2" href="#">
							Crear tu cuenta
							<i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
						</a>
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
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>

	
<!--===============================================================================================-->	
	
    <script src="Scripts/jquery-3.4.1.min.js"></script>
<!--===============================================================================================-->
    <script src="Scripts/popper.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
<!--===============================================================================================-->
    <script src="Scripts/Plantilla/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
    <script src="Scripts/Plantilla/vendor/tilt/tilt.jquery.min.js"></script>
	<script >
		$('.js-tilt').tilt({
			scale: 1.1
		})
	</script>
<!--===============================================================================================-->	
    <script src="Scripts/Plantilla/js/main.js"></script>
     <script src="Scripts/Ejecucion/login.js"></script>

</body>
</html>
