let isNotif = false;
let notifCount = 0;

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
        $.get('/api/Social/Notification')
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
        $.get("/api/Social/AcceptFriend", { friendId: friendId })
            .done(function () {
                $(this).closest(".notification-container").remove();
                $.get('/api/Social/Notification')
                    .done(function (notificationData) {
                        RenderNotifications(notificationData);
                    });
            });
    });

    $(document).on('click', ".decline-button", function () {
        let friendId = $(this).closest(".notification-container").data("friendid") - 0;
        $.get("api/Social/DeclineFriend", { friendId: friendId })
            .done(function () {
                $(this).closest(".notification-container").remove();
                $.get('api/Social/Notification')
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
        if (notifCount == 1)
        {
            notifCount++;
            let divClone = $("notif-div-bottom.template").clone();
            let elementBottomCheck = $(".notif-div-bottom:not(.template)").css("bottom");
            if (elementBottomCheck === "70px") {
                divClone.css("bottom", "185px");
            }

            divClone.removeClass("template");
            divClone.css("bottom", "110px");
            divClone.appendTo("body");
            divClone.fadeIn(200);
            divClone.find(".notif-text").text(message);
            let photo = $('<img>').attr("src", userPhoto);
            divClone.find(".notif-div-bottom-content").append(photo);
            setTimeout(function () {
                divClone.fadeOut(200, function () {
                    divClone.remove();
                    notifCount--;
                });
            }, 3000);

            return;
        }
        if (notifCount == 2) {
            return;
        }
        notifCount++;
        let divClone = $(".notif-div-bottom.template").clone();
        divClone.removeClass("template");
        divClone.appendTo("body");
        divClone.fadeIn(200);
        divClone.find(".notif-text").text(message);
        let photo = $('<img>').attr("src", userPhoto);
        divClone.find(".notif-div-bottom-content").append(photo);
        setTimeout(function () {
            divClone.fadeOut(200, function () {
                divClone.remove();
                notifCount--;
            });
        }, 3000);

    });


    hubConnection.on("SendMessageNotificaton", function (message, userName, userPhoto, userId) {
        if (window.location.pathname + window.location.search == "/SocialMessages/GetSingleDialog?dialogFriendId=" + userId) {
            return;
        }
        if (notifCount == 1) {
            notifCount++;

            if (message.length > 22) {
                message = message.slice(0, 21);
                message += "...";
            }

            let clone = $(".notif-div-bottom.template").clone();
            let elementBottomCheck = $(".notif-div-bottom:not(.template)").css("bottom");
            if (elementBottomCheck === "70px")
            {
                clone.css("bottom", "185px");

            }
            clone.removeClass("template");
            clone.appendTo("body");
            clone.fadeIn(200);
            clone.find(".notif-text").text(message);
            //clone.text(message);
            clone.find(".user-message-name").text(userName + " send message");
            let photo = $('<img>').attr("src", userPhoto);
            clone.find(".notif-div-bottom-content").append(photo);

            setTimeout(function () {
                clone.fadeOut(200, function () {
                    notifCount--;
                    clone.remove();

                });

            }, 3000);

            return;
        }
        if (notifCount == 2) {
            return;
        }
        else {
            notifCount++;
            if (message.length > 22) {
                message = message.slice(0, 21);
                message += "...";
            }
            let clone = $(".notif-div-bottom.template").clone();
            clone.removeClass("template");
            clone.appendTo("body");
            clone.fadeIn(200);
            clone.find(".notif-text").text(message);
            //clone.text(message);
            clone.find(".user-message-name").text(userName + " send message");
            let photo = $('<img>').attr("src", userPhoto);
            clone.find(".notif-div-bottom-content").append(photo);

            setTimeout(function () {
                clone.fadeOut(200, function () {
                    clone.remove();
                    notifCount--;
                });

            }, 3000);
        }
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
            let buttonReplace = $(".add-to-friends-button.requested.template").clone();

            $.get("/api/Social/AddFriend", { friendId: id })
                .done(function () {
                    button.replaceWith(buttonReplace.removeClass("template"));
                });

            hubConnection.invoke("SendNotif", "requested", id);
        })
    })


    hubConnection.start();

})


