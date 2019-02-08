Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim Color As String
        Color = GridView1.SelectedValue
        MsgBox(Color)
    End Sub

    Protected Sub SqlDataSource1_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

    End Sub

    Protected Sub SqlDataSource2_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource2.Selecting

    End Sub
End Class