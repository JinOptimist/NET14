$(document).ready(function () {
    $(".unlock").click(function () {
        window.scrollTo(0, document.body.scrollHeight);
        $(".trytoguess.template ").fadeToggle(200);
    });

    $(document).on('click', ".try", function () {
        let text = $(".password").val();
        if (text === "password") {
            $(".password").val(" ");
            //Тут удаляем все ?? ингредиенты
            $(".undefenit").remove();
            //Тут создаем новые ингредиенты
            let first = $("<li>").text("1");
            let second = $("<li>").text("2");
            let third = $("<li>").text("3");
            let four = $("<li>").text("4");
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

