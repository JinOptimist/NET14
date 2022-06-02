$(document).ready(function () {
    const rotationSpeed = 1500;
    let activeImageIndex;

    let imageUrls = [];

    init();

    function init() {
        $.get('/api/Gallery/GetGirlImages')
            .done(function (urls) {
                imageUrls = urls.concat(urls);

                imageUrls = shuffle(imageUrls);

                createImageBlocks(imageUrls);

                showAllImages();

                setTimeout(hideAllImages, rotationSpeed * 2 + 1000);
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
        const currentCrad = $(this);
        const isBackside = $(this).hasClass('backside');
        //if clicked image is open
        if (!isBackside) {
            activeImageIndex = undefined;
            hideCard(currentCrad);
            return;
        }

        const clickedImageIndex = $(this).attr('data-index');
        //if there is no active image
        if (!activeImageIndex) {
            activeImageIndex = clickedImageIndex;

            showCard(currentCrad);
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
            showCard($(`[data-index=${clickedImageIndex}]`));
            setTimeout(hideAllImages, rotationSpeed * 2 + 500);
        }
    }

    function showAllImages(){
        const openCards = $('.image-block.backside:not(.complete)');
        openCards.each(function () {
            if ($(this).hasClass('backside')) {
                showCard($(this));
            }
        });
    }

    function hideAllImages() {
        const openCards = $('.image-block:not(.complete)');
        openCards.each(function () {
            if (!$(this).hasClass('backside')) {
                hideCard($(this));
            }
        });
    }

    function showCard(currentCrad) {
        rotate(currentCrad, 0, 90, () => {
            currentCrad.removeClass('backside');
            rotate(currentCrad, -90, 0, null, true);
        }, true);
    }

    function hideCard(currentCrad) {
        rotate(currentCrad, 0, 90, () => {
            currentCrad.addClass('backside');
            rotate(currentCrad, -90, 0, null, false);
        }, false);
    }

    function rotate(currentCrad, startDeg, endDeg, animationCompleteFunc, isLeft) {
        const cardWidth = currentCrad.width();
        currentCrad.css('transform', 'rotateY(' + startDeg + 'deg)');
        currentCrad.animate(
            {
                transformRotateIndex: endDeg /* или любое другое не очень-то нужное здесь свойство */
            },
            {
                step: function (now, fx) {
                    currentCrad.css('transform', 'rotateY(' + now + 'deg)');
                    const sinValue = Math.sin(now / 180);
                    const deltaWidth = cardWidth * sinValue;
                    if (isLeft) {
                        currentCrad.css('right', 'auto');
                        currentCrad.css('left', deltaWidth);
                    } else {
                        currentCrad.css('left', 'auto');
                        currentCrad.css('right', deltaWidth);
                    }
                },
                duration: rotationSpeed,
                complete: function () {
                    //currentCrad.removeClass('backside'); 
                    if (animationCompleteFunc) {
                        animationCompleteFunc();
                    }
                }
            },
            'swing'
        );
    }
});