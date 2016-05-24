var userid = 'ts7kpdpvz';
var curTime = new Date();
var weekAgoTime = new Date(curTime.getTime() - 7 * 24 * 3600 * 1000);
var monthAgoTime = new Date(curTime.getTime() - 30  * 24 * 3600 * 1000);

var curYear = curTime.getFullYear();
var curMonth = curTime.getMonth() + 1;
curMonth = curMonth < 10 ? ("0" + curMonth) : curMonth;
var curDate = curTime.getDate();
curDate = curDate < 10 ? ("0" + curDate) : curDate;
var curDay = curYear + "-" + curMonth + "-" + curDate;

var weekAgoYear = weekAgoTime.getFullYear();
var weekAgoMonth = weekAgoTime.getMonth() + 1;
weekAgoMonth = weekAgoMonth < 10 ? ("0" + weekAgoMonth) : weekAgoMonth;
var weekAgoDate = weekAgoTime.getDate();
weekAgoDate = weekAgoDate < 10 ? ("0" + weekAgoDate) : weekAgoDate;

var monthAgoYear = monthAgoTime.getFullYear();
var monthAgoMonth = monthAgoTime.getMonth() + 1;
monthAgoMonth = monthAgoMonth < 10 ? ("0" + monthAgoMonth) : monthAgoMonth;
var monthAgoDate = monthAgoTime.getDate();
monthAgoDate = monthAgoDate < 10 ? ("0" + monthAgoDate) : monthAgoDate;

function getDayBefore(data, dateArray){
  var oldTime = curTime;
  var newDays = [];
  var newData = [];
  var newTime, newYear, newMonth, newDate, newDay;
  newDays.unshift(curDay);
  newData.unshift(0);
  for(var j = 0; j < dateArray.length; j++){
    if(curDay == dateArray[j]){
      newData[0] = (data[j]);
    }
  }
  for(var i = 1; i < 30; i++) {
    newTime = new Date(oldTime.getTime() - 24 * 3600 * 1000);
    newYear = newTime.getFullYear();
    newMonth = newTime.getMonth() + 1;
    newMonth = newMonth < 10 ? ("0" + newMonth) : newMonth;
    newDate = newTime.getDate();
    newDate = newDate < 10 ? ("0" + newDate) : newDate;
    newDay = newYear + "-" + newMonth + "-" + newDate;
    oldTime = newTime;
    newDays.unshift(newDay);
    newData.unshift(0);
    for(var j = 0; j < dateArray.length; j++){
      if(newDay == dateArray[j]){
        newData[0] = (data[j]);
      }
    }
  }
  show3(newData, newDays);
}

var url1 = 'http://localhost:5000/api/v1/personalreports/' + userid + '/'
  + weekAgoYear + '-'
  + weekAgoMonth + '-'
  + weekAgoDate + '%2000:00:00.0000000/'
  + curYear + '-'
  + curMonth + '-'
  + curDate + '%2023:59:59.9999999';

var url2 = 'http://localhost:5000/api/v1/personalreports/' + userid + '/'
  + monthAgoYear + '-'
  + monthAgoMonth + '-'
  + monthAgoDate + '%2000:00:00.0000000/'
  + curYear + '-'
  + curMonth + '-'
  + curDate + '%2023:59:59.9999999';

var url3 = "http://localhost:5000/api/v1/teammembers/" + userid;

$.ajax({
  url: url1,
  dataType: 'json',
  type: 'GET',
}).done(function (data) {
  var ttlAmount = data.TotalAmount;
  show1(ttlAmount);
});

$.ajax({
  url: url2,
  dataType: 'json',
  type: 'GET'
}).done(function (data) {
  var amount = data.Amount;
  var ttlAmount = data.TotalAmount;
  var d = data.Date;
  var dateResult = getDate(d);
  var newData = combineSameDate(dateResult, amount);
  show2(ttlAmount);
  getDayBefore(newData[1], newData[0]);
  //show3(newData[1], newData[0]);
});

var size = 0;
var teamDates = [];
var teamNames = [];

$.ajax({
  url: url3,
  dataType: 'json',
  type: 'GET',
  async: false,
  success: function (data) {
    $(data).each(function (idx, item) {
      size++;
      teamNames.push(item.TeamName);
      teamDates.push(item.Date);
      showTeam(size, teamNames, getDate(teamDates));
});
  }
});

function showTeam(s, n, d){
  if(s > 0) {
    document.getElementById("ifHasTeam").innerHTML = "<h3 class=\"sub-header\">Team Information</h3><div id=\"teamInfo\"></div>";
    for(var i = 0; i < s; i++){
      document.getElementById("teamInfo").innerHTML +=
        "<div class=\"col-xs-6 col-sm-4 col-md-2 placeholder\"><div>Team name: </div></div>" +
        "<div class=\"col-xs-6 col-sm-8 col-md-4 placeholder\"><div id=\"teamname\">"+ n[i] +"</div></div>" +
        "<div class=\"col-xs-6 col-sm-4 col-md-2 placeholder\"><div>Create date: </div></div>" +
        "<div class=\"col-xs-6 col-sm-8 col-md-4 placeholder\"><div id=\"teamdate\">"+ d[i] +"</div></div>";
    }
  }
}

function randomColorFactor () {
  return Math.round(Math.random() * 255);
};

function randomColor () {
  return 'rgba(' + randomColorFactor() + ',' + randomColorFactor() + ',' + randomColorFactor() + ',' + '.7' + ')';
};

function getDate(data){
  var date = [];
  for(var i = 0; i < data.length; i++){
    date[i] = data[i].substr(0,10);
  }
  return date;
}

function combineSameDate(d, a){
  var newDate = [];
  var newAmount = [];
  var dataArray = [];
  var n = 0;
  var added = 0;
  newDate[0] = d[0];
  newAmount[0] = a[0];
  for(var i = 1; i < d.length; i++){
    n++;
    added = 0;
    for(var j = 0; j < newDate.length; j++){
      if((d[i] == newDate[j])) {
        newAmount[j] += a[i];
        n--;
        added = 1;
        break;
      }
    }
    if(added == 0) {
      newDate[n] = d[i];
      newAmount[n] = a[i];
    }
  }
  dataArray[0] = newDate;
  dataArray[1] = newAmount;
  return dataArray;
}

function show1(amount) {
  var label;
  if (amount == 0){
    label = "Amount = 0";
  }else{
    label = "Amount = " + amount;
  }
  var config = {
    type: 'doughnut',
    data: {
      datasets: [{
        data: [amount],
        backgroundColor: randomColor()
      }],
      labels: [label]
    },
    options: {
      responsive: true,
      legend: {
        position: 'top',
      },
      title: {
        display: true,
        text: 'Total drinks in a week'
      },
      animation: {
        animateScale: true,
        animateRotate: true
      }
    }
  };

  var ctx1 = document.getElementById("myChart1").getContext("2d");
  window.myDoughnut = new Chart(ctx1, config);
}
function show2(amount) {
  var label;
  if (amount == 0){
    label = "Amount = 0";
  }else{
    label = "Amount = " + amount;
  }
  var config = {
    type: 'doughnut',
    data: {
      datasets: [{
        data: [amount],
        backgroundColor: randomColor()
      }],
      labels: [label]
    },
    options: {
      responsive: true,
      legend: {
        position: 'top'
      },
      title: {
        display: true,
        text: "Total drinks in a Month"
      },
      animation: {
        animateScale: true,
        animateRotate: true
      }
    }
  };

  var ctx2 = document.getElementById("myChart2").getContext("2d");
  window.myDoughnut = new Chart(ctx2, config);
}

function show3(amount, date) {
  var barChartData = {
    labels: date,
    datasets: [{
      label: 'Drink amount',
      backgroundColor: randomColor(),
      data: amount
    }]
  };

  var ctx = document.getElementById("myChart3").getContext("2d");
  window.myBar = new Chart(ctx, {
    type: 'bar',
    data: barChartData,
    options: {
      elements: {
        rectangle: {
          borderWidth: 2,
          borderColor: 'rgb(255,255,255)',
          borderSkipped: 'bottom'
        }
      },
      responsive: true,
      legend: {
        position: 'top',
      },
      title: {
        display: true,
        text: 'Total drink amount in a day'
      }
    }
  });
}


