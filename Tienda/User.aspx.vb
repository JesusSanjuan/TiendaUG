Public Class WebForm4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "Administrador" Then
            Response.Redirect("User.aspx")
        ElseIf System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "SU" Then
            Response.Redirect("login.aspx")
        End If
    End Sub

End Class