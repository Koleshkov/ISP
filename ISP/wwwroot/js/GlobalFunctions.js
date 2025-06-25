function saveAsFile(fileName, byteBase64) {
    var link = document.createElement('a');

    link.href = "data:application/octet-stream;base64," + byteBase64;
    link.download = fileName
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}

function sendEmail(mailto, subject, fileName, byteBase64) {


    var linkMail = document.createElement('a');
    linkMail.href = "mailto:" + mailto + "?" + "subject=" + subject + "&" + "body=" + encodeURIComponent('<img src="data: application/octet-stream; base64,' + byteBase64+'">');

    document.body.appendChild(linkMail); // Needed for Firefox
    linkMail.click();
    document.body.removeChild(linkMail);


}
function isEmpty(str) {
    return (!str || str.length === 0);
}

