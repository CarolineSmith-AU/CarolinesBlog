Imports MySql.Data.MySqlClient
Imports System.Web.Services
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Web.SessionState

Public Class EndpointMaster
    Inherits System.Web.UI.Page
    Implements IReadOnlySessionState

    Private Const blogger_id As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    <WebMethod()> Public Shared Sub Subscribe_To_Blog(ByVal email_addr As String)
        Dim query As String = "INSERT INTO sub_email_list (EMAIL_ADDR, IS_SUBSCRIBED, BLOGGER_ID) VALUES('" & email_addr & "', 1, " & blogger_id & ")"
        Update_SQL_DB(query, "blogdb")
    End Sub

    <WebMethod()> Public Shared Sub Unsubscribe_To_Blog(ByVal email_addr As String)
        Dim query As String = "DELETE FROM sub_email_list WHERE EMAIL_ADDR ='" & email_addr & "' AND BLOGGER_ID = " & blogger_id & ";"
        Update_SQL_DB(query, "blogdb")
    End Sub

    <WebMethod()> Public Shared Function Get_Subscribers()
        Dim query As String = "SELECT * FROM sub_email_list WHERE BLOGGER_ID = " & blogger_id
        Dim dt As DataTable = Get_DataTable(query, "sub_email_list")
        Dim emails As New JArray

        For Each row As DataRow In dt.Rows
            emails.Add(New JObject(New JProperty("EMAIL", row.Item("EMAIL_ADDR"))))
        Next
        Dim output As New JObject(New JProperty("EMAILS", emails))
        Return output.ToString()
    End Function

    <WebMethod()> Public Shared Function Get_Recent_Blog_Posts(ByVal num_to_get As Integer) As String
        Dim query As String = "SELECT * FROM blog_posts WHERE BLOGGER_ID = " & blogger_id & " ORDER BY TIME_STAMP DESC LIMIT " & num_to_get.ToString() & ";"
        Dim dt As DataTable = Get_DataTable(query, "blog_posts")
        Dim posts As New JArray

        For Each row As DataRow In dt.Rows
            Dim post As BlogPost = New BlogPost(row.Item("BLOG_ID"), row.Item("TITLE"), row.Item("TIME_STAMP"), row.Item("POST"), row.Item("BLOG_TYPE"), row.Item("IMAGE_URL"))
            posts.Add(New JObject(New JProperty("BLOG_ID", post.Get_Blog_ID()),
                New JProperty("TITLE", post.Get_Title()),
                New JProperty("DATE", post.Get_Date()),
                New JProperty("BLOG_TEXT", post.Get_Blog_Text()),
                New JProperty("BLOG_TYPE", post.Get_Blog_Type()),
                New JProperty("IMAGE_URL", post.Get_Image_URL())))
        Next
        Dim output As New JObject(New JProperty("POSTS", posts))
        Return output.ToString()
    End Function

    <WebMethod()> Public Shared Function Get_Single_Blog_Post(ByVal blog_id As Integer) As String
        Dim query As String = "SELECT * FROM blog_posts WHERE BLOGGER_ID = " & blogger_id & " AND BLOG_ID = " & blog_id & ";"
        Dim dt As DataTable = Get_DataTable(query, "blog_posts")
        Dim posts As New JArray

        For Each row As DataRow In dt.Rows
            Dim post As BlogPost = New BlogPost(row.Item("BLOG_ID"), row.Item("TITLE"), row.Item("TIME_STAMP"), row.Item("POST"), row.Item("BLOG_TYPE"), row.Item("IMAGE_URL"))
            posts.Add(New JObject(New JProperty("BLOG_ID", post.Get_Blog_ID()),
                New JProperty("TITLE", post.Get_Title()),
                New JProperty("DATE", post.Get_Date()),
                New JProperty("BLOG_TEXT", post.Get_Blog_Text()),
                New JProperty("BLOG_TYPE", post.Get_Blog_Type()),
                New JProperty("IMAGE_URL", post.Get_Image_URL())))
        Next
        Dim output As New JObject(New JProperty("POSTS", posts))
        Return output.ToString()
    End Function

    <WebMethod()> Public Shared Function Get_Posts_By_Type(ByVal blog_type As String) As String
        Dim query As String = "Select * from (Select blog_posts.BLOGGER_ID, blog_posts.BLOG_ID, blog_posts.TITLE, blog_posts.TIME_STAMP, blog_posts.POST, blog_posts.IMAGE_URL, blog_posts.BLOG_TYPE, blog_types.TYPE_NAME
	                           from blog_posts INNER JOIN blog_types on blog_posts.BLOGGER_ID = blog_types.BLOGGER_ID and blog_posts.BLOG_TYPE = blog_types.TYPE_INT)
                               AS b where b.BLOG_TYPE = " & blog_type & " and b.BLOGGER_ID = " & blogger_id & ";"
        Dim dt As DataTable = Get_DataTable(query, "blog_posts")
        Dim posts As New JArray

        For Each row As DataRow In dt.Rows
            Dim post As BlogPost = New BlogPost(row.Item("BLOG_ID"), row.Item("TITLE"), row.Item("TIME_STAMP"), row.Item("POST"), row.Item("TYPE_NAME"), row.Item("IMAGE_URL"))
            posts.Add(New JObject(New JProperty("BLOG_ID", post.Get_Blog_ID()),
                New JProperty("TITLE", post.Get_Title()),
                New JProperty("DATE", post.Get_Date()),
                New JProperty("BLOG_TEXT", post.Get_Blog_Text()),
                New JProperty("BLOG_TYPE", post.Get_Blog_Type()),
                New JProperty("IMAGE_URL", post.Get_Image_URL())))
        Next
        Dim output As New JObject(New JProperty("POSTS", posts))
        Return output.ToString()
    End Function

    'Fix
    <WebMethod()> Public Shared Function Get_Related_Posts_By_Tags(ByVal blog_id As Integer)
        'Get all tages related to the current blogger and related to blog parameter
        Dim get_curr_tags_query As String = "Select * FROM rel_blog_posts_keywords WHERE BLOG_ID = " & blog_id & " And BLOGGER_ID = " & blogger_id
        Dim curr_tags_dt As DataTable = Get_DataTable(get_curr_tags_query, "rel_blog_posts_keywords")
        Dim rec_posts As New JArray

        'Iterate through blog tags
        For Each row1 As DataRow In curr_tags_dt.Rows
            Dim tag As String = row1.Item("KEY_WORD")
            Dim get_rel_blogs_query As String = "Select * from (Select blog_posts.BLOGGER_ID, blog_posts.TITLE, blog_posts.BLOG_TYPE, blog_posts.BLOG_ID from blog_posts
	                                            INNER JOIN rel_blog_posts_keywords ON rel_blog_posts_keywords.KEY_WORD = '" & tag & "' and
	                                            blog_posts.BLOG_ID = rel_blog_posts_keywords.BLOG_ID)
                                                As rb where rb.BLOGGER_ID = " & blogger_id & " and NOT rb.BLOG_ID = " & blog_id & ";"
            Dim rel_posts_dt As DataTable = Get_DataTable(get_rel_blogs_query, "rel_blog_posts_keywords")

            'Add each found related blog post to 'rec_posts' JArray
            For Each row2 As DataRow In rel_posts_dt.Rows
                rec_posts.Add(New JObject(New JProperty("BLOG_ID", row2.Item("BLOG_ID").ToString()),
                        New JProperty("TITLE", row2.Item("TITLE")), New JProperty("BLOG_TYPE", row2.Item("BLOG_TYPE"))))
            Next
        Next
        Dim output As New JObject(New JProperty("POSTS", rec_posts))
        Return output.ToString()
    End Function

    Public Shared Function Get_DataTable(ByVal query As String, ByVal data_table As String)
        Dim dt As DataTable
        Dim connstring As String = "server=aws-blogdb.cs5jheun794a.us-east-2.rds.amazonaws.com;
            userid=admin;
            password=hU8f6Dww;
            database=blogdb"
        Dim conn As New MySqlConnection(connstring)
        Try
            conn.Open()
            Dim da As New MySqlDataAdapter(query, CType(conn, MySqlConnection))
            Dim ds As New DataSet()
            da.Fill(ds, data_table)
            dt = ds.Tables(data_table)
            Return dt
        Catch ex As Exception
            Console.WriteLine("Error: {0}", ex.ToString())
        Finally
            If conn IsNot Nothing Then
                conn.Close()
            End If
        End Try
        Return Nothing
    End Function

    Public Shared Sub Update_SQL_DB(ByVal query As String, ByVal data_table As String)
        Dim connstring As String = "server=aws-blogdb.cs5jheun794a.us-east-2.rds.amazonaws.com;
            userid=admin;
            password=hU8f6Dww;
            database=blogdb"
        Dim conn As New MySqlConnection(connstring)
        Try
            conn.Open()
            Dim da As New MySqlDataAdapter(query, CType(conn, MySqlConnection))
            Dim ds As New DataSet()
            da.Fill(ds, data_table)
        Catch ex As Exception
            Console.WriteLine("Error: {0}", ex.ToString())
        Finally
            If conn IsNot Nothing Then
                conn.Close()
            End If
        End Try
    End Sub
End Class