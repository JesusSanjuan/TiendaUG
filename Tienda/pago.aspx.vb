Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json
Public Class checkout
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

    Private Sub checkout_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim id_user As String = System.Web.HttpContext.Current.Session("id_user").ToString
        Dim id_user_number As Integer = CType(id_user, Integer)

        Dim Contador As Integer = 0
        Dim table2 As New DataTable
        Dim ObjetoAdapador2 As New DataSet1TableAdapters.carritoTableAdapter
        table2 = ObjetoAdapador2.CantidadCompradoGetDataBy(id_user_number)
        Dim sumacarrito As Integer = 0
        Contador = 0
        While (Contador < table2.Rows.Count)
            Dim row As DataRow = table2.Rows(Contador)
            sumacarrito = sumacarrito + row.Item("Cantidad_comprado")
            Contador = Contador + 1
        End While

        Dim ResultadoFinal As Object
        ResultadoFinal = JsonConvert.SerializeObject(sumacarrito)
        Dim script As String = "operacion(" & ResultadoFinal & ", " & System.Web.HttpContext.Current.Session("precioTotal").ToString & ", " & System.Web.HttpContext.Current.Session("precio_envio").ToString & ");"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "operacion", script, True)

    End Sub
    <WebMethod()>
    Public Shared Function Pago_Pedido() As Object
        Dim id_user As String = System.Web.HttpContext.Current.Session("id_user").ToString
        Dim id_user_number As Integer = CType(id_user, Integer)
        Dim obj As String = "NO"
        Dim ResultConsulta(1) As String
        Try
            Dim ObjetoAdapador As New DataSet1TableAdapters.carritoTableAdapter
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