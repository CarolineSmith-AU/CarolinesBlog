$(document).ready(function () {
    Contact.sendMail();
});
Contact = {
    sendMail: function () {
        $(document).on("click", "#send_message_button", function () {
            Contact.checkInput()
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