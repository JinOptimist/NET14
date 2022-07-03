const maxPage = 5;

$(document).ready(function () {

    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/report")
        .build();

    setTimeout(function()
    {
        $(".single-report.loading").each(function (index) {
            let cloneDownloadIcon = $(".download.template").clone();
            let fileName = $(this).data("name");
            cloneDownloadIcon.find(".link").attr({
                target: '_blank',
                href: `http://localhost:42059/reports/${fileName}`
            });
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

            if (pageCount == maxPage) {
                setTimeout(() => progressFinished(progressCircle), 2000);
            }

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
                elemToClone.attr("data-name", report.name);
                elemToClone.find(".report-url").text(report.name);
                elemToClone.find(".report-date").text(report.creatingDate);
                elemToClone.append($('<div class="progress"></div>').circleProgress({
                    max: maxPage,
                    value: 0,
                }));
                clikedElem.next(".user-reports").append(elemToClone.removeClass("template"));


            })
    })

    $(document).on("click", ".cancel-report", function () {
        let report = $(this).closest("[data-id]");
        let reportId = report.data("id");
        let clicked = $(this);

        $.get("/SocialReport/CancellReportTask", { reportId: reportId })
            .done(function () {
                let circle = report.find(".progress");
                
                clicked.remove();
  
                circle.replaceWith($("<div class='canceled'>Cancelled</div>"))
            });
    });
/*    $(".cancel-report").click(function () {

    });*/

    function progressFinished(circle)
    {
        let downloadIcon = $(".download.template").clone();
        let fileName = circle.closest(".single-report").data("name");
        debugger;
        downloadIcon.find(".link").attr({
            target: '_blank',
            href: `http://localhost:42059/reports/${fileName}`
        });
        circle.fadeOut(200, function ()
        {
            let elem = circle.closest(".single-report").find(".cancel-report");
            circle.closest(".single-report").find(".cancel-report").remove();
            circle.replaceWith(downloadIcon.removeClass("template"));
        })
    }
    hubConnection.start();
})