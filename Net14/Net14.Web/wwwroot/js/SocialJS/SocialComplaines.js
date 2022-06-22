$(document).ready(function () {
    $(".more-button-container").click(function () {
        $(this).closest(".user-info").find(".complaints-list").fadeToggle();
    })
})