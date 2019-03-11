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


        conectar()
        ' MsgBox("INSERT INTO UG(Cantidad,Descripcion,Precio,Color,Talla,Id_imagen) VALUES('" + Cantidad + "','" + Descrip + "','" + Precio + "','" + Color + "','" + Talla + "','imagen_" + aStr + ".jpg')")
        Dim consulta0 As String = "SELECT COUNT(*) FROM  UG"
        cmd = New SqlCommand(consulta0, conn)
        dr = cmd.ExecuteReader()
        Dim Cantidad As String
        If dr.HasRows Then
            dr.Read()
            Cantidad = dr.GetValue(0)
        End If
        cerrar()

        conectar()
        'Se genera el String de la Consulta
        Dim consulta As String = "SELECT Id_codigo,  Descripcion, Precio, id_imagen, Codigo FROM  UG"
        'Agregamos la sentencia SQL y la conexion
        cmd = New SqlCommand(consulta, conn)
        dr = cmd.ExecuteReader()



        Dim id_codigo As String
        Dim Descripcion As String
        Dim Precio As String
        Dim id_imagen As String
        Dim Codigo As String
        Dim Contador As Integer = 0
        Dim ResultadoFinal As String
        Dim obj(Cantidad - 1) As String
        Dim ResultConsulta(4) As String

        Dim Valor As String = dr.HasRows.ToString()

        While (Contador < Cantidad)
            dr.Read()
            ResultConsulta(0) = dr.GetValue(0)
            ResultConsulta(1) = dr.GetString(1)
                ResultConsulta(2) = dr.GetValue(2)
                ResultConsulta(3) = dr.GetString(3)
                ResultConsulta(4) = dr.GetString(4)

                id_codigo = dr.GetValue(0)
                Descripcion = dr.GetString(1)
                Precio = dr.GetValue(2)
                id_imagen = dr.GetSqlString(3)
                Codigo = dr.GetSqlString(4)

            obj(Contador) = JsonConvert.SerializeObject(ResultConsulta)
            Contador = Contador + 1

        End While

        ResultadoFinal = JsonConvert.SerializeObject(obj)
        ' Dim script As String = "operacion('" & id_codigo & "','" & Descripcion & "','" & Precio & "','" & id_imagen & "','" & Codigo & "');"
        'ScriptManager.RegisterStartupScript(Page, GetType(Page), "operacion", script, True)
        cerrar()

    End Sub
End Class