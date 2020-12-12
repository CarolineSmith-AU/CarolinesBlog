Imports MySql.Data.MySqlClient

Public Class HomePage
    Inherits System.Web.UI.Page

    Private conn As MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Get_Recent_Blog_Posts()
    End Sub
    Public Sub Get_Recent_Blog_Posts()
        Try
            Init_Conn()

            Dim query As String = "SELECT * FROM blog_posts ORDER BY TIME_STAMP DESC LIMIT 3;"
            Dim da As New MySqlDataAdapter(query, conn)
            Dim ds As New DataSet()
            da.Fill(ds, "blog_posts")
            Dim dt As DataTable = ds.Tables("blog_posts")
            Dim post_html As String = "<div class='blog-posts content-section'>"
            Dim close_div As String = "</div>"

            For Each row As DataRow In dt.Rows
                post_html &= "<div class='blog-post' data-id=" & row.Item("ID") & "'><div class='blog-image-container'><img src='" & row.Item("IMAGE_URL") & "'/><a class='button-link' href='" & row.Item("BLOG_URL") & "'><div class='gold-button blog-button pointer'><span class='button-text'>Read Post</span></div></a></div><span class='blog-Date'>" & row.Item("TIME_STAMP") & "</span><h2 class='blog-title'>" & row.Item("TITLE") & "</h2></div>"
            Next
            post_html &= close_div
            asp_rec_blogs.Text = post_html
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