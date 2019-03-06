Imports System.Data.SqlClient

Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim ids As String
    Dim ds As New DataSet
    Dim da As OleDb.OleDbDataAdapter

    Public Shared conn As SqlConnection = New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog = TiendaUG;")
    'Public Shared conn As SqlConnection = New SqlConnection("Data Source=.;Initial Catalog=TiendaUG;User ID=Sa;Password=Jesus1993")
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public Function conectar() As SqlConnection
        Try
            conn.Open()
            'MsgBox("Conectado")
        Catch ex As Exception
            MsgBox("Error")
        End Try
        Return conn
    End Function

    Public Function cerrar() As SqlConnection
        conn.Close()
        Return conn
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' If System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "Usuario" Then
        'Response.Redirect("Admin2.aspx")
        ' ElseIf System.Web.HttpContext.Current.Session(“tipo_user”).ToString() = "SU" Then
        ' Response.Redirect("login.aspx")
        ' End If
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
        If dr.HasRows Then
            dr.Read()
            Codigo.Text = dr.GetSqlString(7)
            Descripcion.Text = dr.GetSqlString(2)
            Prec.Text = dr.GetDouble(3)
            Cant.Text = dr.GetSqlString(1)

            Color = dr.GetSqlString(5)
            Talla = dr.GetSqlString(6)
            Dim script As String = "operacion('" & Color & "','" & Talla & "');"
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "operacion", script, True)
        End If

        cerrar()



    End Sub

    Protected Sub SqlDataSource1_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting

    End Sub


    Private Sub Borrar_ServerClick(sender As Object, e As EventArgs) Handles Borrar.ServerClick
        Dim idNum As Integer = CType(idenPrinc.Text, Integer)
        Dim ObjetoAdapador As New DataSet1TableAdapters.UGTableAdapter
        Dim ObjetoDataSetCliente As New DataSet1TableAdapters.UGTableAdapter
        ObjetoAdapador.Borrar(idNum)
        MsgBox("Registro borrado con exito")
    End Sub

    Private Sub Mod_ServerClick(sender As Object, e As EventArgs) Handles [Mod].ServerClick
        Dim idNum As Integer = CType(idenPrinc.Text, Integer)
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
        Precio = Cant.Text

        If FileUpload1.HasFile Then
            'Dim filename As String
            'filename = Path.GetFileName(FileUpload1.FileName)
            FileUpload1.SaveAs(Server.MapPath("~/Imagen_server/imagen_" + Codig + ".jpg"))
        End If

        Dim ObjetoAdapador As New DataSet1TableAdapters.UGTableAdapter
        Dim ObjetoDataSetCliente As New DataSet1TableAdapters.UGTableAdapter
        ObjetoAdapador.Actualizar(Cantidad, Descrip, Precio, Color, Talla, "imagen_" + Codig, idNum)
        MsgBox("Actualizado con exito")
    End Sub

    Protected Sub Col_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Col.SelectedIndexChanged

    End Sub

    Protected Sub Cant_TextChanged(sender As Object, e As EventArgs) Handles Cant.TextChanged

    End Sub

    Protected Sub idenPrinc_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class