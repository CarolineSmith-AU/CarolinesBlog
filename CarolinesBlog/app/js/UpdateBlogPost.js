$(document).ready(function () {
    $(document).on("click", "#submit_post_ID", function () {
        var id = $("#post_ID_input").val();
        getPost(id);
    });

    $(document).on("click", "#update_blog_post", function () {
        updatePost(BlogPost.post.ID);
    });
});

BlogPost = {
    post: null
};

getPost = function (id) {
    var data = { blog_id: id }
    var params = JSON.stringify(data);
    $.ajax({
        type: "POST",
        url: "/app/vb/EndpointMaster.aspx/Get_Single_Blog_Post",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: params,
        cache: false,
        success: function (data) {
            var dataJson = JSON.parse(data.d);
            BlogPost.post = new Blog_Post(dataJson.POSTS[0]);
            showUpdateForm();
        },
        error: function () {
            console.log("Ajax call failed");
        }
    });
};

updatePost = function (id) {
    var password = $("#password_input").val();
    var blog_title = $("#blog_title_input").val();
    var blog_image = $("#blog_image_input").val();
    var blog_tags = $("#blog_tags_input").val();
    var blog_type = $("#blog_type_input").val();
    var blog_post = $("#blog_post_input").val();

    var data = { password: password, blog_title: blog_title, blog_image: blog_image, blog_tags: blog_tags, blog_type: blog_type, blog_post: blog_post, blog_id: id }
    var params = JSON.stringify(data);
    $.ajax({
        type: "POST",
        url: "/app/vb/EndpointMaster.aspx/Update_Post",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: params,
        cache: false,
        success: function (data) {
            console.log("Successfully updated new blog post!");
        },
        error: function () {
            console.log("Ajax call failed");
        }
    });
};

showUpdateForm = function () {
    $("#Form1").addClass("hidden");
    $("#Form2").removeClass("hidden");

    $("#blog_title_input").val(BlogPost.post.Title);
    $("#blog_tags_input").val(BlogPost.post.Tags.join(","));
    $("#blog_type_input").val(BlogPost.post.Type);
    $("#blog_image_input").val(BlogPost.post.Image_URL);
    $("#blog_post_input").val(BlogPost.post.Text);
};