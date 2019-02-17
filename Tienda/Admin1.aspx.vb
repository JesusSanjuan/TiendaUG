Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json
Imports System.Configuration

Public Class WebForm1




    Inherits System.Web.UI.Page
    Public Shared conn As SqlConnection = New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog = TiendaUG;")
    Public Shared cmd As SqlCommand
    Public Shared dr As SqlDataReader
    Friend Shared Function GetConnectionString(nameConnectionString As String) As String

        ' Obtenemos el archivo de configuración de la aplicación. 
        ' 
        Dim config As Configuration =
       ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

        ' Devolvemos la cadena de conexión que se corresponda con el nombre especificado.
        '
        Dim cs As ConnectionStringSettings = config.ConnectionStrings.ConnectionStrings(nameConnectionString)

        If (cs Is Nothing) Then _
        Throw New ArgumentNullException("nameConnectionString", "No se ha especificado la cadena de conexión.")

        Dim connString As String = cs.ConnectionString
        If (connString = String.Empty) Then _
       Throw New ArgumentNullException("nameConnectionString", "No se ha especificado la cadena de conexión.")

        Return connString

    End Function


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

        Dim cadenaConexion As String = NombreClase.GetConnectionString("MiCadenaConexion")

    End Sub

    <WebMethod()>
    Public Shared Function altaproducto(ByVal Cantidad As String, ByVal Codig As String, ByVal Descrip As String, ByVal Precio As String, ByVal Color As String, ByVal Talla As String) As Object


        conectar()
        Dim obj As String = "SU"
        Dim ResultConsulta(1) As String
        Dim consulta As String = "INSERT INTO UG(Cantidad,Codigo,Descripcion,Precio,Color,Talla,Id_imagen) VALUES('" + Cantidad + "','" + Codig + "','" + Descrip + "','" + Precio + "','" + Color + "','" + Talla + "','imagen_" + Codig + ".jpg')"
        'Agregamos la sentencia SQL y la conexion
        cmd = New SqlCommand(consulta, conn)
        'Establecemos una variable auxiliar  para determinar si la consulta se ejecuta bien o no
        Dim i As Integer = cmd.ExecuteNonQuery()
        'compara si la consulta fue hecha bien si esta es mayor que 1

        If i > 0 Then
            'Si la consulta es correcta manda este mensaje
            ResultConsulta(0) = "true"
            obj = JsonConvert.SerializeObject(ResultConsulta)
        Else
            'si la consulta es incorrecta manda el siguiente mensaje
            ResultConsulta(0) = "false"
            obj = JsonConvert.SerializeObject(ResultConsulta)
        End If
        cerrar()
        Return obj
    End Function


    <WebMethod()>
    Public Function Prueba(ByVal Cantidad As String) As Object
        MsgBox("Hola Mundo")
        Dim obj As String = "SU"
        Dim filepath As String = Server.MapPath("\Upload")
        Return obj
    End Function

    Protected Sub Descripcion_TextChanged(sender As Object, e As EventArgs) Handles Descripcion.TextChanged

    End Sub
End Class