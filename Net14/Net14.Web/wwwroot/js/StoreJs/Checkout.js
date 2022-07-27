$(document).ready(function () {
    $(".delivery").hide();
    $(".checkout_costdelivery").hide()
    var sum = $("#cost12").text();
    const costDelivery = 5;
    $("#finishCost").text(sum);
    $('input[name="Sum"]').val(parseInt(sum));
    $('input[type="radio"]').click(function () {

        if ($(this).attr("value") == "Pickup") {
            $(".box").hide();
            $(".pickup").show();
            $('input[name="CheckedDeliveryAddressId"]').prop('checked', false);
            $('input[name="Sum"]').val(parseInt(sum))
            $("#finishCost").text(sum);
            $(".checkout_costdelivery").hide()
        }
        if ($(this).attr("value") == "Delivery") {
            $(".box").hide();
            $(".delivery").show();
            $('input[name="CheckedStoreAddressId"]').prop('checked', false);
            $('input[name="Sum"]').val(parseInt(sum) + costDelivery);
            $("#finishCost").text(parseInt(sum) + costDelivery + '$');
            $(".checkout_costdelivery").show()
        }

    });

});