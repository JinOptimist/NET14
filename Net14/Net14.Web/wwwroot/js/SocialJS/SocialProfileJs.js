$(document).ready(function () {
    $(".send-message-profile").click(function () {
        $("#zatemnenie").fadeIn(200);
    });

    $(".close-pop").click(function () {
        $("#zatemnenie").fadeOut(200);
    });
});