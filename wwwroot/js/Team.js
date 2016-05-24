var userid = 'ts7kpdpvz';
//    function () {
//    //get user id from session or cookies
//};

$(document).ready(function () {
    $.ajax({
        url: 'http://localhost:5000/api/v1/teammembers/' + userid,
        dataType: 'json',
        type: 'GET',
    }).done(function (data) {
        var length = data.length;
        //alert(data[0].Name);
        var str = "";
        for (var i = 0; i < length; i++) {
            str = str + "<tr id=\"" + data[i].TeamName + "\"><td id=\"teamname\">" + data[i].TeamName + "</td>" +
                  
                  "<td id=\"teamdate\">" + format(data[i].Date) + "</td>" +
                  "<td><input type=\"button\" class=\"teamaction\" id=\"" + data[i].TeamId + "\" value=\"Leave\"></td></tr>";
        }
        $('#joinedTeam').append(str);
    });

    $("table").click(function (e) {
        var btn = e.target.value;
        if (btn == "Leave") {
            var res = confirm("Leave the team?");
        } if (btn == "Join") {
            var res = confirm("Join the team?");
        }
        if (res == true) {
            var tm = {
                UserId: userid,
                TeamId: e.target.id
            };
            var url = 'http://localhost:5000/api/v1/teams/';
            alert(tm.TeamId);
            $.post(url, tm, function () {
                location.reload();
            });
        }
    });

    $("#searchteam").click(function () {
        var name = $('#searchbar').val();
        $("#searchresult").replaceWith("<tbody id=\"searchresult\"></tbody>");
        //alert(name);
        $.ajax({
            url: 'http://localhost:5000/api/v1/teams/' + name,
            dataType: 'json',
            type: 'GET',
        }).done(function (data) {
            var length = data.length;
            //alert(data[0].Name);
            var str = "";
            for (var i = 0; i < length; i++) {
                str = str + "<tr id=\"" + data[i].Id + "\"><td id=\"teamname\">" + data[i].TeamName + "</td>" +
                     
                      "<td id=\"teamdate\">" + format(data[i].Date) + "</td>" +
                      "<td><input type=\"button\" class=\"teamaction\" id=\"" + data[i].TeamId + "\" value=\"Join\"/></td></tr>";
            }
            $('#searchresult').append(str);
        });
    });

    $("#submit").click(function () {
        //alert();
        var name = $("#newTeamName").val();
        var team = {
            UserId: userid,
            TeamName: name
        };
        var apiurl = 'http://localhost:5000/api/v1/Teams';
        //alert(team.Name);
        $.post(apiurl, team, function (data) {

        });
    });
});


function format(d) {
    var date = new Date(d);
    //alert(date.getYear());
    var yr = date.getFullYear();
    var month = date.getMonth() < 10 ? '0' + (date.getMonth()+1) : (date.getMonth()+1);
    var day = date.getDate() < 10 ? '0' + date.getDate() : date.getDate();
    return (yr + '-' + month + '-' + day);
}


//$("tbody").click(function (e) {
//    var ab = e.target.id;
//    alert(ab);
//});
