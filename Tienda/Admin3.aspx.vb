Public Class Admin3
    Inherits System.Web.UI.Page
    Dim idPedido As String
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

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        idPedido = GridView1.SelectedValue

        Dim table As New DataTable
        Dim ObjetoAdapador As New DataSet1TableAdapters.carritoTableAdapter
        table = ObjetoAdapador.ConsultaPedidoAdmin(idPedido, idPedido)

    End Sub
End Class