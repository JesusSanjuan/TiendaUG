﻿Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json
Public Class checkout
    Inherits System.Web.UI.Page

    Public Shared conn As SqlConnection = New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog = TiendaUG;")
    'Public Shared conn As SqlConnection = New SqlConnection("Data Source=.;Initial Catalog=TiendaUG;User ID=Sa;Password=Jesus1993")
    Public Shared cmd As SqlCommand
    Public Shared dr As SqlDataReader
    Public Shared Function conectar() As SqlConnection
        Try
            conn.Open()
            'MsgBox("Conectado")
        Catch ex As Exception
            MsgBox("Error Conexion a base de datos " & ex.ToString)
        End Try
        Return conn
    End Function

    Public Shared Function cerrar() As SqlConnection
        conn.Close()
        Return conn
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "Administrador" Then
                Response.Redirect("tiendaug.aspx")
            ElseIf System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "SU" Then
                Response.Redirect("login.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("index.aspx")
        End Try
    End Sub

    Private Sub checkout_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim id_user As String = System.Web.HttpContext.Current.Session("id_user").ToString
        Dim id_user_number As Integer = CType(id_user, Integer)
        conectar()
        ' MsgBox("INSERT INTO UG(Cantidad,Descripcion,Precio,Color,Talla,Id_imagen) VALUES('" + Cantidad + "','" + Descrip + "','" + Precio + "','" + Color + "','" + Talla + "','imagen_" + aStr + ".jpg')")
        Dim consultaCan As String = "SELECT COUNT(Cantidad_comprado) FROM  carrito WHERE  carrito.Id_usuario =" & id_user_number & "and carrito.status_compra = 'carrito'"
        cmd = New SqlCommand(consultaCan, conn)
        dr = cmd.ExecuteReader()
        Dim CantidadCan As String
        dr.Read()
        CantidadCan = dr.GetValue(0)
        cerrar()

        conectar()
        'Se genera el String de la Consulta
        Dim Contador As Integer = 0
        Dim ResultadoFinal As Object = 0
        Dim consulta2 As String = "SELECT Cantidad_comprado FROM  carrito WHERE  carrito.Id_usuario =" & id_user_number & "and carrito.status_compra = 'carrito'"
        'Agregamos la sentencia SQL y la conexion
        cmd = New SqlCommand(consulta2, conn)
        dr = cmd.ExecuteReader()
        Dim sumacarrito As Integer = 0
        If dr.HasRows Then
            Contador = 0
            While (Contador < CantidadCan)
                dr.Read()
                sumacarrito = sumacarrito + dr.GetValue(0)
                Contador = Contador + 1
            End While
        End If
        cerrar()
        Dim ResultadoFinal2 As Object
        ResultadoFinal2 = JsonConvert.SerializeObject(sumacarrito)
        Dim script As String = "operacion(" & ResultadoFinal & "," & ResultadoFinal2 & ", " & System.Web.HttpContext.Current.Session("precioTotal").ToString & ", " & System.Web.HttpContext.Current.Session("precio_envio").ToString & ");"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "operacion", script, True)
        cerrar()
    End Sub
    <WebMethod()>
    Public Shared Function Pago_Pedido() As Object
        Dim id_user As String = System.Web.HttpContext.Current.Session("id_user").ToString
        Dim id_user_number As Integer = CType(id_user, Integer)
        Dim obj As String = "NO"
        Dim ResultConsulta(1) As String
        Try
            Dim ObjetoAdapador As New DataSet1TableAdapters.carritoTableAdapter
            Dim ObjetoDataSetCliente As New DataSet1TableAdapters.carritoTableAdapter
            ObjetoAdapador.ActualizaEstatusCompra("pagado", id_user_number, "carrito")
            ResultConsulta(0) = "true"
            ResultConsulta(1) = "ninguno"
            obj = JsonConvert.SerializeObject(ResultConsulta)
        Catch ex As Exception
            ResultConsulta(0) = "error"
            ResultConsulta(1) = ex.ToString
            obj = JsonConvert.SerializeObject(ResultConsulta)
        End Try
        Return obj
    End Function
End Class