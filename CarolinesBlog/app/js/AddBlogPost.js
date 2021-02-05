$(document).ready(function () {
    $(document).on("click", "#add_blog_post", function () {
        addPost();
    });
});

addPost = function () {
    var password = $("#password_input").val();
    var blog_title = $("#blog_title_input").val();
    var blog_image = $("#blog_image_input").val();
    var blog_tags = $("#blog_tags_input").val();
    var blog_type = $("#blog_type_input").val();
    var blog_post = $("#blog_post_input").val();

    var data = { password: password, blog_title: blog_title, blog_image: blog_image, blog_tags: blog_tags, blog_type: blog_type, blog_post: blog_post }
    var params = JSON.stringify(data);
    $.ajax({
        type: "POST",
        url: "/app/vb/EndpointMaster.aspx/Add_Post",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: params,
        cache: false,
        success: function (data) {
            console.log("Successfully added new blog post!");
        },
        error: function () {
            console.log("Ajax call failed");
        }
    });
};