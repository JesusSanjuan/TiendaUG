Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json

Public Class pedidos
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
    Private Sub pedidos_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
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

        Dim ResultadoF2 As Object
        ResultadoF2 = JsonConvert.SerializeObject(sumacarrito)


        Dim Contador2 As Integer = 0
        Dim table2 As New DataTable
        Dim ObjetoAdapador2 As New DataSet1TableAdapters.carritoTableAdapter
        table2 = ObjetoAdapador2.ConsultaPedidosUser(id_user_number)

        Dim ResultadoFinal As Object
        Dim obj(table2.Rows.Count - 1, 5) As Object

        While (Contador2 < table2.Rows.Count)
            Dim row2 As DataRow = table2.Rows(Contador2)
            obj(Contador2, 0) = row2.Item("Estado_Compra")
            obj(Contador2, 1) = row2.Item("Numero_Pedido")
            obj(Contador2, 2) = row2.Item("Fecha_del_pedido")
            Select Case row2.Item("Precio_del_envio")
                Case 180
                    obj(Contador2, 3) = "Entrega del Dia Siguiente"
                Case 105
                    obj(Contador2, 3) = "Entrega Estandar"
                Case 0
                    obj(Contador2, 3) = "Recoleccion Personal"
            End Select
            obj(Contador2, 4) = row2.Item("Precio_del_envio")
            obj(Contador2, 5) = row2.Item("Cantidad_del_pedido")
            Contador2 = Contador2 + 1
        End While
        ResultadoFinal = JsonConvert.SerializeObject(obj)

        Dim script As String = "operacion(" & ResultadoF2 & "," & ResultadoFinal & ");"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "operacion", script, True)
    End Sub
    <WebMethod()>
    Public Shared Function Consulta_pedido_user(ByVal numpedido As String) As Object
        Dim table2 As New DataTable
        Dim ObjetoAdapador2 As New DataSet1TableAdapters.carritoTableAdapter
        table2 = ObjetoAdapador2.ConsultaProductosAdmin(numpedido)

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
        Return ResultadoFinal
    End Function
End Class