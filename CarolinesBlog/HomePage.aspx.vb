Imports MySql.Data.MySqlClient

Public Class HomePage
    Inherits System.Web.UI.Page

    Private conn As MySqlConnection
    Private website_conn As New WebsiteMaster

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Get_Recent_Blog_Posts()
    End Sub
    Public Sub Get_Recent_Blog_Posts()
        Dim query As String = "SELECT * FROM blog_posts ORDER BY TIME_STAMP DESC LIMIT 3;"
        Dim dt As DataTable = website_conn.Get_DataTable(query, "blog_posts")
        Dim post_html As String = "<div class='blog-posts content-section'>"
        Dim close_div As String = "</div>"

        For Each row As DataRow In dt.Rows
            post_html &= "<div class='blog-post' data-id=" & row.Item("ID") & "'><div class='blog-image-container'><img src='" & row.Item("IMAGE_URL") & "'/><a class='button-link' href='" & row.Item("BLOG_URL") & "'><div class='gold-button blog-button pointer'><span class='button-text'>Read Post</span></div></a></div><span class='blog-Date'>" & row.Item("TIME_STAMP") & "</span><h2 class='blog-title'>" & row.Item("TITLE") & "</h2></div>"
        Next
        post_html &= close_div
        asp_rec_blogs.Text = post_html
    End Sub

End Class