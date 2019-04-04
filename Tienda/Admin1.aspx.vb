Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "Usuario" Then
                Response.Redirect("Admin1.aspx")
            ElseIf System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "SU" Then
                Response.Redirect("login.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("index.aspx")
        End Try
    End Sub

    <WebMethod()>
    Public Shared Function altaproducto(ByVal Cantidad As String, ByVal Codig As String, ByVal Descrip As String, ByVal Precio As String, ByVal Color As String, ByVal Talla As String) As Object

        Dim obj As String = "SU"
        Dim ResultConsulta(1) As String
        Try
            Dim ObjetoAdapador As New DataSet1TableAdapters.UGTableAdapter
            ObjetoAdapador.InsertarProductoNuevo(Cantidad, Codig, Descrip, Precio, Color, Talla, Codig + ".jpg")
            ResultConsulta(0) = "true"
            obj = JsonConvert.SerializeObject(ResultConsulta)
        Catch ex As Exception
            ResultConsulta(0) = "false"
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

    <WebMethod()>
    Public Function Prueba(ByVal Cantidad As String) As Object
        MsgBox("Hola Mundo")
        Dim obj As String = "SU"
        Dim filepath As String = Server.MapPath("\Upload")
        Return obj
    End Function

End Class