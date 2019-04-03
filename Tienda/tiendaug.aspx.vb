Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json

Public Class WebForm4
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "Administrador" Then
                Response.Redirect("tiendaug.aspx")
            ElseIf System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "Usuario" Then

            ElseIf System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "SU" Then
                Response.Redirect("login.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("index.aspx")
        End Try
    End Sub
    Private Sub WebForm4_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Dim table As New DataTable
        Dim ObjetoAdapador As New DataSet1TableAdapters.UGTableAdapter
        table = ObjetoAdapador.ObtenerProductosGetDataBy

        Dim Contador As Integer = 0
        Dim ResultadoFinal As Object
        Dim obj(table.Rows.Count - 1, 6) As Object

        While (Contador < table.Rows.Count)
            Dim row As DataRow = table.Rows(Contador)
            obj(Contador, 0) = row.Item("Id_codigo")
            obj(Contador, 1) = row.Item("Descripcion")
            obj(Contador, 2) = row.Item("Precio")
            obj(Contador, 3) = row.Item("id_imagen")
            obj(Contador, 4) = row.Item("Color")
            obj(Contador, 5) = row.Item("Talla")
            obj(Contador, 6) = row.Item("Cantidad")
            Contador = Contador + 1
        End While
        ResultadoFinal = JsonConvert.SerializeObject(obj)

        Dim id_user As String = System.Web.HttpContext.Current.Session("id_user").ToString
        Dim id_user_number As Integer = CType(id_user, Integer)

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

        Dim ResultadoFinal2 As Object
        ResultadoFinal2 = JsonConvert.SerializeObject(sumacarrito)
        Dim script As String = "operacion(" & ResultadoFinal & "," & ResultadoFinal2 & ");"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "operacion", script, True)

    End Sub
    <WebMethod()>
    Public Shared Function compraproducto(ByVal idCodigo As Integer) As Object
        Dim id_user As String = System.Web.HttpContext.Current.Session("id_user").ToString
        Dim id_user_number As Integer = CType(id_user, Integer)

        Dim table As New DataTable
        Dim ObjetoAdapador As New DataSet1TableAdapters.carritoTableAdapter
        table = ObjetoAdapador.CompraAgregada(idCodigo, id_user_number)

        Dim res0(1) As Object
        Dim no_agregado_jamas As Boolean
        If table.Rows.Count > 0 Then
            Dim row As DataRow = table.Rows(0)
            res0(0) = row.Item("Id_compra")
            res0(1) = row.Item("Cantidad_comprado")
            no_agregado_jamas = True
        Else
            no_agregado_jamas = False
        End If


        Dim obj As String = "NO"
        Dim ResultConsulta(7) As String

        Dim table2 As New DataTable
        Dim ObjetoAdapador2 As New DataSet1TableAdapters.UGTableAdapter
        table2 = ObjetoAdapador2.ConsultarProducto(idCodigo)

        Dim res(4) As Object
        Dim row2 As DataRow = table2.Rows(0)
        res(0) = row2.Item("Descripcion")
        res(1) = row2.Item("Color")
        res(2) = row2.Item("Talla")
        res(3) = row2.Item("Codigo")
        res(4) = row2.Item("Cantidad")
        Dim minuevovalor As Integer
        minuevovalor = res(4) - 1

        If no_agregado_jamas Then
            Try
                Dim ObjetoAdapador3 As New DataSet1TableAdapters.carritoTableAdapter
                Dim intMyInteger As Integer
                intMyInteger = res0(1) + 1
                ObjetoAdapador3.Actualizar_compra(intMyInteger, res0(0))
                ResultConsulta(0) = "trueRe"
                ResultConsulta(1) = "Nada"
                ResultConsulta(2) = res(0)
                ResultConsulta(3) = res(1)
                ResultConsulta(4) = res(2)
                ResultConsulta(5) = res(3)
                ResultConsulta(6) = minuevovalor
                obj = JsonConvert.SerializeObject(ResultConsulta)
            Catch ex As Exception
                ResultConsulta(0) = "errorRe"
                ResultConsulta(1) = ex.ToString
                obj = JsonConvert.SerializeObject(ResultConsulta)
            End Try
        Else
            Try
                Dim ObjetoAdapador3 As New DataSet1TableAdapters.carritoTableAdapter
                ObjetoAdapador3.InsertarCompra(idCodigo, id_user_number, 1)
                ResultConsulta(0) = "true"
                ResultConsulta(1) = "Nada"
                ResultConsulta(2) = res(0)
                ResultConsulta(3) = res(1)
                ResultConsulta(4) = res(2)
                ResultConsulta(5) = res(3)
                ResultConsulta(6) = minuevovalor
                obj = JsonConvert.SerializeObject(ResultConsulta)
            Catch ex As Exception
                ResultConsulta(0) = "error"
                ResultConsulta(1) = ex.ToString
                obj = JsonConvert.SerializeObject(ResultConsulta)
            End Try
        End If

        Try
            Dim ObjetoAdapador4 As New DataSet1TableAdapters.UGTableAdapter
            ObjetoAdapador4.ActualizarCantidadProducto(minuevovalor, idCodigo)
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Return obj
    End Function
    '<WebMethod()>
    'Public Shared Function reactualizar() As Object
    '    Dim table As New DataTable
    '    Dim ObjetoAdapador As New DataSet1TableAdapters.UGTableAdapter
    '    table = ObjetoAdapador.ObtenerProductosGetDataBy
    '    Dim Contador As Integer = 0
    '    Dim ResultadoFinal As Object
    '    Dim obj(table.Rows.Count - 1, 6) As Object

    '    While (Contador < table.Rows.Count)
    '        Dim row As DataRow = table.Rows(Contador)
    '        obj(Contador, 0) = row.Item("Id_codigo")
    '        obj(Contador, 1) = row.Item("Descripcion")
    '        obj(Contador, 2) = row.Item("Precio")
    '        obj(Contador, 3) = row.Item("id_imagen")
    '        obj(Contador, 4) = row.Item("Color")
    '        obj(Contador, 5) = row.Item("Talla")
    '        obj(Contador, 6) = row.Item("Cantidad")
    '        Contador = Contador + 1
    '    End While
    '    ResultadoFinal = JsonConvert.SerializeObject(obj)
    '    Return ResultadoFinal
    'End Function
End Class