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

        let data = { Text: message, DiscussionId = discussionId };
        jQuery.ajax({
            url: "/api/SendMessage/AddMessageToDiscussion",
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
        }).done(function () {

        });

        hubConnection.invoke("AddMessage", message);
    });

    hubConnection.start()
});
