Imports System.Net.Mail
Imports System.IO
Imports System.Web.Services
Imports MailMessage = System.Net.Mail.MailMessage
Imports System.Net.Mime

Public Class Mail
    Inherits System.Web.UI.Page

    Private Const blogger_id As Integer = 1
    Private Const Email_From As String = "cleeannsmith@gmail.com"
    Private Const Email_Password As String = "Cls-311815129145"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim post As New BlogPost("1", "Test Blog Title", "01/21/2021", "Blog post body.......", 1, "C:\Users\cleea\source\repos\CarolineSmith-AU\CarolinesBlog\CarolinesBlog\app\Images\gardenia_square_2.jpg")
        Email_Send_Blog_Notif(post)
    End Sub

    <WebMethod()> Public Shared Sub Email_Send_Blog_Notif(ByVal post As BlogPost)
        Try
            Dim mailBodyHTML As String = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "app\email_templates\NewBlogPost.html")
            Dim resultHTML As String = String.Format(mailBodyHTML, post.Get_Title(), post.Get_Blog_Text(), "https://localhost:44378/")
            Dim addrFrom As MailAddress = New MailAddress(Email_From, "Caroline Smith")
            Dim addrTo As MailAddress = New MailAddress("csmith0097@gmail.com")
            Dim message As MailMessage = New MailMessage(addrFrom, addrTo)
            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(resultHTML, Encoding.UTF8, MediaTypeNames.Text.Html)
            Dim emailImage As LinkedResource = New LinkedResource(post.Get_Image_URL(), MediaTypeNames.Image.Jpeg)
            emailImage.ContentId = "imageID"
            emailImage.ContentType.Name = emailImage.ContentId
            emailImage.ContentLink = New Uri("cid:" & emailImage.ContentId)
            htmlView.LinkedResources.Add(emailImage)
            message.Subject = "New blog post! BlackGirlGolden"
            message.IsBodyHtml = False
            message.AlternateViews().Add(htmlView)
            'message.Body = resultHTML

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