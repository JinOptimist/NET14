$(document).ready(function () {
    $(".unlock").click(function () {
        window.scrollTo(0, document.body.scrollHeight);
        $(".trytoguess.template ").fadeToggle(200);
    });

    $(document).on('click', ".try", function () {
        let text = $(".password").val();
        if (text === "12345") {
            $(".password").val(" ");
            //��� ������� ��� ?? �����������
            $(".undefenit").remove();
            //��� ������� ����� �����������
            let first = $("<li>").text("������ ������");
            let second = $("<li>").text("����� �������");
            let third = $("<li>").text("��� ��������");
            let four = $("<li>").text("������� ������� �������� �������������");
            //��� �� �� ��������� � ������
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

