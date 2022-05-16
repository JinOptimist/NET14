$(document).ready(function () {

    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/CalendarGlobalNotifications")
        .build();

    //React on server send info about message
    hubConnection.on("AdminsHello", function () {
        let span = $('<span>');
        span.text('Hello! ');
        $('.messages').append(span);
    });

    hubConnection.on("UserEntered", function (name) {
        let span = $('<span>');
        span.text('someone try to enter ');
        $('.messages').append(span);
    });

    
    $('.funButton').click(function () {
        hubConnection.invoke("AdminsHello");
    });

    $('.test').click(function () {
        hubConnection.invoke("UserEntered");
    });

    hubConnection.start();
    
});