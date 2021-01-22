$(document).ready(function () {
    Subscribe.setListeners();
    Navigation.setEventListeners();
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

Util = {
    templateHelper: function (templateString, data) {
        templateString = $.trim(templateString);
        return templateString.replace(/%(\w*)%/g, function (m, key) {
            return data.hasOwnProperty(key) ? data[key] : "";
        });
    }
};