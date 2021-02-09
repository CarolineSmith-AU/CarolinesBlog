$(document).ready(function () {
    $(document).on("click", "#add_blog_post", function () {
        addPost();
    });
    getTypesAndImages();
});

addPost = function () {
    var password = $("#password_input").val();
    var blog_title = $("#blog_title_input").val();
    var blog_image = $("#images_select").val();
    var blog_tags = $("#blog_tags_input").val();
    var blog_type = $("#blog_type_select").val();
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

Blogger = {
    types: null,
    images: null
}