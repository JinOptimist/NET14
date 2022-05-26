$(document).ready(function () {
    $('.myAccountDeleteProduct').mouseover(function () {
        $(this).attr('src',"/images/Store/delete_forever_FILL1.svg");
    });
    $('.myAccountDeleteProduct').mouseout(function () {
        $(this).attr('src', "/images/Store/delete_forever_FILL0.svg");
    });

    $('.remove-product').click(function () {
        const product = $(this).closest('.product-row');
        const productId = $(this).attr('data-id');
        const basketId = $(this).attr('data-basket-id');
        

        $.get(`/Store/RemoveProduct?id=${productId}`)
            .done(function () {
                product.remove();
                if ($('.product-row').length == 0) {
                    window.location.reload();
                }
            });
    });
    $('#changeMasterData').click(function () {
        $('#popupAccount1').show(800);
    })
    $('.popupClose').click(function () {
        $('#popupAccount1').hide(800); 
    })
    $('#changePassword').click(function () {
        $('#popupAccount2').show(800);
    })
    $('.popupClose').click(function () {
        $('#popupAccount2').hide(800);
    })

});