$(document).ready(function () {
    //Order is important!
    BlogListView.SetEventListeners();
    BlogListView.GetAllBlogs();
});
BlogListView = {
    blogs: null,
    blogsPerPage: 30,
    currPage: 1,

    SetEventListeners: function () {
        $(document).on("click", "#older", function () {
            location.pathname = "/blog/page/" + (BlogListView.currPage + 1)
        });
        $(document).on("click", "#newer", function () {
            location.pathname = "/blog/page/" + (BlogListView.currPage - 1)
        });
    },
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
                BlogListView.SetPagination();
                BlogListView.SetListViewHTML();
            },
            error: function () {
                console.log("Ajax call failed");
            }
        });
    },
    SetListViewHTML: function () {
        var template = $("#blog_posts_template").html();
        const maxIndexCurrPage = BlogListView.blogsPerPage * BlogListView.currPage;
        const startIndex = (BlogListView.blogsPerPage * BlogListView.currPage) - BlogListView.blogsPerPage;

        var html = BlogListView.blogs.reduce(function (accumulator, currVal, index) {
            if ((index >= maxIndexCurrPage) || (index < startIndex)) {
                return accumulator;
            }
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
    },
    SetPagination: function () {
        var urlColl = location.pathname.split("/");
        var page = urlColl[3];
        const maxIndexCurrPage = BlogListView.blogsPerPage * page;

        if (page == undefined || page == "" || page == null || page == 1) {
            BlogListView.currPage = 1;
            $("#newer").addClass("hidden");
            $("#older").removeClass("hidden");
            BlogListView.currPage = 1;
        } else if (BlogListView.blogs.length == maxIndexCurrPage) {
            $("#older").addClass("hidden");
            $("#newer").removeClass("hidden");
            BlogListView.currPage = page;
        }

        if (BlogListView.blogs.length <= BlogListView.blogsPerPage) {
            $("#older").addClass("hidden");
            $("#newer").addClass("hidden");
        }
    }
};
