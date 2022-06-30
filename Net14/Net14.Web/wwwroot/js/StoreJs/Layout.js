
$(document).ready(function () {
    
    const cook = Cookies.get('SmileLag');
    $('#language2').val(cook).attr("selected", "selected");

    $("#language2")
        .change(function () {
            const language2 = $("#language2 option:selected").val()
            Cookies.set('SmileLag', language2);
            window.location.reload();
        })
});