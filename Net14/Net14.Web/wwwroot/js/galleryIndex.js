$(document).ready(function () {

    $('.image-link').click(function () {
        $('.image-toggle')
            .removeClass('active');

        $(this)
            .closest('.image-block')
            .find('.image-toggle')
            .toggleClass('active');
    });
});