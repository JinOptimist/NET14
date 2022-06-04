$(document).ready(function () {
    $(document).on("click", ".subscribe", function () {
        var button = $(this);
        let buttonToReplace = $(".unsubscribe.template");
        var id = $(this).closest(".head-info").data("id");
        $.get("/api/SocialGroups/Subscribe", { groupId: id })
            .done(function () {
                button.replaceWith(buttonToReplace.removeClass("template"));
            })
    });

    $(document).on("click", ".unsubscribe", function () {
        var button = $(this);
        var id = $(this).closest(".head-info").data("id");
        let buttonToReplace = $(".subscribe.template");
        $.get("/api/SocialGroups/Unsubscribe", { groupId: id })
            .done(function () {
                button.replaceWith(buttonToReplace.removeClass("template"));
            })
    });
})