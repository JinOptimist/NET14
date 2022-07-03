$(document).ready(function () {
    const hubConnectionMessage = new signalR.HubConnectionBuilder()
        .withUrl("/messages")
        .build();

    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/notif")
        .build();

    $(".send-message-profile").click(function () {
        $("#zatemnenie").fadeIn(200);
    });

    $(".close-pop").click(function () {
        $("#zatemnenie").fadeOut(200);
    });

    $(".add-to-friends-profile:not(.delete)").click(function () {

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
            hubConnectionMessage.invoke("SendMessage", text, userId.toString());
        });

        hubConnectionMessage.start();

    });


    $(document).ready(function () {
        $(".album-photo").click(function () {
            let id = $(".profile-wrapper").data("id");
            let photoUrl = $(this).find(".photo").attr("src");

            $(".watch-photo").find(".album-img").attr("src", photoUrl);
            $(".watch-photo").fadeIn();

        })

        $(".profile-photo").click(function ()
        {
            let photoUrl = $(this).attr("src");

            $(".watch-photo").find(".album-img").attr("src", photoUrl);
            $(".watch-photo").fadeIn();
        })
    })

    $('.photo-container').slick({
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 3
    });

    $(".close-pop-photo").click(function () {
        $(".watch-photo").fadeToggle();
    });

    $(".add-to-friends-profile.delete").click(function () {
        let userId = $(this).closest(".profile-wrapper").data("id");
        let buttonClicked = $(this);
        $.get("/api/Social/DeleteFriend", { friendId: userId })
            .done(function ()
            {
                let buttonToReplace = $(".add-to-friends-profile.template");
                buttonClicked.replaceWith(buttonToReplace.removeClass("template"));
            });
    });

});

function isEmpty(str) {
    if (str.trim() == '')
        return true;

    return false;
}