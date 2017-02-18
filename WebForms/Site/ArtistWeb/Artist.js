function insert(name) {
    $.ajax({
        type: "POST",
        url: 'CreateArtist.aspx/InsertArtist',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: { 'name': name },
        success: function (data, status, xhr) {
            alert(data.d);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}