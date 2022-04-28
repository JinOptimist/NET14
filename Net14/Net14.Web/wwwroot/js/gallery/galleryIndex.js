$(document).ready(function () {
    $('.image-link').click(function () {
        $('.image-toggle')
            .removeClass('active');

        let url = $(this).attr('src');
        $('.big-image').attr('src', url);
        $(this)
            .closest('.image-block')
            .find('.image-toggle')
            .toggleClass('active');
    });

    $('a').click(function () {
        $(this).hide();
    });
});