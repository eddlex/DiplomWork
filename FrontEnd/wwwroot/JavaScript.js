function setFocus(filedId) {
    document.getElementById(filedId).focus();
}

function getRowCount() {
    return parseInt((window.innerHeight - 10) / 10)
}
function setLinkRed() {
    document.getElementById('forgotPasswordLink').style.color = 'red';
}

window.getElementBounds = function(element) {
    const rect = element.getBoundingClientRect();
    return {
        left: rect.left,
        top: rect.top,
        width: rect.width,
        height: rect.height
    };
};