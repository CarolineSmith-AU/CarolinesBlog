<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MainPage.aspx.vb" Inherits="CarolinesBlog.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"
        integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0="
        crossorigin="anonymous"></script>
    <script
        src="https://code.jquery.com/jquery-2.2.4.min.js"
        integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44="
        crossorigin="anonymous"></script>
    <script
        src="https://code.jquery.com/jquery-1.12.4.min.js"
        integrity="sha256-ZosEbRLbNQzLpnKIkEdrPv7lOy9C27hHQ+Xp8a4MxAQ="
        crossorigin="anonymous"></script>
    <script type="text/javascript" src="/app/js/Navigation.js"></script>
    <link href="/app/css/MainPage.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/app/css/font-awesome.min.css" type="text/css" />
    <link rel="stylesheet" href="/app/css/font-awesome.css" type="text/css" />
</head>
<body>
    <div id="side_nav_container" class="side-navigation closed">
        <span id="side_nav_close" class="x-out">X</span>
        <ul class="menu-nav">
            <li class="menu-depth-1"><span>About Me</span></li>
            <li class="menu-depth-1 "><span>Hair Care</span>
                <ul class="menu-sub-nav-1">
                    <li class="menu-depth-2"><span>List Item 1 - But Longer</span></li>
                    <li class="menu-depth-2"><span>List Item 2</span></li>
                    <li class="menu-depth-2"><span>List Item 3 - Longer</span></li>
                </ul>
            </li>
            <li class="menu-depth-1"><span>Photography</span></li>
            <li class="menu-depth-1"><span>Fitness</span></li>
            <li class="menu-depth-1"><span>Fashion</span></li>
        </ul>
    </div>
    <div class="page-header">
        <div class="logo">
            <span class="logo-text">Black Girl Golden</span>
        </div>
        <i id="side_nav_hamburger" class="fa fa-bars"></i>
    </div>
    <div class="full-image-header">
        <img src="\app\Images\Pink hat8_large_cropped.jpg" />
        <div class="image-overlay">
            <div class="overlay-text">
            </div>
        </div>
    </div>
    <div class="content-container">
    </div>
</body>
</html>
