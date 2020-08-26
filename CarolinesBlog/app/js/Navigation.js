$(document).ready(function () {
    Navigation = setEventListeners();

    function setEventListeners() {
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
});