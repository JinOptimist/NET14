$(document).ready(function () {
    $(".main-message-container").scrollTop($(".main-message-container").prop('scrollHeight'));

    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/messages")
        .build();

    $(".message-send-button").click(function (e) {
        e.preventDefault();
        var time = new Date();
        let message = $(".message-input").val();
        if (isEmpty(message))
        {
            return;
        }
        $(".message-input").val('');

        let userId = $(".dialog-user-info").attr("data-id");
        hubConnection.invoke("SendMessage", message, userId);
        let sentMessage = $(".single-message-sent.template").clone();
        sentMessage.find(".txt").text(message);
        sentMessage.find(".sent-time").text(time.toLocaleTimeString().slice(0, -3))
        sentMessage.appendTo(".main-message-container");
        sentMessage.removeClass("template");
        $(".main-message-container").scrollTop($(".main-message-container").prop('scrollHeight'));
    });


    hubConnection.on("RecievedMessage", function (recievedMessage, date) {
        let messageRecieved = $(".single-message-recieved.template").clone();
        messageRecieved.find(".txt").text(recievedMessage);
        messageRecieved.find(".recieved-time").text(date);
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