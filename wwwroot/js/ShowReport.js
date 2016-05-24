var storage = window.localStorage;
var storedData = storage.getItem("result");
var curTime = new Date();
var dateRange = [];
var cDataNum;
var cData = [];
var dateData;
var startDate, endDate;
var userId = "ts7kpdpvz";

dataArray = storedData.split(",");

//alert(dataArray);
switch (dataArray[0]){
  case "1":
    dateData = dataArray[1];
    dateRange = readDate(dateData);
    var url = personAll(dateRange);
    showPersonAll(url);
    //http://localhost:5000/api/v1/personalreports/ts7kpdpvz/2016-03-31%2001:25:59.7338745/2016-05-31%2001:25:59.7338745
    break;
  case "2":
    cDataNum = dataArray[1];
    for(var i = 0, j = 2; i < cDataNum; i++, j++){
      cData.push(dataArray[j]);
    }
    dateData = dataArray[j];
    dateRange = readDate(dateData);
    var urls = personCat(cDataNum, cData, dateRange);
    var catNames = getCatName(cData);
    showPersonCat(urls, catNames);
    //http://localhost:5000/api/v1/personalreports/ts7kpdpvz/1/2016-03-03%2001:25:59.7338745/2016-05-31%2001:25:59.7338745
    break;
  case "3":
    cDataNum = dataArray[1];
    for(var n = 0, m = 2; n < cDataNum; n++, m++){
      cData.push(dataArray[m]);
    }
    dateData = dataArray[m];
    dateRange = readDate(dateData);
    urls = personCat(cDataNum, cData, dateRange);
    catNames = getCatName(cData);
    showPersonType(urls, catNames);
    //http://localhost:5000/api/v1/personalreports/ts7kpdpvz/1/2016-03-03%2001:25:59.7338745/2016-05-31%2001:25:59.7338745
    break;
  case "4":
    dateData = dataArray[1];
    dateRange = readDate(dateData);
    var teamInfo = personTeam();
    urls = teamAll(teamInfo, dateRange);
    //alert(urls);
    showTeamAll(urls, teamInfo);
    //http://localhost:5000/api/v1/teamreports/9/2016-02-24%2011:18:28.9824702/2016-04-18%2014:28:55.3521218
    break;
  case "5":
    cDataNum = dataArray[1];
    for(var a = 0, b = 2; a < cDataNum; a++, b++){
      cData.push(dataArray[b]);
    }
    dateData = dataArray[b];
    dateRange = readDate(dateData);
    var teamInfo = personTeam();
    urls = teamCat(teamInfo, cDataNum, cData, dateRange);
    catNames = getCatName(cData);
    showTeamCat(urls, teamInfo, catNames);
    //http://localhost:5000/api/v1/teamreports/9/1/2016-02-24%2011:18:28.9824702/2016-04-18%2014:28:55.3521218
    break;
  case "6":
    cDataNum = dataArray[1];
    for(var c = 0, d = 2; c < cDataNum; c++, d++){
      cData.push(dataArray[d]);
    }
    dateData = dataArray[d];
    dateRange = readDate(dateData);
    var teamInfo = personTeam();
    urls = teamCat(teamInfo, cDataNum, cData, dateRange);
    catNames = getCatName(cData);
    showTeamType(urls, teamInfo, catNames);
    //http://localhost:5000/api/v1/teamreports/9/1/2016-02-24%2011:18:28.9824702/2016-04-18%2014:28:55.3521218
    break;
  default:
    break;
}
function getCatName(cats){
  var catNames = [];
  for(var i = 0; i < cats.length; i++) {
    if(cats[i] == 1){
      catNames.push("Coffee");
    } else if(cats[i] == 2){
      catNames.push("Tea");
    } else if(cats[i] == 3){
      catNames.push("Pop");
    }else {
      catNames.push("Juice");
    }
  }
  return catNames;
}

function personTeam(){
  var url = "http://localhost:5000/api/v1/teammembers/" + userId;
  var size = 0;
  var teamIds = [];
  var teamNames = [];

  $.ajax({
    url: url,
    dataType: 'json',
    type: 'GET',
    async: false,
    success: function (data) {
      $(data).each(function (idx, item) {
        size++;
        teamIds.push(item.TeamId);
        teamNames.push(item.TeamName);
      });
    }
  });

  var teamInfo = [];
  teamInfo.push(size);
  teamInfo.push(teamIds);
  teamInfo.push(teamNames);

  return teamInfo;
}

function personAll(date){
  var url = "http://localhost:5000/api/v1/personalreports/" + userId + "/" + date[0] + "%2000:00:00.0000000/" + date[1] + "%2023:59:59.9999999";
  return url;
}
function personCat(n, d, date){
  var url;
  var urls = [];
  for(var i = 0; i < n; i++) {
    url = "http://localhost:5000/api/v1/personalreports/" + userId  + "/" + d[i] + "/" + date[0] + "%2000:00:00.0000000/" + date[1] + "%2023:59:59.9999999";
    urls.push(url);
  }
  return urls;
}
function teamAll(t, date){
  var tSize = t[0];
  var tIds = t[1];
  var tId;
  var url;
  var urls = [];

  for (var i = 0; i < tSize; i++){
    tId = tIds[i];
    url = "http://localhost:5000/api/v1/teamreports/" + tId + "/" + date[0] + "%2000:00:00.0000000/" + date[1] + "%2023:59:59.9999999";
    urls.push(url);
  }
  return urls;
}
function teamCat(t, n, d, date){
  var tSize = t[0];
  var tIds = t[1];
  var tId;
  var url;
  var tUrls = [];
  var urls = [];
  for (var i = 0; i < tSize; i++){
    tId = tIds[i];
    for(var j = 0; j < n; j++) {
      url = "http://localhost:5000/api/v1/teamreports/" + tId + "/" + d[j] + "/" + date[0] + "%2000:00:00.0000000/" + date[1] + "%2023:59:59.9999999";
      urls.push(url);
    }
  }
  return urls;
}

function readDate(data){
  switch (data){
    case "7":
      startDate = getPreDate(7);
      endDate = getCurDate();
      break;
    case "30":
      startDate = getPreDate(30);
      endDate = getCurDate();
      break;
    case "90":
      startDate = getPreDate(90);
      endDate = getCurDate();
      break;
    case "180":
      startDate = getPreDate(180);
      endDate = getCurDate();
      break;
    case "365":
      startDate = getPreDate(365);
      endDate = getCurDate();
      break;
    default:
      startDate = data.substr(6,4) + "-" + data.substr(0,2) + "-" + data.substr(3,2);
      endDate = data.substr(19,4) + "-" + data.substr(13,2) + "-" + data.substr(16,2);
      break;
  }
  dateRange.push(startDate);
  dateRange.push(endDate);
  return dateRange;
}

function getCurDate(){
  var curYear = curTime.getFullYear();
  var curMonth = curTime.getMonth() + 1;
  curMonth = curMonth < 10 ? ("0" + curMonth) : curMonth;
  var curDate = curTime.getDate();
  curDate = curDate < 10 ? ("0" + curDate) : curDate;
  return curYear + "-" + curMonth + "-" + curDate;
}

function getPreDate(n){
  var preTime = new Date(curTime.getTime() - (n * 24 * 3600 * 1000));
  var preYear = preTime.getFullYear();
  var preMonth = preTime.getMonth() + 1;
  preMonth = preMonth < 10 ? ("0" + preMonth) : preMonth;
  var preDate = preTime.getDate();
  preDate = preDate < 10 ? ("0" + preDate) : preDate;
  return preYear + "-" + preMonth + "-" + preDate;
}

function showPersonAll(url){
  var ttlAmount;
  $.ajax({
    url: url,
    dataType: 'json',
    type: 'GET'
  }).done(function (data) {
    ttlAmount = data.TotalAmount;
    showNumber(ttlAmount, "", "Total amount of drinks");
  });
}
function showPersonCat(urls, catNames){
  var ttlAmounts = [];
  var i, ttlAmount;
  var colors;
  for(i = 0; i < urls.length; i++) {
    $.ajax({
      url: urls[i],
      dataType: 'json',
      type: 'GET',
      async: false
    }).done(function (data) {
      ttlAmount = data.TotalAmount;

      ttlAmounts.push(ttlAmount);
    });
  }
  if(ttlAmounts.length == 1){
    showNumber(ttlAmounts[0], catNames[0], "Total amount of drinks");
  }else {
    colors = getRandomColor(i);
    showDoughnut(ttlAmounts, catNames, colors, "Total amount of drinks by categories");
  }
}

function showPersonType(urls, catNames){
  var ttlAmounts = [];
  var amount = [], a = [];
  var ttlType = [];
  var typeNum = [];
  var colors = [];
  var i, t, ttlAmount;
  for(i = 0; i < urls.length; i++) {
    $.ajax({
      url: urls[i],
      dataType: 'json',
      type: 'GET',
      async: false
    }).done(function (data) {
      ttlAmount = data.TotalAmount;
      if(ttlAmount != 0) {
        t = data.TypeName;
        a = data.Amount;
        var combineType = combineSameType(t, a);
        t = combineType[0];
        a = combineType[1];
        amount = amount.concat(a);
        ttlType = ttlType.concat(t);
        typeNum.push(t.length);
        colors = colors.concat(getRandomColor(t.length));
      } else{
        typeNum.push(0);
      }
      ttlAmounts.push(ttlAmount);
    });
  }
  showBar2(catNames, ttlAmounts, ttlType, typeNum, amount, colors, "Total amount of drinks by types");
}
function showTeamAll(urls, tm){
  var names = tm[2];
  var ttlAmounts = [];
  var i, ttlAmount;
  var color;
  for(i = 0; i < urls.length; i++) {
    $.ajax({
      url: urls[i],
      dataType: 'json',
      type: 'GET',
      async: false
    }).done(function (data) {
      ttlAmount = data.TotalAmount;
      ttlAmounts.push(ttlAmount);
    });
  }
  color = randomColor();
  if(ttlAmounts.length == 1){
    showNumber(ttlAmounts[0], names[0], "Total amount of drinks");
  }else {
    showBar1(ttlAmounts, names, color, "Total amount of drinks by teams");
  }
}
function showTeamCat(urls, tm, catNames){
  var names = tm[2];
  var ttlAmounts = [];
  var i, ttlAmount;
  var colors;
  for(i = 0; i < urls.length; i++) {
    $.ajax({
      url: urls[i],
      dataType: 'json',
      type: 'GET',
      async: false
    }).done(function (data) {
      ttlAmount = data.TotalAmount;
      ttlAmounts.push(ttlAmount);
    });
  }
  if(ttlAmounts.length == 1){
    showNumber(ttlAmounts[0], catNames[0], "Total amount of drink in team: " + names[0]);
  }else {
    colors = getRandomColor(catNames.length);
    showBar3(names, ttlAmounts, catNames, colors, "Total amount of drinks by categories");
  }
}
function showTeamType(urls, tm, catNames){
  var ttlAmounts = [];
  var amount = [], a = [];
  var ttlType = [];
  var typeNum = [];
  var colors = [];
  var i, t, ttlAmount;
  for(i = 0; i < urls.length; i++) {
    $.ajax({
      url: urls[i],
      dataType: 'json',
      type: 'GET',
      async: false
    }).done(function (data) {
      ttlAmount = data.TotalAmount;
      if(ttlAmount != 0) {
        t = data.TypeName;
        a = data.Amount;
        var combineType = combineSameType(t, a);
        t = combineType[0];
        a = combineType[1];
        amount = amount.concat(a);
        ttlType = ttlType.concat(t);
        typeNum.push(t.length);
        colors = colors.concat(getRandomColor(t.length));
      } else{
        typeNum.push(0);
      }
      ttlAmounts.push(ttlAmount);
    });
  }
  var names = tm[2];
  var labels = [];
  var label;
  for(var n = 0; n < names.length; n++){
    for(var m = 0; m < catNames.length; m++) {
      label = names[n] + "-" + catNames[m];
      labels.push(label);
    }
  }
  showBar4(labels, ttlAmounts, ttlType, typeNum, amount, colors, "Total amount of drinks by types");
}

function getRandomColor(n){
  var color = [];
  for(var i = 0; i < n; i++){
    color[i] = randomColor();
  }
  return color;
}

function randomColorFactor () {
  return Math.round(Math.random() * 255);
}

function randomColor () {
  return 'rgba(' + randomColorFactor() + ',' + randomColorFactor() + ',' + randomColorFactor() + ',' + '.7' + ')';
}

function combineSameType(t, a){
  var newType = [];
  var newAmount = [];
  var dataArray = [];
  var n = 0;
  var added = 0;
  newType[0] = t[0];
  newAmount[0] = a[0];
  for(var i = 1; i < t.length; i++){
    n++;
    added = 0;
    for(var j = 0; j < newType.length; j++){
      if((t[i] == newType[j])) {
        newAmount[j] += a[i];
        n--;
        added = 1;
        break;
      }
    }
    if(added == 0) {
      newType[n] = t[i];
      newAmount[n] = a[i];
    }
  }
  dataArray[0] = newType;
  dataArray[1] = newAmount;
  return dataArray;
}

function showNumber(amount, title, text) {
  var color = randomColor();
  document.getElementById("chart").innerHTML = "<div class=\"col-xs-12 col-sm-12 col-md-7 placeholder\"><h4  id=\"indexTitle\">"
    + text + "</h4>" + "<div id=\"subtitle\">" + title + "</div>" +
    "<div style=\"color:" + color + ";\" id=\"indexNum1\">" + amount + "</div></div>";
}

function showDoughnut(amount, label, colors, text){
  if(amount.length == 1 && amount[0] == 0) {
    label[0] = "Amount = 0";
  }else{
    for(var p = 0; p < amount.length; p++)
    label[p] = label[p] + " = " + amount[p];
  }
  var config = {
    type: 'doughnut',
    data: {
      datasets: [{
        data: amount,
        backgroundColor: colors
      }],
      labels: label
    },
    options: {
      responsive: true,
      legend: {
        position: 'top'
      },
      title: {
        display: true,
        text: [text]
      },
      animation: {
        animateScale: true,
        animateRotate: true
      }
    }
  };

  var index = 1;
  var chartName = "myChart" + index;
  document.getElementById("chart").innerHTML = "<div class=\"col-xs-12 col-sm-12 col-md-7 placeholder\"><canvas id=\"myChart" + index + "\" width=\"400\" height=\"400\"></canvas></div>";
  var ctx = document.getElementById(chartName).getContext("2d");
  window.myDoughnut = new Chart(ctx, config);
}
function showBar1(amount, label, color, text){
  if(amount.length == 1 && amount[0] == 0) {
    label[0] = "Amount = 0";
  }
  var barChartData = {
    labels: label,
    datasets: [{
      label: 'Total amount of drink',
      backgroundColor: color,
      data: amount
    }]
  };

var index = 1;
var chartName = "myChart" + index;
document.getElementById("chart").innerHTML = "<div class=\"col-xs-12 col-sm-12 col-md-9 placeholder\"><canvas id=\"myChart" + index + "\" width=\"400\" height=\"400\"></canvas></div>";
var ctx = document.getElementById(chartName).getContext("2d");
  window.myBar = new Chart(ctx, {
    type: 'bar',
    data: barChartData,
    options: {
      elements: {
        rectangle: {
          borderWidth: 2,
          borderColor: color,
          borderSkipped: 'bottom'
        }
      },
      responsive: true,
      legend: {
        position: 'top',
      },
      title: {
        display: true,
        text: text
      }
    }
  });
}

function showBar2(labels, ttlAmounts, types, typeNum, amounts, colors, text) {
  var dataArray;
  var i = 0, j = 0;
  var array = [];
  for(var a = 0; a < labels.length; a++) {
    if(ttlAmounts[a] != 0) {
      for(var b = 0; b < typeNum[j]; b++) {
        dataArray = [];
        for(var n = 0; n < labels.length; n++){
          dataArray.push(0);
        }
        dataArray[j] = amounts[i];
        array.push({"label" : types[i], "backgroundColor" : colors[i], "data" : dataArray});
        i++;
      }
      j++;
    }
    else{
      j++;
    }
  }

  var barChartData = {
    labels: labels,
    datasets: array
  };

  var index = 1;
  var chartName = "myChart" + index;
  document.getElementById("chart").innerHTML = "<div class=\"col-xs-12 col-sm-12 col-md-9 placeholder\"><canvas id=\"myChart" + index + "\" width=\"400\" height=\"400\"></canvas></div>";
  var ctx = document.getElementById(chartName).getContext("2d");
  window.myBar = new Chart(ctx, {
    type: 'bar',
    data: barChartData,
    options: {
      title:{
        display: true,
        text: text
      },
      tooltips: {
        mode: 'label'
      },
      responsive: true,
      scales: {
        xAxes: [{
          stacked: true
        }],
        yAxes: [{
          stacked: true
        }]
      }
    }
  });
}

function showBar3(labels, ttlAmounts, catNames, colors, text) {
  var dataArray;
  var array = [];
  for(var a = 0; a < catNames.length; a++) {
    dataArray = [];
    for(var b = 0, c = a; b < labels.length; b++, c+=catNames.length) {
      dataArray.push(ttlAmounts[c]);
    }
    array.push({"label" : catNames[a], "backgroundColor" : colors[a], "data" : dataArray});
  }

  var barChartData = {
    labels: labels,
    datasets: array
  };

  var index = 1;
  var chartName = "myChart" + index;
  document.getElementById("chart").innerHTML = "<div class=\"col-xs-12 col-sm-12 col-md-9 placeholder\"><canvas id=\"myChart" + index + "\" width=\"400\" height=\"400\"></canvas></div>";
  var ctx = document.getElementById(chartName).getContext("2d");
  window.myBar = new Chart(ctx, {
    type: 'bar',
    data: barChartData,
    options: {
      title:{
        display: true,
        text: text
      },
      tooltips: {
        mode: 'label'
      },
      responsive: true,
      scales: {
        xAxes: [{
          stacked: true
        }],
        yAxes: [{
          stacked: true
        }]
      }
    }
  });
}

function showBar4(labels, ttlAmounts, types, typeNum, amounts, colors, text) {
  var dataArray;
  var i = 0, j = 0;
  var array = [];
  for(var a = 0; a < labels.length; a++) {
    if(ttlAmounts[a] != 0) {
      for(var b = 0; b < typeNum[j]; b++) {
        dataArray = [];
        for(var n = 0; n < labels.length; n++){
          dataArray.push(0);
        }
        dataArray[j] = amounts[i];
        array.push({"label" : types[i], "backgroundColor" : colors[i], "data" : dataArray});
        i++;
      }
      j++;
    }
    else{
      j++;
    }
  }

  var barChartData = {
    labels: labels,
    datasets: array
  };

  var index = 1;
  var chartName = "myChart" + index;
  document.getElementById("chart").innerHTML = "<div class=\"col-xs-12 col-sm-12 col-md-9 placeholder\"><canvas id=\"myChart" + index + "\" width=\"400\" height=\"400\"></canvas></div>";
  var ctx = document.getElementById(chartName).getContext("2d");
  window.myBar = new Chart(ctx, {
    type: 'bar',
    data: barChartData,
    options: {
      title:{
        display: true,
        text: text
      },
      tooltips: {
        mode: 'label'
      },
      responsive: true,
      scales: {
        xAxes: [{
          stacked: true
        }],
        yAxes: [{
          stacked: true
        }]
      }
    }
  });
}
