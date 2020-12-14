$(document).ready(function () {
    EventListeners.setListeners();
});

Subscribe = {
    showSuccessMessage: function () {
        $(".sub-section").addClass("hidden");
        $(".sub-success-section").addClass("show");
    }
};

EventListeners = {
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

Util = {
    templateHelper: function (templateString, data) {
        templateString = $.trim(templateString);
        return templateString.replace(/%(\w*)%/g, function (m, key) {
            return data.hasOwnProperty(key) ? data[key] : "";
        });
    }
};