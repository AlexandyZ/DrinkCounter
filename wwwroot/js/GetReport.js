var selected;
var dateRange;
var radio1, radio2;
var c1, c2, c3, c4;
var cArray = [];
var tArray = [];

var resultArray = [];
var showType;
var cNum = 0;

var storage = window.localStorage;

function getReport(form) {
  selected = form.select.selectedIndex;
  dateRange = form.select.options[selected].text;
  radio1 = $("input[name='radio']:checked").val();
  radio2 = $("input[name='radio2']:checked").val();
  c1 = form.c1.checked;
  c2 = form.c2.checked;
  c3 = form.c3.checked;
  c4 = form.c4.checked;
  var result = processData();
  //alert(result);
  if(result[0] == 0){
    return false;
  }else {
    storage.setItem("result", result);
    location.reload();
    window.open('result.html');
  }
}

function processData(){
  switch (selected){
    case 0:
      dateRange = 7;
      break;
    case 1:
      dateRange = 30;
      break;
    case 2:
      dateRange = 90;
      break;
    case 3:
      dateRange = 180;
      break;
    case 4:
      dateRange = 365;
      break;
    case 5:
      break;
    default:
      break;
  }

  if(radio2 == "p1") {
    if(radio1 == "t2") {
      resultArray = getType(1);
    }else{
      resultArray = getType(2);
    }
  }else{
    if(radio1 == "t2") {
      resultArray = getType(3);
    }else{
      resultArray = getType(4);
    }
  }
  resultArray.push(dateRange);
  return resultArray;
}

function getType(m){
  if(!c1 && !c2 && !c3 && !c4){
    if(m == 1) {
      showType = 1;
      tArray.push(showType);
      //show total drink amount in a period of time, personal, no types
      return tArray;
    }else if(m == 2){
      alert("Please select a category.");
      showType = 0;
      tArray.push(showType);
    }else if(m == 3){
      showType = 4;
      tArray.push(showType);
      //show total drink amount in a period of time, team, no types
      return tArray;
    }else if(m == 4){
      alert("Please select a category.");
      showType = 0;
      tArray.push(showType);
    }
  }else{
    if(c1){
      cNum++;
      cArray.push(1);
    }
    if(c2){
      cNum++;
      cArray.push(2);
    }
    if(c3){
      cNum++;
      cArray.push(3);
    }
    if(c4){
      cNum++;
      cArray.push(4);
    }
    if(m == 1) {
      showType = 2;
      //show drink number of cNum categories in a period of time, personal, no types
    }else if(m == 2){
      showType = 3;
      //show cNum graphs each has drink amount of types, personal
    }else if(m == 3){
      showType = 5;
      //show drink number of cNum categories in a period of time, team, no types
    }else if(m == 4){
      showType = 6;
      //show cNum graphs each has drink amount of types, team
    }
    tArray.push(showType);
    tArray.push(cNum);
    tArray.push(cArray);
    return tArray;
  }
}