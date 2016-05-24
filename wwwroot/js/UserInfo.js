var userid = 'ts7kpdpvz';
//    function () {
//    //get user id from session or cookies
//};

$(document).ready(function () {
    $.ajax({
        url: 'http://localhost:5000/api/v1/userinfos/' + userid,
        dataType: 'json',
        type: 'GET'
    }).done(function (data) {
        $('#firstname').text(data.Firstname);
        $('#lastname').text(data.Lastname);
        $('#gender').text(data.Gender);
        $('#age').text(data.Age);
        $('#address').text(data.Address);
    });
});

$("#edit").click(function () {
    $(location).attr("href", "../edit.html");
});