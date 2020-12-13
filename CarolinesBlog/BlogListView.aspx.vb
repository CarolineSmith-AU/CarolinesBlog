Imports System
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class BlogListView
    Inherits System.Web.UI.Page

    Private website_conn As New WebsiteMaster

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Get_All_Blog_Posts()
    End Sub

    Public Sub Get_All_Blog_Posts()
        Dim query As String = "SELECT * FROM blog_posts ORDER BY TIME_STAMP DESC;"
        Dim dt As DataTable = website_conn.Get_DataTable(query, "blog_posts")
        Dim post_html As String = ""

        For Each row As DataRow In dt.Rows
            post_html &= "<a class='blog-content' href='" & row.Item("BLOG_URL") & "?dataID=" & row.Item("ID") & "'><div data-id=" & row.Item("ID") & "><h1 class='blog-post-header'>" & row.Item("TITLE") & "</h1><div class='blog-post-Date'><span>" & row.Item("TIME_STAMP") & "</span></div><img class='blog-post-picture' src='" & row.Item("IMAGE_URL") & "' width='100%' height: 'auto';><p>" & row.Item("POST").Substring(0, 200) & "..." & "</p></div></a>"
        Next
        asp_blog_container.Text = post_html
    End Sub

End Class