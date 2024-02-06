function setFocus(filedId) {
    document.getElementById(filedId).focus();
}

function getRowCount() {
    return parseInt((window.innerHeight - 10) / 10)
}
function setLinkRed() {
    document.getElementById('forgotPasswordLink').style.color = 'red';
}
