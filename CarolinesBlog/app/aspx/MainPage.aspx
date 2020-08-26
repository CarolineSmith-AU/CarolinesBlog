<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MainPage.aspx.vb" Inherits="CarolinesBlog.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/app/css/MainPage.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/app/css/font-awesome.min.css" type="text/css" />
    <link rel="stylesheet" href="/app/css/font-awesome.css" type="text/css" />
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <script type="text/javascript" src="/app/js/Navigation.js"></script>
</head>
<body>
    <div id="side_nav_container" class="side-navigation closed page-load">
        <span id="side_nav_close" class="x-out">X</span>
        <ul class="menu-nav">
            <li class="menu-depth-1"><span>Home</span></li>
            <li class="menu-depth-1"><span>Golden Tresses</span></li>
            <li class="menu-depth-1"><span>Golden Style</span></li>
            <li class="menu-depth-1"><span>Golden Life</span></li>
            <li class="menu-depth-1"><span>Golden Thoughts</span></li>
            <li class="menu-depth-1"><span>Golden Girl</span></li>
            <li class="menu-depth-1"><span>Golden Connections</span></li>
        </ul>
    </div>
    <div class="page-header">
        <div class="social-media-header">
            <a class="fa fa-envelope social"></a>
            <a class="fa fa-instagram social"></a>
            <a class="fa fa-facebook-square social"></a>
        </div>
        <div class="logo">
            <span class="logo-text">Black Girl Golden</span>
        </div>
        <div id="top_nav" class="menu-nav-container">
            <ul class="menu-nav">
                <li class="menu-depth-1"><span>Home</span></li>
                <li class="menu-depth-1"><span>Golden Tresses</span></li>
                <li class="menu-depth-1"><span>Golden Style</span></li>
                <li class="menu-depth-1"><span>Golden Life</span></li>
                <li class="menu-depth-1"><span>Golden Thoughts</span></li>
                <li class="menu-depth-1"><span>Golden Girl</span></li>
                <li class="menu-depth-1"><span>Golden Connections</span></li>
            </ul>
        </div>
        <i id="side_nav_hamburger" class="fa fa-bars"></i>
    </div>
    <div class="full-image-header">
        <img src="\app\Images\Pink hat8_enlarged_cropped.jpg" />
    </div>
    <div class="content-container">
        <div class="page-content-header">
            <h1 class="content-header">A Lifestyle and Self-Love Blog</h1>
        </div>
        <div class="whats-in-the-mine content-section">
            <div class="whats-in-mine-text">
                <h1>What's in the mine?</h1>
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
            </div>
            <div class="whats-in-mine-img-cont">
                <img class="whats-in-mine-image" src="\app\Images\Girl-Reading_Resized.jpg" />
            </div>
        </div>
        <div class="recent-blog-posts content-section">
            <span class="recent-blogs-title">Recent Blog Posts</span>
            <div class="blog-posts">
                <div class="blog-post-1 blog-post">
                    <img src="\app\Images\journaling_1_square_small.jpg" />
                    <h2 class="blog-title">Your Blog Title Should Go Here</h2>
                    <p class="blog-preview">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor 
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud 
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                    </p>
                    <span>Read More</span>
                </div>
                <div class="blog-post-2 blog-post">
                    <img src="\app\Images\journaling_1_square_small.jpg" />
                    <h2 class="blog-title">Your Blog Title Should Go Here</h2>
                    <p class="blog-preview">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor 
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud 
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                    </p>
                    <span>Read More</span>
                </div>
                <div class="blog-post-3 blog-post">
                    <img src="\app\Images\journaling_1_square_small.jpg" />
                    <h2 class="blog-title">Your Blog Title Should Go Here</h2>
                    <p class="blog-preview">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor 
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud 
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                    </p>
                    <span>Read More</span>
                </div>
            </div>
        </div>
    </div>
<%--    <div class="image-container">
        <img src="\app\Images\dark_journal_1_resized.jpg" />
        <div class="image-overlay">
            <span class="overlay-text">“If there's a book that you want to read, but it hasn't been written yet, then you must write it.”</span>
        </div>
    </div>--%>
    <div class="quote-container">
        <div class="quote">
            <span class="quote-text">“If there's a book that you want to read, but it hasn't been written yet, then you must write it.”</span>
            <span class="quotee">- Toni Morrison</span>
        </div>
    </div>
    <div class="page-footer">
        <div class="social-media-footer">
            <a id="footer_email" class="fa fa-envelope social"></a>
            <a id="footer_instagram" class="fa fa-instagram social"></a>
            <a id="footer_facebook" class="fa fa-facebook-square social"></a>
        </div>
    </div>
</body>
</html>
