function ViewDiv()
{

    document.getElementById('header-settings').style.display = (document.getElementById('header-settings').style.display != 'flex') ? 'flex' : 'none';    
}

function ViewClosedForm(el)
{
    if (el.id == "change-name-button") {
        document.getElementById('form-container-name').style.display = (document.getElementById('form-container-name').style.display != 'flex') ? 'flex' : 'none';

    }
    else if (el.id == "change-place-button") {
        document.getElementById('form-container-place').style.display = (document.getElementById('form-container-place').style.display != 'flex') ? 'flex' : 'none';

    }
    else if (el.id == "change-email-button")
    {
        document.getElementById('form-container-email').style.display = (document.getElementById('form-container-email').style.display != 'flex') ? 'flex' : 'none';

    }
}

