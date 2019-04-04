Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json

Public Class WebForm5
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        System.Web.HttpContext.Current.Session(“tipo_user”) = "SU"
    End Sub

    <WebMethod()>
    Public Shared Function testmethod(ByVal User As String, ByVal Password As String) As Object
        Dim table1 As New DataTable
        Dim ObjetoAdapador1 As New DataSet1TableAdapters.UsersTableAdapter
        table1 = ObjetoAdapador1.Selec_Login(User, Password)
        Dim obj As String = "SU"
        Dim ResultConsulta(2) As String

        If table1.Rows.Count > 0 Then
            Dim row As DataRow = table1.Rows(0)
            System.Web.HttpContext.Current.Session("id_user") = Row.Item("Id_usuario")
            System.Web.HttpContext.Current.Session("tipo_user") = Row.Item("Tipo_user")
            ResultConsulta(0) = Row.Item("Id_usuario")
            ResultConsulta(1) = Row.Item("Tipo_user")
            obj = JsonConvert.SerializeObject(ResultConsulta)
        ElseIf table1.Rows.Count = 0 Then
            ResultConsulta(0) = "0"
            ResultConsulta(1) = "SU"
            System.Web.HttpContext.Current.Session("tipo_user") = "SU"
            obj = JsonConvert.SerializeObject(ResultConsulta)
        End If
        Return obj
    End Function

End Class