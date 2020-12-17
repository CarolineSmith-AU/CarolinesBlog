$(document).ready(function () {
    BlogPostTemplate.GetRecentBlogs();
});
BlogPostTemplate = {
    blogs: null,

    GetRecentBlogs: function () {
        var id = BlogMaster.GetIDFromURL();
        var data = { blog_id: id }
        var params = JSON.stringify(data);
        $.ajax({
            type: "POST",
            url: "/EndpointMaster.aspx/Get_Single_Blog_Post",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: params,
            cache: false,
            success: function (data) {
                console.log(data.d);
                var dataJson = JSON.parse(data.d);
                BlogPostTemplate.blogs = dataJson.POSTS;
                BlogPostTemplate.SetPostViewHTML();
            },
            error: function () {
                console.log("Ajax call failed");
            }
        });
    },
    SetPostViewHTML: function () {
        var template = $("#blog_post_template").html();
        var html = BlogPostTemplate.blogs.reduce(function (accumulator, currVal) {
            var cleanedTitle = currVal.TITLE.replace("&", "and");
            cleanedTitle = cleanedTitle.replace(/[^a-zA-Z0-9 ]/g, "");
            return accumulator + Util.templateHelper(template, {
                blog_id: currVal.BLOG_ID,
                image_url: "../../" + currVal.IMAGE_URL,
                date: currVal.DATE,
                title: currVal.TITLE,
                blog_text: currVal.BLOG_TEXT
            });
        }, "");

        $("#blog_post_container").html(html);
    },
};
