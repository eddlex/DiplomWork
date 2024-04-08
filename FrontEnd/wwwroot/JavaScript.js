function setFocus(filedId) {
    document.getElementById(filedId).focus();
}

function getRowCount() {
    return parseInt((window.innerHeight - 10) / 10)
}
function setLinkRed() {
    document.getElementById('forgotPasswordLink').style.color = 'red';
}
function getWindowInnerHeight() {
    return window.innerHeight;
}
let s = true

function SearchOption()
{
    const optionsList = document.getElementsByClassName("SelectValue");
    const optionsDiv = document.getElementsByClassName("option");

    
    optionName = document.getElementById("search").value.trim().toLowerCase()

    for (let i in optionsList)
    {
        var op = optionsList[i].innerText.toLowerCase();

        if (op.indexOf(optionName) !== -1) 
        {
            optionsDiv[i].style.display = "block";
        } else
        {
            optionsDiv[i].style.display = "none";
        }
    }
}


window.SetFocusToElement = (element) => {
    element.focus();
};


