$(document).ready(function () {

    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .build();

    //React on server send info about message 
    

    hubConnection.on("AddMessage", function (message, name) {
        let div = $('<div>');
        div.text(name + ": " + message);

        $('.messages').append(div);
    });

    $('.sendMessageButton').click(function () {
        const message = $('.new-message').val();
        const discussionId = $('.discussion-id').val();

        hubConnection.invoke("AddMessage", message, discussionId);
    });

    hubConnection.start()
});
