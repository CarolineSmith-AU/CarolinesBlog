Imports System.Net.Mail
Imports System.IO
Imports System.Web.Services
Imports MailMessage = System.Net.Mail.MailMessage
Imports System.Net.Mime
Imports Newtonsoft.Json.Linq

Public Class Mail
    Inherits System.Web.UI.Page

    Private Const blogger_id As Integer = 1
    Private Const From_Name As String = "BlackGirlGolden"
    'Private Const Email_From As String = "cleeannsmith@gmail.com"
    'Private Const Email_Password As String = "38r7Zy0!_~"
    Private Const Email_From As String = "blackgirlgolden@gmail.com"
    Private Const Email_Password As String = "beebop11"

    'Social Media Links
    Private Const Instagram_Link As String = ""
    Private Const Facebook_Link As String = ""
    Private Const Twitter_Link As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Build email for new blog post notification
    <WebMethod()> Public Shared Sub Email_Send_Blog_Notif(ByVal post As BlogPost)
        Dim mailBodyHTML As String = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "app\email_templates\NewBlogPost.html")
        'Dim blogURL As String = "https://blackgirlgolden.com/blog/" & post.Get_Blog_ID.ToString() & "/" & post.Get_Title().Replace()
        Dim resultHTML As String = String.Format(mailBodyHTML, post.Get_Title(), post.Get_Blog_Text(), "https://blackgirlgolden.com")

        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(resultHTML, Encoding.UTF8, "text/html")

        Dim blogImage As LinkedResource = Create_Linked_Resource("C:\Users\cleea\source\repos\CarolineSmith-AU\VintageBlogTemp\CarolinesBlog" & post.Get_Image_URL().Replace("/", "\"), "imageID")
        htmlView.LinkedResources.Add(blogImage)
        Dim instaImage As LinkedResource = Create_Linked_Resource("C:\Users\cleea\source\repos\CarolineSmith-AU\VintageBlogTemp\CarolinesBlog\app\Images\instagram_black.jpg", "instagramID")
        htmlView.LinkedResources.Add(instaImage)
        Dim fbImage As LinkedResource = Create_Linked_Resource("C:\Users\cleea\source\repos\CarolineSmith-AU\VintageBlogTemp\CarolinesBlog\app\Images\facebook_black.jpg", "facebookID")
        htmlView.LinkedResources.Add(fbImage)

        Dim jsonString As String = EndpointMaster.Get_Subscribers()
        Dim emailJSON As JToken = JToken.Parse(jsonString)
        Dim emailArray As JArray = emailJSON.Item("EMAILS")
        For Each email In emailArray
            Dim addrFrom As MailAddress = New MailAddress(Email_From, From_Name)
            Dim addrTo As MailAddress = New MailAddress(email.Value(Of String)("EMAIL").ToString())
            Dim message As MailMessage = New MailMessage(addrFrom, addrTo)
            message.Subject = "New blog post! BlackGirlGolden"
            message.AlternateViews.Add(htmlView)
            message.IsBodyHtml = True

            Send_Mail(message)
        Next
    End Sub

    <WebMethod> Public Shared Sub Send_Mail_To_Blogger(firstname As String, lastname As String, returnEmail As String, body As String)
        Dim mailBodyHTML As String = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "app\email_templates\ContactBlogger.html")
        Dim resultHTML As String = String.Format(mailBodyHTML, firstname, firstname & " " & lastname, body, firstname, returnEmail)
        Dim addrFrom As MailAddress = New MailAddress(returnEmail, firstname)
        Dim addrTo As MailAddress = New MailAddress(Email_From)
        Dim message As MailMessage = New MailMessage(addrFrom, addrTo)

        message.Subject = firstname & " " & lastname & " has messaged you!"
        message.IsBodyHtml = True
        message.Body = resultHTML

        Send_Mail(message)
    End Sub

    Public Shared Function Create_Linked_Resource(ByVal imgURL As String, ByVal cid As String)
        Dim imgExt As String = imgURL.Substring(imgURL.LastIndexOf(".") + 1)
        Dim resourceType As String = ""
        Select Case imgExt
            Case "png"
                resourceType = "image/jpeg"
            Case "jpg"
                resourceType = "image/jpeg"
            Case Else
                resourceType = ""
        End Select
        Dim resource As LinkedResource = New LinkedResource(imgURL, resourceType)
        resource.ContentId = cid
        resource.ContentLink = New Uri("cid:" & resource.ContentId)
        Return resource
    End Function

    'Sets up client and sends email
    Public Shared Sub Send_Mail(ByRef message As MailMessage)
        Try
            Dim client As SmtpClient = New SmtpClient()
            client.Host = "smtp.gmail.com"
            client.Port = 587
            client.UseDefaultCredentials = False
            client.Credentials = New System.Net.NetworkCredential(Email_From, Email_Password)
            client.EnableSsl = True
            client.Send(message)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Class