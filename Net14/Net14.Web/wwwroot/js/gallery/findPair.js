$(document).ready(function () {

    let activeImageIndex;

    let imageUrls = [];

    init();

    function init() {
        $.get('/Gallery/UrlsForFindPair')
            .done(function (urls) {
                imageUrls = urls.concat(urls);

                imageUrls = shuffle(imageUrls);

                createImageBlocks(imageUrls);
            });
    }

    function createImageBlocks(images) {
        for (var i = 0; i < images.length; i++) {
            var url = images[i];

            const imageBlock = $('<div>');
            imageBlock.addClass('image-block');
            imageBlock.addClass('backside');
            imageBlock.attr('data-index', i);
            imageBlock.click(onImageBlockClick);

            const imageTag = $('<img>');
            imageTag.attr('src', url);
            imageTag.addClass('girl-image');

            imageBlock.append(imageTag);

            $('.desc').append(imageBlock);
        }
    }

    function shuffle(array) {
        var m = array.length, t, i;

        // While there remain elements to shuffle…
        while (m) {

            // Pick a remaining element…
            i = Math.floor(Math.random() * m--);

            // And swap it with the current element.
            t = array[m];
            array[m] = array[i];
            array[i] = t;
        }

        return array;
    }

    function onImageBlockClick() {
        const isBackside = $(this).hasClass('backside');
        //if clicked image is open
        if (!isBackside) {
            activeImageIndex = undefined;
            $(this).addClass('backside');
            return;
        }

        const clickedImageIndex = $(this).attr('data-index');
        //if there is no active image
        if (!activeImageIndex) {
            activeImageIndex = clickedImageIndex;
            $(this).removeClass('backside');
            return;
        }

        const activeImageUrl = imageUrls[activeImageIndex];
        const clickedImageUrl = imageUrls[clickedImageIndex];
        if (activeImageUrl == clickedImageUrl) {
            //if pair was founded
            $(`[data-index=${activeImageIndex}]`).addClass('complete');
            $(`[data-index=${activeImageIndex}]`).removeClass('backside');
            $(`[data-index=${clickedImageIndex}]`).addClass('complete');
            $(`[data-index=${clickedImageIndex}]`).removeClass('backside');
            activeImageIndex = undefined;
        } else {
            //if fail
            activeImageIndex = undefined;
            $(`[data-index=${clickedImageIndex}]`).removeClass('backside');
            setTimeout(hideAllImages, 500);
        }
    }

    function hideAllImages() {
        $('.image-block:not(.complete)').addClass('backside');
    }
});