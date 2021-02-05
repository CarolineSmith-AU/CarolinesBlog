<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Website.master" CodeBehind="BlogListView.aspx.vb" Inherits="CarolinesBlog.BlogListView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/app/css/BlogListView.css" rel="stylesheet" type="text/css" />
    <link href="/app/css/BlogPostTemplate.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/app/js/BlogListView.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="blog_list_view_container" class="blog-posts content-section"></div>

    <script type="text/html" id="blog_posts_template">
        <a href="%blog_url%" class='blog-post'>
            <div data-id="%blog_id%">
                <div class='blog-image-container'>
                    <img src='%image_url%' /><div class='gold-button blog-button pointer'><span class='button-text'>Read Post</span></div>
                </div>
                <span class="blog-type-text">%blog_type% </span>
                <span class='blog-date'>%date%</span><h2 class='blog-title'>%title%</h2>
            </div>
        </a>
    </script>
</asp:Content>
