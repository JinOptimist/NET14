$(document).ready(function () {
    $('.icon').click(function () {
        let url = $(this).attr('src');
        $('.icon1').attr('src', url);
    });
});