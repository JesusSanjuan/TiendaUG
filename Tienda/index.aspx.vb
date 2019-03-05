﻿Imports System.Data.SqlClient
Imports System.Web.Services
Imports Newtonsoft.Json

Public Class WebForm5
    Inherits System.Web.UI.Page

    Public Shared conn As SqlConnection = New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog = TiendaUG;")
    'Public Shared conn As SqlConnection = New SqlConnection("Data Source=.;Initial Catalog=TiendaUG;User ID=Sa;Password=Jesus1993")
    Public Shared cmd As SqlCommand
    Public Shared dr As SqlDataReader
    Public Shared Function conectar() As SqlConnection
        Try
            conn.Open()
            'MsgBox("Conectado")
        Catch ex As Exception
            MsgBox("Error con la conexion de base de datos")
        End Try
        Return conn
    End Function

    Public Shared Function cerrar() As SqlConnection
        conn.Close()
        Return conn
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        System.Web.HttpContext.Current.Session(“tipo_user”) = "SU"
    End Sub

    <WebMethod()>
    Public Shared Function testmethod(ByVal User As String, ByVal Password As String) As Object
        conectar()
        Dim consulta As String = "SELECT Id_usuario,Tipo_user FROM  Users WHERE UserName = '" + User + "' and  Contrasena='" + Password + "'"
        cmd = New SqlCommand(consulta, conn)
        dr = cmd.ExecuteReader()

        Dim obj As String = "SU"
        Dim ResultConsulta(2) As String

        If dr.HasRows = True Then
            dr.Read()
            System.Web.HttpContext.Current.Session(“id_user”) = dr.GetSqlInt32(0)
            System.Web.HttpContext.Current.Session(“tipo_user”) = dr.GetString(1)
            ResultConsulta(0) = dr.GetSqlInt32(0)
            ResultConsulta(1) = dr.GetString(1)
            obj = JsonConvert.SerializeObject(ResultConsulta)
        ElseIf dr.HasRows = False Then
            ResultConsulta(0) = "0"
            ResultConsulta(1) = "SU"
            System.Web.HttpContext.Current.Session(“tipo_user”) = "SU"
            obj = JsonConvert.SerializeObject(ResultConsulta)
        End If
        cerrar()
        Return obj
    End Function

End Class