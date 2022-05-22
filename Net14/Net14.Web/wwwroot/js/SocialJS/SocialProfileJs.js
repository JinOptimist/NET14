$(document).ready(function () {

    $(".send-message-profile").click(function () {
        $("#zatemnenie").fadeIn(200);
    });

    $(".close-pop").click(function () {
        $("#zatemnenie").fadeOut(200);
    });

    $(".add-to-friends-profile").click(function () {
        const hubConnection = new signalR.HubConnectionBuilder()
            .withUrl("/notif")
            .build();
        let button = $(this);
        let id = String($(this).closest(".profile-wrapper").data("id"));
        let buttonReplace = $(".add-to-friends-button.requested.template").clone();

        $.get("/api/Social/AddFriend", { friendId: id })
            .done(function () {
                button.replaceWith(buttonReplace.removeClass("template"));
            });

        hubConnection.invoke("SendNotif", "requested", id);

        hubConnection.start();
    })

    $(document).on("click", ".send-message-profile-pop", function () {

        const hubConnection = new signalR.HubConnectionBuilder()
            .withUrl("/messages")
            .build();

        let text = $(".texarea-profile").val();

        if (isEmpty(text)) {
            return;
        }

        $(".texarea-profile").val("");

        let userId = $(".profile-wrapper").data("id");
        let data = { Message: text, UserId: userId };

        jQuery.ajax({
            url: "/api/SocialMessages/SendMessage",
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
        }).done(function () {
            hubConnection.invoke("SendMessage", text, userId.toString());
        });

        hubConnection.start();

    });
});

function isEmpty(str) {
    if (str.trim() == '')
        return true;

    return false;
}