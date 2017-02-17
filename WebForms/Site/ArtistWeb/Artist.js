function GetData() {
    $.ajax({
        type: "POST",
        url: 'ListArtist.aspx/GetMessage',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data, status, xhr) {
            alert(data.d);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}