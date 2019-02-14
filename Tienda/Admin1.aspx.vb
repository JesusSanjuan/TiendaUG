Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json

Public Class WebForm1

    Inherits System.Web.UI.Page
    Public Shared conn As SqlConnection = New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog = TiendaUG;")
    Public Shared cmd As SqlCommand
    Public Shared dr As SqlDataReader
    Public Shared Function conectar() As SqlConnection
        Try
            conn.Open()
            'MsgBox("Conectado")
        Catch ex As Exception
            MsgBox("Error")
        End Try
        Return conn
    End Function

    Public Shared Function cerrar() As SqlConnection
        conn.Close()
        Return conn
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub Button2_ServerClick(sender As Object, e As EventArgs) Handles Alta.ServerClick
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
    <WebMethod()>
    Public Shared Function testmethod(ByVal Cantidad As String, ByVal Codig As String, ByVal Descrip As String) As Object
        conectar()
        Dim consulta As String = "SELECT Id_usuario,Tipo_user FROM  Users WHERE UserName = '" + User + "' and  Contrasena='" + Password + "'"
        cmd = New SqlCommand(consulta, conn)
        dr = cmd.ExecuteReader()

        Dim obj As String = "SU"
        Dim ResultConsulta(2) As String

        If dr.HasRows = True Then
            dr.Read()
            ResultConsulta(0) = dr.GetSqlInt32(0)
            ResultConsulta(1) = dr.GetString(1)
            obj = JsonConvert.SerializeObject(ResultConsulta)
        ElseIf dr.HasRows = False Then
            ResultConsulta(0) = "0"
            ResultConsulta(1) = "SU"
            obj = JsonConvert.SerializeObject(ResultConsulta)
        End If
        cerrar()
        Return obj
    End Function

End Class