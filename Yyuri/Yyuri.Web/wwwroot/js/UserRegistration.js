$(function () {

    //$("#UserRegistrationModal input[name = 'Email']").blur(function () {

    //    var email = $("#UserRegistrationModal input[name = 'Email']").val();

    //    var url = "Account/UserNameExists?userName=" + email;

    //    $.ajax({
    //        type: "GET",
    //        url: url,
    //        success: function (data) {
    //            if (data == true) {

    //                PresentClosableBootstrapAlert("#alert_placeholder_register", "warning", "Email không hợp lệ", "Địa chỉ email này đã được đăng ký");

    //            }
    //            else {
    //                CloseAlert("#alert_placeholder_register");
    //            }
    //        },
    //        error: function (xhr, ajaxOptions, thrownError) {
    //            var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

    //            PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

    //            console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);

    //        }
    //    });
    //});


    var registerUserButton = $("#UserRegistrationModal button[name = 'register']").click(onUserRegisterClick);

    function onUserRegisterClick()
    {
        var url = "Account/RegisterUser";

        var antiForgeryToken = $("#UserRegistrationModal input[name='__RequestVerificationToken']").val();

        alert(antiForgeryToken);
        //var email = $("#UserRegistrationModal input[name='Email']").val();
        //var password = $("#UserRegistrationModal input[name='Password']").val();
        //var confirmPassword = $("#UserRegistrationModal input[name='ConfirmPassword']").val();

        //var user = {
        //    __RequestVerificationToken: antiForgeryToken,
        //    Email: email,
        //    Password: password,
        //    ConfirmPassword: confirmPassword,
        //    AcceptUserAgreement: true
        //};

        //$.ajax({
        //    type: "POST",
        //    url: url,
        //    data: user,
        //    success: function (data) {

        //        var parsed = $.parseHTML(data);

        //        var hasErrors = $(parsed).find("input[name='RegistrationInValid']").val() == 'true';

        //        if (hasErrors) {

        //            $("#UserRegistrationModal").html(data);
        //            var registerUserButton = $("#UserRegistrationModal button[name = 'register']").click(onUserRegisterClick);
        //            $("#UserRegistrationModal input[name = 'AcceptUserAgreement']").click(onAcceptUserAgreementClick);

        //            $("#UserRegistrationForm").removeData("validator");
        //            $("#UserRegistrationForm").removeData("unobtrusiveValidation");
        //            $.validator.unobtrusive.parse("#UserRegistrationForm");
        //        }
        //        else {
        //            location.href = '/Home/Index';
        //        }

        //    },
        //    error: function (xhr,ajaxOptions,thrownError) {
        //        var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

        //        PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

        //        console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
        //    }

        //});

    }

});