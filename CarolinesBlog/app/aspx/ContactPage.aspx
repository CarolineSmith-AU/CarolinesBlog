<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Website.Master" CodeBehind="ContactPage.aspx.vb" Inherits="CarolinesBlog.ContactPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/app/css/ContactPage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/app/js/ContactPage.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-section">
        <div class="page-content-header">
            <h1 class="content-header">Get in touch with me</h1>
        </div>
        <form id="contact_form">
            <div id="name_row" class="form-row">
                <input id="first_name_input" class="input row-6" type="text" placeholder="First name" />
                <input id="last_name_input" class="input row-6" type="text" placeholder="Last name" />
            </div>
            <div id="email_addr_row" class="form-row">
                <input id="email_addr_input" class="input row-12" type="text" placeholder="*Email Address" required/>
            </div>
            <div id="message_row" class="form-row">
                <textarea id="message_input" class="input row-12" placeholder="*Message" required></textarea>
            </div>
            <div class="button-form-row">
                <input id="send_message_button" class="gold-button pointer" type="submit" value="Send">
            </div>
        </form>
    </div>
</asp:Content>
