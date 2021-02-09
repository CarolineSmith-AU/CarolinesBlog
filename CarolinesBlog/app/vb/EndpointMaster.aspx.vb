Imports MySql.Data.MySqlClient
Imports System.Web.Services
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Web.SessionState
Imports System.IO

Public Class EndpointMaster
    Inherits System.Web.UI.Page
    Implements IReadOnlySessionState

    Private Const blogger_id As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    <WebMethod()> Public Shared Sub Subscribe_To_Blog(ByVal email_addr As String)
        Dim query2 As String = "SELECT * FROM sub_email_list WHERE EMAIL_ADDR = '" & email_addr & "' and BLOGGER_ID = " & blogger_id
        Dim dt As DataTable = Get_DataTable(query2, "blogdb")
        If dt.Rows.Count = 0 Then
            Dim query As String = "INSERT INTO sub_email_list (EMAIL_ADDR, IS_SUBSCRIBED, BLOGGER_ID) VALUES('" & email_addr & "', 1, " & blogger_id & ")"
            Update_SQL_DB(query, "blogdb")
        Else
            Return
        End If
    End Sub

    <WebMethod()> Public Shared Sub Unsubscribe_From_Blog(ByVal email_addr As String)
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

    Public Shared Function Get_Image_URLs()
        Dim images As Array = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory & "app\Images")
        Dim cleaned_urls As ArrayList = New ArrayList
        For Each image As String In images
            cleaned_urls.Add(image.Substring(image.IndexOf("\app")).Replace("\", "/"))
        Next
        Return cleaned_urls
    End Function

    <WebMethod()>
    Public Shared Function Get_Blog_Data()
        Dim blog_type_query As String = "SELECT * FROM blog_types WHERE BLOGGER_ID = " & blogger_id
        Dim dt As DataTable = Get_DataTable(blog_type_query, "blog_types")
        Dim types As New JArray

        For Each row As DataRow In dt.Rows
            types.Add(New JObject(New JProperty("BLOG_TYPE_INT", row.Item("TYPE_INT")),
                New JProperty("BLOG_TYPE_NAME", row.Item("TYPE_NAME"))))
        Next

        Dim images As ArrayList = Get_Image_URLs()

        Dim output As New JObject(New JProperty("TYPES", types),
            New JProperty("IMAGES", images))
        Return output.ToString()
    End Function

    <WebMethod()> Public Shared Function Get_Recent_Blog_Posts(ByVal num_to_get As Integer) As String
        Dim query As String = "SELECT * FROM blog_posts WHERE BLOGGER_ID = " & blogger_id & " ORDER BY TIME_STAMP DESC" & If(num_to_get = -1, "", " LIMIT " & num_to_get.ToString() & ";")
        Dim dt As DataTable = Get_DataTable(query, "blog_posts")
        Dim posts As New JArray

        For Each row As DataRow In dt.Rows
            Dim tags_array As ArrayList = Get_Tags(row.Item("BLOG_ID"))
            Dim post As BlogPost = New BlogPost(row.Item("BLOG_ID"), row.Item("TITLE"), row.Item("TIME_STAMP"), row.Item("POST"), row.Item("BLOG_TYPE"), row.Item("IMAGE_URL"), tags_array)
            posts.Add(New JObject(New JProperty("BLOG_ID", post.Get_Blog_ID()),
                New JProperty("TITLE", post.Get_Title()),
                New JProperty("DATE", post.Get_Date()),
                New JProperty("BLOG_TEXT", post.Get_Blog_Text()),
                New JProperty("BLOG_TYPE", post.Get_Blog_Type()),
                New JProperty("IMAGE_URL", post.Get_Image_URL()),
                New JProperty("TAGS", post.Get_Tags())))
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
                New JProperty("IMAGE_URL", post.Get_Image_URL()),
                New JProperty("TAGS", Get_Tags(post.Get_Blog_ID()))))
        Next
        Dim output As New JObject(New JProperty("POSTS", posts))
        Return output.ToString()
    End Function

    <WebMethod()> Public Shared Function Get_Posts_By_Type(ByVal blog_id As String, ByVal num_to_get As Integer) As String
        Dim get_blog_type As String = "select BLOG_TYPE from blog_posts where BLOG_ID = " & blog_id & " and BLOGGER_ID = " & blogger_id & ";"
        Dim type_dt As DataTable = Get_DataTable(get_blog_type, "blog_posts")
        Dim type As Integer

        For Each row As DataRow In type_dt.Rows
            type = row.Item("BLOG_TYPE")
        Next

        Dim query As String = "Select * from (Select blog_posts.BLOGGER_ID, blog_posts.BLOG_ID, blog_posts.TITLE, blog_posts.TIME_STAMP, blog_posts.POST, blog_posts.IMAGE_URL, blog_posts.BLOG_TYPE, blog_types.TYPE_NAME
	                           from blog_posts INNER JOIN blog_types on blog_posts.BLOGGER_ID = blog_types.BLOGGER_ID and blog_posts.BLOG_TYPE = blog_types.TYPE_INT)
                               AS b where b.BLOG_TYPE = " & type & " and b.BLOGGER_ID = " & blogger_id & "and NOT b.BLOG_ID = " & blog_id & " ORDER BY TIME_STAMP DESC" & If(num_to_get = -1, "", " LIMIT " & num_to_get.ToString() & ";")
        Dim dt As DataTable = Get_DataTable(query, "blog_posts")
        Dim posts As New JArray

        For Each row As DataRow In dt.Rows
            Dim post As BlogPost = New BlogPost(row.Item("BLOG_ID"), row.Item("TITLE"), row.Item("TIME_STAMP"), row.Item("POST"), row.Item("TYPE_NAME"), row.Item("IMAGE_URL"))
            posts.Add(New JObject(New JProperty("BLOG_ID", post.Get_Blog_ID()),
                New JProperty("TITLE", post.Get_Title()),
                New JProperty("DATE", post.Get_Date()),
                New JProperty("BLOG_TEXT", post.Get_Blog_Text()),
                New JProperty("TYPE_NAME", post.Get_Blog_Type()),
                New JProperty("IMAGE_URL", post.Get_Image_URL())))
        Next
        Dim output As New JObject(New JProperty("POSTS", posts))
        Return output.ToString()
    End Function

    'Fix
    <WebMethod()> Public Shared Function Get_Related_Posts_By_Tags(ByVal blog_id As Integer, ByVal num_to_get As Integer)
        'Get all tages related to the current blogger and related to blog parameter
        Dim tags_array As ArrayList = Get_Tags(blog_id)
        Dim posts As New JArray

        'Iterate through blog tags
        For Each tag As String In tags_array
            Dim get_rel_blogs_query As String = "Select * from (Select blog_posts.BLOGGER_ID, blog_posts.IMAGE_URL, blog_posts.TIME_STAMP, blog_posts.TITLE, blog_posts.POST, blog_posts.BLOG_TYPE, blog_posts.BLOG_ID from blog_posts
	                                            INNER JOIN rel_blog_posts_keywords ON rel_blog_posts_keywords.KEY_WORD Like '%" & tag & "%' and
	                                            blog_posts.BLOG_ID = rel_blog_posts_keywords.BLOG_ID)
                                                As rb where rb.BLOGGER_ID = " & blogger_id & " and NOT rb.BLOG_ID = " & blog_id & " ORDER BY rb.TIME_STAMP DESC" & If(num_to_get = -1, "", " LIMIT " & num_to_get.ToString() & ";")
            Dim rel_posts_dt As DataTable = Get_DataTable(get_rel_blogs_query, "rel_blog_posts_keywords")

            'Add each found related blog post to 'rec_posts' JArray
            For Each row2 As DataRow In rel_posts_dt.Rows
                Dim tags_array_2 As ArrayList = Get_Tags(row2.Item("BLOG_ID"))

                Dim post As BlogPost = New BlogPost(row2.Item("BLOG_ID"), row2.Item("TITLE"), row2.Item("TIME_STAMP"), row2.Item("POST"), "", row2.Item("IMAGE_URL"), tags_array_2)
                Dim jObj As JObject = New JObject(New JProperty("BLOG_ID", post.Get_Blog_ID()),
                    New JProperty("TITLE", post.Get_Title()),
                    New JProperty("DATE", post.Get_Date()),
                    New JProperty("BLOG_TEXT", post.Get_Blog_Text()),
                    New JProperty("TYPE_NAME", post.Get_Blog_Type()),
                    New JProperty("IMAGE_URL", post.Get_Image_URL()),
                    New JProperty("TAGS", post.Get_Tags()))
                posts.Add(jObj)

            Next
        Next
        Dim output As New JObject(New JProperty("POSTS", posts))
        Return output.ToString()
    End Function

    Public Shared Function Get_Tags(ByVal blog_id As Integer)
        Dim get_curr_tags_query As String = "Select * FROM rel_blog_posts_keywords WHERE BLOG_ID = " & blog_id & " And BLOGGER_ID = " & blogger_id
        Dim tags_dt As DataTable = Get_DataTable(get_curr_tags_query, "rel_blog_posts_keywords")
        Dim tags_array As ArrayList = New ArrayList

        'Get tags of current post
        For Each row3 As DataRow In tags_dt.Rows
            tags_array.Add(row3.Item("KEY_WORD"))
        Next
        Return tags_array
    End Function

    <WebMethod()>
    Public Shared Sub Add_Post(ByVal password As String, blog_title As String, blog_image As String, blog_tags As String, blog_type As Integer, blog_post As String)
        If (password.Equals("hU8f6Dww")) Then
            Dim add_query As String = "Insert Into blog_posts (TITLE, TIME_STAMP, POST, IMAGE_URL, BLOGGER_ID, BLOG_TYPE) Values('" & blog_title & "', curdate(), '" & blog_post & "', '" & blog_image & "', " & blogger_id & ", " & blog_type & ");"
            Dim newID As Integer = Update_SQL_DB(add_query, "blog_posts")

            Dim tags_array As Array = blog_tags.Split(",")
            For Each tag In tags_array
                Dim tag_query As String = "Insert Into rel_blog_posts_keywords (BLOG_ID, KEY_WORD, BLOGGER_ID) Values(" & newID & ", '" & tag & "', " & blogger_id & ");"
                Update_SQL_DB(tag_query, "rel_blog_posts_keywords")
            Next
            Dim post As New BlogPost(newID, blog_title, "", blog_post, blogger_id, blog_image)
            Mail.Email_Send_Blog_Notif(post)
        Else
            Return
        End If
    End Sub

    <WebMethod()>
    Public Shared Sub Update_Post(ByVal password As String, blog_title As String, blog_image As String, blog_tags As String, blog_type As Integer, blog_post As String, blog_id As Integer)
        If (password.Equals("hU8f6Dww")) Then
            Dim update_query As String = "Update blog_posts Set TITLE = '" & blog_title & "', POST = '" & blog_post & "', IMAGE_URL = '" & blog_image & "', BLOG_TYPE = " & blog_type & " Where BLOG_ID = " & blog_id & " and BLOGGER_ID = " & blogger_id & ";"
            Update_SQL_DB(update_query, "blog_posts")

            Dim delete_tags As String = "Delete from rel_blog_posts_keywords where BLOG_ID = " & blog_id & " and BLOGGER_ID = " & blogger_id & ";"
            Update_SQL_DB(delete_tags, "blog_posts")

            Dim tags_array As Array = blog_tags.Split(",")
            For Each tag In tags_array
                Dim tag_query As String = "Insert Into rel_blog_posts_keywords (BLOG_ID, KEY_WORD, BLOGGER_ID) Values(" & blog_id & ", '" & tag & "', " & blogger_id & ");"
                Update_SQL_DB(tag_query, "rel_blog_posts_keywords")
            Next
        Else
            Return
        End If
    End Sub

    Public Shared Function Get_DataTable(ByVal query As String, ByVal data_table As String)
        Dim dt As DataTable
        Dim connstring As String = "server=aws-blogdb.cs5jheun794a.us-east-2.rds.amazonaws.com;
            userid=admin;
            password=hU8f6Dww;
            database=blogdb"

        '*****************Use below connection string for testing on local************************
        'Dim connstring As String = "host=localhost;
        '    port=3306;
        '    userid=root;
        '    password=hU8f6Dw;
        '    database=blogdb"
        '*****************************************************************************************
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

    Public Shared Function Update_SQL_DB(ByVal query As String, ByVal data_table As String)
        Dim newID
        Dim connstring As String = "server=aws-blogdb.cs5jheun794a.us-east-2.rds.amazonaws.com;
            userid=admin;
            password=hU8f6Dww;
            database=blogdb"

        '*****************Use below connection string for testing on local************************
        'Dim connstring As String = "host=localhost;
        '    port=3306;
        '    userid=root;
        '    password=hU8f6Dw;
        '    database=blogdb"
        '*****************************************************************************************

        Dim conn As New MySqlConnection(connstring)
        Try
            conn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
            cmd.ExecuteScalar()
            newID = cmd.LastInsertedId
            Return newID
        Catch ex As Exception
            Console.WriteLine("Error: {0}", ex.ToString())
        Finally
            If conn IsNot Nothing Then
                conn.Close()
            End If
        End Try
        Return Nothing
    End Function
End Class