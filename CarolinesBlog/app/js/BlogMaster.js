$(document).ready(function () {
    BlogMaster.getLoadedBlogTemplate();
});

BlogMaster = {

    blogs: null,

    getLoadedBlogTemplate: function () {
        var id = BlogMaster.GetIDFromURL();

        if (id == "" || id == undefined || id == null) {    
            BlogMaster.getRecentPosts();
        } else {
            BlogMaster.getRelatedPosts(id);
        }
    },
    getRelatedPosts: function (id) {
        var data = { blog_id: id };
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
    setRelatedBlogsHTML: function () {
        var template = $("#blog_nav_posts_template").html();
        var html = BlogMaster.blogs.reduce(function (accumulator, currVal) {
            var cleanedTitle = currVal.TITLE.replace("&", "and");
            cleanedTitle = cleanedTitle.replace(/[^a-zA-Z0-9 ]/g, "");
            return accumulator + Util.templateHelper(template, {
                blog_id: currVal.BLOG_ID,
                blog_url: "/" + currVal.BLOG_TYPE + "/" + currVal.BLOG_ID + "/" + cleanedTitle.replace(/\s+/g, "-").toLowerCase(),
                title: currVal.TITLE
            });
        }, "");
        html = "<h2>Related Posts</h2>" + html;
        $("#posts_popular_section").html(html);
    },

    setRecentBlogsHTML: function () {
        var template = $("#blog_nav_posts_template").html();
        var html = BlogMaster.blogs.reduce(function (accumulator, currVal) {
            var cleanedTitle = currVal.TITLE.replace("&", "and");
            cleanedTitle = cleanedTitle.replace(/[^a-zA-Z0-9 ]/g, "");
            return accumulator + Util.templateHelper(template, {
                blog_id: currVal.BLOG_ID,
                blog_url: "/" + currVal.BLOG_TYPE + "/" + currVal.BLOG_ID + "/" + cleanedTitle.replace(/\s+/g, "-").toLowerCase(),
                title: currVal.TITLE
            });
        }, "");
        html = "<h2>Recent Posts</h2>" + html;
        $("#posts_popular_section").html(html);
    },
    GetIDFromURL: function () { //change to split function later 
        var coll = window.location.pathname.split("/");
        return coll[2];
    }
};