$(document).ready(function () {
    $(".operations.comment").click(function () {
        $(this).closest(".content-element").find(".single-comment:not(.template)").remove();
        $(this).closest(".content-element-card").find(".comments").slideToggle(200);
        let divWithId = +$(this).closest(".content-element").attr("data-id");
        let elementToClone = $(this).closest(".content-element").find(".single-comment.template");
        let commentDiv = $(this).closest(".content-element").find(".comment-elements");
        let comment;

        $.get('/api/Social/GetComments', { postId: divWithId })
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
        $.get("/api/Social/AddComment", { postId: id, text: commmentInput })
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
        if ($(this).val()=="")
        {
            $(this).closest(".input-container").find("input.comm").removeClass("active");
            return;
        }
        $(this).closest(".input-container").find("input.comm").addClass("active");
    })

    $(document).on("click", ".operations.like:not(.active)", function () {
        let clicked = $(this);
        var id = +$(this).closest(".content-element").attr("data-id");

        $.get("/api/Social/AddLike", { postId: id })
            .done(function ()
            {
                var elementToReplace = $(".operations.like.active.template").clone();
                var likesCountEncrement = parseInt(clicked.closest(".like-container").find(".likes-count").text());
                clicked.closest(".like-container").find(".likes-count").text(++likesCountEncrement);
                clicked.replaceWith(elementToReplace.removeClass("template"));
            });

    })

    $(document).on("click", ".operations.like.active", function () {
        let clicked = $(this);
        var id = +$(this).closest(".content-element").attr("data-id");



        $.get("/api/Social/RemoveLike", { postId: id })
            .done(function ()
            {
                var elementToReplace = $("#disable").clone();
                var likesCountEncrement = parseInt(clicked.closest(".like-container").find(".likes-count").text());
                clicked.closest(".like-container").find(".likes-count").text(--likesCountEncrement);
                clicked.replaceWith(elementToReplace.removeClass("template"));

            })

    })

    $('.add-image').change(function () {
        var file = $(this)[0].files[0].name;
        var span = $(this).closest(".add-post-form").find(".file-name");
        span.text(file);
    });

    $(".post-input").click(function () {
        $(".add-post").animate({
            "min-height": '150px',
        }, 300, function () {
            $(".block-send").fadeIn(200);
        });

    });

    $(document).mouseup(function (e) {
        var container = $(".add-post");
        var buttonFile = $(".add-image");
        var sendButton = $(".send-post");


        if (!container.is(e.target) && container.has(e.target).length === 0
            && !buttonFile.is(e.target) && buttonFile.has(e.target).length === 0
            && !sendButton.is(e.target) && sendButton.has(e.target).length === 0) {
            $(".block-send").hide();
            $(".add-post").animate({
                "min-height": '55px',
            }, 300, function () {
                $(".post-input").val("");
            });
        }
    });

    $(".more-button-container").click(function () {
        $(this).closest(".user-info").find(".more-div").fadeToggle();
    })

    $(".delete-post").click(function () {
        let post = $(this).closest(".content-element");
        let id = post.data("id");
        $.get("/api/Social/DeletePost", { postId: id })
            .done(function () {

                post.fadeOut(200, () => post.remove());

            })
    })


    $(".complane").click(function () {

        let Post = $(this).closest(".content-element").data("id");
        let data = {
            Post: Post
        };

        jQuery.ajax({
            url: "/api/Social/MakeAComplain",
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
        }).done(function () {
            alert("done");
        });
    })

})

