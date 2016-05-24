$(document).ready(function () {
    var id = localStorage.getItem('CategoryId');
    $.ajax({
        url: 'http://localhost:5000/api/v1/drinktypes/' + id,
        dataType: 'json',
        type: 'GET',
    }).done(function (data) {
        var length = data.TypeName.length;
        var str = "";
        var name = data.TypeName;
        var newName = getNewName(name, length);
        for (var i = 0; i < length; i++) {
            str = str + "<div class=\"col-xs-6 col-sm-2 col-md-2 placeholder\">" +
            "<input type=\"image\" class=\"img-responsive\"src=\"images/" + data.TypeName[i] + ".gif\"" +
            "name=\"" + data.TypeName[i] + "\" border=\"0\" id=\"" + data.TypeId[i] + "\">" +
            "<h5 style=\"text-align:center; margin-left:-15px;\">" + newName[i] + "</h5></div>";
        }
        $('#idn').append(str);
    });
    $("div").click(function (e) {
        var tid = e.target.id;
        var tname = e.target.name;
        //alert(e.target.id);
        localStorage.setItem('TypeId', tid);
        localStorage.setItem('TypeName', tname);
        $(location).attr('href', 'add.html');
        //alert(id); 
    });
});

function getNewName(data, length){
    var newNames = [];
    for(var i = 0; i < length; i++){
        var len = data[i].length;
        if(len > 16){
            newNames[i] = data[i].substr(0,14) + "...";
        }else{
            newNames[i] = data[i];
        }
    }
    return newNames;
}