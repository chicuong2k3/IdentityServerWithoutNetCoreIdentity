window.addEventListener('load', function () {
    var keyUri = document.getElementById('qrKeyUri').innerText;
    var qr = new QRCode(document.getElementById('qrCode'), {
        text: keyUri,
        width: 128,
        height: 128,
        colorDark: "#000000",
        colorLight: "#ffffff"
    });
});
