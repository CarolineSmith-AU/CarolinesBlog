$(document).ready(function () {
    BlogListView.GetAllBlogs();
});
BlogListView = {
    blogs: null,

    GetBlogType: function () {
        var type = window.location.pathname.substring(1); //Erase first char which is '/'
        return type;
    },
    GetAllBlogs: function () {
        var data = { num_to_get: -1 }
        var params = JSON.stringify(data);
        $.ajax({
            type: "POST",
            url: "/app/vb/EndpointMaster.aspx/Get_Recent_Blog_Posts",
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
                BlogListView.blogs = posts;
                BlogListView.SetListViewHTML();
            },
            error: function () {
                console.log("Ajax call failed");
            }
        });
    },
    SetListViewHTML: function () {
        var template = $("#blog_posts_template").html();
        var html = BlogListView.blogs.reduce(function (accumulator, currVal) {
            var cleanedTitle = currVal.Title.replace("&", "and");
            cleanedTitle = cleanedTitle.replace(/[^a-zA-Z0-9 ]/g, "");
            var tagsString = currVal.Tags.reduce(function (acc, curr) {
                return acc + curr + " | ";
            }, "");
            tagsString = tagsString.substring(0, tagsString.length - 2);
            return accumulator + Util.templateHelper(template, {
                blog_id: currVal.ID,
                image_url: currVal.Image_URL,
                blog_url: "/blog/" + currVal.ID + "/" + cleanedTitle.replace(/\s+/g, "-").toLowerCase(),
                date: currVal.Date,
                blog_type: tagsString,
                title: currVal.Title
            });
        }, "");

        $("#blog_list_view_container").html(html);
    }
};
