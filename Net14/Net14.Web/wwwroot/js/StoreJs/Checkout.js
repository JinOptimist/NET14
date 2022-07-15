$(document).ready(function () {
    $(".delivery").hide();

    $('input[type="radio"]').click(function () {
        if ($(this).attr("value") == "Pickup") {
            $(".box").hide();
            $(".pickup").show();
            $('input[name="CheckedDeliveryAddressId"]').prop('checked', false);
        }
        if ($(this).attr("value") == "Delivery") {
            $(".box").hide();
            $(".delivery").show();
            $('input[name="CheckedStoreAddressId"]').prop('checked', false);
        }
       
        
    });
});