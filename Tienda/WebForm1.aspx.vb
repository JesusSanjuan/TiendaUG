Imports System.Data.SqlClient
Imports System                 'Nos ayuda a tener el control de las carpetas del servidor.
Imports System.IO              'Nos ayuda a tener el control de las carpetas del servidor.
Imports System.Web





Public Class WebForm1

    Inherits System.Web.UI.Page
    Private tempfolder As String = New String("~/archivos")
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


    Private Sub Button2_ServerClick(sender As Object, e As EventArgs) Handles Button2.ServerClick
        Dim Descrip As String
        Dim Codig As String
        Dim Cantidad As String
        Dim Color As String
        Dim Precio As String
        Dim Talla As String
        Select Case True
            Case radio1.Checked = True
                Talla = "Chica"
            Case radio2.Checked = True
                Talla = "Mediana"
            Case radio3.Checked = True
                Talla = "Grande"
            Case radio4.Checked = True
                Talla = "Extra-Grande"
            Case Else
                Talla = "Ninguno"
        End Select

        Descrip = Descripcion.Text
        Codig = Codigo.Text
        Cantidad = Cant.Text
        Color = Col.SelectedItem.ToString()
        Precio = Lacantidad.Text

        If FileUpload1.HasFile Then
            'Dim filename As String
            'filename = Path.GetFileName(FileUpload1.FileName)
            FileUpload1.SaveAs(Server.MapPath("~/Imagen_server/imagen_" + Codig + ".jpg"))
        End If


        conectar()
        ' MsgBox("INSERT INTO UG(Cantidad,Descripcion,Precio,Color,Talla,Id_imagen) VALUES('" + Cantidad + "','" + Descrip + "','" + Precio + "','" + Color + "','" + Talla + "','imagen_" + aStr + ".jpg')")

        'Se genera el String de la Consulta
        Dim consulta As String = "INSERT INTO UG(Cantidad,Codigo,Descripcion,Precio,Color,Talla,Id_imagen) VALUES('" + Cantidad + "','" + Codig + "','" + Descrip + "','" + Precio + "','" + Color + "','" + Talla + "','imagen_" + Codig + ".jpg')"
        'Agregamos la sentencia SQL y la conexion
        cmd = New SqlCommand(consulta, conn)
        'Establecemos una variable auxiliar  para determinar si la consulta se ejecuta bien o no
        Dim i As Integer = cmd.ExecuteNonQuery()
        'compara si la consulta fue hecha bien si esta es mayor que 1
        If i > 0 Then
            'Si la consulta es correcta manda este mensaje
            MsgBox("Producto Agregado")
        Else
            'si la consulta es incorrecta manda el siguiente mensaje
            MsgBox("Error al Agregar")
        End If
        'se Cierra la conexion
        cerrar()
    End Sub

    Protected Sub Descripcion_TextChanged(sender As Object, e As EventArgs) Handles Descripcion.TextChanged

    End Sub
End Class