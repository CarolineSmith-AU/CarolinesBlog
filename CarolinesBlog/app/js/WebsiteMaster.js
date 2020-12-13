$(document).ready(function () {
    getLoadedTemplate();
    function getLoadedTemplate() {
        var url = window.location.pathname;
        var currPageName = url.substring(url.lastIndexOf('/') + 1);
        console.log(currPageName);

        switch (currPageName) {
            case "BlogPostTemplate.aspx":
                dataIDURL();
                break;
            case "BlogListView.aspx":
                break;
            default:
                console.log("Page not recognized");
        }

        function dataIDURL() {
            const params = new URLSearchParams(window.location.search);
            const dataID = params.get("dataID");
            console.log(dataID);

        }
    }
});