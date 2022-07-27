$(document).ready(function () {
    $('.word-in-english').click(function () {

        $(this)
            .closest('.word-block')
            .find('.word-in-russian')
            .toggle(250);
    });

});