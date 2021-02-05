<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Website.Master" CodeBehind="Unsubscribe.aspx.vb" Inherits="CarolinesBlog.Unsubscribe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/app/css/Form.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-section">
        <div class="page-content-header">
            <h1 class="content-header form-header">Are you sure you want to unsubscribe?</h1>
            <p class="form-subtext">Enter the email you want removed from the mailing list.</p>
        </div>
        <form id="contact_form">
            <div id="email_row" class="form-row">
                <input id="email_input" class="input row-6" name="email" type="text" placeholder="*Email" required />
            </div>
            <div class="button-form-row">
                <input id="unsub_button" class="gold-button pointer" type="submit" value="Unsubscribe" />
            </div>
        </form>
    </div>
</asp:Content>
