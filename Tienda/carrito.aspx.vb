Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json

Public Class cart
    Inherits System.Web.UI.Page

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

        Dim Contador As Integer = 0
        Dim table1 As New DataTable
        Dim ObjetoAdapador1 As New DataSet1TableAdapters.carritoTableAdapter
        table1 = ObjetoAdapador1.CantidadCompradoGetDataBy(id_user_number)
        Dim sumacarrito As Integer = 0
        Contador = 0
        While (Contador < table1.Rows.Count)
            Dim row As DataRow = table1.Rows(Contador)
            sumacarrito = sumacarrito + row.Item("Cantidad_comprado")
            Contador = Contador + 1
        End While

        Dim table2 As New DataTable
        Dim ObjetoAdapador2 As New DataSet1TableAdapters.carritoTableAdapter
        table2 = ObjetoAdapador2.SelecObtenerArticuloUsuario(id_user_number)

        Dim Contador2 As Integer = 0
        Dim Res(table2.Rows.Count - 1, 1) As Object
        While (Contador2 < table2.Rows.Count)
            Dim row As DataRow = table2.Rows(Contador2)
            Res(Contador2, 0) = row.Item("id_codigo_articulo")
            Res(Contador2, 1) = row.Item("Cantidad_comprado")
            Contador2 = Contador2 + 1
        End While

        Dim res2((Res.Length / Res.Rank) - 1, 6) As Object
        For Index As Integer = 0 To (Res.Length / Res.Rank) - 1

            Dim table3 As New DataTable
            Dim ObjetoAdapador3 As New DataSet1TableAdapters.UGTableAdapter
            table3 = ObjetoAdapador3.Obtener_carac_producto_de_usuario(Res(Index, 0))
            Dim row As DataRow = table3.Rows(0)
            res2(Index, 0) = row.Item("Descripcion")
            res2(Index, 1) = row.Item("Color")
            res2(Index, 2) = row.Item("Talla")
            res2(Index, 3) = row.Item("Precio")
            res2(Index, 4) = row.Item("Codigo")
            res2(Index, 5) = row.Item("id_imagen")
            res2(Index, 6) = Res(Index, 1)
        Next
        Dim ResultadoF As Object
        Dim ResultadoF2 As Object
        ResultadoF = JsonConvert.SerializeObject(res2)
        ResultadoF2 = JsonConvert.SerializeObject(sumacarrito)


        Dim TestDateTime As Date = Date.Now
        Dim TestStr As String
        TestStr = Format(TestDateTime, "MMddHHmmss")
        System.Web.HttpContext.Current.Session("numero_pedido") = TestStr
        Dim script As String = "operacion(" & ResultadoF & "," & ResultadoF2 & "," & TestStr & ");"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "operacion", script, True)
    End Sub
    <WebMethod()>
    Public Shared Function borrarCarrito() As Object
        Dim obj As String = "NO"
        Dim id_user As String = System.Web.HttpContext.Current.Session("id_user").ToString
        Dim id_user_number As Integer = CType(id_user, Integer)
        Dim table As New DataTable
        Dim ObjetoAdapador As New DataSet1TableAdapters.carritoTableAdapter
        table = ObjetoAdapador.ConsultaCarritoStock(id_user_number)
        Dim Contador2 As Integer = 0
        While (Contador2 < table.Rows.Count)
            Dim row As DataRow = table.Rows(Contador2)
            Dim ObjetoAdapador2 As New DataSet1TableAdapters.UGTableAdapter
            ObjetoAdapador2.ActualizarCantidadProducto(row.Item("ActualizacionStock"), row.Item("codigo_articulo"))
            Contador2 = Contador2 + 1

        End While

        Dim ResultConsulta(1) As String
        Try
            Dim ObjetoAdapador3 As New DataSet1TableAdapters.carritoTableAdapter
            ObjetoAdapador3.Borrar(id_user)
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
            ObjetoAdapador.ActualizarEnvio(precio_envio, id_user_number, "carrito")
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