$(document).ready(function () {
    const animationSpeed = 1 * 1000;
    const autoClickTime = 3 * 1000;
    const currentImageWidth = 200;

    let isAnimationActive = false;
    let isHovered = false;

    let images = [];

    let currentIndex = 0;

    init();

    function init() {
        $.get('/api/Gallery/GetGirlImages')
            .done(function (data) {
                images = data;
                updateImages();
            });

        setInterval(function () {
            if (isHovered) {
                return;
            }
            $('.next-step-1').click();
        }, autoClickTime);
    }

    $('.carusel').mouseover(function () {
        isHovered = true;
        console.log('mouseover');
    });

    $('.carusel').mouseout(function () {
        isHovered = false;
        console.log('mouseout');
    });

    $('.next-step-1').click(function () {
        spin(true);
    });

    $('.prev-step-1').click(function () {
        spin(false);
    });

    function spin(isForwardDirection) {
        if (isAnimationActive) {
            return;
        }

        isAnimationActive = true;

        if (!isForwardDirection) {
            $('.prev-step-2').animate({
                width: currentImageWidth / 2
            }, animationSpeed);
        }
        const prevStep1Width = isForwardDirection
            ? 1
            : currentImageWidth;
        $('.prev-step-1').animate({
            width: prevStep1Width
        }, animationSpeed);

        const nextStep1Width = isForwardDirection
            ? currentImageWidth
            : 1;
        $('.next-step-1').animate({
            width: nextStep1Width
        }, animationSpeed);

        if (isForwardDirection) {
            $('.next-step-2').animate({
                width: currentImageWidth / 2
            }, animationSpeed);
        }

        $('.current').animate(
            {
                width: currentImageWidth / 2
            },
            animationSpeed,
            'swing',
            function () {
                if (isForwardDirection) {
                    currentIndex++;
                } else {
                    currentIndex--;
                }

                currentIndex = calcIndex(currentIndex);
                updateImages();
                setDefaultStyle();
                isAnimationActive = false;
            });
    }

    function setDefaultStyle() {
        $('.current').css('width', 200);

        $('.prev-step-1').css('width', 100);
        $('.next-step-1').css('width', 100);

        $('.prev-step-2').css('width', 1);
        $('.next-step-2').css('width', 1);
    }

    function updateImages() {
        var currentImageUrl = images[currentIndex];
        $('.current img').attr('src', currentImageUrl);
        var prevStep2 = calcIndex(currentIndex - 2);
        var prevStep1 = calcIndex(currentIndex - 1);
        var nextStep1 = calcIndex(currentIndex + 1);
        var nextStep2 = calcIndex(currentIndex + 2);

        $('.prev-step-2 img').attr('src', images[prevStep2]);
        $('.prev-step-1 img').attr('src', images[prevStep1]);
        $('.next-step-1 img').attr('src', images[nextStep1]);
        $('.next-step-2 img').attr('src', images[nextStep2]);
    }

    function calcIndex(index) {
        if (index < 0) {
            return images.length + index;
        }

        if (index >= images.length) {
            return index % images.length;
        }

        return index;
    }
});