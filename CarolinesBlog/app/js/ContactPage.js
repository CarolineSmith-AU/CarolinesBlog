$(document).ready(function () {
    Contact.sendMail();
    var urlParams = new URLSearchParams(window.location.search);
    if (urlParams.get('email') != "" & urlParams.get('email') != undefined) {
        Modal.OpenModal({
            title: "Email Sent Successfully",
            templateName: "/app/aspx/SuccessMessage.html",
            message: "Thanks for contacting me! I look forward to reading what's on your mind.",
            searchSite: function (searchInput) {
                console.log("Searching merchandise.");
            }
        });
    }
});
Contact = {
    sendMail: function () {
        $(document).on("click", "#send_message_button", function (e) {
            Contact.checkInput(e)
        });
    },

    checkInput: function () {
        var firstname = $("#first_name_input").val();
        var lastname = $("#last_name_input").val();
        var returnEmail = $("#email_addr_input").val();
        var body = $("#message_input").val();

        if (returnEmail == "" || returnEmail == undefined || body == "" || body == undefined) {
            return;
        } else {
            console.log("clicked");
            var data = { firstname: firstname, lastname: lastname, returnEmail: returnEmail, body: body };
            var params = JSON.stringify(data);
            $.ajax({
                type: "POST",
                url: "/Mail.aspx/Send_Mail_To_Blogger",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: params,
                cache: false,
                success: function (data) {
                    console.log(data.d);
                    var dataJson = JSON.parse(data.d);
                },
                error: function () {
                    console.log("Ajax call failed");
                }
            });
        }
    }
};