Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json

Public Class WebForm4
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
        Dim obj(table.Rows.Count - 1, 5) As Object

        While (Contador < table.Rows.Count)
            Dim row As DataRow = table.Rows(Contador)
            obj(Contador, 0) = row.Item("Id_codigo")
            obj(Contador, 1) = row.Item("Descripcion")
            obj(Contador, 2) = row.Item("Precio")
            obj(Contador, 3) = row.Item("id_imagen")
            obj(Contador, 4) = row.Item("Color")
            obj(Contador, 5) = row.Item("Talla")
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
        cerrar()

    End Sub
    <WebMethod()>
    Public Shared Function compraproducto(ByVal idCodigo As Integer) As Object
        Dim id_user As String = System.Web.HttpContext.Current.Session("id_user").ToString
        Dim id_user_number As Integer = CType(id_user, Integer)

        conectar()
        'Se genera el String de la Consulta
        Dim consulta0 As String = "SELECT Id_compra, Cantidad_comprado FROM  carrito WHERE  carrito.id_codigo_articulo =" & idCodigo & "and carrito.id_usuario=" & id_user & "and carrito.status_compra = 'carrito'"
        'Agregamos la sentencia SQL y la conexion
        cmd = New SqlCommand(consulta0, conn)
        dr = cmd.ExecuteReader()
        Dim res0(1) As Object
        Dim no_agregado_jamas As Boolean = dr.HasRows
        If dr.HasRows Then

            dr.Read()
            res0(0) = dr.GetValue(0)
            res0(1) = dr.GetValue(1)
        End If
        cerrar()


        Dim obj As String = "NO"
        Dim ResultConsulta(6) As String

        conectar()
        'Se genera el String de la Consulta
        Dim consulta As String = "SELECT Descripcion, Color, Talla, Codigo FROM  UG WHERE UG.Id_codigo =" & idCodigo 
        'Agregamos la sentencia SQL y la conexion
        cmd = New SqlCommand(consulta, conn)
        dr = cmd.ExecuteReader()
        Dim res(3) As Object

        If dr.HasRows Then
            dr.Read()
            res(0) = dr.GetString(0)
            res(1) = dr.GetString(1)
            res(2) = dr.GetString(2)
            res(3) = dr.GetString(3)
        End If
        cerrar()

        If no_agregado_jamas Then
            Try
                Dim ObjetoAdapador As New DataSet1TableAdapters.carritoTableAdapter
                Dim ObjetoDataSetCliente As New DataSet1TableAdapters.carritoTableAdapter
                Dim intMyInteger As Integer
                intMyInteger = res0(1) + 1
                ObjetoAdapador.Actualizar_compra(intMyInteger, res0(0))
                ResultConsulta(0) = "trueRe"
                ResultConsulta(1) = "Nada"
                ResultConsulta(2) = res(0)
                ResultConsulta(3) = res(1)
                ResultConsulta(4) = res(2)
                ResultConsulta(5) = res(3)
                obj = JsonConvert.SerializeObject(ResultConsulta)
            Catch ex As Exception
                ResultConsulta(0) = "errorRe"
                ResultConsulta(1) = ex.ToString
                obj = JsonConvert.SerializeObject(ResultConsulta)
            End Try
        Else
            Try
                Dim ObjetoAdapador As New DataSet1TableAdapters.carritoTableAdapter
                Dim ObjetoDataSetCliente As New DataSet1TableAdapters.carritoTableAdapter
                ObjetoAdapador.InsertarCompra(idCodigo, id_user_number, 1, "carrito")
                ResultConsulta(0) = "true"
                ResultConsulta(1) = "Nada"
                ResultConsulta(2) = res(0)
                ResultConsulta(3) = res(1)
                ResultConsulta(4) = res(2)
                ResultConsulta(5) = res(3)
                obj = JsonConvert.SerializeObject(ResultConsulta)
            Catch ex As Exception
                ResultConsulta(0) = "error"
                ResultConsulta(1) = ex.ToString
                obj = JsonConvert.SerializeObject(ResultConsulta)
            End Try
        End If

        Return obj
    End Function
End Class