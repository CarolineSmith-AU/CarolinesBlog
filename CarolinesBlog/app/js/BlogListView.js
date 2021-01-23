$(document).ready(function () {
    BlogListView.GetBlogListType();
});
BlogListView = {
    blogs: null,

    GetBlogListType: function () {
        var blogType = BlogListView.GetBlogType();

        if (blogType == "blog") { //one type of blog or all blog posts by blogger
            BlogListView.GetAllBlogs();
        }  else {
            BlogListView.GetBlogsByType(blogType);
        }
    },
    GetBlogType: function () {
        var type = window.location.pathname.substring(1); //Erase first char which is '/'
        return type;
    },
    GetBlogsByType: function (blog_type) {
        var data = { num_to_get: 10, blog_type: blog_type }
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
                BlogListView.blogs = dataJson.POSTS;
                BlogListView.SetListViewHTML();
            },
            error: function () {
                console.log("Ajax call failed");
            }
        });
    },
    GetAllBlogs: function () {
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
                BlogListView.blogs = dataJson.POSTS;
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
            var cleanedTitle = currVal.TITLE.replace("&", "and");
            cleanedTitle = cleanedTitle.replace(/[^a-zA-Z0-9 ]/g, "");
            return accumulator + Util.templateHelper(template, {
                blog_id: currVal.BLOG_ID,
                image_url: currVal.IMAGE_URL,
                blog_url: "/" + currVal.BLOG_TYPE + "/" + currVal.BLOG_ID + "/" + cleanedTitle.replace(/\s+/g, "-").toLowerCase(),
                date: currVal.DATE,
                title: currVal.TITLE,
                blog_text: currVal.BLOG_TEXT
            });
        }, "");

        $("#blog_list_view_container").html(html);
    }
};
