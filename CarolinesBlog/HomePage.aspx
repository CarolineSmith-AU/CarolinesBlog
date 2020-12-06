<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Website.Master" CodeBehind="HomePage.aspx.vb" Inherits="CarolinesBlog.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/app/css/HomePage.css" rel="stylesheet" type="text/css" />
    <link href="/app/css/Uniform_Styles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="quote-container">
        <div class="quote">
            <span class="quote-text">“If there's a book that you want to read, but it hasn't been written yet, then you must write it.”</span>
            <span class="quotee">- Toni Morrison</span>
        </div>
    </div>

</asp:Content>
