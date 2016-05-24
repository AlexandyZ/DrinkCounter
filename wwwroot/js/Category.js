var userid = 'ts7kpdpvz';
    //function () {
//    //get user id from session or cookies
//};

$(document).ready(function () {
    $("div input").click(function (e) {
        var id = e.target.id;
        //alert(e.target.id);
        localStorage.setItem('CategoryId', id);
        $(location).attr('href', 'types.html');
        //alert(id); 
    });
});