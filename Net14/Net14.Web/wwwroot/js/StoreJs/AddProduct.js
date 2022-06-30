$(document).ready(function () {
    $("#brand1").change(function () {
        var brand = $("#brand1 option:selected").text();
        $(".brandCategories").text(brand);
    }).change();
    $("#category1")
        .change(function () {
            var category = $("#category1 option:selected").text();
            $(".coolCategories").text(category);
        }).change();
    $("#color1")
        .change(function () {
            var color = $("#color1 option:selected").text();
            $(".coolColor").text(color);
        }).change();
    $("#gender1")
        .change(function () {
            var gender = $("#gender1 option:selected").text();
            $(".gender").text(gender);
        }).change();
    $("#material1")
        .change(function () {
            var material = $("#material1 option:selected").text();
            $(".coolMaterial").text(material);
        }).change();
    $("#addNameProduct")
        .change(function () {
            var material = $("#addNameProduct").val();
            $(".addProductName").text(material);
        });
    $("#addPrice")
        .change(function () {
            var material = $("#addPrice").val();
            $(".cost").text(material);
        });
    $('input[name="CheckedSizes"]').change(function () {
       
        var size = $(this).val();

        if ($(this).prop('checked')) {
            var sizeAdd = $('<div>');
            sizeAdd.addClass('ButtonSize');
            sizeAdd.text(size);
            sizeAdd.attr('data-size', size);
            $('.buttonssize').append(sizeAdd);
        } else {
            $(`.ButtonSize[data-size='${size}']`).remove()
        }
    });
    
});