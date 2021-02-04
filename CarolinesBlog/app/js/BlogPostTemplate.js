$(document).ready(function () {
    BlogPostTemplate.GetRecentBlogs();
});
BlogPostTemplate = {
    blog: null,

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
                BlogPostTemplate.blog = new Blog_Post(dataJson.POSTS[0]);
                BlogPostTemplate.SetPostViewHTML();
            },
            error: function () {
                console.log("Ajax call failed");
            }
        });
    },
    SetPostViewHTML: function () {
        var template = $("#blog_post_template").html();
        var html = Util.templateHelper(template, {
            blog_id: BlogPostTemplate.blog.ID,
            image_url: "../../" + BlogPostTemplate.blog.Image_URL,
            date: BlogPostTemplate.blog.Date,
            title: BlogPostTemplate.blog.Title,
            blog_text: BlogPostTemplate.blog.Text
        });

        $("#blog_post_container").html(html);
    },
};
