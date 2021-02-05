<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Website.Master" CodeBehind="HomePage.aspx.vb" Inherits="CarolinesBlog.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/app/css/HomePage.css" rel="stylesheet" type="text/css" />
    <link href="/app/css/BlogListView.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/app/js/HomePage.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="full-image-header">
        <img src="/app/Images/Yellow%20set%2031-%20J.jpg" />
    </div>
    <div id="sbs-subscribe" class="side-by-side-module content-section">
        <div class="column">
            <img src="/app/Images/Journal 3- J.jpg" />
        </div>
        <div class="column sbs-subscribe-form">
            <h1 class="content-header sbs-header">A Lifestyle and Self-Love Blog</h1>
            <p class="sbs-paragraph">Sign up to be notified about new blog posts and new content! Stay up-to-date about what's new with the BLACKGIRLGOLDEN.</p>

            <div class="sub-section">
                <input id="sbs_email_sub_input" class="input sub-input" type="text" placeholder="Email" />
                <div class="gold-button pointer blog-sub-button" id="sbs_blog_sub_button">
                    <span class="button-text">Subscribe</span>
                </div>
            </div>
            <div class="sub-success-section hidden">
                <p>You have successfully subscribed!</p>
            </div>
        </div>
    </div>
    <div class="whats-in-the-mine padding-top-bottom">
        <div class="whats-in-mine-text">
            <h1 class="sub-content-header black">What's in the mine?</h1>
            <p>
                <strong>I still believe that people read for themselves.</strong> I still believe that people write for their souls. Firmly rooted on that belief, this is a space for the things I call valuable.
                <br />
                <br />
                My mine.
                <br />
                <br />
                There are many ways to extract gold from the Earth; the two most used involve breaking through rock and separation through water. But no one finds the gold without the prowess of the prospector; the person willing to do the work, pursue the process, and determine the places where valuable things lie. We break through the rock to allow ourselves to be vulnerable enough to learn… we sift through the streams to determine what’s important enough to keep.
                <br />
                <br />
                If you are a prospector, I hope this may serve as a valuable little piece of Earth for you. Finding your gold is your life’s work. 
                <br />
                <br />
                I pray this message finds you actively mining for your gold, extracting what you need, molding what you want, and refining who you are.
                <br />
                <br />
                Oh, and do yourself a favor…play “Black Gold” by Esperanza Spalding and Algebra Blessett or “Golden” by Jill Scott and get your whole, entire life….
                <br />
                <br />
                Stay golden…
            </p>
            <a href="/about">
                <div class="black-button pointer" id="about_me_button">
                    <span class="button-text">Read About Me</span>
                </div>
            </a>
        </div>
    </div>
    <div class="recent-blog-posts surround-margin padding-top-bottom content-section">
        <h1 class="content-header">Read the Latest Posts</h1>

        <div id="rec_blogs_container" class='blog-posts'></div>
        <a class="view-all-link pointer" href="/blog">
            <div id="view_all_blogs" class="black-button pointer">
                <span class="button-text">View All Posts</span>
            </div>
        </a>
    </div>
    <div class="quote-container surround-margin padding-top-bottom content-section">
        <div class="quote">
            <span class="quote-text">“If there's a book that you want to read, but it hasn't been written yet, then you must write it.”</span>
            <span class="quotee">- Toni Morrison</span>
        </div>
    </div>
    <div class="image-container margin-top-bottom" id="subscribe_module">
        <div class="full-screen-sub-image">
            <img src="/app/Images/dark_journal_1_resized.jpg" />
            <div id="sub_module_form">
                <h1 id="sub_module_header">Subscribe to be notified about new blog posts.</h1>
                <div class="sub-section">
                    <div id="email_input_box" class="input-button-one-line">
                        <input id="email_sub_input" class="input sub-input" type="text" placeholder="Email" />
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
