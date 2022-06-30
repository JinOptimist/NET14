
$(document).ready(function () {
    $('.progress').circleProgress({
        max: 100,
        value: 20,
    });
    $(".create-new-report").click(function ()
    {
        $('.progress').circleProgress('value', 50);
        let userId = $(this).data("userid");
        let clikedElem = $(this);

        $.get("/SocialReport/GetReport", { userId: userId })
            .done(function ()
            {
                let elemToClone = $(".single-report.notready.template").clone();
                elemToClone.find(".report-url").text("URL");
                elemToClone.find(".report-date").text("Today");
                clikedElem.next(".user-reports").append(elemToClone.removeClass("template"));
            })
    })
})