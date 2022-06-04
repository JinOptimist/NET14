$(document).ready(function () {
    $(".submit-currency").click(function () {
        let currency = $(".select-currency option:selected").val();

        $.get("/api/SocialCurrency/GetCurrency", { cur: currency })
            .done(function (currency) {

                RenderCurrency(currency);
            })
    });

    function RenderCurrency(currency) {
        $(".currency").text("1 " + currency.cur_Abbreviation);
        $(".byn").text(currency.cur_OfficialRate + " BYN");
    }
})