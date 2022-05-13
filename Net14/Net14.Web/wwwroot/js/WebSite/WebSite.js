$(document).ready(function () {
    $(".unlock").click(function () {
        window.scrollTo(0, document.body.scrollHeight);
        $(".trytoguess.template ").fadeToggle(200);
    });

    $(document).on('click', ".try", function () {
        let text = $(".password").val();
        if (text === "12345") {
            $(".password").val(" ");
            //Тут удаляем все ?? ингредиенты
            $(".undefenit").remove();
            //Тут создаем новые ингредиенты
            let first = $("<li>").text("Кольцо Мальца");
            let second = $("<li>").text("Слюна Лягушки");
            let third = $("<li>").text("Зуб Анашкина");
            let four = $("<li>").text("Ресница Соловей Виктории Александровны");
            //Тут мы их добавляем в список
            $(".list").append(first);
            $(".list").append(second);
            $(".list").append(third);
            $(".list").append(four);
        }
        else {

            alert("Incorrect password");
        }
    });

    $(".form").submit(function (e) {
        e.preventDefault();
    });

    $(".image-div").animate()

})

