$(document).ready(function () {
    $('.myAccountDeleteProduct').mouseover(function () {
        $(this).attr('src',"/images/Store/delete_forever_FILL1.svg");
    });
    $('.myAccountDeleteProduct').mouseout(function () {
        $(this).attr('src', "/images/Store/delete_forever_FILL0.svg");
    });
});