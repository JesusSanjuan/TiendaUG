Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json

Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim ids As String
    Dim ds As New DataSet
    Dim da As OleDb.OleDbDataAdapter

    Public Shared conn As SqlConnection = New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog = TiendaUG;")
    'Public Shared conn As SqlConnection = New SqlConnection("Data Source=.;Initial Catalog=TiendaUG;User ID=Sa;Password=Jesus1993")
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
        Try
            If System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "Usuario" Then
                Response.Redirect("Admin1.aspx")
            ElseIf System.Web.HttpContext.Current.Session("tipo_user").ToString() = "SU" Then
                Response.Redirect("login.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("index.aspx")
        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        ids = GridView1.SelectedValue
        idenPrinc.Text = ids

        conectar()
        ' MsgBox("INSERT INTO UG(Cantidad,Descripcion,Precio,Color,Talla,Id_imagen) VALUES('" + Cantidad + "','" + Descrip + "','" + Precio + "','" + Color + "','" + Talla + "','imagen_" + aStr + ".jpg')")
        Dim idNum As Integer = CType(idenPrinc.Text, Integer)
        'Se genera el String de la Consulta
        Dim consulta As String = "SELECT Id_codigo, Cantidad, Descripcion, Precio, Color, Talla, id_imagen, Codigo FROM  UG WHERE Id_codigo =@idStaff"
        'Agregamos la sentencia SQL y la conexion
        cmd = New SqlCommand(consulta, conn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@idStaff", SqlDbType.Int)
        cmd.Parameters("@idStaff").Value = idNum
        dr = cmd.ExecuteReader()

        Dim Color As String
        Dim Talla As String
        Dim Direccion As String
        If dr.HasRows Then
            dr.Read()
            Codigo.Text = dr.GetSqlString(7)
            Descripcion.Text = dr.GetSqlString(2)
            Prec.Text = dr.GetDouble(3)
            Cant.Text = dr.GetSqlString(1)

            Color = dr.GetSqlString(4)
            Talla = dr.GetSqlString(5)
            Direccion = dr.GetSqlString(6)
            Dim script As String = "operacion('" & Color & "','" & Talla & "','" & Direccion & "');"
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "operacion", script, True)
        End If
        cerrar()
    End Sub
    <WebMethod()>
    Public Shared Function modificar(ByVal Cantidad As String, ByVal Codig As String, ByVal Descript As String, ByVal Precio As String, ByVal Color As String, ByVal Talla As String, ByVal idProductos As String) As Object
        Dim obj As String = "NO"
        Dim ResultConsulta(1) As String
        Try
            Dim idNum As Integer = CType(idProductos, Integer)
            Dim ObjetoAdapador As New DataSet1TableAdapters.UGTableAdapter
            Dim ObjetoDataSetCliente As New DataSet1TableAdapters.UGTableAdapter
            ObjetoAdapador.Actualizar(Cantidad, Descript, Precio, Color, Talla, "imagen_" + Codig + ".jpg", idNum)
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
    <WebMethod()>
    Public Shared Function eliminarproducto(ByVal idProductos As String) As Object
        Dim obj As String = "NO"
        Dim ResultConsulta(1) As String
        Try
            Dim idNum As Integer = CType(idProductos, Integer)
            Dim ObjetoAdapador As New DataSet1TableAdapters.UGTableAdapter
            Dim ObjetoDataSetCliente As New DataSet1TableAdapters.UGTableAdapter
            ObjetoAdapador.Borrar(idNum)
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
    <WebMethod()>
    Public Shared Function cerrarsesion(ByVal Dato1 As String) As Object
        Dim obj As String = "NO"
        Dim ResultConsulta(1) As String
        Try
            System.Web.HttpContext.Current.Session(“id_user”) = "SU"
            System.Web.HttpContext.Current.Session(“tipo_user”) = ""
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