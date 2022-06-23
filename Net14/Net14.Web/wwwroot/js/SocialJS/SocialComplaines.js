$(document).ready(function () {
    $(".operations.complains").click(function () {
        let id = $(this).closest(".content-element").data("id");
        let container = $(this).closest(".like-container").find(".complaines-container");
        let elementToCopy = $(this).closest(".like-container").find(".single-complain.template");


        $.get("/api/Social/Complains", { postId: id })
            .done(function (complains)
            {
                for (let i = 0; i < complains.length; i++) {
                    let newElement = elementToCopy.clone();
                    newElement.text(complains[i].reasonOfComplain);
                    newElement.appendTo(container);
                    newElement.removeClass("template");
                }

            })
        $(this).closest(".like-container").find(".complain-pop").fadeIn();
    })

    $(".go-and-cancel-complain-page").click(function () {
        let elements = $(this).closest(".complain-pop").find(".single-complain:not(.template)");
        for (let i = 0; i < elements.length; i++)
        {
            elements[i].remove();
        }
        $(this).closest(".complain-pop").fadeOut();
    });

    $(".operations.share").click(function () {
        let post = $(this).closest(".content-element");

        let id = post.data("id");
        $.get("/api/Social/DeletePost", { postId: id })
            .done(function () {

                post.fadeOut(200, () => post.remove());

            });
    });

})