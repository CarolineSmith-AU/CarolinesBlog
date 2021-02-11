$(document).ready(function () {
    //Order is important!
    BlogListView.SetEventListeners();
    BlogListView.GetAllBlogs();
});
BlogListView = {
    blogs: null,
    blogsPerPage: 20,
    currPage: 1,

    SetEventListeners: function () {
        $(document).on("click", "#older", function () {
            
            location.pathname = "/blog/page/" + (BlogListView.currPage + 1)
        });
        $(document).on("click", "#newer", function () {
            location.pathname = "/blog/page/" + (BlogListView.currPage - 1)
        });
        $(document).on("input", "#search_site_input", function (e) {
            var searchInput = e.currentTarget.value;
            console.log(searchInput);
            if (searchInput == "") {
                BlogListView.SetListViewHTML();
                BlogListView.SetPagination(false);
            } else {
                BlogListView.SearchAndRebuild(searchInput);
                BlogListView.SetPagination(true);
            }
        });
    },

    SearchAndRebuild: function (input) {
        var inputArray = input.trim().split(/[ ,]+/);
        const filterParams = ["Title", "Date", "Text", "Tags"];
        //const monthAbb = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        const specialChars = /[.,'\/#!$%\^&\*;:{}=\-_`~()]/g;
        var filteredBlogs = [];
        var allBlogs = BlogListView.blogs; //copy of all blogs
        inputArray.forEach(function (str) {
            var relBlogs = allBlogs.filter(function (blog) {
                return filterParams.some(function (param) {
                    if (param == "Tags") {
                        var tags = blog[param];
                        return tags.some(function (tag) {
                            return tag.toString().replace(specialChars, "").toLowerCase().includes(str.toLowerCase());
                        });
                    }
                    var value = blog[param];
                    return value.toString().replace(specialChars, "").toLowerCase().includes(str.toLowerCase());
                });
            });
            relBlogs.forEach(function (blog) { //remove duplicates
                if (filteredBlogs.find(function (post) {
                    return blog.ID == post.ID;
                }) == undefined) {
                    filteredBlogs.push(blog);
                }
            });
            allBlogs = relBlogs;
        });
        BlogListView.SetListViewHTML(allBlogs);
        $.expr[":"].contains = $.expr.createPseudo(function (arg) {
            return function (elem) {
                return $(elem).text().toUpperCase().indexOf(arg.toUpperCase()) >= 0;
            };
        });
        //container.find(".emailRowContent").find('span:contains("' + $("#col_search").val() + '")').css("background-color", "#ffff66");
        //container.find(".emailRowHeader").find('span:contains("' + $("#col_search").val() + '")').css("background-color", "#ffff66");
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
                BlogListView.SetPagination(false);
                BlogListView.SetListViewHTML();
            },
            error: function () {
                console.log("Ajax call failed");
            }
        });
    },
    SetListViewHTML: function (blogs) {
        var html = "";
        var template = $("#blog_posts_template").html();
        if (blogs != undefined || blogs != null) {
            html = blogs.reduce(function (accumulator, currVal, index) {
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
        } else {
            const maxIndexCurrPage = BlogListView.blogsPerPage * BlogListView.currPage;
            const startIndex = (BlogListView.blogsPerPage * BlogListView.currPage) - BlogListView.blogsPerPage;
            html = BlogListView.blogs.reduce(function (accumulator, currVal, index) {
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
        }
        if (html == "") {
            $("#blog_list_emtpy_view").removeClass("hidden");
        } else {
            $("#blog_list_emtpy_view").addClass("hidden");
        }
        $("#blog_list_view_container").html(html);
    },
    SetPagination: function (hidePagination) {
        var urlColl = location.pathname.split("/");
        var page = urlColl[3];
        const maxIndexCurrPage = BlogListView.blogsPerPage * page;

        if (BlogListView.blogs.length <= BlogListView.blogsPerPage || hidePagination == true) {
            $("#older").addClass("hidden");
            $("#newer").addClass("hidden");
            return;
        }

        if (page == undefined || page == "" || page == null || page == 1) {
            BlogListView.currPage = 1;
            $("#newer").addClass("hidden");
            $("#older").removeClass("hidden");
            BlogListView.currPage = 1;
            return;
        } else if (BlogListView.blogs.length == maxIndexCurrPage) {
            $("#older").addClass("hidden");
            $("#newer").removeClass("hidden");
            BlogListView.currPage = parseInt(page, 10);
            return;
        }
        BlogListView.currPage = parseInt(page, 10);
    },
};
