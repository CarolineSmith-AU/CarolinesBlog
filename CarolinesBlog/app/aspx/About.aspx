<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="/app/master_pages/Website.Master" CodeBehind="About.aspx.vb" Inherits="CarolinesBlog.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/app/css/About.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="about padding-top-bottom">
        <div class="about-text-container">
            <h1 class="sub-content-header black">About Me</h1>
            <p class="about-text">
                Quiet as it’s kept…
                <br />
                <br />
                Oftentimes this expression is used in our communities to denote things that should be kept to ourselves. However, so much of our growth is inhibited when we keep everything to ourselves. That’s why I’m here. I am challenging myself to share…my struggles…my triumphs…my tips. I want to facilitate meaningful exchanges, where we help each other find our gold and reach our goals.
                <br />
                <br />
                My name is Lauren and I’m the woman behind this site. I am Georgia-grown, God’s child, a high-school teacher, legal-eagle, novice historian, natural hair lover, a burgeoning writer, Taurus Sun and Rising, Leo Moon, future business owner, and vintage as hell. Warning, if you have it all together, this is not the blog for you! But, if you’ve ever asked yourself…
                <br />
                <br />
                “Why am I here?” 
                <br />
                “Why are relationships so hard?”
                <br />
                “What’s my beauty aesthetic?”
                <br />
                “Will I always live my life financially frustrated?”
                <br />
                “What does self-care mean for me?”
                <br />
                “What do I wear?”
                <br />
                “How do I navigate race and politics while maintaining peace?”
                <br />
                “What can I learn from pop culture?”
                <br />
                “How can I learn to love my body?”
                <br />
                <br />
                …you might find something here for you. Welcome to the mine! Don’t forget to take some gold with you before you go, subscribe to my e-mail list, and follow my social media handles!
            </p>
            <div id="about_sub_container">
                <div class="sub-section">
                    <div id="email_input_box" class="input-button-one-line">
                        <input id="email_sub_input" class="input sub-input" type="text" placeholder="Email" />
                        <div class="black-button pointer blog-sub-button" id="blog_sub_button">
                            <span class="button-text">Subscribe</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="black-social-media">
                <a id="footer_email" class="fa fa-envelope social" href="/contact"></a>
                <a id="footer_instagram" class="fa fa-instagram social" href="https://www.instagram.com/lalalearnsya/" target="_blank"></a>
                <%--<a id="footer_facebook" class="fa fa-facebook-square social"></a>--%>
            </div>
        </div>
    </div>
</asp:Content>
