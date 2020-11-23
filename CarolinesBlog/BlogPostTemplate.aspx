<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Blog.master" CodeBehind="BlogPostTemplate.aspx.vb" Inherits="CarolinesBlog.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/app/css/BlogPostTemplate.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BlogContent" runat="server">
    <div id="blog_content_container">
        <div id="blog_content">
            Hello
        </div>
    </div>
</asp:Content>
