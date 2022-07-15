$(document).ready(function () {
    $(".delivery").hide();

    $('input[type="radio"]').click(function () {
        var sum = $('input[name="Sum"]').val();
        const costDelivery = 5;
        if ($(this).attr("value") == "Pickup") {
            $(".box").hide();
            $(".pickup").show();
            $('input[name="CheckedDeliveryAddressId"]').prop('checked', false);
            $('input[name="Sum"]').val(sum)
        }
        if ($(this).attr("value") == "Delivery") {
            $(".box").hide();
            $(".delivery").show();
            $('input[name="CheckedStoreAddressId"]').prop('checked', false);
            $('input[name="Sum"]').val(sum + costDelivery)
        }


    });
});