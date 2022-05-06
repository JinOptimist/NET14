$(document).ready(function () {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/messages")
        .build();

    $(".message-send-button").click(function () {
        let message = $(".message-input").val();
        let userId = $(".dialog-user-info").attr("data-id");
        debugger;
        hubConnection.invoke("SendMessage", message, userId);
    })

    hubConnection.start();
})