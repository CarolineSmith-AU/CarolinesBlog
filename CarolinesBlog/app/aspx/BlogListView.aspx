<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="/app/master_pages/Website.Master" CodeBehind="BlogListView.aspx.vb" Inherits="CarolinesBlog.BlogListView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/app/css/BlogListView.css" rel="stylesheet" type="text/css" />
    <link href="/app/css/BlogPostTemplate.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/app/js/BlogListView.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="search-bar-container-top">
        <input id="search_site_input" class="input" type="text" placeholder="Filter blog post results..." />
        <i class="fa fa-search pointer"></i>
    </div>

    <div id="blog_list_emtpy_view" class="content-section hidden">
        <p class="empty-view-text">There are no blog posts matching your search results.</p>
    </div>

    <div id="blog_list_view_container" class="blog-posts content-section"></div>

    <div class="content-section" id="pagination_container">
        <span class="pointer" id="newer"><i class="fa fa-angle-left"></i>newer</span>
        <span class="pointer" id="older">older<i class="fa fa-angle-right"></i></span>
    </div>

    <script type="text/html" id="blog_posts_template">
        <a href="%blog_url%" class='blog-post'>
            <div data-id="%blog_id%">
                <div class='blog-image-container'>
                    <img src='%image_url%' />
                    <div class='gold-button blog-button pointer'><span class='button-text'>Read Post</span></div>
                </div>
                <span class="blog-type-text">%blog_type% </span>
                <span class='blog-date'>%date%</span><h2 class='blog-title'>%title%</h2>
            </div>
        </a>
    </script>
</asp:Content>
