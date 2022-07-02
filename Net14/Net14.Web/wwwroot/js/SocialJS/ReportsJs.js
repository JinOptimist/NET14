const maxPage = 5;

$(document).ready(function () {

    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/report")
        .build();

    setTimeout(function()
    {
        $(".single-report.loading").each(function (index) {
            let cloneDownloadIcon = $(".download.template").clone();
            let elem = $(this);
            $(this).find(".loader").fadeOut(200, function ()
            {
                elem.find(".loader").replaceWith(cloneDownloadIcon.removeClass("template"));
            })

        });




    }, 2000)
    hubConnection.on("Progress_Update", function (pageCount, reportId) {
        let number = reportId - 0;
        let proggressBarObj = $(`.single-report[data-id='${number}']`);
        let progressCircle = proggressBarObj.find(".progress");
        if (proggressBarObj.hasClass("loading")) {
            proggressBarObj.removeClass("loading");
            proggressBarObj.find(".loader").replaceWith($('<div class="progress"></div>').circleProgress({
                max: maxPage,
                value: pageCount
            }));
        }
        else
        {
            progressCircle.circleProgress('value', pageCount);

        }
        if (pageCount == maxPage)
        {
            progressFinished(progressCircle);
        }
    });

    $('.progress').circleProgress({
        max: maxPage,
        value: 0,
    });

    $(".create-new-report").click(function () {
        let userId = $(this).data("userid");
        let clikedElem = $(this);

        $.get("/SocialReport/GetReport", { userId: userId })
            .done(function (report) {

                let elemToClone = $(".single-report.template").clone();
                elemToClone.attr("data-id", report.id);
                elemToClone.find(".report-url").text(report.name);
                elemToClone.find(".report-date").text(report.creatingDate);
                elemToClone.append($('<div class="progress"></div>').circleProgress({
                    max: maxPage,
                    value: 0,
                }));
                clikedElem.next(".user-reports").append(elemToClone.removeClass("template"));


            })
    })

    function progressFinished(circle)
    {
        let downloadIcon = $(".download.template").clone();
        circle.fadeOut(200, function ()
        {
            circle.replaceWith(downloadIcon.removeClass("template"));
        })
        console.log("function");
    }
    hubConnection.start();
})