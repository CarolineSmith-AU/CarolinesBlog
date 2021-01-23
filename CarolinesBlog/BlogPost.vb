Public Class BlogPost
    Private blog_id As Integer
    Private title As String
    Private date_stamp As String
    Private blog_text As String
    Private blog_type As String
    Private image_url As String
    Private tags As ArrayList

    Public Sub New(blog_id As String, title As String, date_stamp As String, blog_text As String, blog_type As String, image_url As String, Optional ByVal tags As ArrayList = Nothing)
        Me.blog_id = blog_id
        Me.title = title
        Me.date_stamp = date_stamp
        Me.blog_text = blog_text
        Me.blog_type = blog_type
        Me.image_url = image_url
        Me.tags = tags
    End Sub

    Public Function Get_Blog_ID() As Integer
        Return Me.blog_id
    End Function

    Public Sub Set_Blog_ID(ByVal id As Integer)
        Me.blog_id = id
    End Sub

    Public Function Get_Title() As String
        Return Me.title
    End Function

    Public Sub Set_Title(ByVal title As String)
        Me.title = title
    End Sub

    Public Function Get_Date() As String
        Return Me.date_stamp
    End Function

    Public Sub Set_Date(ByVal date_stamp As String)
        Me.date_stamp = date_stamp
    End Sub

    Public Function Get_Blog_Text() As String
        Return Me.blog_text
    End Function

    Public Sub Set_Blog_Text(ByVal blog_text As String)
        Me.blog_text = blog_text
    End Sub

    Public Function Get_Blog_Type() As String
        Return Me.blog_type
    End Function

    Public Sub Set_Blog_Type(ByVal blog_type As String)
        Me.blog_type = blog_type
    End Sub

    Public Function Get_Image_URL() As String
        Return Me.image_url
    End Function

    Public Sub Set_Image_Url(ByVal image_url As String)
        Me.image_url = image_url
    End Sub

    Public Function Get_Tags() As ArrayList
        Return Me.tags
    End Function

    Public Sub Set_Tags(ByVal tags As ArrayList)
        Me.tags = tags
    End Sub
End Class
