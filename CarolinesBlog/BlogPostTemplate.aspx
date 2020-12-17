<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Blog.master" CodeBehind="BlogPostTemplate.aspx.vb" Inherits="CarolinesBlog.BlogPostTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/app/css/BlogPostTemplate.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/app/js/BlogPostTemplate.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BlogContent" runat="server">
    <div id="blog_post_container">

    </div>

    <script type="text/html" id="blog_post_template">
         <div id="blog_content">
             <h1 class="blog-post-header">%title%</h1>
             <div class="blog-post-date"><span>%date%</span></div>
             <img class="blog-post-picture" src="%image_url%" width="100%" height: "auto";/>
             <p>%blog_text%</p>
         </div>
    </script>
</asp:Content>
