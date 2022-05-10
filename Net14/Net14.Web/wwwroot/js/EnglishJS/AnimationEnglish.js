$(document).ready(function () {
    const animationSpeed = 1000;

    let images = [];

    let currentIndex = 0;

    init();

    function init() {
        $.get('/api/English/GetImagesWithWords')
            .done(function (data){
                images = data;
                updateImages();
            });
    };

    $('.next button').click(function () {
        $('.next-step-1 img').animate({
            width: 400
        }, animationSpeed)
        $('.current img').animate({
            width: 200
        }, animationSpeed)
        $('.prev-step-1 img').animate({
            width: 0
        }, animationSpeed)
        $('.next-step-2 img').animate(
            {
                width: 200
            },
            animationSpeed,
            'swing',
            function () {
                currentIndex = calcIndex(currentIndex + 1);
                updateImages()
                setDefaultStyle()
            });
    });
    function setDefaultStyle() {
        $('.current img').css('width', 400)

        $('.prev-step-1 img').css('width', 200)
        $('.next-step-1 img').css('width', 200)

        $('.prev-step-2 img').css('width', 1)
        $('.next-step-2 img').css('width', 1)
    };
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
            return index % images.length
        }
        return index;
    }
});