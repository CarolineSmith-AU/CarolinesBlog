$(document).ready(function () {
    $(document).on("click", "#submit_post_ID", function () {
        var id = $("#posts_select").val();
        getPost(id);
    });

    $(document).on("click", "#update_blog_post", function () {
        updatePost(BlogPost.post.ID);
    });

    getAllPosts();
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

getAllPosts = function () {
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
            var dataJson = JSON.parse(data.d);
            var posts = [];
            dataJson.POSTS.forEach(function (item, index) {
                posts.push(new Blog_Post(item));
            });
            Blogger.posts = posts;
            setAllPostsDropdown();
        },
        error: function () {
            console.log("Ajax call failed");
        }
    });
};

updatePost = function (id) {
    var password = $("#password_input").val();
    var blog_title = $("#blog_title_input").val();
    var blog_image = $("#images_select").val();
    var blog_tags = $("#blog_tags_input").val();
    var blog_type = $("#blog_type_select").val();
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

getTypesAndImages = function () {
    $.ajax({
        type: "POST",
        url: "/app/vb/EndpointMaster.aspx/Get_Blog_Data",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {},
        cache: false,
        success: function (data) {
            console.log("Getting blog types...");
            var dataJson = JSON.parse(data.d);
            var types = [];
            dataJson.TYPES.forEach(function (item, index) {
                types.push(new Blog_Type(item))
            });
            Blogger.types = types;
            Blogger.images = dataJson.IMAGES;
            setTypesDropdown();
            setImagesDropdown();
        },
        error: function () {
            console.log("Ajax call failed");
        }
    });
};

setTypesDropdown = function () {
    var types = document.querySelector("#blog_type_select");
    Blogger.types.forEach(function (type) {
        var type_option = document.createElement('option');
        type_option.value = type.Type;
        type_option.text = type.Name;
        types.add(type_option);
    });
}

setImagesDropdown = function () {
    var images = document.querySelector("#images_select");
    Blogger.images.forEach(function (image) {
        var image_option = document.createElement('option');
        image_option.value = image;
        image_option.text = image.split("/")[3];
        images.add(image_option);
    });
}

setAllPostsDropdown = function () {
    var posts = document.querySelector("#posts_select");
    Blogger.posts.forEach(function (post) {
        var post_option = document.createElement('option');
        post_option.value = post.ID;
        post_option.text = post.Title;
        posts.add(post_option);
    });
}

showUpdateForm = function () {
    $("#Form1").addClass("hidden");
    $("#Form2").removeClass("hidden");

    $("#blog_title_input").val(BlogPost.post.Title);
    $("#blog_tags_input").val(BlogPost.post.Tags.join(","));
    $("#blog_type_select").val(BlogPost.post.Type);
    $("#images_select").val(BlogPost.post.Image_URL);
    $("#blog_post_input").val(BlogPost.post.Text);
    getTypesAndImages();
};

Blogger = {
    types: null,
    images: null,
    posts: null
}