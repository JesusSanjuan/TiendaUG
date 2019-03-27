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
        ' MsgBox("INSERT INTO UG(Cantidad,Descripcion,Precio,Color,Talla,Id_imagen) VALUES('" + Cantidad + "','" + Descrip + "','" + Precio + "','" + Color + "','" + Talla + "','imagen_" + aStr + ".jpg')")
        Dim consultaCan As String = "SELECT COUNT(Cantidad_comprado) FROM  carrito WHERE  carrito.Id_usuario =" & id_user_number
        cmd = New SqlCommand(consultaCan, conn)
        dr = cmd.ExecuteReader()
        Dim CantidadCan As String
        dr.Read()
        CantidadCan = dr.GetValue(0)
        cerrar()

        conectar()
        'Se genera el String de la Consulta
        Dim Contador As Integer = 0
        Dim consulta2 As String = "SELECT Cantidad_comprado FROM  carrito WHERE  carrito.Id_usuario =" & id_user_number
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


        conectar()
        ' MsgBox("INSERT INTO UG(Cantidad,Descripcion,Precio,Color,Talla,Id_imagen) VALUES('" + Cantidad + "','" + Descrip + "','" + Precio + "','" + Color + "','" + Talla + "','imagen_" + aStr + ".jpg')")
        Dim consultaCan2 As String = "SELECT id_codigo_articulo, Cantidad_comprado FROM  carrito WHERE  carrito.Id_usuario =" & id_user_number & "and carrito.status_compra = 'carrito'"
        cmd = New SqlCommand(consultaCan2, conn)
        dr = cmd.ExecuteReader()
        Dim res(1) As Object

        If dr.HasRows Then
            dr.Read()
            res(0) = dr.GetValue(0)
            res(1) = dr.GetValue(1)
        End If
        cerrar()
        conectar()
        Dim consulta As String = "SELECT Descripcion, Color, Talla, Precio, Codigo FROM  UG WHERE UG.Id_codigo =" & res(0)
        'Agregamos la sentencia SQL y la conexion
        cmd = New SqlCommand(consulta, conn)
        dr = cmd.ExecuteReader()
        Dim res2(4) As Object

        If dr.HasRows Then
            dr.Read()
            res2(0) = dr.GetString(0)
            res2(1) = dr.GetString(1)
            res2(2) = dr.GetString(2)
            res2(3) = dr.GetValue(3)
            res2(4) = dr.GetString(4)
        End If
        cerrar()
        Dim ResultadoFinal(6) As Object
        ResultadoFinal(0) = res2(0)
        ResultadoFinal(1) = res2(1)
        ResultadoFinal(2) = res2(2)
        ResultadoFinal(3) = res2(3)
        ResultadoFinal(4) = res2(4)
        ResultadoFinal(5) = res(1)
        Dim ResultadoFinal3 As Object
        ResultadoFinal3 = JsonConvert.SerializeObject(ResultadoFinal)



        Dim script As String = "operacion(" & ResultadoFinal3 & "," & ResultadoFinal2 & ");"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "operacion", script, True)
    End Sub
End Class