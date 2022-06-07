$(document).ready(function () {
    $('.myAccountDeleteProduct').mouseover(function () {
        $(this).attr('src', "/images/Store/delete_forever_FILL1.svg");
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
    $('#changePassword').click(function () {
        $('#popupAccount2').show(800);
    })
    $('#addNewAdress').click(function () {
        $('#popupAccount3').show(800);
    })
    $('.popupClose').click(function () {
        $('#popupAccount1,#popupAccount2,#popupAccount3').hide(800);
    })

    $('.update-user').click(function () {
        const firstName = $('#firstName').val();
        const lastName = $('#lastName').val();
        const email = $('#email').val();
        const phoneNumber = $('#phoneNumber').val();

        $.get("/api/Store/ChangeMasterData", { firstName: firstName, lastName: lastName, email: email, phoneNumber: phoneNumber })
            .done(function () {
                window.location.reload();
            });
    });
    $('.update-pass').click(function () {
        const password = $('#password2').val();
        $.get("/api/Store/ChangePass", { password: password})
            .done(function () {
                window.location.reload();
            });
    });
    $('.add-adress').click(function () {
        const country = $('#country').val();
        const postСode = $('#postСode').val();
        const city = $('#city').val();
        const street = $('#street').val();
        const house = $('#house').val();
        const room = $('#room').val();
        $.get("/api/Store/AddDeliveryAdress", { country: country, postСode: postСode, city: city, street: street, house: house,room:room})
            .done(function () {
                window.location.reload();
            });
    });
});