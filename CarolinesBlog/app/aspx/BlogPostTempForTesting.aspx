<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/app/master_pages/Blog.master" CodeBehind="BlogPostTempForTesting.aspx.vb" Inherits="CarolinesBlog.BlogPostTempForTesting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/app/css/BlogPostTemplate.css" rel="stylesheet" type="text/css" />
    <link href="/app/css/BlogListView.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/app/js/BlogPostTemplate.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BlogContent" runat="server">
    <div id="blog_post_container">
        <div id="blog_content" class="blog-content">
            <h1 class="blog-post-header">%title%</h1>
            <div class="blog-post-date"><span>%date%</span></div>
            <img class="blog-post-picture" src="%image_url%" />
            <div class="full-blog-post">
            </div>
        </div>
    </div>
</asp:Content>

