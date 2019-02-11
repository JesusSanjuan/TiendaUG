Imports System.Data.SqlClient

Public Class WebForm3
    Inherits System.Web.UI.Page

    Dim ids As String
    Dim ds As New DataSet
    Dim da As OleDb.OleDbDataAdapter

    Public conn As SqlConnection = New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog = TiendaUG;")
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public Function conectar() As SqlConnection
        Try
            conn.Open()
            'MsgBox("Conectado")
        Catch ex As Exception
            MsgBox("Error")
        End Try
        Return conn
    End Function

    Public Function cerrar() As SqlConnection
        conn.Close()
        Return conn
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Inicio_ServerClick(sender As Object, e As EventArgs) Handles Inicio.ServerClick

        conectar()
        ' MsgBox("INSERT INTO UG(Cantidad,Descripcion,Precio,Color,Talla,Id_imagen) VALUES('" + Cantidad + "','" + Descrip + "','" + Precio + "','" + Color + "','" + Talla + "','imagen_" + aStr + ".jpg')")
        Dim Name As String = usert.Text
        Dim Pass As String = password.Text
        'Se genera el String de la Consulta
        Dim consulta As String = "SELECT Id_usuario,Tipo_user FROM  Users WHERE UserName = '" + Name + "' and  Contrasena='" + Pass + "'"
        'Agregamos la sentencia SQL y la conexion
        cmd = New SqlCommand(consulta, conn)

        dr = cmd.ExecuteReader()

        If dr.HasRows Then
            dr.Read()
            MsgBox(dr.GetString(1))

        End If

        cerrar()


    End Sub


End Class