

function ViewClosedForm(el)
{
    if (el.id == "change-name-button") {
        if ($("#form-container-name").css("display") == "flex") {
            $("#form-container-name").fadeOut(200);
        }
        else
        {
            $("#form-container-name").css("display", "flex").hide().fadeIn(200);

        }
    }
    else if (el.id == "change-place-button") {
        if ($("#form-container-place").css("display") == "flex") {
            $("#form-container-place").fadeOut(200);
        }
        else {
            $("#form-container-place").css("display", "flex").hide().fadeIn(200);

        }
    }
    else if (el.id == "change-email-button")
    {
        if ($("#form-container-email").css("display") == "flex") {
            $("#form-container-email").fadeOut(200);
        }
        else {
            $("#form-container-email").css("display", "flex").hide().fadeIn(200);

        }

    }
}
$(document).ready(function () {
    $("#settings-icon").click(function () {
        if ($("#header-settings").css("display") == "flex") {
            $("#header-settings").fadeOut(200);
        }
        else
        {
            $("#header-settings").css("display", "flex").hide().fadeIn(200);

        }
    })
});
$(document).ready(function () {
    $(".filters-header").click(function () {
        $("#form-filter-user").slideToggle();
    });
});

$(document).ready(function () {
    $(".operations.comment").click(function () {
        $(this).closest(".content-element-card").find(".comments").slideToggle(200);
    })
})



$(document).ready(function () {
    $(".add-post-header").click(function () {
        $("#form-add-post").slideToggle();
    });
});
$(document).ready(function () {
    $(".add-file-header").click(function () {
        $("#form-add-file").slideToggle();
    });
});
$(document).ready(function () {
    $(".show-file-header").click(function () {
        $("#form-show-files").slideToggle();
    });
});
