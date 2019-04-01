Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json

Public Class cart
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

    Private Sub cart_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim id_user As String = System.Web.HttpContext.Current.Session("id_user").ToString
        Dim id_user_number As Integer = CType(id_user, Integer)

        conectar()
        Dim consultaCan As String = "SELECT COUNT(Cantidad_comprado) FROM  carrito WHERE  carrito.Id_usuario =" & id_user_number & "and carrito.status_compra = 'carrito'"
        cmd = New SqlCommand(consultaCan, conn)
        dr = cmd.ExecuteReader()
        Dim CantidadCan As String
        dr.Read()
        CantidadCan = dr.GetValue(0)
        cerrar()

        conectar()
        Dim Contador As Integer = 0
        Dim consulta2 As String = "SELECT Cantidad_comprado FROM  carrito WHERE  carrito.Id_usuario =" & id_user_number & "and carrito.status_compra = 'carrito'"
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


        conectar()
        Dim consultaCan2 As String = "SELECT COUNT(id_codigo_articulo) FROM  carrito WHERE  carrito.Id_usuario =" & id_user_number & "and carrito.status_compra = 'carrito'"
        cmd = New SqlCommand(consultaCan2, conn)
        dr = cmd.ExecuteReader()
        Dim CantidadCan2 As String
        dr.Read()
        CantidadCan2 = dr.GetValue(0)
        cerrar()

        conectar()
        Dim consultaCan3 As String = "SELECT id_codigo_articulo, Cantidad_comprado FROM  carrito WHERE  carrito.Id_usuario =" & id_user_number & "and carrito.status_compra = 'carrito'"
        cmd = New SqlCommand(consultaCan3, conn)
        dr = cmd.ExecuteReader()
        Contador = 0
        Dim Res(CantidadCan2 - 1, 1) As Object
        While (Contador < CantidadCan)
            dr.Read()
            Res(Contador, 0) = dr.GetValue(0)
            Res(Contador, 1) = dr.GetValue(1)
            Contador = Contador + 1
        End While
        cerrar()

        Dim res2((Res.Length / Res.Rank) - 1, 6) As Object
        For Index As Integer = 0 To (Res.Length / Res.Rank) - 1
            conectar()
            Dim consulta As String = "SELECT Descripcion, Color, Talla, Precio, Codigo, id_imagen FROM  UG WHERE UG.Id_codigo =" & Res(Index, 0)
            cmd = New SqlCommand(consulta, conn)
            dr = cmd.ExecuteReader()
            dr.Read()
            res2(Index, 0) = dr.GetString(0)
            res2(Index, 1) = dr.GetString(1)
            res2(Index, 2) = dr.GetString(2)
            res2(Index, 3) = dr.GetValue(3)
            res2(Index, 4) = dr.GetString(4)
            res2(Index, 5) = dr.GetString(5)
            res2(Index, 6) = Res(Index, 1)
            cerrar()
        Next
        Dim ResultadoF As Object
        Dim ResultadoF2 As Object
        ResultadoF = JsonConvert.SerializeObject(res2)
        ResultadoF2 = JsonConvert.SerializeObject(sumacarrito)
        Dim script As String = "operacion(" & ResultadoF & "," & ResultadoF2 & ");"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "operacion", script, True)
    End Sub
    <WebMethod()>
    Public Shared Function borrarCarrito() As Object
        Dim obj As String = "NO"
        Dim id_user As String = System.Web.HttpContext.Current.Session("id_user").ToString
        Dim id_user_number As Integer = CType(id_user, Integer)
        Dim ResultConsulta(1) As String
        Try
            Dim ObjetoAdapador As New DataSet1TableAdapters.carritoTableAdapter
            Dim ObjetoDataSetCliente As New DataSet1TableAdapters.carritoTableAdapter
            ObjetoAdapador.Borrar(id_user, "Carrito")
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
    <WebMethod()>
    Public Shared Function Alta_envio(ByVal precio_envio As String, ByVal precioTotal As String) As Object
        Dim obj As String = "NO"
        System.Web.HttpContext.Current.Session("precio_envio") = precio_envio
        System.Web.HttpContext.Current.Session("precioTotal") = precioTotal
        Dim id_user As String = System.Web.HttpContext.Current.Session("id_user").ToString
        Dim id_user_number As Integer = CType(id_user, Integer)
        Dim ResultConsulta(1) As String
        Try
            Dim ObjetoAdapador As New DataSet1TableAdapters.carritoTableAdapter
            Dim ObjetoDataSetCliente As New DataSet1TableAdapters.carritoTableAdapter
            ObjetoAdapador.ActualizarEnvio(precio_envio, id_user_number)
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