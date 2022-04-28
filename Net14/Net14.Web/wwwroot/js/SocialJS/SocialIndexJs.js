$(document).ready(function () {
    $(".operations.comment").click(function () {
        $(this).closest(".content-element").find(".single-comment:not(.template)").remove();
        $(this).closest(".content-element-card").find(".comments").slideToggle(200);
        let divWithId = +$(this).closest(".content-element").attr("data-id");
        let elementToClone = $(this).closest(".content-element").find(".single-comment.template");
        let commentDiv = $(this).closest(".content-element").find(".comment-elements");
        let comment;

        $.get('/Social/GetComments', { postId: divWithId })
            .done(function (comments) {
                for (let i = 0; i < comments.length; i++) {
                    comment = elementToClone.clone();
                    comment.removeClass("template");
                    comment.find(".user-photo").attr("src", comments[i].user.userPhoto);
                    comment.find(".user-name-comment").text(comments[i].user.firstName + " " + comments[i].user.lastName);
                    comment.find(".comment-text").text(comments[i].text);
                    comment.appendTo(commentDiv);
                }
                commentDiv.scrollTop(commentDiv.prop('scrollHeight'));
            });

    })

    $(document).on('click', "input.comm.active", function (e) {
        e.preventDefault();
        var id = +$(this).closest(".content-element").attr("data-id");
        let elementToClone = $(this).closest(".content-element").find(".single-comment.template");
        let commentDiv = $(this).closest(".content-element").find(".comment-elements");
        let commmentInput = $(this).closest(".input-container").find(".to-comment").val();
        $(this).closest(".input-container").find(".to-comment").val("");

        $.post("/Social/AddComment", { postId: id, text: commmentInput })
            .done(function (user) {
                comment = elementToClone.clone();
                comment.removeClass("template");
                comment.find(".user-photo").attr("src", user.userPhoto);
                comment.find(".user-name-comment").text(user.firstName + " " + user.lastName);
                comment.find(".comment-text").text(commmentInput);
                comment.appendTo(commentDiv);
                commentDiv.scrollTop(commentDiv.prop('scrollHeight'));
            })
            .fail(function (responce) {
                if (responce.status == 401) {
                    window.location.replace("/SocialAuthentication/Autorization?ReturnUrl=/Social/Index");
                }
            })

        $(this).closest(".input-container").find("input.comm").removeClass("active");
    })


    $(".input-container").submit(function (event) {
        event.preventDefault();
    });

    $('.to-comment').on('input', function () {
        if ($(this).val() == "") {
            $(this).closest(".input-container").find("input.comm").removeClass("active");
            return;
        }
        $(this).closest(".input-container").find("input.comm").addClass("active");
    })


})

$(document).ready(function () {
    $(".operations.like").click(function () {
        let th = $(this);
        debugger;
        let id = $(this).closest(".content-element").data("id");

        $.get('/Social/AddLike', { postId: id })
            .done(function () {
                th.addClass("active");
            })

    })
})