$(document).ready(function () {

    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .build();

    //React on server send info about message
    hubConnection.on("OneMoreClick", function () {
        let span = $('<span>');
        span.text('Click!');
        $('.messages').append(span);
    });

    hubConnection.on("AddMessage", function (message, name) {
        let div = $('<div>');
        div.text(name + ': ' + message);
        $('.messages').append(div);
    });
    

    //Trigger action
    $('.sendMessage').click(function () {
        const message = $('.new-message').val();
        hubConnection.invoke("AddMessage", message);
    });

    //Trigger action
    $('.sendMessageButton').click(function () {
        hubConnection.invoke("OneMoreClick");
    });

    hubConnection.start();
});