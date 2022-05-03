$(document).ready(function () {
    $(document).on("click", ".subscribe", function () {
        var button = $(this);
        var id = $(this).closest(".head-info").data("id");
        $.get("/SocialGroups/Subscribe", { groupId: id })
            .done(function () {
                button.replaceWith($(`<div class="unsubscribe" >Unsubscribe</div>`))
            })
    });

    $(document).on("click", ".unsubscribe", function () {
        var button = $(this);
        var id = $(this).closest(".head-info").data("id");
        $.get("/SocialGroups/Unsubscribe", { groupId: id })
            .done(function () {
                button.replaceWith($(`<div class="subscribe" >Subscribe</div>`))
            })
    });
})