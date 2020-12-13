<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Blog.master" CodeBehind="BlogListView.aspx.vb" Inherits="CarolinesBlog.BlogListView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/app/css/BlogListView.css" rel="stylesheet" type="text/css" />
    <link href="/app/css/BlogPostTemplate.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/app/js/BlogListView.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BlogContent" runat="server">
    <asp:Literal ID="asp_blog_container" runat="server">
    </asp:Literal>
</asp:Content>
