$(document).ready(function () {
    BlogMaster.getLoadedBlogTemplate();
});

BlogMaster = {

    blogs: null,

    getLoadedBlogTemplate: function () {
        var id = BlogMaster.GetIDFromURL();

        if (id == "" || id == undefined || id == null) {    
            return;
        } else {
            BlogMaster.GetBlogsByType(id);
        }
    },
    GetBlogsByType: function (blog_id) {
        var data = { blog_id: blog_id, num_to_get: 3 }
        var params = JSON.stringify(data);
        $.ajax({
            type: "POST",
            url: "/EndpointMaster.aspx/Get_Posts_By_Type",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: params,
            cache: false,
            success: function (data) {
                console.log(data.d);
                var dataJson = JSON.parse(data.d);
                var posts = [];
                dataJson.POSTS.forEach(function (item, index) {
                    posts.push(new Blog_Post(item));
                });
                BlogMaster.blogs = posts;
                BlogMaster.SetRelPostsHTML();
            },
            error: function () {
                console.log("Ajax call failed");
            }
        });
    },

    SetRelPostsHTML: function () {
        var template = $("#blog_rel_posts_template").html();
        var html = BlogMaster.blogs.reduce(function (accumulator, currVal) {
            var cleanedTitle = currVal.Title.replace("&", "and");
            cleanedTitle = cleanedTitle.replace(/[^a-zA-Z0-9 ]/g, "");
            return accumulator + Util.templateHelper(template, {
                blog_id: currVal.ID,
                image_url: currVal.Image_URL,
                blog_url: "/blog/" + currVal.ID + "/" + cleanedTitle.replace(/\s+/g, "-").toLowerCase(),
                date: currVal.Date,
                blog_type: currVal.Type_Name,
                title: currVal.Title
            });
        }, "");
        $("#rel_posts_section").html(html);
    },

    GetIDFromURL: function () { //change to split function later 
        var coll = window.location.pathname.split("/");
        return coll[2];
    }
};