<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Website.Master" CodeBehind="HomePage.aspx.vb" Inherits="CarolinesBlog.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/app/css/HomePage.css" rel="stylesheet" type="text/css" />
    <link href="/app/css/Uniform_Styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/app/js/HomePage.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="full-image-header">
        <img src="\app\Images\Pink hat8_enlarged_cropped.jpg" />
    </div>
    <div class="content-container">
        <div class="page-content-header">
            <h1 class="content-header">A Lifestyle and Self-Love Blog</h1>
        </div>
        <div class="whats-in-the-mine content-section side-by-side-module">
            <div class="whats-in-mine-text" id="left">
                <h1 class="sub-content-header black">What's in the mine?</h1>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor 
                incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud 
                exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
                irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla 
                pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia 
                deserunt mollit anim id est laborum.
                </p>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor 
                incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud 
                exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
                irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla 
                pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia 
                deserunt mollit anim id est laborum.
                </p>
                <div class="black-button pointer" id="about_me_button">
                    <span class="button-text">Read About Me</span>
                </div>
            </div>
            <div class="whats-in-mine-img-cont" id="right">
                <img class="whats-in-mine-image" src="\app\Images\lauren_blue_dress_resized_4.jpg" width="100%" />
            </div>
        </div>
        <div class="recent-blog-posts content-section">
            <span class="recent-blogs-title content-header">Recent Blog Posts</span>

            <div id="rec_blogs_container" class='blog-posts content-section'></div>
            <a class="view-all-link pointer content-section" href="/blog">
                <div id="view_all_blogs" class="black-button pointer">
                    <span class="button-text">View All Posts</span>
                </div>
            </a>
        </div>
    </div>
    <div class="quote-container">
        <div class="quote">
            <span class="quote-text">“If there's a book that you want to read, but it hasn't been written yet, then you must write it.”</span>
            <span class="quotee">- Toni Morrison</span>
        </div>
    </div>
    <div class="image-container" id="subscribe_module">
        <div class="full-screen-sub-image">
            <img src="app/Images/dark_journal_1_resized.jpg" />
            <div id="sub_module_form">
                <h1 id="sub_module_header">Subscribe to be notified about new blog posts.</h1>
                <div class="sub-section">
                    <div id="email_input_box" class="input-button-one-line">
                        <p id="email_label">Email</p>
                        <input id="email_sub_input" class="input sub-input" type="text" placeholder="" />
                        <div class="black-button pointer blog-sub-button" id="blog_sub_button">
                            <span class="button-text">Subscribe</span>
                        </div>
                    </div>
                </div>
                <div class="sub-success-section hidden">
                    <p>You have successfully subscribed!</p>
                </div>
            </div>
        </div>
    </div>

    <script type="text/html" id="rec_blog_template">
        <div class='blog-post' data-id="%blog_id%">
            <div class='blog-image-container'>
                <img src='%image_url%' /><a class='button-link' href='%blog_url%'><div class='gold-button blog-button pointer'><span class='button-text'>Read Post</span></div>
                </a>
            </div>
            <span class='blog-Date'>%date%</span><h2 class='blog-title'>%title%</h2>
        </div>
    </script>
</asp:Content>
