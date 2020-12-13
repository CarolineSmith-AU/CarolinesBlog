Imports MySql.Data.MySqlClient

Public Class WebsiteMaster
    Inherits System.Web.UI.MasterPage

    Private conn As MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub Init_Conn()
        Dim connstring As String = "server=aws-blogdb.cs5jheun794a.us-east-2.rds.amazonaws.com;
            userid=admin;
            password=hU8f6Dww;
            database=blogdb"

        conn = New MySqlConnection(connstring)
        conn.Open()
    End Sub

    Public Sub Close_Conn()
        If conn IsNot Nothing Then
            conn.Close()
        End If
    End Sub

    Public Function Get_Conn()
        Return Me.conn
    End Function

    Public Function Get_DataTable(ByVal query As String, ByVal data_table As String)
        Dim dt As DataTable
        Try
            Init_Conn()
            Dim da As New MySqlDataAdapter(query, CType(conn, MySqlConnection))
            Dim ds As New DataSet()
            da.Fill(ds, data_table)
            dt = ds.Tables(data_table)
            Return dt
        Catch ex As Exception
            Console.WriteLine("Error: {0}", ex.ToString())
        Finally
            Close_Conn()
        End Try
        Return Nothing
    End Function

    Public Sub Subscribe_To_Blog(ByVal email As String)
        Dim query As String = "INSERT INTO sub_email_list (EMAIL_ADDR, IS_SUBSCRIBED) VALUES(" & email & ", 1"
    End Sub
End Class