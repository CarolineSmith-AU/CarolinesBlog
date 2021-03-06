﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UpdateBlogPost.aspx.vb" Inherits="CarolinesBlog.UpdateBlogPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="/app/css/WebsiteMaster.css" rel="stylesheet" type="text/css" />
    <link href="/app/css/Uniform_Styles.css" rel="stylesheet" type="text/css" />
    <link href="/app/css/Form.css" rel="stylesheet" type="text/css" />
    <script type="text/JavaScript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script type="text/javascript" src="/app/js/UpdateBlogPost.js"></script>
    <script type="text/javascript" src="/app/js/BlogObjects.js"></script>
</head>
<body>
    <div class="content-section">
        <div class="page-content-header">
            <h1 class="content-header">Update A Blog Post</h1>
        </div>
        <div id="Form1">
            <div id="post_ID" class="form-row">
                <select id="posts_select" class="input row-12" type="text">
                    <option value="select-image" disabled selected>Select Blog to Edit</option>
                </select>
            </div>
            <div class="button-form-row">
                <input id="submit_post_ID" class="gold-button pointer" value="Submit" />
            </div>
        </div>
        <form id="Form2" runat="server" class="hidden">
            <div id="auth" class="form-row">
                <input id="password_input" class="input row-12" type="password" placeholder="*Password" required />
            </div>
            <div id="blog_title" class="form-row">
                <input id="blog_title_input" class="input row-12" type="text" placeholder="*Title" required />
            </div>
            <div id="blog_tags" class="form-row">
                <input id="blog_tags_input" class="input row-12" type="text" placeholder="*3-4 Tags (i.e. tag1,tag2,tag3,tag4)" required />
            </div>
            <div id="blog_type" class="form-row">
                <select id="blog_type_select" class="input row-12" type="text">
                    <option value="select-type" disabled selected>Select Blog Type</option>
                </select>
            </div>
            <div id="blog_image" class="form-row">
                <select id="images_select" class="input row-12" type="text">
                    <option value="select-image" disabled selected>Select Image</option>
                </select>
            </div>
            <div id="blog_post" class="form-row">
                <textarea id="blog_post_input" class="input row-12" placeholder="*Blog Post (i.e. <p>INSERT_HTML_CONTENT</p>)" required></textarea>
            </div>
            <div class="button-form-row">
                <input id="update_blog_post" class="gold-button pointer" type="submit" value="Update Post" />
            </div>
        </form>
    </div>
</body>
</html>
