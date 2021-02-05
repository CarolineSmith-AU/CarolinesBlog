$(document).ready(function () {
    Subscribe.setListeners();
    Navigation.setEventListeners();

    var urlParams = new URLSearchParams(window.location.search);
    if (urlParams.get('email') != "" & urlParams.get('email') != undefined) {
        Modal.OpenModal({
            title: "You have successfully unsubscribed.",
            templateName: "/app/aspx/SuccessMessage.html",
            message: "Sorry to see you go! You're always welcome back.",
            searchSite: function (searchInput) {
                console.log("Searching merchandise.");
            }
        });
    }
});

Subscribe = {
    showSuccessMessage: function () {
        $(".sub-section").addClass("hidden");
        $(".sub-success-section").addClass("show");
    },
    setListeners: function () {
        $(document).on("click", ".blog-sub-button", function () {
            console.log("Subscribe button clicked!");
            const email_addr = $(".sub-input").val();
            console.log(email_addr);
            var data = { email_addr: email_addr };
            var params = JSON.stringify(data)

            $.ajax({
                type: "POST",
                action: "Subscribe_To_Blog",
                url: "/EndpointMaster.aspx/Subscribe_To_Blog",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache: false,
                success: function (data) {
                    console.log(data);
                    Subscribe.showSuccessMessage();
                },
                error: function () {
                    console.log("Ajax call failed");
                }
            });
        });

        $(document).on("click", "#unsub_button", function () {
            Subscribe.unsub();
        });
    },

    unsub: function () {
        const email = $("#email_input").val();

        if (email == "" || email == undefined) {
            return;
        } else {
            console.log("clicked");
            var data = { email_addr: email };
            var params = JSON.stringify(data);
            $.ajax({
                type: "POST",
                url: "/EndpointMaster.aspx/Unsubscribe_From_Blog",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: params,
                cache: false,
                success: function () {

                },
                error: function () {
                    console.log("Ajax call failed");
                }
            });
        }
    }
};

Navigation = {
    setEventListeners: function () {
    $(document).on("click", "#side_nav_hamburger", function () {
        console.log("Nav menu clicked");
        $("#side_nav_container").addClass("slide-open");
        $("#side_nav_container").removeClass("closed");
        $("#side_nav_container").removeClass("page-load");
    });

    $(document).on("click", "#side_nav_close", function () {
        console.log("Nav menu clicked");
        $("#side_nav_container").addClass("closed");
        $("#side_nav_container").removeClass("slide-open");
    });
}
};

Modal = {
    OpenModal: function (options) {
        var html = "<div class='modal-title'><i class='fa fa-check-circle-o' ></i><h3 class='modal-title-text'>" + options.title + "</h3></div><span class='modal-close modal-x-out'>X</span>";
        $.ajax(options.templateName, {
            success: function (response) {
                //html = html + response + "<div class='modal-button-container'><div class='modal-button modal-close'><span class='modal-button-text'>Close</span></div></div>";
                html = html + Util.templateHelper(response, {
                    message: options.message
                });
                $("#modal_content").html(html);
                Modal.SetCloseModalListener(options);
            }
        });
        $("#modal_container").removeClass("closed");
        $("#modal_container").addClass("open");
    },

    SetCloseModalListener: function (options) {
        $(document).on("click", ".modal-close", function () {
            $("#modal_container").removeClass("open");
            $("#modal_container").addClass("closed");
        });

        //$("#modal_container").closest(".modal").click(function () {
        //    $("#modal_content").html("");
        //    $("#modal_container").removeClass("open");
        //    $("#modal_container").addClass("closed");
        //});

        $(document).on("click", "#" + options.searchSite.name, function () {
            console.log("Search button has been clicked!");
            options.searchSite($("#search_input").val());
        });
    }
};

Util = {
    templateHelper: function (templateString, data) {
        templateString = $.trim(templateString);
        return templateString.replace(/%(\w*)%/g, function (m, key) {
            return data.hasOwnProperty(key) ? data[key] : "";
        });
    }
};