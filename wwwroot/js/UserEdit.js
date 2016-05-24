var userid = "ts7kpdpvz";
    //function () {
    //get user id from session or cookies
//};

/*
$.validator.addMethod('passwordMatch', function (value, element) {

    // The two password inputs
    var password = $("#register-password").val();
    var confirmPassword = $("#register-pass-confirm").val();

    // Check for equality with the password inputs
    if (password != confirmPassword) {
        return false;
    } else {
        return true;
    }

}, "Your Passwords Must Match");

$('#profileform').validate({
    // rules
    rules: {
        register_password: {
            required: true,
            minlength: 3
        },
        register_pass_confirm: {
            required: true,
            minlength: 3,
            passwordMatch: true // set this on the field you're trying to match
        }
    },

    // messages
    messages: {
        register_password: {
            required: "What is your password?",
            minlength: "Your password must contain more than 3 characters"
        },
        register_pass_confirm: {
            required: "You must confirm your password",
            minlength: "Your password must contain more than 3 characters",
            passwordMatch: "Your Passwords Must Match" // custom message for mismatched passwords
        }
    }
});//end validate
*/


$(document).ready(function () {
    $.ajax({
        url: 'http://localhost:5000/api/v1/userinfos/' + userid,
        dataType: 'json',
        type: 'GET'
    }).done(function (data) {
        $('#efirstname').val(data.Firstname);
        $('#elastname').val(data.Lastname);
        $('#egender').val(data.Gender);
        $('#eage').val(data.Age);
        $('#eaddress').val(data.Address);
    });
});

$("#profileform").validate();

$("#submit").click(function () {
    var fname = $('#efirstname').val();
    var lname = $('#elastname').val();
    var gender = $('#egender').val();
    var age = $('#eage').val();
    var addr = $('#eaddress').val();

    var user = {
        Id: userid,
        Firstname: fname,
        Lastname: lname,
        Age: age,
        Gender: gender,
        Address: addr,
    };
    var url = 'http://localhost:5000/api/v1/userinfos';
    $.post(url,
           user,
           success());
});

function success() {
    window.location = "http://localhost:5000/profile.html";
}