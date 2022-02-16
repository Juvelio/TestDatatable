$("#Reporte").click(function (e) {
    e.preventDefault();

    GenerarReporte();
});



function GenerarReporte() {
    $.ajax({
        type: "POST",
        url: "Reporte.aspx/GenerarReporte",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            if (xhr.status === 401) {
            }
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            //console.log(data.d);
            var blob = base64ToBlob(data.d);
            var file = new Blob([blob], { type: 'application/pdf' });
            var fileURL = URL.createObjectURL(file);
            window.open(fileURL);
        },
        complete: function (xhr, status) {
        }
    });
}


function base64ToBlob(base64) {
    const binaryString = window.atob(base64);
    const len = binaryString.length;
    const bytes = new Uint8Array(len);
    for (let i = 0; i < len; ++i) {
        bytes[i] = binaryString.charCodeAt(i);
    }
    return new Blob([bytes], { type: 'application/pdf' });
};

