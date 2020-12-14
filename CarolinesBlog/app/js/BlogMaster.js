$(document).ready(function () {
    BlogMaster.getLoadedTemplate();

});

BlogMaster = {

    blogs: null,

    getLoadedTemplate: function () {
        var url = window.location.pathname;
        var currPageName = url.substring(url.lastIndexOf('/') + 1);
        console.log(currPageName);

        switch (currPageName) {
            case "BlogPostTemplate.aspx":
                BlogMaster.getRelatedPosts();
                break;
            case "BlogListView.aspx":
                BlogMaster.getRecentPosts();
                break;
            default:
                console.log("Page not recognized");
        }
    },

    getRelatedPosts: function () {
        var blog_id = BlogMaster.dataIDURL();
        var data = { blog_id: blog_id };
        var params = JSON.stringify(data)
        $.ajax({
            type: "POST",
            url: "/EndpointMaster.aspx/Get_Related_Posts",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: params,
            cache: false,
            success: function (data) {
                console.log(data.d);
                var dataJson = JSON.parse(data.d);
                BlogMaster.blogs = dataJson.REC_POSTS;
                BlogMaster.setRelatedBlogsHTML();
            },
            error: function () {
                console.log("Ajax call failed");
            }
        });
    },

    getRecentPosts: function () {
        var data = { num_to_get: 10 }
        var params = JSON.stringify(data);
        $.ajax({
            type: "POST",
            url: "/EndpointMaster.aspx/Get_Recent_Blog_Posts",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: params,
            cache: false,
            success: function (data) {
                console.log(data.d);
                var dataJson = JSON.parse(data.d);
                BlogMaster.blogs = dataJson.POSTS;
                BlogMaster.setRecentBlogsHTML();
            },
            error: function () {
                console.log("Ajax call failed");
            }
        });
    },

    dataIDURL: function () {
        const params = new URLSearchParams(window.location.search);
        const dataID = params.get("dataID");
        console.log(dataID);
        return dataID;

    },

    setRelatedBlogsHTML: function () {
        var template = $("#blog_nav_posts_template").html();
        var html = BlogMaster.blogs.reduce(function (accumulator, currVal) {
            return accumulator + Util.templateHelper(template, {
                blog_id: currVal.BLOG_ID,
                blog_url: currVal.BLOG_URL,
                title: currVal.TITLE
            });
        }, "");
        html = "<h2>Related Posts</h2>" + html;
        $("#posts_popular_section").html(html);
    },

    setRecentBlogsHTML: function () {
        var template = $("#blog_nav_posts_template").html();
        var html = BlogMaster.blogs.reduce(function (accumulator, currVal) {
            return accumulator + Util.templateHelper(template, {
                blog_id: currVal.BLOG_ID,
                blog_url: currVal.BLOG_URL,
                title: currVal.TITLE
            });
        }, "");
        html = "<h2>Recent Posts</h2>" + html;
        $("#posts_popular_section").html(html);
    }

};