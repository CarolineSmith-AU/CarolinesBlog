Imports System
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class BlogListView
    Inherits System.Web.UI.Page

    Private conn As MySqlConnection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Get_All_Blog_Posts()
    End Sub

    Public Sub Get_All_Blog_Posts()
        Try
            Init_Conn()

            Dim query As String = "SELECT * FROM blog_posts;"
            Dim da As New MySqlDataAdapter(query, conn)
            Dim ds As New DataSet()
            da.Fill(ds, "blog_posts")
            Dim dt As DataTable = ds.Tables("blog_posts")
            Dim post_html As String = ""

            For Each row As DataRow In dt.Rows
                post_html &= "<div id='blog_content'><h1 class='blog-post-header'>" & row.Item("TITLE") & "</h1><div class='blog-post-Date'><span>" & row.Item("TIME_STAMP") & "</span></div><img class='blog-post-picture' src='" & row.Item("IMAGE_URL") & "' width='100%' height: 'auto';><p>" & row.Item("POST").Substring(0, 200) & "..." & "</p></div>"
            Next
            asp_blog_container.Text = post_html
        Catch ex As Exception
            Console.WriteLine("Error: {0}", ex.ToString())
        Finally
            Close_Conn()
        End Try
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

End Class