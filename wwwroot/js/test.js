// //used for test
//$(document).ready(function () {
//    $.ajax({
//        url: "http://localhost:5000/api/v1/values",
//        dataType: 'json',
//        contentType: 'application/json; charset=utf-8',
//        type: 'GET'
//    }).done(function(data) {
//        $('#test').text(data.DrinkName);
//    });
//});

// //Get from ReportsController
// $("#get").click(function () {
//     var userid = $("#counter").val();
//     alert(userid);
//     $.ajax({
//         type: 'GET',
//         dataType: 'json',
//         url: 'http://drinkapi.azurewebsites.net/api/v1/reports/' + userid,
//         success: function (data) {
//             /*var length=data.length,
//             for(var i=0;i<length;i++){
//                 var sum=sum+data[i].Amount;
//             }*/
//             alert(data[1].Amount);
//         },
//     })
// });

 //Post into TeamsController
 $("#add").click(function () {
     //alert();
     var name = $("#team").val();
     var time = new Date();
     var team = {
         Name: name,
         CreateDate: time
     };
     //team = JSON.stringify({ 'team': team });
     //alert(team[0].Name);
     //alert(team[0].CreateDate);
     //$.post("http://localhost:5000/api/v1/Teams",
     //    { 
     //        Name: $("#team").val(),
     //        CreateDate: new Date()
     //    },
     //    function () {
     //        alert("ok");
     //    });
     var apiurl = 'http://localhost:5000/api/v1/Teams';

     $.post(apiurl, team, function (data) {

     });
     //$.ajax({
     //    type: 'POST',
     //    dataType: 'json',
     //    contentType: 'application/json; charset=utf-8',
     //    data: team,
     //    url: 'http://localhost:5000/api/v1/Teams',
     //    //async: false,
     //    success: function () {
     //        //$(location).attr('href','dashboardurl');
     //        alert("OK");
     //    },
     //    error: function () {
     //        alert("bad");
     //    }
     //});
 });