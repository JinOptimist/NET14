let start = 1;

$(document).ready(function ()
{
    $(".button").click(function ()
    {
        if ($(this).css("opacity") == "0.1")
        {
            return;
        }
        if (($(this).text().trim()) != String(start)) {
            $(this).css("background-color", "rgba(255, 0, 0, 0.5)")
            setTimeout(() => {
                $(this).css("background-color", "white")
            }, 500);
        }
        else if (($(this).text().trim()) == String(start))
        {
            if (($(this).text().trim()) == String(24))
            {
                start = 1;
                location.reload(); //Когда доходим до 24, то страница перезагрузится 
            }
            $(this).css("opacity", "0.1");
            start += 1;
        }
        
    })
})
//$(this).css("opacity", "0.1");
