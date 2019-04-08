Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json

Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim ids As String

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
        Dim idNum As Integer = CType(idenPrinc.Text, Integer)

        Dim table As New DataTable
        Dim ObjetoAdapador As New DataSet1TableAdapters.UGTableAdapter
        table = ObjetoAdapador.ConsultaTotalAdmin(idNum)

        Dim Color As String
        Dim Talla As String
        Dim Direccion As String

        Dim Contador As Integer = 0
        Dim row As DataRow = table.Rows(0)
        Codigo.Text = row.Item("Id_codigo")
        Descripcion.Text = row.Item("Descripcion")
        Prec.Text = row.Item("Precio")
        Cant.Text = row.Item("Cantidad")
        Color = row.Item("Color")
        Talla = row.Item("Talla")
        Direccion = row.Item("id_imagen")



        Dim script As String = "operacion('" & Color & "','" & Talla & "','" & Direccion & "');"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "operacion", script, True)

    End Sub
    <WebMethod()>
    Public Shared Function modificar(ByVal Cantidad As String, ByVal Codig As String, ByVal Descript As String, ByVal Precio As String, ByVal Color As String, ByVal Talla As String, ByVal idProductos As String) As Object
        Dim obj As String = "NO"
        Dim ResultConsulta(1) As String
        Try
            Dim idNum As Integer = CType(idProductos, Integer)
            Dim ObjetoAdapador As New DataSet1TableAdapters.UGTableAdapter
            Dim ObjetoDataSetCliente As New DataSet1TableAdapters.UGTableAdapter
            ObjetoAdapador.Actualizar(Cantidad, Descript, Precio, Color, Talla, "imagen_" + Codig + ".jpg", Codig, idNum)
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