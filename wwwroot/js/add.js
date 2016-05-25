var userid = 'ts7kpdpvz';
    //function () {
//    //get user id from session or cookies
//};
$(document).ready(function () {
    var idCat = localStorage.getItem('CategoryId');
    if(idCat == 1){
        document.getElementById("acategory").innerHTML = "Coffee";
    }else if(idCat == 2){
        document.getElementById("acategory").innerHTML = "Tea";
    }else if(idCat == 3){
        document.getElementById("acategory").innerHTML = "Pop";
    }else{
        document.getElementById("acategory").innerHTML = "Juice";
    }
    var id = localStorage.getItem('TypeId');
    var name = localStorage.getItem('TypeName');
    //$.ajax({
    //    url: 'http://localhost:5000/api/v1/drinktypes/' + id,
    //    dataType: 'json',
    //    type: 'GET',
    //}).done(function (data) {
    //    $("#atype").text(data);               
    //});
    $("#atype").text(name);

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            var re = new RegExp(regexp);
            return this.optional(element) || re.test(value);
        },
        "Please check your input."
    );

    $("#addDrinkForm").validate({
        rules: {
            quantity: {
                regex: "^[1-9]\{1,2}d*$"
            }
        },
        messages: {
            quantity: {
                regex: "Please enter a positive number"
            }
        }
    });

    $("#submit").click(function () {
        var tid = id;
        var qty = $("#aquantity").val();
        var uid = userid;
        var add = {
            Amount: qty,
            UserId: uid,
            TypeId: tid
        };
        var url = 'http://localhost:5000/api/v1/DrinkCounts/';
        //alert(e.target.id);
        $.post(url, add, function (data) {
            //alert("Save successfully!");
        });
        $(location).attr('href', 'index.html');
    });
});