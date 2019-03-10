Public Class WebForm4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "Administrador" Then
                Response.Redirect("tiendaug.aspx")



            ElseIf System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "Usuario" Then
                MsgBox("Entro")
                Dim script As String = "AnoActual();"
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "anioactual", script, True)
            ElseIf System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "SU" Then
                Response.Redirect("login.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("index.aspx")
        End Try
    End Sub

End Class