function ViewDiv()
{
    let element = document.getElementById("header-settings");
    let icon = document.getElementById("settings-icon");


    if (element.style.display == "none") {
        icon.style.background = "url(../images/Social/settings-black.png)";
        icon.style.backgroundSize = "cover";
        element.style.display = "flex";


    }
    else {
        icon.style.background = "url(../images/Social/settings.png)";
        icon.style.backgroundSize = "cover";
        element.style.display = "none";
    }
}

function ViewClosedForm(el)
{
    if (el.id == "change-name-button") {
        let element = document.getElementById("form-container-name");
        if (element.style.display == "none") {
            element.style.display = "flex";
        }
        else {
            element.style.display = "none";
        }
    }
    else if (el.id == "change-place-button") {
        let element = document.getElementById("form-container-place");
        if (element.style.display == "none") {
            element.style.display = "flex";
        }
        else {
            element.style.display = "none";
        }
    }
    else if (el.id == "change-email-button")
    {
        let element = document.getElementById("form-container-email");
        if (element.style.display == "none") {
            element.style.display = "flex";
        }
        else
        {
            element.style.display = "none";
        }
    }
}

