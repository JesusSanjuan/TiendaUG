Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json
Public Class Admin3
    Inherits System.Web.UI.Page
    Dim idPedido As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "Usuario" Then
                Response.Redirect("Admin1.aspx")
            ElseIf System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "SU" Then
                Response.Redirect("login.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("index.aspx")
        End Try
    End Sub

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        idPedido = GridView1.SelectedValue

        Dim table As New DataTable
        Dim ObjetoAdapador As New DataSet1TableAdapters.carritoTableAdapter
        table = ObjetoAdapador.ConsultaPedidoAdmin(idPedido, idPedido)

        Dim row As DataRow = table.Rows(0)
        Estado_compra.Text = row.Item("Estado_Compra")
        idenPrinc.Text = row.Item("Numero_Pedido")
        Nombre_cliente.Text = row.Item("Nombre_del_Cliente")
        Fecha_pedido.Text = row.Item("Fecha_del_Pedido")
        Precio_envio.Text = "$" & row.Item("Precio_del_Envio") & ".00"
        Cantidad_prod.Text = row.Item("Cantidad_del_pedido")
        Select Case row.Item("Precio_del_Envio")
            Case 180
                Tipo_envio.Text = "Entrega del Dia Siguiente"
            Case 105
                Tipo_envio.Text = "Entrega Estandar"
            Case 0
                Tipo_envio.Text = "Recoleccion Personal"
        End Select

        Dim table2 As New DataTable
        Dim ObjetoAdapador2 As New DataSet1TableAdapters.carritoTableAdapter
        table2 = ObjetoAdapador2.ConsultaProductosAdmin(idPedido)

        Dim Contador As Integer = 0
        Dim ResultadoFinal As Object
        Dim obj(table2.Rows.Count - 1, 6) As Object

        While (Contador < table2.Rows.Count)
            Dim row2 As DataRow = table2.Rows(Contador)
            obj(Contador, 0) = row2.Item("Descripcion")
            obj(Contador, 1) = row2.Item("Precio")
            obj(Contador, 2) = row2.Item("Talla")
            obj(Contador, 3) = row2.Item("Color")
            obj(Contador, 4) = row2.Item("Codigo")
            obj(Contador, 5) = row2.Item("Cantidad_comprado")
            obj(Contador, 6) = row2.Item("id_imagen")
            Contador = Contador + 1
        End While
        ResultadoFinal = JsonConvert.SerializeObject(obj)

        Dim script As String = "operacion(" & ResultadoFinal & ");"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "operacion", script, True)

    End Sub

    <WebMethod()>
    Public Shared Function Actualizar_Pedido(ByVal numpedido As String) As Object
        Dim obj As String = "NO"
        Dim ResultConsulta(1) As String
        Try
            Dim ObjetoAdapador3 As New DataSet1TableAdapters.carritoTableAdapter
            ObjetoAdapador3.ActulizarEstatusAdmin("Enviado", numpedido)
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