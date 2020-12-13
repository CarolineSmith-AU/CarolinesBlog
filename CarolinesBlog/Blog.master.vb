Imports System
Imports System.Data
Imports System.IO
Imports System.Collections.Specialized
Imports MySql.Data.MySqlClient

Public Class Blog
    Inherits System.Web.UI.MasterPage

    Private website_conn As New WebsiteMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim page_name As String = Path.GetFileName(Request.PhysicalPath)
        If String.Compare(page_name, "BlogPostTemplate.aspx") = 0 Then
            Get_Related_Posts()
        Else
            'Get_Recent_Posts()
        End If
    End Sub

    Public Sub Get_Related_Posts()
        Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim path As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim data_id As String = HttpContext.Current.Request.QueryString.Get("dataID")
        Dim get_curr_tags_query As String = "SELECT * FROM rel_blog_posts_keywords WHERE ID =" & data_id
        Dim curr_tags_dt As DataTable = website_conn.Get_DataTable(get_curr_tags_query, "rel_blog_posts_keywords")
        Dim close_html As String = "</div>"
        Dim related_html As String = "<div class='blog-nav-section' id='posts_popular_section'><h2>Related Posts</h2>"

        For Each row1 As DataRow In curr_tags_dt.Rows
            Dim get_rel_tags_query As String = "SELECT * FROM rel_blog_posts_keywords WHERE KEY_WORD = '" & row1.Item("KEY_WORD") & "' AND NOT ID = " & data_id & " LIMIT 10"
            Dim rel_tags_dt As DataTable = website_conn.Get_DataTable(get_rel_tags_query, "rel_blog_posts_keywords")
            For Each row2 As DataRow In rel_tags_dt.Rows
                Dim get_rel_posts_query As String = "SELECT * FROM blog_posts WHERE ID = " & row2.Item("ID")
                Dim rel_posts_dt As DataTable = website_conn.Get_DataTable(get_rel_posts_query, "blog_posts")
                For Each row3 As DataRow In rel_posts_dt.Rows
                    related_html &= "<a class='topic-row' data-id=" & row3.Item("ID") & " href='" & row3.Item("BLOG_URL") & "?dataID=" & row3.Item("ID") & "'><div class='topic-text'><span>" & row3.Item("TITLE") & "</span></div></a>"
                Next
            Next
        Next
        related_html &= close_html

        asp_blog_nav_posts.Text = related_html
    End Sub

End Class