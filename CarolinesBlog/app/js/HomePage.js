$(document).ready(function () {
    HomePage.GetRecentBlogs();
});
HomePage = {
    blogs: null,

    GetRecentBlogs: function () {
        var data = { num_to_get: 3 }
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
                var posts = [];
                dataJson.POSTS.forEach(function (item, index) {
                    posts.push(new Blog_Post(item));
                });
                HomePage.blogs = posts;
                HomePage.SetRecentBlogsHTML();
            },
            error: function () {
                console.log("Ajax call failed");
            }
        });
    },
    SetRecentBlogsHTML: function () {
        var template = $("#rec_blog_template").html();
        var html = HomePage.blogs.reduce(function (accumulator, currVal) {
            var cleanedTitle = currVal.Title.replace("&", "and");
            cleanedTitle = cleanedTitle.replace(/[^a-zA-Z0-9 ]/g, "");
            return accumulator + Util.templateHelper(template, {
                blog_id: currVal.ID,
                image_url: currVal.Image_URL,
                blog_url: "/blog/" + currVal.ID + "/" + cleanedTitle.replace(/\s+/g, "-").toLowerCase(),
                date: currVal.Date,
                title: currVal.Title
            });
        }, "");

        $("#rec_blogs_container").html(html);
    },
};
