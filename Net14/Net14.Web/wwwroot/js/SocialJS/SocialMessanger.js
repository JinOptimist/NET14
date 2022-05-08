$(document).ready(function () {
    $(".main-message-container").scrollTop($(".main-message-container").prop('scrollHeight'));

    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/messages")
        .build();

    $(".message-send-button").click(function (e) {
        e.preventDefault();
        let message = $(".message-input").val();
        if (isEmpty(message))
        {
            return;
        }
        $(".message-input").val('');

        let userId = $(".dialog-user-info").attr("data-id");
        hubConnection.invoke("SendMessage", message, userId);
        let sentMessage = $(".single-message-sent.template").clone();
        sentMessage.find(".message-text-sent").text(message);
        sentMessage.appendTo(".main-message-container");
        sentMessage.removeClass("template");
        $(".main-message-container").scrollTop($(".main-message-container").prop('scrollHeight'));
    });


    hubConnection.on("RecievedMessage", function (recievedMessage) {
        let messageRecieved = $(".single-message-recieved.template").clone();
        messageRecieved.find(".message-text-recieved").text(recievedMessage);
        messageRecieved.appendTo(".main-message-container");
        messageRecieved.removeClass("template");
        $(".main-message-container").scrollTop($(".main-message-container").prop('scrollHeight'));
    });

    hubConnection.start();
});


function isEmpty(str) {
    if (str.trim() == '')
        return true;

    return false;
}