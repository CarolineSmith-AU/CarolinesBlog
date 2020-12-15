Imports MySql.Data.MySqlClient
Imports System.Web.Services
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class EndpointMaster
    Inherits System.Web.UI.Page
    Implements IReadOnlySessionState

    Private Shared conn As MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    <WebMethod()> Public Shared Sub Subscribe_To_Blog(ByVal email_addr As String)
        Dim query As String = "INSERT INTO sub_email_list (EMAIL_ADDR, IS_SUBSCRIBED, BLOGGER_ID) VALUES('" & email_addr & "', 1, 1)"
        Try
            Init_Conn()
            Dim da As New MySqlDataAdapter(query, CType(conn, MySqlConnection))
            Dim ds As New DataSet()
            da.Fill(ds, "blogdb")
        Catch ex As Exception
            Console.WriteLine("Error: {0}", ex.ToString())
        Finally
            Close_Conn()
        End Try
    End Sub

    <WebMethod()> Public Shared Function Get_Recent_Blog_Posts(ByVal num_to_get As Integer) As String
        Dim query As String = "SELECT * FROM blog_posts WHERE BLOGGER_ID = 1 ORDER BY TIME_STAMP DESC LIMIT " & num_to_get.ToString() & ";"
        Dim dt As DataTable = Get_DataTable(query, "blog_posts")
        Dim posts As New JArray

        For Each row As DataRow In dt.Rows
            Dim post As BlogPost = New BlogPost(row.Item("BLOG_ID"), row.Item("TITLE"), row.Item("TIME_STAMP"), row.Item("POST"), row.Item("BLOG_TYPE"), row.Item("IMAGE_URL"), row.Item("BLOG_URL"))
            posts.Add(New JObject(New JProperty("BLOG_ID", row.Item("BLOG_ID").ToString()),
                New JProperty("TITLE", row.Item("TITLE")),
                New JProperty("DATE", row.Item("TIME_STAMP").ToString()),
                New JProperty("BLOG_TEXT", row.Item("POST")),
                New JProperty("BLOG_TYPE", row.Item("BLOG_TYPE").ToString()),
                New JProperty("IMAGE_URL", row.Item("IMAGE_URL")),
                New JProperty("BLOG_URL", row.Item("BLOG_URL").ToString() & "?dataID=" & row.Item("BLOG_ID").ToString())))
        Next
        Dim output As New JObject(New JProperty("POSTS", posts))
        Return output.ToString()
    End Function

    <WebMethod()> Public Shared Function Get_Related_Posts(ByVal blog_id As Integer)
        Dim get_curr_tags_query As String = "Select * FROM rel_blog_posts_keywords WHERE BLOG_ID = " & blog_id & " And BLOGGER_ID = " & 1
        Dim curr_tags_dt As DataTable = Get_DataTable(get_curr_tags_query, "rel_blog_posts_keywords")
        Dim rec_posts As New JArray

        For Each row1 As DataRow In curr_tags_dt.Rows
            Dim get_rel_tags_query As String = "Select * FROM rel_blog_posts_keywords WHERE BLOGGER_ID = " & 1 & " And KEY_WORD = '" & row1.Item("KEY_WORD") & "' AND NOT BLOG_ID = " & blog_id & " LIMIT 10"
            Dim rel_tags_dt As DataTable = Get_DataTable(get_rel_tags_query, "rel_blog_posts_keywords")
            For Each row2 As DataRow In rel_tags_dt.Rows
                Dim get_rel_posts_query As String = "SELECT * FROM blog_posts WHERE BLOGGER_ID = 1 AND BLOG_ID = " & row2.Item("BLOG_ID")
                Dim rel_posts_dt As DataTable = Get_DataTable(get_rel_posts_query, "blog_posts")
                For Each row3 As DataRow In rel_posts_dt.Rows
                    rec_posts.Add(New JObject(New JProperty("BLOG_ID", row3.Item("BLOG_ID").ToString()),
                        New JProperty("TITLE", row3.Item("TITLE")),
                        New JProperty("BLOG_URL", row3.Item("BLOG_URL") & "?dataID=" & row3.Item("BLOG_ID").ToString())))
                Next
            Next
        Next
        Dim output As New JObject(New JProperty("REC_POSTS", rec_posts))
        Return output.ToString()
    End Function

    Public Shared Function Get_DataTable(ByVal query As String, ByVal data_table As String)
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

    Public Shared Sub Init_Conn()
        Dim connstring As String = "server=aws-blogdb.cs5jheun794a.us-east-2.rds.amazonaws.com;
            userid=admin;
            password=hU8f6Dww;
            database=blogdb"

        conn = New MySqlConnection(connstring)
        conn.Open()
    End Sub

    Public Shared Sub Close_Conn()
        If conn IsNot Nothing Then
            conn.Close()
        End If
    End Sub

    Public Shared Function Get_Conn()
        Return conn
    End Function
End Class