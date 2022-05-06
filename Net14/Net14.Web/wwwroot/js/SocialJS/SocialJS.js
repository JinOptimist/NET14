

function ViewClosedForm(el)
{
    if (el.id == "change-name-button") {
        if ($("#form-container-name").css("display") == "flex") {
            $("#form-container-name").fadeOut(200);
        }
        else
        {
            $("#form-container-name").css("display", "flex").hide().fadeIn(200);

        }
    }
    else if (el.id == "change-place-button") {
        if ($("#form-container-place").css("display") == "flex") {
            $("#form-container-place").fadeOut(200);
        }
        else {
            $("#form-container-place").css("display", "flex").hide().fadeIn(200);

        }
    }
    else if (el.id == "change-email-button")
    {
        if ($("#form-container-email").css("display") == "flex") {
            $("#form-container-email").fadeOut(200);
        }
        else {
            $("#form-container-email").css("display", "flex").hide().fadeIn(200);

        }

    }
}


$(document).ready(function () {
    $("#settings-icon").click(function () {
        if ($("#header-settings").css("display") == "flex") {
            $("#header-settings").fadeOut(200);
        }
        else
        {
            $(".notification-block").fadeOut(200);
            $("#header-settings").css("display", "flex").hide().fadeIn(200);


        }
    })
});
$(document).ready(function () {
    $(".filters-header").click(function () {
        $("#form-filter-user").slideToggle();
    });
});




$(document).ready(function () {
    $(".add-post-header").click(function () {
        $("#form-add-post").slideToggle();
    });
});
$(document).ready(function () {
    $(".add-file-header").click(function () {
        $("#form-add-file").slideToggle();
    });
});
$(document).ready(function () {
    $(".show-file-header").click(function () {
        $("#form-show-files").slideToggle();
    });
});

$(document).ready(function () {
    $(".select").click(function () {
        $(".select.active").toggleClass("active");
        $(this).toggleClass("active");
    })
})


$(document).ready(function () {
    $("#find-game").click(function () {
        $(this)
            .closest(".settings-div")
            .find(".menu-games")
            .toggle(100);
    });
});


$(document).ready(function () {
    $("#notification-icon").click(() => {
        $("#header-settings").fadeOut(200);
        $(".notification-block").fadeToggle(200);
        UpdateNotifications();
        $.get('/Social/Notification')
            .done(function (notificationData) {
                RenderNotifications(notificationData);
            });

    })

    function RenderNotifications(notificationData) {
        $(".notification-container:not(.template)").remove();
        $(".notification-container-decline-accept:not(.template)").remove();
        for (let i = 0; i < notificationData.length; i++) {

            if (notificationData[i].friendRequestStatus == 0) {
                let elementToCopy = $(".notification-container.template");
                let finalElement = elementToCopy.clone();
                finalElement.attr("data-friendId", notificationData[i].sender.id);
                finalElement.find(".user-photo-notification").attr("src", notificationData[i].sender.userPhoto);
                finalElement.find(".friend-user-notification").text(notificationData[i].sender.firstName + ' ' + notificationData[i].sender.lastName + " made a friend request");
                finalElement.appendTo(".flex-notification");
                finalElement.removeClass("template");
            }
            else if (notificationData[i].friendRequestStatus == 1 && notificationData[i].type == 1) {
                let elementToCopy = $(".notification-container-decline-accept.template");
                let finalElement = elementToCopy.clone();
                finalElement.find(".user-photo-notification").attr("src", notificationData[i].receiver.userPhoto);
                finalElement.find(".friend-user-notification").text(" You accepted a friend request from " + notificationData[i].sender.firstName + ' ' + notificationData[i].sender.lastName);
                finalElement.appendTo(".flex-notification");
                finalElement.removeClass("template");
            }
            else if (notificationData[i].friendRequestStatus == 2 && notificationData[i].type == 1) {
                let elementToCopy = $(".notification-container-decline-accept.template");
                let finalElement = elementToCopy.clone();
                finalElement.find(".user-photo-notification").attr("src", notificationData[i].sender.userPhoto);
                finalElement.find(".friend-user-notification").text("You declined a friend request from " + notificationData[i].sender.firstName + ' ' + notificationData[i].sender.lastName);
                finalElement.appendTo(".flex-notification");
                finalElement.removeClass("template");
            }
            else if (notificationData[i].friendRequestStatus == 2 && notificationData[i].type == 2) {
                let elementToCopy = $(".notification-container-decline-accept.template");
                let finalElement = elementToCopy.clone();
                finalElement.find(".user-photo-notification").attr("src", notificationData[i].sender.userPhoto);
                finalElement.find(".friend-user-notification").text(notificationData[i].receiver.firstName + ' ' + notificationData[i].receiver.lastName + " declined a friend request");
                finalElement.appendTo(".flex-notification");
                finalElement.removeClass("template");
            }
            else if (notificationData[i].friendRequestStatus == 1 && notificationData[i].type == 2) {
                let elementToCopy = $(".notification-container-decline-accept.template");
                let finalElement = elementToCopy.clone();
                finalElement.find(".user-photo-notification").attr("src", notificationData[i].receiver.userPhoto);
                finalElement.find(".friend-user-notification").text(notificationData[i].receiver.firstName + ' ' + notificationData[i].receiver.lastName + " accepted a friend request");
                finalElement.appendTo(".flex-notification");
                finalElement.removeClass("template");
            }
        }
    }

    $(document).on('click', ".accept-button", function () {
        let friendId = $(this).closest(".notification-container").data("friendid") - 0;
        $.get("/Social/AcceptFriend", { friendId: friendId })
            .done(function () {
                $(this).closest(".notification-container").remove();
                $.get('/Social/Notification')
                    .done(function (notificationData) {
                        RenderNotifications(notificationData);
                    });
            });
    });

    $(document).on('click', ".decline-button", function () {
        let friendId = $(this).closest(".notification-container").data("friendid") - 0;
        $.get("/Social/DeclineFriend", { friendId: friendId })
            .done(function () {
                $(this).closest(".notification-container").remove();
                $.get('/Social/Notification')
                    .done(function (notificationData) {
                        RenderNotifications(notificationData);
                    });
            });
    })

    function UpdateNotifications() {
        $(".badge").hide(100);
    }

})

$(document).ready(() => {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/notif")
        .build();


    hubConnection.on("SendNotif", function (message, userPhoto) {
        $(".notif-div-bottom").fadeIn(200);
        $(".notif-div-bottom-content").text(message);
        let photo = $('<img>').attr("src", userPhoto);
        $(".notif-div-bottom-content").append(photo);
        setTimeout(function () {
            $(".notif-div-bottom").fadeOut(200);
        }, 3000);
    });

    $(document).on('click', ".accept-button", function () {
        let friendId = String($(this).closest(".notification-container").data("friendid"));
        hubConnection.invoke("SendNotif", "accept", friendId);

    });

    $(document).on('click', ".decline-button", function () {
        let friendId = String($(this).closest(".notification-container").data("friendid"));
        hubConnection.invoke("SendNotif", "decline", friendId);
    });

    $(document).ready(function () {
        $(".add-to-friends-button").click(function () {
            let button = $(this);
            let id = String($(this).closest(".find-recomendation-element-menu").data("friend"));

            $.get("/Social/AddFriend", { friendId: id })
                .done(function () {
                    button.addClass("requested").text("Requested");
                });

            hubConnection.invoke("SendNotif", "requested", id);
        })
    })


    hubConnection.start();

})


