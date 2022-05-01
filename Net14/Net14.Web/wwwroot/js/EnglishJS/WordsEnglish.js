$(document).ready(function () {
    const wordsInEnglish =
        [
            'sun',
            'apple',
            'go',
            'friend',
            'name',
            'play'
        ];
    const wordsInRussian =
        [
            'солнце',
            'яблоко',
            'идти',
            'друг',
            'имя',
            'играть'
        ];

    init();

    $('.card-block').click(function () {
        $(this).toggleClass('pressed-card-block')
    })

    function init() {
        let wordsSource = wordsInEnglish.concat(wordsInRussian);

        wordsSource = Shuffle(wordsSource);

        CreateCardWithWord(wordsSource);
    }
    function CreateCardWithWord(words) {
        for (var i = 0; i < words.length; i++) {

            var word = words[i];

            const cardBlock = $('<div>');
            cardBlock.text(word)
            cardBlock.addClass('card-block');
            cardBlock.addClass('pressed-card-block')
            $('.word-cards').append(cardBlock);

        }
    }
    function Shuffle(array) {
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
});